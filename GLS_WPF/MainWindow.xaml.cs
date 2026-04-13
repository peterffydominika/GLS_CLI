using GLS_CLI;
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

namespace GLS_WPF {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Program.Beolvas();
            dtgAdatok.ItemsSource = Program.autoAdatok;
        }

        private void btnFelvisz_Click(object sender, RoutedEventArgs e) {
            if (!Program.autoAdatok.Any(x => x.Datum == DateTime.Parse(tbxDatum.Text)))
            {
                Program.autoAdatok.Add(new AutoAdatok($"{tbxDatum.Text};{tbxNev.Text};{tbxKm.Text};{tbxCsomagok.Text};{tbxFogyasztas.Text}"));

                dtgAdatok.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Már van ilyen dátumú adat!");
            }
        }

        private void BtnModositas_Click(object sender, RoutedEventArgs e) {

        }

        private void BtnMentes_Click(object sender, RoutedEventArgs e) {

        }
    }
}