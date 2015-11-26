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
using Microsoft.Win32;
using System.IO;

namespace SimpleNotepadApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
       
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.DefaultExt = ".txt";
            filedialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
 
                filedialog.ShowDialog();
                StreamReader reader = new StreamReader(filedialog.FileName);
                if (textarea.Text!=string.Empty)
                {
                    textarea.Text = "";
                }
                textarea.Text = reader.ReadToEnd();
                reader.Close();
                
             
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.Filter="Text files (*.txt)|*.txt|All files (*.*)|*.*";
            savedialog.ShowDialog();
          /*  if (savedialog.OverwritePrompt == true)
            {
                MessageBox.Show("File already exists");
            }*/
            //if(savedialog.FileName)
            StreamWriter writer = new StreamWriter(savedialog.FileName);
            writer.Write(textarea.Text);
            writer.Close();

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);

        }
    }
}
