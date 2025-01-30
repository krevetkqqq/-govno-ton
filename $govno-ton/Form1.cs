using System.Windows.Forms;
using System;
using MainCode;
using System.IO;
using NAudio.Wave;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GeckoTerminalGraph
{
    public partial class MainForm : Form
    {
        private string[] musicFiles;
        private int currentTrackIndex = -1;
        private WaveOutEvent waveOut;
        private AudioFileReader audioFileReader;
        private bool isSwitched = false;
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            InitializeTimer();
            Timer_Tick(null, null);
            LoadMusicFiles();
            InitializeClickTimer();
            CreateRoundedRegion(20);
        }
        private void InitializeClickTimer()
        {
            var timer = new Timer();
            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += SwitchState;
        }
        private void SwitchState(object sender, EventArgs e)
        {
            isSwitched = false;
        }
        private void InitializeTimer()
        {
            var timer = new Timer();
            timer.Interval = 60000; // 60000 миллисекунд = 1 минута
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
        }

        private async void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                decimal price = await Program.GetPriceAsync();
                Console.WriteLine(price);
                string text = price.ToString() + "$";
                cost.Text = text;

                decimal price2 = await Program.GetPriceAsync2();
                Console.WriteLine(price2);
                string text2 = price2.ToString() + "$";
                cost2.Text = text2;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private string GetProjectRoot(string startupPath)
        {
            DirectoryInfo dirInfo = Directory.GetParent(startupPath);
            dirInfo = Directory.GetParent(dirInfo.FullName);
            return dirInfo.FullName;
        }
        private void LoadMusicFiles()
        {
            // Убедитесь, что путь к папке правильный
            string musicFolderPath = Path.Combine(GetProjectRoot(Application.StartupPath), "Resources", "music");
            Console.WriteLine(musicFolderPath);
            if (Directory.Exists(musicFolderPath))
            {
                musicFiles = Directory.GetFiles(musicFolderPath, "*.*", SearchOption.AllDirectories); // Поддерживает различные форматы
            }
            else
            {
                MessageBox.Show("Папка с музыкой не найдена.");
                musicFiles = new string[0];
            }
        }

        private void PlayTrack(int index)
        {
            if (index >= 0 && index < musicFiles.Length)
            {
                currentTrackIndex = index;
                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut.Dispose();
                    audioFileReader.Dispose();
                }
                audioFileReader = new AudioFileReader(musicFiles[currentTrackIndex]);
                waveOut = new WaveOutEvent();
                waveOut.Init(audioFileReader);
                waveOut.PlaybackStopped += WaveOut_PlaybackStopped;
                waveOut.Play();
            }
        }

        private void WaveOut_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                PlayNextTrack();
            }));
        }

        private void PlayNextTrack()
        {
            if (isSwitched)
                return;
            if (currentTrackIndex + 1 < musicFiles.Length)
            {
                PlayTrack(currentTrackIndex + 1);
                isSwitched = true;
            }
            else
            {
                PlayTrack(0);
                isSwitched = true;
            }
        }

        private void PlayPreviousTrack()
        {
            if (isSwitched)
            {
                return;
            }
            if (currentTrackIndex - 1 >= 0)
            {
                PlayTrack(currentTrackIndex - 1);
                isSwitched = true;
            }
            else
            {
                PlayTrack(musicFiles.Length - 1);
                isSwitched = true;
            }
        }

        private void buttonPlayPause_Click(object sender, EventArgs e)
        {
            if (waveOut == null || currentTrackIndex == -1)
            {
                if (musicFiles.Length > 0)
                {
                    PlayTrack(0);
                }
            }
            else
            {
                if (waveOut.PlaybackState == PlaybackState.Playing)
                {
                    waveOut.Pause();
                }
                else
                {
                    waveOut.Play();
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Dispose();
                audioFileReader.Dispose();
            }
            base.OnFormClosing(e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            PlayTrack(currentTrackIndex);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlayPreviousTrack();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            buttonPlayPause_Click(null, null);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.TopMost = !this.TopMost;
        }
        private void CreateRoundedRegion(int radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90); // Левый верхний угол
                path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90); // Правый верхний угол
                path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90); // Правый нижний угол
                path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90); // Левый нижний угол
                path.CloseFigure();

                this.Region = new Region(path);
            }
        }
    }
}
    