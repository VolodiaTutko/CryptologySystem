using CryptoSystem.CesarCipher;
using Microsoft.Win32;
using RSA;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace CryptoSystem.RSA
{
    /// <summary>
    /// Interaction logic for RSA_Main.xaml
    /// </summary>
    public partial class RSA_Main : Window
    {
       public RSA_Ciepher rsa = new RSA_Ciepher();
        public RSA_Main()
        {
            InitializeComponent();
            textBoxForCipher.Text = "Текст...";

            rsa.GenerateKeys(1024);

            rsa.PublicKey = 6553;
            rsa.PrivateKey = rsa.CalcPrivateKey();

        }

        private void CreateFile_Click(object sender, RoutedEventArgs e)
        {           
            
                textBoxForCipher.Text = "Текст...";           

        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        string textToSave = textBoxForCipher.Text;
                        writer.Write(textToSave);
                        MessageBox.Show("Файл успішно збережено.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка збереження файлу: {ex.Message}");
                }
            }
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string fileContent = reader.ReadToEnd();
                        textBoxForCipher.Text = fileContent;
                        MessageBox.Show("Файл успішно відкрито.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка відкриття файлу: {ex.Message}");
                }
            }
        }

        private void PrintFile_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                FlowDocument document = new FlowDocument(new Paragraph(new Run(textBoxForCipher.Text)));
                document.PageWidth = printDialog.PrintableAreaWidth;
                document.PageHeight = printDialog.PrintableAreaHeight;

                printDialog.PrintDocument(((IDocumentPaginatorSource)document).DocumentPaginator, "Printing File");
            }
        }

        private void AboutDeveloper_Click(object sender, RoutedEventArgs e)
        {
            string aboutMessage = "Це програма для криптографічного шифрування шляхом зсуву.\n\n" +
                                  "Розроблена мною з любов'ю та удосконалено за допомогою WPF та C#.\n\n" +
                                  "Автор: Тутко Володимир Григорович, студент факультету прикладної математики \n" +
                                  "Спеціальність: Комп'ютерні науки \n" +
                                  "Середній бал іспитів минулого семестру: 89.8  \n" +
                                  "Версія: 1.0";

            MessageBox.Show(aboutMessage, "Про розробника", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        
        private void SaveFileAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        string textToSave = textBoxForDeCipher.Text;
                        writer.Write(textToSave);
                        MessageBox.Show("Файл успішно збережено.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка збереження файлу: {ex.Message}");
                }
            }
        }

        private void OwnKey_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string publicKeyText = publicKeyBox.Text;

                BigInteger publicKey = BigInteger.Parse(publicKeyText);

                rsa.GenerateKeys(1024);
                rsa.PublicKey = publicKey;

               
                if (rsa._phi != 0)
                {
                    rsa.PrivateKey = rsa.CalcPrivateKey();
                    MessageBox.Show("Public key set successfully.");
                }
                else
                {
                    MessageBox.Show("Error setting private key: phi value is 0.");
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Error setting public key: " + ex.Message);
            }
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string inputText = textBoxForCipher.Text;

               
                byte[] bytes = Encoding.UTF8.GetBytes(inputText);

                
                BigInteger message = new BigInteger(bytes);

                
                BigInteger encryptedMessage = rsa.Encrypt(message);

                
                textBoxForDeCipher.Text = encryptedMessage.ToString();
                textBoxForInfo.Clear();
                textBoxForInfo.AppendText("Public Key: " + rsa.PublicKey + "\n");
                textBoxForInfo.AppendText("Private Key: " + rsa.PrivateKey + "\n");
                textBoxForInfo.AppendText("N: " + rsa.N + "\n");
                
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Encryption failed: " + ex.Message);
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
               
                BigInteger encryptedMessage = BigInteger.Parse(textBoxForCipher.Text);

               
                BigInteger decryptedMessage = rsa.Decrypt(encryptedMessage);

               
                byte[] bytes = decryptedMessage.ToByteArray();
                string decryptedText = Encoding.UTF8.GetString(bytes);

                
                textBoxForDeCipher.Text = decryptedText;
                textBoxForInfo.Clear();
                textBoxForInfo.AppendText("Public Key: " + rsa.PublicKey + "\n");
                textBoxForInfo.AppendText("Private Key: " + rsa.PrivateKey + "\n");
                textBoxForInfo.AppendText("N: " + rsa.N + "\n");
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Decryption failed: " + ex.Message);
            }
        }
    }
}
