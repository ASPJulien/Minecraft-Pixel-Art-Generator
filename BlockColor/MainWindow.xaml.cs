using Microsoft.Win32;
using MinecraftBlockColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BlockColor
{

    public partial class MainWindow : Window
    {

        public static string ImagePath;
        public static string FolderPath;

        public MainWindow()
        {
            InitializeComponent();
            Uri fileUri = new Uri("/image-preview.png", UriKind.Relative);
            image.Source = new BitmapImage(fileUri);
        }

        public void Image_Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog ofdImage = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".png",
                Filter = "Image (.png)|*.png"
            };
            if (ofdImage.ShowDialog() == true)
            {
                ButtonImageText.Content = ofdImage.FileName;
                ImagePath = ofdImage.FileName;
                Uri fileUri = new Uri(ofdImage.FileName);
                image.Source = new BitmapImage(fileUri);
            }
        }

        public void Folder_Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            if (dialog.ShowDialog(this).GetValueOrDefault())
            {
                FolderPath = dialog.SelectedPath;
                ButtonFolderText.Content = FolderPath;
            }
        }
        
        public void Generate_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ImagePath != null || FolderPath != null)
            {
                Program.GeneratePixelArt(ImagePath, FolderPath);    
            }
            else
                System.Windows.MessageBox.Show("Please select an image and a folder");
        }
    }
}
