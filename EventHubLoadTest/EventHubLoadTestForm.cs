using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Azure; // Namespace for CloudConfigurationManager
using Microsoft.WindowsAzure.Storage; // Namespace for CloudStorageAccount
using Microsoft.WindowsAzure.Storage.Blob; // Namespace for Blob storage types
using System.Collections.Concurrent;

namespace EventHubLoadTest
{
   

    public partial class EventHubLoadTestForm : Form
    {
        Random _random = new Random();
        EventHubClient _client;
        UInt64 _counter;
        bool _started = false;
        Stopwatch _watch = System.Diagnostics.Stopwatch.StartNew();
        Stopwatch _runWatch = System.Diagnostics.Stopwatch.StartNew();
        Dictionary<string, UInt64> _sentResults;
        string[] _data;
        double _highestRPS;
        ConcurrentQueue<string> _compressedFiles = new ConcurrentQueue<string>();
        ConcurrentQueue<string> _deCompressedFiles = new ConcurrentQueue<string>();
        private bool _downloadStarted;

        public EventHubLoadTestForm()
        {
            InitializeComponent();

            try
            {
                lblStatus.Text = "connecting Event Hub...";
                _client = EventHubClient.CreateFromConnectionString(Properties.Settings.Default.EventHubConnectionString);
                _client.RetryPolicy = new NoRetry();

                lblStatus.Text = "Event Hub connected";
                txtParallelism.Text = tbPrallelism.Value.ToString();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "failed connecting to event hub. " + ex.Message;
            }

        }

        private async Task StartSingleFile()
        {
            _highestRPS = 0;
            _counter = 0;
            _started = true;
            _runWatch.Restart();
            _sentResults = new Dictionary<string, UInt64>();
            Dictionary<string, UInt64> cycleSentResults = null;
            int sample = 0;

            UpdateLabel(lblTotal, "0");

            while (_started && _runWatch.Elapsed.TotalMinutes <= int.Parse(txtMinutesToRun.Text))
            {
                if (sample == 0)
                {
                    _watch.Restart();
                }
                cycleSentResults = await SendParallelAsync(tbPrallelism.Value);
                StringBuilder sb = new StringBuilder();
                foreach (var item in cycleSentResults)
                {
                    if (_sentResults.ContainsKey(item.Key))
                    {
                        _sentResults[item.Key] += item.Value;
                    }
                    else
                    {
                        _sentResults.Add(item.Key, item.Value);
                    }
                    sb.Append($"{item.Key}: {_sentResults[item.Key]}\n");
                }
                UpdateLabel(lblSentResults, sb.ToString());
                _counter += (UInt64)tbPrallelism.Value;
                UpdateLabel(lblTotal, _counter.ToString());
                UpdateLabel(lblTimeElapsed, $"{_runWatch.Elapsed.TotalMinutes:N2} minutes");

                sample++;
                if (sample == 10)
                {
                    double rps = CalculateRPS(_watch, tbPrallelism.Value * sample);
                    UpdateLabel(lblRPS, rps.ToString("N2"));

                    if (_highestRPS < rps)
                    {
                        _highestRPS = rps;
                    }

                    double targetRPS = double.Parse(txtTargetRPS.Text);
                    if (cbAutomatic.Checked)
                    {
                        if (rps < targetRPS * .95)
                        {
                            //tbPrallelism.Value = (int)((targetRPS / rps) * tbPrallelism.Value);
                            tbPrallelism.Value++;
                            UpdateTextbox(txtParallelism, tbPrallelism.Value.ToString());
                        }
                        else if (rps > targetRPS * 1.05)
                        {
                            //tbPrallelism.Value = (int)((targetRPS / rps) * tbPrallelism.Value);
                            tbPrallelism.Value--;
                            UpdateTextbox(txtParallelism, tbPrallelism.Value.ToString());
                        }
                    }
                    sample = 0;
                }

                GC.Collect();
                //await Task.Delay(10);
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = true;
            btnStart.Enabled = false;
            btnLoadData.Enabled = false;

            if (rbSingleLocalFile.Checked)
            {
                await StartSingleFile();
            }
            else
            {
                await StartRemoteGzipedFiles();
            }

            btnStop.Enabled = false;
            btnStart.Enabled = true;

        }

        private async Task StartRemoteGzipedFiles()
        {
            string fileName;
            int lines;
            _highestRPS = 0;
            _counter = 0;
            _started = true;
            _runWatch.Restart();
            _sentResults = new Dictionary<string, UInt64>();
            SendFilesResult cycleSentResults;

            UpdateLabel(lblTotal, "0");

            while (_started && _runWatch.Elapsed.TotalMinutes <= int.Parse(txtMinutesToRun.Text))
            {
                if (_deCompressedFiles.TryDequeue(out fileName))
                {
                    _watch.Restart();
                    UpdateLabel(lblDecompressedFilesInQueue, _deCompressedFiles.Count().ToString());
                    cycleSentResults = await SendFileParallelAsync(tbPrallelism.Value, fileName);
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in cycleSentResults.Results)
                    {
                        if (_sentResults.ContainsKey(item.Key))
                        {
                            _sentResults[item.Key] += item.Value;
                        }
                        else
                        {
                            _sentResults.Add(item.Key, item.Value);
                        }
                        sb.Append($"{item.Key}: {_sentResults[item.Key]}\n");
                    }
                    UpdateLabel(lblSentResults, sb.ToString());
                    _counter += (UInt64)cycleSentResults.Lines;
                    UpdateLabel(lblTotal, _counter.ToString());
                    UpdateLabel(lblTimeElapsed, $"{_runWatch.Elapsed.TotalMinutes:N2} minutes");

                    double rps = CalculateRPS(_watch, cycleSentResults.Lines);
                    UpdateLabel(lblRPS, rps.ToString("N2"));

                    if (_highestRPS < rps)
                    {
                        _highestRPS = rps;
                    }

                    double targetRPS = double.Parse(txtTargetRPS.Text);
                    if (cbAutomatic.Checked)
                    {
                        if (rps < targetRPS * .95)
                        {
                            tbPrallelism.Value++;
                            UpdateTextbox(txtParallelism, tbPrallelism.Value.ToString());
                        }
                        else if (rps > targetRPS * 1.05)
                        {
                            tbPrallelism.Value--;
                            UpdateTextbox(txtParallelism, tbPrallelism.Value.ToString());
                        }
                    }

                    GC.Collect();                    
                }
                else
                {
                    await Task.Delay(1000);
                }
            }
        }

