using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace Mic.Volo.WpfDownloader
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
        WebClient _client;
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            using (var client = new WebClient())
            {
                BtnDown.IsEnabled = false;
                TextOut.Text = string.Empty;
                try
                {
                    var address = new Uri(SearchS.Text);

                    string result = client.DownloadString(address);

                    //Task<string> downloadTask = client.DownloadStringTaskAsync(address);
                    TextOut.Text = result;
                    //TextOut.Text = "Downloading...";

                    //string result = awa

                    //TextOut.Text = new string(result.Take(200).ToArray());
                }
                catch (UriFormatException)
                {
                    TextOut.Text = "Invalid URL";
                }
                catch (WebException exception)
                {
                    TextOut.Text = exception.Message;
                }
                catch (NotSupportedException exception)
                {
                    TextOut.Text = exception.Message;
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    BtnDown.IsEnabled = true;
                }
            }
        }
        private async Task<double> CalculateAsync(int n)
        {
            Func<double> func = () =>
            {
                var result = Enumerable.Range(0, n).Select(i => Math.Sin(i)).Sum();

                return result;
            };

            Task<double> task = Task.Factory.StartNew<double>(func);

            return await task;
        }

        private void AddLineClick(object sender, RoutedEventArgs e)
        {
            TextBox textbox = new TextBox();
            


        }

        private void btnDwS_Click(object sender, RoutedEventArgs e)
        {
            string url = TextURLS.Text;
            if(!string.IsNullOrEmpty(url))
            {
                Thread thread = new Thread(() =>
                  {
                      Uri uri = new Uri(url);
                      string filename = System.IO.Path.GetFileName(uri.AbsolutePath);
                      _client.DownloadFileAsync(uri, filename);
                  });
            }
        }
    }
}
