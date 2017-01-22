using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using YanLib.AppInfo;
using YanLib.Core;
using YoutubeExtractor;

namespace YouTubeDownloader
{
    public partial class FmYouTubeDownloader : Form
    {
        private Thread threadGetYouTubeInfo;
        private Thread threadDownloadYouTube;
        private cDateTime dateTime = new cDateTime();
        private List<VideoInfo> videoInfos = new List<VideoInfo>();
        private System.Windows.Forms.Timer nowTimeTimer = new System.Windows.Forms.Timer()
        {
            Interval = 1000
        };

        public FmYouTubeDownloader()
        {
            InitializeComponent();
        }

        private void FmYouTubeDownloader_Load(object sender, EventArgs e)
        {
            // MenuStrip
            // //
            functionToolStripMenuItem.Text = "功能";
            functionToolStripMenuItem.Image = Properties.Resources.Function;
            // //
            newDownloadToolStripMenuItem.Text = "新增下載";
            newDownloadToolStripMenuItem.Image = Properties.Resources.New;
            // //
            exitToolStripMenuItem.Text = "結束";
            exitToolStripMenuItem.Image = Properties.Resources.Exit;
            // //
            aboutToolStripMenuItem.Text = "關於";
            aboutToolStripMenuItem.Image = Properties.Resources.Info;

            // StatuStrip
            // //
            NowTimeToolStripStatusLabel.Text = OtherSkills.CallNowTime().ToString();
            NowTimeToolStripStatusLabel.Spring = true;
            // //
            PoweredbyToolStripStatusLabel.Text = "Powered by Yan";
            PoweredbyToolStripStatusLabel.IsLink = true;

            //
            nowTimeTimer.Tick += nowTimeTimer_Tick;
            nowTimeTimer.Enabled = true;

            //
            newDownloadToolStripMenuItem_Click(sender, null);
            //
            TextBoxSettings.TextBoxWaterMark(youTubeURLTextBox, @"Example: https://www.youtube.com/");
            youTubeURLTextBox.Font = new Font(youTubeURLTextBox.Font.FontFamily, youTubeURLTextBox.Font.Size, FontStyle.Italic);
            TextBoxSettings.TextBoxWaterMark(savePathTextBox, @"Example: %systemdrive%\users\%username%\Desktop");
            savePathTextBox.Font = new Font(savePathTextBox.Font.FontFamily, savePathTextBox.Font.Size, FontStyle.Italic);
            savePathTextBox.MaxLength = 260;

            //
            FormSettings.SetFormShowLocation(
                Form: this,
                Text: "YouYube Downloader_v" + OtherSkills.AppVersion(),
                Icon: Properties.Resources.Icon_YouTubeDownloader);
        }

        private void newDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
            if (threadGetYouTubeInfo != null)
            {
                try
                {
                    threadGetYouTubeInfo.Abort();
                }
                catch (ThreadAbortException) { }
            }
            if (threadDownloadYouTube != null)
            {
                try
                {
                    threadDownloadYouTube.Abort();
                }
                catch (ThreadAbortException) { }
            }
            videoInfos.Clear();
            //
            this.Text = "YouTube Downloader_v" + OtherSkills.AppVersion();
            //
            youTubeURLTextBox.Enabled = true;
            youTubeURLTextBox.ReadOnly = false;
            youTubeURLTextBox.Text = string.Empty;
            getYouTubeInfoButton.Enabled = true;
            //
            getYouTubeInfoProgressBar.Value = 0;
            getYouTubeInfoProgressBar.Visible = false;
            // 
            videoQualityComboBox.Enabled = false;
            videoQualityComboBox.Items.Clear();
            videoQualityComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            extractAudioCheckBox.Checked = false;
            extractAudioCheckBox.Enabled = false;
            extractAudioCheckBox.Visible = false;
            //
            savePathTextBox.Text = string.Empty;
            savePathTextBox.Enabled = false;
            selectPathButton.Enabled = false;
            //
            downloadProgressBar.Value = 0;
            downloadProgressBar.Maximum = 100;
            downloadProgressBar.Minimum = 0;
            downloadProgressBar.Visible = (sender == null);
            downloadButton.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OtherSkills.KillAppProcess();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmAppInfo fm = new FmAppInfo(
                appName: "YouTube Downloader", appVersion: OtherSkills.AppVersion(), appPng: Properties.Resources.PNG_YouTubeDownloader, formText: "About", appIcon: Properties.Resources.Icon_YouTubeDownloader);
            fm.ShowDialog();
            fm.Close();
        }
        private void youTubeURLTextBox_TextChanged(object sender, EventArgs e)
        {
            youTubeURLTextBox.Font = new Font(
                youTubeURLTextBox.Font.FontFamily,
                youTubeURLTextBox.Font.Size,
                youTubeURLTextBox.Text.Length > 0 ? FontStyle.Regular : FontStyle.Italic);
        }

