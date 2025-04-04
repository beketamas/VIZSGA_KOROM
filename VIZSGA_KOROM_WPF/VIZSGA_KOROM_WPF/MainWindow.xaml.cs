using Microsoft.Win32;
using System.Collections.ObjectModel;
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
using VIZSGA_KOROM.Models;

namespace VIZSGA_KOROM_WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        List<Auto> autok = [];
        btnBetolt.Click += (s, e) => 
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true && s is Button)
            {
                try
                {
                    autok = Auto.ReadCSV(openFileDialog.FileName);
                    dgAutok.ItemsSource = autok;

                }
                catch (Exception n)
                {

                    MessageBox.Show($"Hiba: {n}", "!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        };
        tbEv.TextChanged += (s, e) =>
        {
            if (s is TextBox mezo)
                lbAutok.ItemsSource = autok.Where(x => x.GyartasiEv == mezo.Text).Select(y => $"{y.Marka} {y.Model}").ToList();
        };
        btnBezar.Click += (s, e) =>
        {
            if (s is Button)
            {
                var valasz = MessageBox.Show("Bizots ki akar lépni?", "?" , MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (valasz == MessageBoxResult.Yes)
                    Close();

                return;
                
            }
        };
    }
}