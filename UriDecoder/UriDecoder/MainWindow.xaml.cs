using System;
using System.Windows;

namespace UriDecoder {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btnDecode_Click(object sender, RoutedEventArgs e) {
            if (txtEncodedUri.Text.Length > 0) {
                try {
                    string uriString = txtEncodedUri.Text;
                    string decoded = System.Web.HttpUtility.UrlDecode(uriString);

                    if (chkUnescapeUnicode.IsChecked.HasValue && chkUnescapeUnicode.IsChecked.Value) {
                        decoded = System.Text.RegularExpressions.Regex.Unescape(decoded);
                    }

                    txtDecodedUri.Text = decoded;
                }
                catch (Exception ex) {
                    txtDecodedUri.Text = "[Error] - " + ex.Message;
                }
                
            }
        }
    }
}