        private double CalculateRPS(Stopwatch watch, int requests)
        {
            return requests / (watch.ElapsedMilliseconds / 1000.0f);
        }

        public async Task<Dictionary<string, UInt64>> SendParallelAsync(int paralellizm)
        {
            Dictionary<string, UInt64> res = new Dictionary<string, UInt64>();
            Task[] tasks = new Task[paralellizm];
            for (int i = 0; i < paralellizm; i++)
            {
                tasks[i] = SendAsync();
            }

            // Wait for all tasks to complete. 
            await Task.Factory.ContinueWhenAll(tasks, (data) =>
            {
                // Propagate all exceptions and mark all faulted tasks as observed.
                Task.WaitAll(data);
            });

            foreach (var item in tasks
                .Where(t => t.Exception != null)
                .GroupBy(t => t.Exception.Message)
                .Select(group => new { Exception = group.Key, Count = group.Count() }))
            {
                res.Add(item.Exception, (UInt64)item.Count);
            }

            res.Add(TaskStatus.RanToCompletion.ToString(), (UInt64)tasks.Count(t => t.Status == TaskStatus.RanToCompletion));

            return res;
        }



        public async Task<SendFilesResult> SendFileParallelAsync(int paralellizm, string fileName)
        {
            SendFilesResult results = new SendFilesResult();
            Dictionary<string, UInt64> res = new Dictionary<string, UInt64>();
            results.Results = res;
            string[] data = File.ReadAllLines(fileName);
            results.Lines = 0;
            int page = data.Length / paralellizm;
            int cycles = 1;
            int lastPageSize;
            int maxBatchLimitPerTheard;
            int.TryParse(txtBatchLimitPerThread.Text, out maxBatchLimitPerTheard);
            if (page > maxBatchLimitPerTheard)
            {
                page = maxBatchLimitPerTheard;
                cycles = data.Length / (paralellizm * page);
                lastPageSize = data.Length % (paralellizm * page);
            }
            else if (page > 0)
            {
                lastPageSize = data.Length % paralellizm;
            }
            else
            {
                page = 1; // minimum page per thread
            }

            for (int c = 0; c < cycles && _started; c++)
            {
                UpdateLabel(lblBatchNumberCycle, c.ToString());

                int tasksNeeded = paralellizm;
                if (c==cycles -1) // last cycle
                {
                    tasksNeeded = data.Length % (paralellizm * page);
                    if (tasksNeeded == 0)
                    {
                        tasksNeeded = paralellizm;
                    }
                }

                Task[] tasks = new Task[tasksNeeded];
                for (int i = 0; i < tasksNeeded && _started; i++)
                {
                    int fromLine = (c*paralellizm +i ) *  page;
                    int toLine = fromLine + page;

                    if (fromLine >= data.Length)
                    {
                        break;
                    }

                    if (toLine > data.Length)
                    {
                        toLine = data.Length;
                    }

                    tasks[i] = SendBatchAsync(data, fromLine, toLine);
                }

                // Wait for all tasks to complete. 
                await Task.Factory.ContinueWhenAll(tasks, (d) =>
                {
                // Propagate all exceptions and mark all faulted tasks as observed.
                Task.WaitAll(d);
                });

                foreach (var item in tasks
                    .Where(t => t.Exception != null)
                    .GroupBy(t => t.Exception.Message)
                    .Select(group => new { Exception = group.Key, Count = group.Count() }))
                {
                    res.Add(item.Exception, (UInt64)item.Count);
                }

                if (res.ContainsKey(TaskStatus.RanToCompletion.ToString()))
                {
                    res[TaskStatus.RanToCompletion.ToString()] += (UInt64)tasks.Count(t => t.Status == TaskStatus.RanToCompletion);
                }
                else
                {
                    res.Add(TaskStatus.RanToCompletion.ToString(), (UInt64)tasks.Count(t => t.Status == TaskStatus.RanToCompletion));
                }

                results.Lines += tasks.Count(t => t.Status == TaskStatus.RanToCompletion) * page;
            }

            return results;
        }

