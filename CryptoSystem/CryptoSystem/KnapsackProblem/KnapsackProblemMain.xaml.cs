using CryptoSystem.CesarCipher;
using CryptoSystem.GamaCipher;
using Microsoft.Win32;
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
using System.Windows.Shapes;

namespace CryptoSystem.KnapsackProblem
{
  
    public partial class KnapsackProblemMain : Window
    {
        private KnapsackProblem knapsackProblem;
        public KnapsackProblemMain()
        {
            InitializeComponent();

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
            string aboutMessage = "Це програма для криптографічного шифрування Трітеміуса.\n\n" +
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
        private void FrequanceTable_Click(object sender, RoutedEventArgs e)
        {
            string inputText = textBoxForCipher.Text;
            List<FrequencyItem> frequencyTable = BuildFrequencyTable(inputText);
            var tableWindow = new FreqTable(frequencyTable);
            tableWindow.ShowDialog();
        }

        private void FrequanceTable2_Click(object sender, RoutedEventArgs e)
        {
            string inputText = textBoxForDeCipher.Text;
            List<FrequencyItem> frequencyTable = BuildFrequencyTable(inputText);
            var tableWindow = new FreqTable(frequencyTable);
            tableWindow.ShowDialog();
        }



        public List<FrequencyItem> BuildFrequencyTable(string input)
        {
            Dictionary<char, int> frequencyDictionary = new Dictionary<char, int>();

            foreach (char symbol in input)
            {
                if (char.IsLetter(symbol))
                {
                    char lowerSymbol = char.ToLower(symbol);

                    if (frequencyDictionary.ContainsKey(lowerSymbol))
                    {
                        frequencyDictionary[lowerSymbol]++;
                    }
                    else
                    {
                        frequencyDictionary[lowerSymbol] = 1;
                    }
                }
            }


            List<FrequencyItem> frequencyList = frequencyDictionary
                .Select(kv => new FrequencyItem { Symbol = kv.Key, Frequency = kv.Value })
                .OrderByDescending(item => item.Frequency)
                .ToList();

            return frequencyList;
        }

		//--------------------------------------------------------------------------------------------------------------------//

		private void EncryptButton(object sender, RoutedEventArgs e)
		{
            string message = textBoxForCipher.Text;
            var knapsack = new KnapsackProblem(message);
            knapsackProblem = knapsack;
            knapsackProblem.GenerateKeys();
            int encryptedMessage = knapsackProblem.EncryptMessage(message);
            textBoxForDeCipher.Text = encryptedMessage.ToString();
        }

		private void DecryptButton(object sender, RoutedEventArgs e)
		{
            int encryptedMessage;
            if (int.TryParse(textBoxForCipher.Text, out encryptedMessage))
            {
                string decryptedMessage = knapsackProblem.DecryptMessage(encryptedMessage);
                textBoxForDeCipher.Text = decryptedMessage;
            }
            else
            {
                MessageBox.Show("Помилка при дешифруванні. Спробуйте ще раз.");
            }
        }

		private void Button_Click(object sender, RoutedEventArgs e)
		{

		}

		


	}
}
