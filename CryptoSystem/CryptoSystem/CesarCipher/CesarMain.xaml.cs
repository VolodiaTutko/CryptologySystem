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

namespace CryptoSystem.CesarCipher
{
  public partial class CesarMain : Window
    {
        public CesarMain()
        {
            InitializeComponent();
			UK.IsChecked = true;
		}

		private void CreateFile_Click(object sender, RoutedEventArgs e)
		{
			if (UK.IsChecked == true)
			{
				textBoxForCipher.Text = "Текст...";
			}
			else
			{
				textBoxForCipher.Text = "Text...";
			}

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

		private void EncryptButton_Click(object sender, RoutedEventArgs e)
		{
			string key = keyBox.Text;
			string plaintext = textBoxForCipher.Text;
			int shift;

			if (!int.TryParse(key, out shift))
			{
				MessageBox.Show("Ключ повинен бути цілим числом.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			bool isUkrainianAlphabet = UK.IsChecked == true;

			SymmetricCipher cipher = new SymmetricCipher(isUkrainianAlphabet: isUkrainianAlphabet);

			if (cipher.ValidateKey(key, isUkrainianAlphabet))
			{
				string ciphertext = cipher.Encrypt(plaintext, shift);
				textBoxForDeCipher.Text = ciphertext;
			}
			else
			{
				MessageBox.Show("Невірний ключ. Ключ повинен бути цілим числом!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void DecryptButton_Click(object sender, RoutedEventArgs e)
		{
			string key = keyBox.Text;
			string ciphertext = textBoxForCipher.Text;
			int shift;

			if (!int.TryParse(key, out shift))
			{
				MessageBox.Show("Ключ повинен бути цілим числом.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			bool isUkrainianAlphabet = UK.IsChecked == true;

			SymmetricCipher cipher = new SymmetricCipher(isUkrainianAlphabet: isUkrainianAlphabet);

			if (cipher.ValidateKey(key, isUkrainianAlphabet))
			{
				string decryptedText = cipher.Decrypt(ciphertext, shift);
				textBoxForDeCipher.Text = decryptedText;
			}
			else
			{
				MessageBox.Show("Невірний ключ. Ключ повинен бути цілим числом < за розмір вхідного алфавіту!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
			}
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

		private void Atack_Click(object sender, RoutedEventArgs e)
		{
			bool isUkrainianAlphabet = UK.IsChecked == true;
			string inputText = textBoxForCipher.Text;
			var attackWindow = new Attack(inputText, isUkrainianAlphabet);
			attackWindow.ShowDialog();

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

		private void Premium_Click(object sender, RoutedEventArgs e)
		{

			var premiumWindow = new Premium();
			premiumWindow.ShowDialog();
		}



	}
	public class FrequencyItem
	{
		public char Symbol { get; set; }
		public int Frequency { get; set; }
	}




	public class SymmetricCipher
	{
		private string alphabet;

		public SymmetricCipher(bool isUkrainianAlphabet)
		{
			alphabet = isUkrainianAlphabet
			? "абвгґдеєжзиіїйклмнопрстуфхцчшщьюяАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ0123456789!@#$%^&*()_+-="
			: "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=";
		}

		public bool ValidateKey(string key, bool isUkrainianAlphabet)
		{

			alphabet = isUkrainianAlphabet
			  ? "абвгґдеєжзиіїйклмнопрстуфхцчшщьюяАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ0123456789!@#$%^&*()_+-="
			  : "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=";

			int maxKey = alphabet.Length - 1;

			return int.TryParse(key, out int keyAsInt) && keyAsInt >= 0 && keyAsInt <= maxKey;
		}

		public string Encrypt(string input, int shift)
		{
			StringBuilder result = new StringBuilder();

			foreach (char symbol in input)
			{
				int position = alphabet.IndexOf(symbol);

				if (position == -1)
				{
					result.Append(symbol);
				}
				else
				{
					int shiftedPosition = position + shift;
					if (shiftedPosition < 0)
					{
						shiftedPosition += alphabet.Length;
					}

					char shiftedSymbol = alphabet[shiftedPosition];
					result.Append(shiftedSymbol);
				}
			}

			return result.ToString();
		}

		public string Decrypt(string input, int shift)
		{
			return Encrypt(input, -shift);
		}
	}
}
