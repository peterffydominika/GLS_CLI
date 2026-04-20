using GLS_CLI;
using Microsoft.Win32;
using System.IO;
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
            if (!Validator())
            {
                MessageBox.Show("Hibás vagy hiányzó adatok!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
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
            
        }

        private void BtnModositas_Click(object sender, RoutedEventArgs e) {
            if (!Validator())
            {
                MessageBox.Show("Hibás vagy hiányzó adatok!","Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                Program.autoAdatok[dtgAdatok.SelectedIndex].Modosito(new AutoAdatok($"{tbxDatum.Text};{tbxNev.Text};{tbxKm.Text};{tbxCsomagok.Text};{tbxFogyasztas.Text}"));
                dtgAdatok.Items.Refresh();
            }
        }
        private bool Validator()
        {
            if(tbxNev.Text == "" || tbxDatum.Text == "" || tbxKm.Text == "" || tbxCsomagok.Text == "" || tbxFogyasztas.Text == "")
            {
                return false;
            }
            DateTime tesztDatum;
            if (!DateTime.TryParse(tbxDatum.Text, out tesztDatum))
            {
                return false;
            }
            if(int.Parse(tbxCsomagok.Text) <= 0 || int.Parse(tbxKm.Text) <= 0 || int.Parse(tbxFogyasztas.Text) <= 0)
            {
                return false;
            }
            return true;
        }

        private void BtnMentes_Click(object sender, RoutedEventArgs e) {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.FileName = "gls.txt";
                if (sfd.ShowDialog() == true)
                {
                    StreamWriter sw = new StreamWriter(sfd.FileName);
                    foreach (AutoAdatok auto in Program.autoAdatok)
                    {
                        sw.WriteLine($"{auto.Datum};{auto.SoforNev};{auto.NapiKilometer};{auto.KezbesitettCsomagokSzama};{auto.NapiFogyasztas}");
                    }
                    sw.Close();
                }
                MessageBox.Show("Sikeres mentés!", "", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgAdatok_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            tbxDatum.Text = Program.autoAdatok[dtgAdatok.SelectedIndex].Datum.ToString();
            tbxNev.Text = Program.autoAdatok[dtgAdatok.SelectedIndex].SoforNev.ToString();
            tbxKm.Text = Program.autoAdatok[dtgAdatok.SelectedIndex].NapiKilometer.ToString();
            tbxCsomagok.Text = Program.autoAdatok[dtgAdatok.SelectedIndex].KezbesitettCsomagokSzama.ToString();
            tbxFogyasztas.Text = Program.autoAdatok[dtgAdatok.SelectedIndex].NapiFogyasztas.ToString();
        }
    }
}