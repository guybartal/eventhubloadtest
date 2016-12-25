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
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPrallelism)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRPS
            // 
            this.lblRPS.AutoSize = true;
            this.lblRPS.Location = new System.Drawing.Point(64, 154);
            this.lblRPS.Name = "lblRPS";
            this.lblRPS.Size = new System.Drawing.Size(0, 13);
            this.lblRPS.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "RPS:";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(106, 115);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(25, 115);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 235);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(587, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(115, 181);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTotal.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total messages:";
            // 
            // tbPrallelism
            // 
            this.tbPrallelism.Location = new System.Drawing.Point(166, 12);
            this.tbPrallelism.Maximum = 100;
            this.tbPrallelism.Minimum = 1;
            this.tbPrallelism.Name = "tbPrallelism";
            this.tbPrallelism.Size = new System.Drawing.Size(335, 45);
            this.tbPrallelism.TabIndex = 10;
            this.tbPrallelism.Value = 5;
            this.tbPrallelism.Scroll += new System.EventHandler(this.tbPrallelism_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Parallelism:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Time elapsed:";
            // 
            // lblMinutesToRun
            // 
            this.lblMinutesToRun.AutoSize = true;
            this.lblMinutesToRun.Location = new System.Drawing.Point(22, 54);
            this.lblMinutesToRun.Name = "lblMinutesToRun";
            this.lblMinutesToRun.Size = new System.Drawing.Size(77, 13);
            this.lblMinutesToRun.TabIndex = 14;
            this.lblMinutesToRun.Text = "Minutes to run:";
            // 
            // lblTimeElapsed
            // 
            this.lblTimeElapsed.AutoSize = true;
            this.lblTimeElapsed.Location = new System.Drawing.Point(102, 208);
            this.lblTimeElapsed.Name = "lblTimeElapsed";
            this.lblTimeElapsed.Size = new System.Drawing.Size(0, 13);
            this.lblTimeElapsed.TabIndex = 15;
            // 
            // txtMinutesToRun
            // 
            this.txtMinutesToRun.Location = new System.Drawing.Point(106, 51);
            this.txtMinutesToRun.Mask = "000000000";
            this.txtMinutesToRun.Name = "txtMinutesToRun";
            this.txtMinutesToRun.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtMinutesToRun.Size = new System.Drawing.Size(41, 20);
            this.txtMinutesToRun.TabIndex = 17;
            this.txtMinutesToRun.Text = "60";
            this.txtMinutesToRun.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTargetRPS
            // 
            this.txtTargetRPS.Location = new System.Drawing.Point(107, 84);
            this.txtTargetRPS.Mask = "000000000";
            this.txtTargetRPS.Name = "txtTargetRPS";
            this.txtTargetRPS.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtTargetRPS.Size = new System.Drawing.Size(41, 20);
            this.txtTargetRPS.TabIndex = 19;
            this.txtTargetRPS.Text = "5000";
            this.txtTargetRPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Target RPS:";
            // 
            // lblSentResults
            // 
            this.lblSentResults.AutoSize = true;
            this.lblSentResults.Location = new System.Drawing.Point(280, 120);
            this.lblSentResults.Name = "lblSentResults";
            this.lblSentResults.Size = new System.Drawing.Size(0, 13);
            this.lblSentResults.TabIndex = 20;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(187, 115);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 21;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // txtParallelism
            // 
            this.txtParallelism.Location = new System.Drawing.Point(105, 12);
            this.txtParallelism.Mask = "000";
            this.txtParallelism.Name = "txtParallelism";
            this.txtParallelism.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtParallelism.Size = new System.Drawing.Size(43, 20);
            this.txtParallelism.TabIndex = 23;
            this.txtParallelism.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtParallelism.TextChanged += new System.EventHandler(this.txtParallelism_TextChanged);
            // 
            // cbAutomatic
            // 
            this.cbAutomatic.AutoSize = true;
            this.cbAutomatic.Location = new System.Drawing.Point(508, 14);
            this.cbAutomatic.Name = "cbAutomatic";
            this.cbAutomatic.Size = new System.Drawing.Size(72, 17);
            this.cbAutomatic.TabIndex = 24;
            this.cbAutomatic.Text = "automatic";
            this.cbAutomatic.UseVisualStyleBackColor = true;
            // 
            // EventHubLoadTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 257);
            this.Controls.Add(this.cbAutomatic);
            this.Controls.Add(this.txtParallelism);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.lblSentResults);
            this.Controls.Add(this.txtTargetRPS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMinutesToRun);
            this.Controls.Add(this.lblTimeElapsed);
            this.Controls.Add(this.lblMinutesToRun);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPrallelism);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblRPS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Name = "EventHubLoadTestForm";
            this.Text = "Azure EventHub load test";
            this.Load += new System.EventHandler(this.EventHubLoadTestForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPrallelism)).EndInit();
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
    }
}