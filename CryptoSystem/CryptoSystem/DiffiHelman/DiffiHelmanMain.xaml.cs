using DiffiHelman;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CryptoSystem.DiffiHelman
{
 
    public partial class DiffiHelmanMain : Window
    {

        public DiffieHellman _user;
        public DiffiHelmanMain()
        {
            InitializeComponent();
            _user = new DiffieHellman();
        }


        private void PublicKeyClick(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show("Ok");
                _user._prime = BigInteger.Parse(textP.Text);
                _user._generator = BigInteger.Parse(textG.Text);
                _user._privateKey = BigInteger.Parse(textPrivateKey.Text);

                _user.CalcPublicKey(_user._privateKey);
                textPublicKeyUser.Text = _user.CalcPublicKey(_user._privateKey).ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Переконайтеся, що всі поля заповнені правильними числовими значеннями.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void SecretKeyClick(object sender, RoutedEventArgs e)
        {
            try
            {
                BigInteger otherPublicKey = BigInteger.Parse(textPublicKeyOther.Text);
                BigInteger secretKey = _user.GenerateSharedSecret(otherPublicKey);
                textKey.Text = secretKey.ToString();
            }
            catch (FormatException)
            {
                MessageBox.Show("Будь ласка, введіть правильне числове значення для публічного ключа іншого користувача.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}
