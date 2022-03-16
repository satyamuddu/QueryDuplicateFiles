using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfAppTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IEnumerable<IEnumerable<string>>[] fileByNameAndLength;

        public MainWindow()
        {
            InitializeComponent();
            this.fileCollection.Clear();
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            this.fileCollection.Clear();
            
            //QueryDuplicateFiles.QueryDuplicateFiles.startFolder = @"D:\toganesh";
            //QueryDuplicateFiles.QueryDuplicateFiles.extension = "jpg";

            //foreach (var x in QueryDuplicateFiles.QueryDuplicateFiles.QueryDuplicatesByFileNameAndLength())
            //{
            //    foreach (var y in x)
            //    {
            //        foreach (var z in y)
            //        {
            //            Console.WriteLine(z);
            //            Thumbnails.Items.Add(new BitmapImage(new Uri(QueryDuplicateFiles.QueryDuplicateFiles.startFolder+z)));
            //        }
            //    }
            //}


        }

        private void browse_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            fbd.ShowDialog();
            directory.Text = fbd.SelectedPath;
        }

        private void Label_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void load_Click(object sender, RoutedEventArgs e)
        {

            QueryDuplicateFiles.QueryDuplicateFiles.startFolder = directory.Text;
            QueryDuplicateFiles.QueryDuplicateFiles.extension = "*.jpg";
            fileByNameAndLength = QueryDuplicateFiles.QueryDuplicateFiles.QueryDuplicatesByFileNameAndLength().ToArray();

            foreach (var x in fileByNameAndLength)
            {
                foreach (var y in x)
                {
                    this.fileCollection.Clear();
                    this.fileCollection = new Avalon.Demo.FileCollection(y.ToArray());
                    this.mylistView.ItemsSource = this.fileCollection;

                    //foreach (var z in y)
                    //{
                    //    Console.WriteLine(z);
                    //}
                }
            }

        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            this.fileCollection.Clear();

        }
    }
}
