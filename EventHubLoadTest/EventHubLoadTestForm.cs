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
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

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

        public EventHubLoadTestForm()
        {
            InitializeComponent();

            try
            {
                lblStatus.Text = "connecting Event Hub...";
                _client = EventHubClient.CreateFromConnectionString(Properties.Settings.Default.EventHubConnectionString);
                lblStatus.Text = "Event Hub connected";
                txtParallelism.Text = tbPrallelism.Value.ToString();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "failed connecting to event hub. " + ex.Message;
            }

        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = true;
            btnStart.Enabled = false;
            btnLoadData.Enabled = false;

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
                        _sentResults.Add(item.Key,item.Value);
                    }
                    sb.Append($"{item.Key}: {_sentResults[item.Key]}\n");
                }
                UpdateLabel(lblSentResults, sb.ToString());
                _counter+= (UInt64) tbPrallelism.Value;
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
            EventData data = GenerateData();
            _client.RetryPolicy = new NoRetry();
            //_client.RetryPolicy = new RetryExponential(
            //            TimeSpan.Zero,
            //            TimeSpan.FromSeconds(30),
            //            10);
            // Send single message async
            await _client.SendAsync(data);
        }

        private EventData GenerateData()
        {
            // Create the device/temperature metric
            //MetricEvent info = new MetricEvent() { DeviceId = , Temperature = _random.Next(100) };
            //JsonSerializer jsonSerializer = new Newtonsoft.Json.JsonSerializer();

            //EventData data = new EventData(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(info)))
            EventData data = new EventData(Encoding.UTF8.GetBytes(_data[_random.Next(_data.Length)]))
            {
                PartitionKey = _random.Next(5).ToString()
            };

            // Set user properties if needed
            data.Properties.Add("Type", "Telemetry_" + DateTime.Now.ToLongTimeString());
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
            int parallelism = int.Parse(txtParallelism.Text);
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
}
