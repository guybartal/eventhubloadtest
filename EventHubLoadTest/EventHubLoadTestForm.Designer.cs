namespace EventHubLoadTest
{
    partial class EventHubLoadTestForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRPS = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCurrentTask = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPrallelism = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblMinutesToRun = new System.Windows.Forms.Label();
            this.lblTimeElapsed = new System.Windows.Forms.Label();
            this.txtMinutesToRun = new System.Windows.Forms.MaskedTextBox();
            this.txtTargetRPS = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSentResults = new System.Windows.Forms.Label();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtParallelism = new System.Windows.Forms.MaskedTextBox();
            this.cbAutomatic = new System.Windows.Forms.CheckBox();
            this.btnLoadDataFromBlob = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbRemoteGzipedFiles = new System.Windows.Forms.RadioButton();
            this.rbSingleLocalFile = new System.Windows.Forms.RadioButton();
            this.btnStopDownload = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCompressedFilesInQueue = new System.Windows.Forms.Label();
            this.lblDecompressedFilesInQueue = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBatchLimitPerThread = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblBatchNumberCycle = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPrallelism)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRPS
            // 
            this.lblRPS.AutoSize = true;
            this.lblRPS.Location = new System.Drawing.Point(136, 0);
            this.lblRPS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRPS.Name = "lblRPS";
            this.lblRPS.Size = new System.Drawing.Size(0, 20);
            this.lblRPS.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "RPS:";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(159, 244);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(112, 35);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(38, 244);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 35);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblCurrentTask});
            this.statusStrip1.Location = new System.Drawing.Point(0, 545);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1233, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // lblCurrentTask
            // 
            this.lblCurrentTask.Name = "lblCurrentTask";
            this.lblCurrentTask.Size = new System.Drawing.Size(0, 17);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(136, 53);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 20);
            this.lblTotal.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 40);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total messages:";
            // 
            // tbPrallelism
            // 
            this.tbPrallelism.Location = new System.Drawing.Point(314, 18);
            this.tbPrallelism.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPrallelism.Maximum = 100;
            this.tbPrallelism.Minimum = 1;
            this.tbPrallelism.Name = "tbPrallelism";
            this.tbPrallelism.Size = new System.Drawing.Size(502, 45);
            this.tbPrallelism.TabIndex = 10;
            this.tbPrallelism.Value = 5;
            this.tbPrallelism.Scroll += new System.EventHandler(this.tbPrallelism_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Parallelism:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 106);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Time elapsed:";
            // 
            // lblMinutesToRun
            // 
            this.lblMinutesToRun.AutoSize = true;
            this.lblMinutesToRun.Location = new System.Drawing.Point(33, 83);
            this.lblMinutesToRun.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMinutesToRun.Name = "lblMinutesToRun";
            this.lblMinutesToRun.Size = new System.Drawing.Size(114, 20);
            this.lblMinutesToRun.TabIndex = 14;
            this.lblMinutesToRun.Text = "Minutes to run:";
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.AutoSize = true;
            this.lblTimeElapsed.Location = new System.Drawing.Point(136, 106);
            this.lblTimeElapsed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Size = new System.Drawing.Size(0, 20);
            this.lblTimeElapsed.TabIndex = 15;
            // 
            // txtMinutesToRun
            // 
            this.txtMinutesToRun.Location = new System.Drawing.Point(212, 78);
            this.txtMinutesToRun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMinutesToRun.Mask = "000000000";
            this.txtMinutesToRun.Name = "txtMinutesToRun";
            this.txtMinutesToRun.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMinutesToRun.Size = new System.Drawing.Size(60, 26);
            this.txtMinutesToRun.TabIndex = 17;
            this.txtMinutesToRun.Text = "60";
            this.txtMinutesToRun.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTargetRPS
            // 
            this.txtTargetRPS.Location = new System.Drawing.Point(213, 129);
            this.txtTargetRPS.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTargetRPS.Mask = "000000000";
            this.txtTargetRPS.Name = "txtTargetRPS";
            this.txtTargetRPS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTargetRPS.Size = new System.Drawing.Size(60, 26);
            this.txtTargetRPS.TabIndex = 19;
            this.txtTargetRPS.Text = "5000";
            this.txtTargetRPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 134);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Target RPS:";
            // 
            // lblSentResults
            // 
            this.lblSentResults.AutoSize = true;
            this.lblSentResults.Location = new System.Drawing.Point(608, 106);
            this.lblSentResults.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSentResults.Name = "lblSentResults";
            this.lblSentResults.Size = new System.Drawing.Size(0, 20);
            this.lblSentResults.TabIndex = 20;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(280, 244);
            this.btnLoadData.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(112, 35);
            this.btnLoadData.TabIndex = 21;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // txtParallelism
            // 
            this.txtParallelism.Location = new System.Drawing.Point(211, 18);
            this.txtParallelism.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtParallelism.Mask = "00000";
            this.txtParallelism.Name = "txtParallelism";
            this.txtParallelism.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtParallelism.Size = new System.Drawing.Size(62, 26);
            this.txtParallelism.TabIndex = 23;
            this.txtParallelism.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtParallelism.TextChanged += new System.EventHandler(this.txtParallelism_TextChanged);
            // 
            // cbAutomatic
            // 
            this.cbAutomatic.AutoSize = true;
            this.cbAutomatic.Location = new System.Drawing.Point(827, 22);
            this.cbAutomatic.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbAutomatic.Name = "cbAutomatic";
            this.cbAutomatic.Size = new System.Drawing.Size(98, 24);
            this.cbAutomatic.TabIndex = 24;
            this.cbAutomatic.Text = "automatic";
            this.cbAutomatic.UseVisualStyleBackColor = true;
            // 
            // btnLoadDataFromBlob
            // 
            this.btnLoadDataFromBlob.Location = new System.Drawing.Point(402, 244);
            this.btnLoadDataFromBlob.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoadDataFromBlob.Name = "btnLoadDataFromBlob";
            this.btnLoadDataFromBlob.Size = new System.Drawing.Size(183, 35);
            this.btnLoadDataFromBlob.TabIndex = 25;
            this.btnLoadDataFromBlob.Text = "Load Data From Blob";
            this.btnLoadDataFromBlob.UseVisualStyleBackColor = true;
            this.btnLoadDataFromBlob.Click += new System.EventHandler(this.btnLoadDataFromBlob_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbRemoteGzipedFiles);
            this.groupBox1.Controls.Add(this.rbSingleLocalFile);
            this.groupBox1.Location = new System.Drawing.Point(345, 65);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(206, 95);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input mode";
            // 
            // rbRemoteGzipedFiles
            // 
            this.rbRemoteGzipedFiles.AutoSize = true;
            this.rbRemoteGzipedFiles.Location = new System.Drawing.Point(15, 58);
            this.rbRemoteGzipedFiles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbRemoteGzipedFiles.Name = "rbRemoteGzipedFiles";
            this.rbRemoteGzipedFiles.Size = new System.Drawing.Size(167, 24);
            this.rbRemoteGzipedFiles.TabIndex = 27;
            this.rbRemoteGzipedFiles.Text = "Remote gziped files";
            this.rbRemoteGzipedFiles.UseVisualStyleBackColor = true;
            // 
            // rbSingleLocalFile
            // 
            this.rbSingleLocalFile.AutoSize = true;
            this.rbSingleLocalFile.Checked = true;
            this.rbSingleLocalFile.Location = new System.Drawing.Point(15, 29);
            this.rbSingleLocalFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbSingleLocalFile.Name = "rbSingleLocalFile";
            this.rbSingleLocalFile.Size = new System.Drawing.Size(131, 24);
            this.rbSingleLocalFile.TabIndex = 28;
            this.rbSingleLocalFile.TabStop = true;
            this.rbSingleLocalFile.Text = "Single local file";
            this.rbSingleLocalFile.UseVisualStyleBackColor = true;
            // 
            // btnStopDownload
            // 
            this.btnStopDownload.Enabled = false;
            this.btnStopDownload.Location = new System.Drawing.Point(593, 244);
            this.btnStopDownload.Name = "btnStopDownload";
            this.btnStopDownload.Size = new System.Drawing.Size(143, 35);
            this.btnStopDownload.TabIndex = 28;
            this.btnStopDownload.Text = "Stop Download";
            this.btnStopDownload.UseVisualStyleBackColor = true;
            this.btnStopDownload.Click += new System.EventHandler(this.btnStopDownload_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(380, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "Compressed files in queue:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.18518F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.81481F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 227F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 505F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblRPS, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTotal, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTimeElapsed, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSentResults, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCompressedFilesInQueue, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblDecompressedFilesInQueue, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblBatchNumberCycle, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(38, 301);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1110, 204);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(381, 106);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Send results:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(380, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Decompressed files in queue:";
            // 
            // lblCompressedFilesInQueue
            // 
            this.lblCompressedFilesInQueue.AutoSize = true;
            this.lblCompressedFilesInQueue.Location = new System.Drawing.Point(607, 0);
            this.lblCompressedFilesInQueue.Name = "lblCompressedFilesInQueue";
            this.lblCompressedFilesInQueue.Size = new System.Drawing.Size(0, 20);
            this.lblCompressedFilesInQueue.TabIndex = 30;
            // 
            // lblDecompressedFilesInQueue
            // 
            this.lblDecompressedFilesInQueue.AutoSize = true;
            this.lblDecompressedFilesInQueue.Location = new System.Drawing.Point(607, 53);
            this.lblDecompressedFilesInQueue.Name = "lblDecompressedFilesInQueue";
            this.lblDecompressedFilesInQueue.Size = new System.Drawing.Size(0, 20);
            this.lblDecompressedFilesInQueue.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 191);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 20);
            this.label9.TabIndex = 31;
            this.label9.Text = "Batch limit (per thread):";
            // 
            // txtBatchLimitPerThread
            // 
            this.txtBatchLimitPerThread.Location = new System.Drawing.Point(213, 191);
            this.txtBatchLimitPerThread.Mask = "00000";
            this.txtBatchLimitPerThread.Name = "txtBatchLimitPerThread";
            this.txtBatchLimitPerThread.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtBatchLimitPerThread.Size = new System.Drawing.Size(60, 26);
            this.txtBatchLimitPerThread.TabIndex = 32;
            this.txtBatchLimitPerThread.Text = "100";
            this.txtBatchLimitPerThread.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(94, 40);
            this.label10.TabIndex = 31;
            this.label10.Text = "Batch cycle number:";
            // 
            // lblBatchNumberCycle
            // 
            this.lblBatchNumberCycle.AutoSize = true;
            this.lblBatchNumberCycle.Location = new System.Drawing.Point(135, 138);
            this.lblBatchNumberCycle.Name = "lblBatchNumberCycle";
            this.lblBatchNumberCycle.Size = new System.Drawing.Size(0, 20);
            this.lblBatchNumberCycle.TabIndex = 32;
            // 
            // EventHubLoadTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 567);
            this.Controls.Add(this.txtBatchLimitPerThread);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnStopDownload);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLoadDataFromBlob);
            this.Controls.Add(this.cbAutomatic);
            this.Controls.Add(this.txtParallelism);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.txtTargetRPS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMinutesToRun);
            this.Controls.Add(this.lblMinutesToRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPrallelism);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EventHubLoadTestForm";
            this.Text = "Azure EventHub load test";
            this.Load += new System.EventHandler(this.EventHubLoadTestForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPrallelism)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblRPS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tbPrallelism;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMinutesToRun;
        private System.Windows.Forms.Label lblTimeElapsed;
        private System.Windows.Forms.MaskedTextBox txtMinutesToRun;
        private System.Windows.Forms.MaskedTextBox txtTargetRPS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSentResults;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.MaskedTextBox txtParallelism;
        private System.Windows.Forms.CheckBox cbAutomatic;
        private System.Windows.Forms.Button btnLoadDataFromBlob;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbRemoteGzipedFiles;
        private System.Windows.Forms.RadioButton rbSingleLocalFile;
        private System.Windows.Forms.Button btnStopDownload;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCompressedFilesInQueue;
        private System.Windows.Forms.Label lblDecompressedFilesInQueue;
        private System.Windows.Forms.ToolStripStatusLabel lblCurrentTask;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtBatchLimitPerThread;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblBatchNumberCycle;
    }
}