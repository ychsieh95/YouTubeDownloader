namespace YouTubeDownloader
{
    partial class FmYouTubeDownloader
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.downloadSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.extractAudioCheckBox = new System.Windows.Forms.CheckBox();
            this.savePathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.videoQualityComboBox = new System.Windows.Forms.ComboBox();
            this.selectPathButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.youTubeURLTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.getYouTubeInfoButton = new System.Windows.Forms.Button();
            this.getYouTubeInfoProgressBar = new System.Windows.Forms.ProgressBar();
            this.downloadButton = new System.Windows.Forms.Button();
            this.downloadProgressBar = new System.Windows.Forms.ProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.NowTimeToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.PoweredbyToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.downloadSettingsGroupBox.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // downloadSettingsGroupBox
            // 
            this.downloadSettingsGroupBox.Controls.Add(this.extractAudioCheckBox);
            this.downloadSettingsGroupBox.Controls.Add(this.savePathTextBox);
            this.downloadSettingsGroupBox.Controls.Add(this.label3);
            this.downloadSettingsGroupBox.Controls.Add(this.videoQualityComboBox);
            this.downloadSettingsGroupBox.Controls.Add(this.selectPathButton);
            this.downloadSettingsGroupBox.Controls.Add(this.label2);
            this.downloadSettingsGroupBox.Controls.Add(this.youTubeURLTextBox);
            this.downloadSettingsGroupBox.Controls.Add(this.label1);
            this.downloadSettingsGroupBox.Controls.Add(this.getYouTubeInfoButton);
            this.downloadSettingsGroupBox.Controls.Add(this.getYouTubeInfoProgressBar);
            this.downloadSettingsGroupBox.Location = new System.Drawing.Point(12, 29);
            this.downloadSettingsGroupBox.Name = "downloadSettingsGroupBox";
            this.downloadSettingsGroupBox.Size = new System.Drawing.Size(504, 120);
            this.downloadSettingsGroupBox.TabIndex = 1;
            this.downloadSettingsGroupBox.TabStop = false;
            this.downloadSettingsGroupBox.Text = "下載設定";
            // 
            // extractAudioCheckBox
            // 
            this.extractAudioCheckBox.AutoSize = true;
            this.extractAudioCheckBox.Location = new System.Drawing.Point(396, 57);
            this.extractAudioCheckBox.Name = "extractAudioCheckBox";
            this.extractAudioCheckBox.Size = new System.Drawing.Size(105, 21);
            this.extractAudioCheckBox.TabIndex = 5;
            this.extractAudioCheckBox.Text = "轉換為音訊檔";
            this.extractAudioCheckBox.UseVisualStyleBackColor = true;
            this.extractAudioCheckBox.CheckedChanged += new System.EventHandler(this.extractAudioCheckBox_CheckedChanged);
            // 
            // savePathTextBox
            // 
            this.savePathTextBox.Location = new System.Drawing.Point(85, 86);
            this.savePathTextBox.Name = "savePathTextBox";
            this.savePathTextBox.Size = new System.Drawing.Size(305, 25);
            this.savePathTextBox.TabIndex = 7;
            this.savePathTextBox.TextChanged += new System.EventHandler(this.savePathTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "儲存路徑：";
            // 
            // videoQualityComboBox
            // 
            this.videoQualityComboBox.FormattingEnabled = true;
            this.videoQualityComboBox.Location = new System.Drawing.Point(85, 55);
            this.videoQualityComboBox.Name = "videoQualityComboBox";
            this.videoQualityComboBox.Size = new System.Drawing.Size(305, 25);
            this.videoQualityComboBox.TabIndex = 4;
            this.videoQualityComboBox.SelectedIndexChanged += new System.EventHandler(this.videoQualityComboBox_SelectedIndexChanged);
            // 
            // selectPathButton
            // 
            this.selectPathButton.Location = new System.Drawing.Point(396, 86);
            this.selectPathButton.Name = "selectPathButton";
            this.selectPathButton.Size = new System.Drawing.Size(102, 25);
            this.selectPathButton.TabIndex = 8;
            this.selectPathButton.Text = "選擇儲存位置";
            this.selectPathButton.UseVisualStyleBackColor = true;
            this.selectPathButton.Click += new System.EventHandler(this.selectPathButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "下載格式：";
            // 
            // youTubeURLTextBox
            // 
            this.youTubeURLTextBox.Location = new System.Drawing.Point(85, 24);
            this.youTubeURLTextBox.Name = "youTubeURLTextBox";
            this.youTubeURLTextBox.Size = new System.Drawing.Size(305, 25);
            this.youTubeURLTextBox.TabIndex = 1;
            this.youTubeURLTextBox.TextChanged += new System.EventHandler(this.youTubeURLTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "影片連結：";
            // 
            // getYouTubeInfoButton
            // 
            this.getYouTubeInfoButton.Location = new System.Drawing.Point(396, 24);
            this.getYouTubeInfoButton.Name = "getYouTubeInfoButton";
            this.getYouTubeInfoButton.Size = new System.Drawing.Size(102, 25);
            this.getYouTubeInfoButton.TabIndex = 2;
            this.getYouTubeInfoButton.Text = "取得視頻選項";
            this.getYouTubeInfoButton.UseVisualStyleBackColor = true;
            this.getYouTubeInfoButton.Click += new System.EventHandler(this.getYouTubeInfoButton_Click);
            // 
            // getYouTubeInfoProgressBar
            // 
            this.getYouTubeInfoProgressBar.Location = new System.Drawing.Point(396, 24);
            this.getYouTubeInfoProgressBar.Name = "getYouTubeInfoProgressBar";
            this.getYouTubeInfoProgressBar.Size = new System.Drawing.Size(102, 25);
            this.getYouTubeInfoProgressBar.TabIndex = 3;
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(408, 155);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(102, 25);
            this.downloadButton.TabIndex = 3;
            this.downloadButton.Text = "下載";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // downloadProgressBar
            // 
            this.downloadProgressBar.Location = new System.Drawing.Point(12, 155);
            this.downloadProgressBar.Name = "downloadProgressBar";
            this.downloadProgressBar.Size = new System.Drawing.Size(390, 25);
            this.downloadProgressBar.TabIndex = 2;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(528, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDownloadToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.functionToolStripMenuItem.Text = "Function";
            // 
            // newDownloadToolStripMenuItem
            // 
            this.newDownloadToolStripMenuItem.Name = "newDownloadToolStripMenuItem";
            this.newDownloadToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.newDownloadToolStripMenuItem.Text = "NewDownload";
            this.newDownloadToolStripMenuItem.Click += new System.EventHandler(this.newDownloadToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NowTimeToolStripStatusLabel,
            this.PoweredbyToolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 185);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(528, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // NowTimeToolStripStatusLabel
            // 
            this.NowTimeToolStripStatusLabel.Name = "NowTimeToolStripStatusLabel";
            this.NowTimeToolStripStatusLabel.Size = new System.Drawing.Size(180, 17);
            this.NowTimeToolStripStatusLabel.Text = "NowTimeToolStripStatusLabel";
            // 
            // PoweredbyToolStripStatusLabel
            // 
            this.PoweredbyToolStripStatusLabel.Name = "PoweredbyToolStripStatusLabel";
            this.PoweredbyToolStripStatusLabel.Size = new System.Drawing.Size(189, 17);
            this.PoweredbyToolStripStatusLabel.Text = "PoweredbyToolStripStatusLabel";
            // 
            // FmYouTubeDownloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 207);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.downloadProgressBar);
            this.Controls.Add(this.downloadSettingsGroupBox);
            this.Controls.Add(this.downloadButton);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FmYouTubeDownloader";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FmYouTubeDownloader_Load);
            this.downloadSettingsGroupBox.ResumeLayout(false);
            this.downloadSettingsGroupBox.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox downloadSettingsGroupBox;
        private System.Windows.Forms.Button getYouTubeInfoButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox youTubeURLTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar getYouTubeInfoProgressBar;
        private System.Windows.Forms.ComboBox videoQualityComboBox;
        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.TextBox savePathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button selectPathButton;
        private System.Windows.Forms.ProgressBar downloadProgressBar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem functionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDownloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel NowTimeToolStripStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel PoweredbyToolStripStatusLabel;
        private System.Windows.Forms.CheckBox extractAudioCheckBox;
    }
}

