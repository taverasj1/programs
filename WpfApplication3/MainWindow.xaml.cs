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

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        public class MyImage
        {
            private ImageSource _image;
            private string _name;

            public MyImage(ImageSource image, string name)
            {
                _image = image;
                _name = name;
            }

            public override string ToString()
            {
                return _name;
            }

            public ImageSource Image
            {
                get { return _image; }
            }

            public string Name
            {
                get { return _name; }
            }
        }
        public List<MyImage> GetImage
        {
            get
            {
                List<MyImage> result = new List<MyImage>();
                foreach (string filename in
                   System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)))
                {
                    try
                    {
                        result.Add(new MyImage(new BitmapImage(new Uri(filename)), System.IO.Path.GetFileNameWithoutExtension(filename)));
                    }
                    catch { }
                }
                return result;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Open file box.
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();  
            dlg.FileName = "Image";
            dlg.DefaultExt = ".png";
            dlg.Filter ="Images (.png)|*.Png";
            // Result handling when opening a document
            if(dlg.ShowDialog() == true)
            {
                string filenames = dlg.FileName;
                //display path in textbox
                pathBox.Text = filenames;
                //save to image
                imageBox.Source = new BitmapImage(new Uri(filenames, UriKind.Absolute));  
            }
        }  
    }
}