        private void getYouTubeInfoButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(youTubeURLTextBox.Text))
            {
                MessageBox.Show(
                    "請提供有效的 YouTube 網址。", "網址無效",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // Clear List
                videoInfos.Clear();
                // Clear ComboBox
                videoQualityComboBox.Items.Clear();
                // Disable groupbox
                newDownloadToolStripMenuItem.Enabled = false;
                youTubeURLTextBox.Enabled = false;
                getYouTubeInfoButton.Enabled = false;
                getYouTubeInfoButton.Visible = false;
                getYouTubeInfoProgressBar.Visible = true;
                getYouTubeInfoProgressBar.Style = ProgressBarStyle.Marquee;
                getYouTubeInfoProgressBar.MarqueeAnimationSpeed = 20;
                
                threadGetYouTubeInfo = new Thread(() => GetYouTubeInfo(youTubeURL: youTubeURLTextBox.Text));
                threadGetYouTubeInfo.Start();
            }
        }

        private void videoQualityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(savePathTextBox.Text))
            {
                savePathTextBox.Text = string.Format(@"{0}\{1}{2}",
                                                     Application.StartupPath,
                                                     videoInfos[videoQualityComboBox.SelectedIndex].Title,
                                                     extractAudioCheckBox.Checked ? videoInfos[videoQualityComboBox.SelectedIndex].AudioExtension : videoInfos[videoQualityComboBox.SelectedIndex].VideoExtension);
            }
            else
            {
                savePathTextBox.Text.Remove(savePathTextBox.Text.LastIndexOf('\\') + 1);
                savePathTextBox.Text += string.Format("{0}{1}",
                                                      videoInfos[videoQualityComboBox.SelectedIndex].Title,
                                                      extractAudioCheckBox.Checked ? videoInfos[videoQualityComboBox.SelectedIndex].AudioExtension : videoInfos[videoQualityComboBox.SelectedIndex].VideoExtension);
            }
            extractAudioCheckBox.Checked = extractAudioCheckBox.Checked || videoInfos[videoQualityComboBox.SelectedIndex].CanExtractAudio;
            extractAudioCheckBox.Enabled = videoInfos[videoQualityComboBox.SelectedIndex].CanExtractAudio;
            extractAudioCheckBox.Visible = videoInfos[videoQualityComboBox.SelectedIndex].CanExtractAudio;
        }

        private void extractAudioCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            savePathTextBox.Text.Remove(savePathTextBox.Text.LastIndexOf('.'));
            savePathTextBox.Text += videoInfos[videoQualityComboBox.SelectedIndex].AudioExtension;
        }

        private void selectPathButton_Click(object sender, EventArgs e)
        {
            string targetPath = OtherSkills.SaveFileDialog(
                FileName: videoInfos[videoQualityComboBox.SelectedIndex].Title,
                Filter: string.Format("{0} Files|*{1}",
                                      extractAudioCheckBox.Checked ? videoInfos[videoQualityComboBox.SelectedIndex].AudioType.ToString() : videoInfos[videoQualityComboBox.SelectedIndex].VideoType.ToString(),
                                      extractAudioCheckBox.Checked ? videoInfos[videoQualityComboBox.SelectedIndex].AudioExtension : videoInfos[videoQualityComboBox.SelectedIndex].VideoExtension),
                Title: "請選擇檔案儲存路徑");
            if (!string.IsNullOrEmpty(targetPath))
            {
                savePathTextBox.Text = targetPath;
            }
        }

        private void savePathTextBox_TextChanged(object sender, EventArgs e)
        {
            savePathTextBox.Font = new Font(
                savePathTextBox.Font.FontFamily,
                savePathTextBox.Font.Size,
                savePathTextBox.Text.Length > 0 ? FontStyle.Regular : FontStyle.Italic);
        }
        private void downloadButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(savePathTextBox.Text))
            {
                MessageBox.Show(
                    "儲存路徑禁止為空，請重新選擇儲存路徑後再嘗試下載。", "路徑錯誤",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("即將開始下載程序，是否繼續下載？", "即將下載", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Control form.
                    // //
                    downloadSettingsGroupBox.Enabled = false;
                    // //
                    newDownloadToolStripMenuItem.Enabled = false;
                    // //
                    downloadProgressBar.Minimum = 0;
                    downloadProgressBar.Maximum = 100;
                    downloadProgressBar.Value = 0;
                    downloadProgressBar.Visible = true;
                    downloadButton.Enabled = false;
                    downloadButton.Text = "0%";

                    // Decipher the video if it has a decrypted signature
                    if (videoInfos[videoQualityComboBox.SelectedIndex].RequiresDecryption)
                    {
                        DownloadUrlResolver.DecryptDownloadUrl(videoInfos[videoQualityComboBox.SelectedIndex]);
                    }

                    VideoInfo videoInfo = videoInfos[videoQualityComboBox.SelectedIndex];
                    string savePath = savePathTextBox.Text;
                    bool isVideo = !extractAudioCheckBox.Checked;

                    threadDownloadYouTube = new Thread(() => DownloadYouTube(videoInfo: videoInfo, savePath: savePath, isVideo: isVideo));
                    threadDownloadYouTube.Start();
                }
            }
        }

        private void nowTimeTimer_Tick(object sender, EventArgs e)
        {
            NowTimeToolStripStatusLabel.Text = OtherSkills.CallNowTime().ToString();
        }

        private void GetYouTubeInfo(string youTubeURL)
        {
            Result result = new Result();
            try
            {
                // Get all available video formats
                videoInfos = DownloadUrlResolver.GetDownloadUrls(youTubeURLTextBox.Text).OrderBy(x => x.VideoType)
                                                                                        .ThenByDescending(x => x.Resolution)
                                                                                        .ThenBy(x => x.AudioType)
                                                                                        .ThenByDescending(x => x.AudioBitrate)
                                                                                        .ToList();
                // Remove unknow video info
                videoInfos.RemoveAll(x => string.IsNullOrEmpty(x.Title));
                // Loop through array of videos
                foreach (VideoInfo currentVideo in videoInfos)
                {
                    // Add video options to ComboBox
                    string itemText = string.Format("{0}, {1}p",
                                                    currentVideo.VideoType.ToString(), currentVideo.Resolution);
                    if (!string.IsNullOrEmpty(currentVideo.AudioExtension))
                    {
                        itemText += string.Format(", {0} {1} KBps", currentVideo.AudioExtension.Trim('.').ToUpper(), currentVideo.AudioBitrate);
                    }
                    AddComboBoxItem(comboBox: videoQualityComboBox, item: itemText);
                    
                }
                result.Status = true;
            }
            catch (ArgumentException)
            {
                result.Caption = "網址無效";
                result.Detials = "請提供有效的 YouTube 網址。";
            }
            catch (Exception e)
            {
                result.Caption = "檢索錯誤";
                result.Detials = "檢索視頻選項時出現問題。";
                Console.WriteLine(e.Message);
            }
            GetYouTubeInfoFinish(result: result);
        }

        private delegate void GetYouTubeInfoFinishCallback(Result result);
        private void GetYouTubeInfoFinish(Result result)
        {
            if (this.InvokeRequired)
            {
                GetYouTubeInfoFinishCallback gytufcb = new GetYouTubeInfoFinishCallback(GetYouTubeInfoFinish);
                this.Invoke(gytufcb, result);
            }
            else
            {
                //
                this.Text = videoInfos.First().Title;
                //
                newDownloadToolStripMenuItem.Enabled = true;
                //
                youTubeURLTextBox.Enabled = true;
                youTubeURLTextBox.ReadOnly = result.Status;
                //
                getYouTubeInfoButton.Enabled = !result.Status;
                getYouTubeInfoButton.Visible = true;
                getYouTubeInfoProgressBar.Visible = false;
                //
                videoQualityComboBox.Enabled = result.Status;
                //
                savePathTextBox.Enabled = result.Status;
                selectPathButton.Enabled = result.Status;
                //
                downloadButton.Enabled = result.Status;
                if (result.Status)
                {
                    // The best is mp4 && have video && have audio
                    if (videoInfos.Any(x => x.VideoType == VideoType.Mp4 && x.Resolution > 0 && x.AudioBitrate > 0))
                    {
                        videoQualityComboBox.SelectedIndex = videoInfos.IndexOf(videoInfos.FirstOrDefault(x => x.VideoType == VideoType.Mp4 && x.Resolution > 0 && x.AudioBitrate > 0));
                    }
                    else
                    {
                        videoQualityComboBox.SelectedIndex = 0;
                    }
                    System.Media.SystemSounds.Exclamation.Play();
                }
                else
                {
                    MessageBox.Show(
                        result.Detials, result.Caption,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DownloadYouTube(VideoInfo videoInfo, string savePath, bool isVideo)
        {
            // Record begin time
            dateTime.BeginTime = DateTime.Now;
            // Download type is video
            if (isVideo)
            {            
                // Initiate a new VideoDownloader object, passing the VideoInfo object and save path
                VideoDownloader videoDownloader = new VideoDownloader(videoInfo, savePath);
                // Register the ProgressChanged event and print the current progress
                videoDownloader.DownloadProgressChanged += (sender, args) => DownloadProgressChanged((int)args.ProgressPercentage);
                videoDownloader.DownloadFinished += (sender, args) => DownloadFinished();
                // Execute the video downloader
                try
                {
                    videoDownloader.Execute();
                }
                catch (IOException) { DownloadFinished(successfully: false, message: "儲存路徑錯誤或不存在，請重新選擇儲存路徑後再嘗試下載。"); }
                catch (Exception e) { DownloadFinished(successfully: false, message: e.Message); }
            }
            // Download type is audio
            else
            {
                // Initiate a new AudioDownloader object, passing the VideoInfo object and save path
                AudioDownloader audioDownloader = new AudioDownloader(videoInfo, savePath);
                // Register the progress events. We treat the download progress as 85% of the progress and the extraction progress only as 15% of the progress,
                // because the download will take much longer than the audio extraction.
                audioDownloader.DownloadProgressChanged += (sender, args) => DownloadProgressChanged((int)(args.ProgressPercentage * 0.85));
                audioDownloader.AudioExtractionProgressChanged += (sender, args) => DownloadProgressChanged((int)(85 + args.ProgressPercentage * 0.15));
                audioDownloader.DownloadFinished += (sender, args) => DownloadFinished();
                // Execute the audio downloader
                try
                {
                    audioDownloader.Execute();
                }
                catch (IOException) { DownloadFinished(successfully: false, message: "儲存路徑錯誤或不存在，請重新選擇儲存路徑後再嘗試下載。"); }
                catch (Exception e) { DownloadFinished(successfully: false, message: e.Message); }
            }

        }

        private delegate void DownloadFinishedCallback(bool successfully = true, string message = "");
        private void DownloadFinished(bool successfully = true, string message = "")
        {
            if (this.InvokeRequired)
            {
                // Record finsh time
                dateTime.EndTime = DateTime.Now;
                // Callback
                DownloadFinishedCallback dfcb = new DownloadFinishedCallback(DownloadFinished);
                this.Invoke(dfcb, successfully, message);
            }
            else
            {
                //
                newDownloadToolStripMenuItem.Enabled = true;
                //
                downloadSettingsGroupBox.Enabled = true;
                //
                downloadButton.Enabled = true;
                downloadButton.Text = "下載";
                //
                // newDownloadToolStripMenuItem_Click(null, null);

                if (successfully)
                {
                    if (MessageBox.Show(
                            string.Format("檔案下載成功（耗時 {0} 秒）！是否開啟檔案儲存目錄？", dateTime.SecondDiff(point: 2)),
                            "下載成功",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(savePathTextBox.Text.Remove(savePathTextBox.Text.LastIndexOf('\\')));
                    }
                }
                else
                {
                    MessageBox.Show(
                            message, "下載錯誤",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private delegate void AddComboBoxItemCallback(ComboBox comboBox, string item);
        private void AddComboBoxItem(ComboBox comboBox, string item)
        {
            if (this.InvokeRequired)
            {
                AddComboBoxItemCallback acbicb = new AddComboBoxItemCallback(AddComboBoxItem);
                this.Invoke(acbicb, comboBox, item);
            }
            else
            {
                comboBox.Items.Add(item);
            }
        }

        private delegate void DownloadProgressChangedCallback(int value);
        private void DownloadProgressChanged(int value)
        {
            if (this.InvokeRequired)
            {
                DownloadProgressChangedCallback dpccb = new DownloadProgressChangedCallback(DownloadProgressChanged);
                this.Invoke(dpccb, value);
            }
            else
            {
                downloadButton.Text = value + "%";
                downloadProgressBar.Value = value;
            }
        }
    }

    public class Result
    {
        public bool Status { get; set; }

        public string Caption { get; set; }

        public string Detials { get; set; }

        public Result(bool Status = false, string Caption = "", string Detials = "")
        {
            this.Status = Status;
            this.Caption = Caption;
            this.Detials = Detials;
        }
    }

    public class cDateTime
    {
        public DateTime BeginTime { get; set; }

        public DateTime EndTime { get; set; }

        public double SecondDiff(int point = 2)
        {
            return (Math.Floor(new TimeSpan(EndTime.Ticks - BeginTime.Ticks).TotalSeconds * (int)Math.Pow(10, point)) / Math.Pow(10, point));
        }
    }
}