        private void UpdateLabel(Label label, string text)
        {
            label.Invoke(new Action(() => label.Text = text));
        }

        private void UpdateTextbox(TextBoxBase textBox, string text)
        {
            textBox.Invoke(new Action(() => textBox.Text = text));
        }

        private async Task SendAsync()
        {
            await SendAsync(_data);
        }


        private async Task SendBatchAsync(string[] data, int fromLine, int toLine)
        {
            List<EventData> evenDataList = new List<EventData>();
            for (int i = fromLine; i < toLine; i++)
            {
                evenDataList.Add(CreateEventData(data[i]));
            }

            await _client.SendBatchAsync(evenDataList);
        }

        private async Task SendAsync(string[] data)
        {
            string line = data[_random.Next(_data.Length)];
            EventData eventData = CreateEventData(line);
            await _client.SendAsync(eventData);
        }

        private EventData CreateEventData(string line)
        {
            EventData data = new EventData(Encoding.UTF8.GetBytes(line));
            //data.Properties.Add("Type", "Telemetry_" + DateTime.Now.ToLongTimeString());
            return data;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _started = false;
            _watch.Stop();
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            btnLoadData.Enabled = true;
        }

        private void EventHubLoadTestForm_Load(object sender, EventArgs e)
        {

        }

        private void tbPrallelism_Scroll(object sender, EventArgs e)
        {
            txtParallelism.Text = tbPrallelism.Value.ToString();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            _data = File.ReadAllLines(openFileDialog.FileName);
            btnStart.Enabled = true;
        }

        private void txtParallelism_TextChanged(object sender, EventArgs e)
        {
            int parallelism;

            if (int.TryParse(txtParallelism.Text, out parallelism))
            {
                if (parallelism >= tbPrallelism.Maximum)
                {
                    tbPrallelism.Maximum = parallelism + 1;
                }
                else if (parallelism < 100)
                {
                    tbPrallelism.Maximum = 100;
                }
                tbPrallelism.Value = parallelism;
            }
        }

