using Microsoft.Win32;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Mon_Player_Audio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MediaPlayer player = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Update;
            timer.Start();

        }

        private void Update(object sender, EventArgs e)
        {
            if (player.Source != null)
            {
                prog.Minimum = 0;
                prog.Maximum = player.NaturalDuration.TimeSpan.TotalSeconds;
                prog.Value = player.Position.TotalSeconds;
            }
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";

            if (fileDialog.ShowDialog() == true)
            {
                player.Open(new System.Uri(fileDialog.FileName));
                player.Play();
                FilePath.Text = fileDialog.FileName;
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            player.Play();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            player.Pause();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
        }

        private void Vol_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            player.Volume = Vol.Value / 100;
        }
    }
}