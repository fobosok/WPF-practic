using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Windows.Forms;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void browse_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowDialog();
            string folder_name = fbd.SelectedPath;
            DirectoryInfo di = new DirectoryInfo(folder_name);
            foreach(var fi in di.GetFiles())
            {

                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(fi.FullName);
                bi.EndInit();
                listbox.Items.Add(new Class1() { Path=bi, full_name=fi.FullName});
            }
        }
       
        private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            image1.Source = new BitmapImage(new Uri((listbox.SelectedItem as Class1).full_name));
        }

    }
}
