using CryptoSystem.CesarCipher;
using CryptoSystem.DiffiHelman;
using CryptoSystem.GamaCipher;
using CryptoSystem.KnapsackProblem;
using CryptoSystem.TritemiusCipher;
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
using CryptoSystem.RSA;

namespace CryptoSystem
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void CesarClick(object sender, RoutedEventArgs e)
		{
			var cesarLab = new CesarMain();
			cesarLab.ShowDialog();
		}


		private void TritemiusClick(object sender, RoutedEventArgs e)
		{
			var tritemiusrLab = new TritemiusMain();
			tritemiusrLab.ShowDialog();
		}
        private void GammaClick(object sender, RoutedEventArgs e)
        {
            var gammaLab = new GammaMainWindow();
            gammaLab.ShowDialog();
        }

        private void KnapsackProblem_Click(object sender, RoutedEventArgs e)
        {
            var knapsackLab = new KnapsackProblemMain();
            knapsackLab.ShowDialog();
        }

        private void openDiffiClick(object sender, RoutedEventArgs e)
        {
            var diffiHelman = new DiffiHelmanMain();
            diffiHelman.ShowDialog();
        }

        private void openRSA_Click(object sender, RoutedEventArgs e)
        {
            var rsaWindow = new RSA_Main();
            rsaWindow.ShowDialog();
        }
    }
}