        private async void btnLoadDataFromBlob_Click(object sender, EventArgs e)
        {
            CloudBlobDirectory dir = GetCloudBlobDirectory();

            btnLoadDataFromBlob.Enabled = false;
            _downloadStarted = true;
            btnStopDownload.Enabled = true;
            rbRemoteGzipedFiles.Checked = true;

            // Loop over items within the container enque them for download and decompression
            BlobContinuationToken token = null;
            do
            {
                var result = await dir.ListBlobsSegmentedAsync(token);
                token = result.ContinuationToken;
                foreach (IListBlobItem item in result.Results)
                {
                    if (item.GetType() == typeof(CloudBlockBlob))
                    {
                        CloudBlockBlob blob = item as CloudBlockBlob;
                        string b = blob.Name;

                        b = b.Substring(b.LastIndexOf("/") + 1, b.Length - b.LastIndexOf("/") - 1);
                        //Trace.WriteLine($"Block blob of length {blob.Properties.Length}: {blob.Uri}");
                        _compressedFiles.Enqueue(b);
                        UpdateLabel(lblCompressedFilesInQueue, _compressedFiles.Count().ToString());
                    }
                }
            } while (token != null);

            
            string blobName, fileName;
            btnStart.Invoke(new Action(() => { btnStart.Enabled = true; }));

            while (_compressedFiles.Count > 0 && _downloadStarted)
            {
                if (_compressedFiles.TryDequeue(out blobName))
                {
                    fileName = await ProcessCompressedFile(blobName);

                    _deCompressedFiles.Enqueue(fileName);
                    UpdateLabel(lblCompressedFilesInQueue, _compressedFiles.Count().ToString());
                    UpdateLabel(lblDecompressedFilesInQueue, _deCompressedFiles.Count().ToString());
                    
                }
            }

            _downloadStarted = false;
            btnStopDownload.Invoke(new Action(() => btnStopDownload.Enabled = false));
            btnLoadDataFromBlob.Invoke(new Action(() => btnLoadDataFromBlob.Enabled = true));
        }

        private async Task Decompress(FileInfo fileToDecompress)
        {
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                string currentFileName = fileToDecompress.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        await decompressionStream.CopyToAsync(decompressedFileStream);
                        Trace.WriteLine("Decompressed: {0}", fileToDecompress.Name);
                    }
                }
            }
        }

        private async Task<string> ProcessCompressedFile(string blobName)
        {
            string compressedFileName = Path.Combine(Properties.Settings.Default.CachePath, blobName);
            string decompressedFileName = compressedFileName.Remove(compressedFileName.Length - ".gz".Length);

            // check if file already exists in local disk (aleady decompressed) then take from cache
            if (File.Exists(decompressedFileName))
            {
                // return file name
                return await Task.FromResult<string>(decompressedFileName);
            }

            if (!File.Exists(compressedFileName))
            {
                // download blob
                if (!Directory.Exists(Properties.Settings.Default.CachePath))
                {
                    Directory.CreateDirectory(Properties.Settings.Default.CachePath);
                }

                CloudBlobDirectory dir = GetCloudBlobDirectory();
                CloudBlockBlob blob = dir.GetBlockBlobReference(blobName);
                using (FileStream fs = File.Create(compressedFileName))
                {
                    await blob.DownloadToStreamAsync(fs);
                    fs.Close();
                }
            }

            // decompress
            FileInfo gzippedFile = new FileInfo(compressedFileName);
            await Decompress(gzippedFile);

            // return file name
            return await Task.FromResult<string>(decompressedFileName);
        }

        private CloudBlobDirectory GetCloudBlobDirectory()
        {
            // Parse the connection string and return a reference to the storage account.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(Properties.Settings.Default.StorageConnectionString);

            // Create the blob client.
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            CloudBlobContainer container = blobClient.GetContainerReference(Properties.Settings.Default.StorageContainter);

            return container.GetDirectoryReference(Properties.Settings.Default.StorageDirectory);
        }

        private void btnStopDownload_Click(object sender, EventArgs e)
        {
            _downloadStarted = false;
            btnStopDownload.Enabled = false;
        }
    }
}
