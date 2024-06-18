using CryptoSystem.CesarCipher;
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

namespace CryptoSystem.TritemiusCipher
{

	public partial class TritemiusMain : Window
	{
		public TritemiusMain()
		{
			InitializeComponent();
			ComboBox.SelectedIndex = 0;
			UK.IsChecked = true;

		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			int selectedIndex = ComboBox.SelectedIndex;

			
			if (selectedIndex == 0)
			{
				TextBox1.Visibility = Visibility.Visible;
				TextBox2.Visibility = Visibility.Visible;
				TextBox3.Visibility = Visibility.Collapsed;
			}
			else if (selectedIndex == 1)
			{
				TextBox1.Visibility = Visibility.Visible;
				TextBox2.Visibility = Visibility.Visible;
				TextBox3.Visibility = Visibility.Visible;
			}
			else if (selectedIndex == 2)
			{
				TextBox1.Visibility = Visibility.Collapsed;
				TextBox2.Visibility = Visibility.Collapsed;
				TextBox3.Visibility = Visibility.Collapsed;
				TextBox4.Visibility = Visibility.Visible;
			}
		}
		//-------------------------------------------------------------------------------------//
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


		//--------------------------------------------------------------------------------------------------------------------//

		private void EncryptButton_Click(object sender, RoutedEventArgs e)
		{
			int selectedIndex = ComboBox.SelectedIndex;

			string A = TextBox1.Text;
			string B = TextBox2.Text;
			string C = TextBox3.Text;
			string gaslo = TextBox4.Text;

			string InMessage = textBoxForCipher.Text;
			bool isUkrainianAlphabet = UK.IsChecked == true;

			TrithemiusCipher cipher = new TrithemiusCipher(isUkrainianAlphabet);


			bool isKeyValid1 = cipher.isValidateKeyCoeff(A);
			bool isKeyValid2 = cipher.isValidateKeyCoeff(B);
			bool isKeyValid3 = cipher.isValidateKeyCoeff(C);

			bool isGasloValid = cipher.IsValidateKeyGaslo(gaslo);

			bool inMessageValid = cipher.IsValidateIn(InMessage);


			if (!inMessageValid)
			{
				MessageBox.Show("Неправильне вхідне повідомлення! Використання символів яких НЕМАЄ у алфавіті!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			int a, b, c;

			if (selectedIndex == 0)
			{
				 

				if (!isKeyValid1 || !isKeyValid2)
				{
					MessageBox.Show("Ключ невідповідний!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				

				bool isa = int.TryParse(A, out a);
				bool isb= int.TryParse(B, out b);

				int[] linearCoefficients = { a, b };

				cipher.linearCoefficients = linearCoefficients;

			}
			else if (selectedIndex == 1) 
			{
				
				if (!isKeyValid1 || !isKeyValid2 || !isKeyValid3)
				{
					MessageBox.Show("Ключ невідповідний!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				bool isa = int.TryParse(A, out a);
				bool isb = int.TryParse(B, out b);
				bool isc = int.TryParse(C, out c);

				int[] nonLinearCoefficients = { a, b, c };
				cipher.nonLinearCoefficients = nonLinearCoefficients;
			}
			else if (selectedIndex == 2)
			{

				if (!isGasloValid)
				{
					MessageBox.Show("Ключ невідповідний!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				cipher.key = gaslo;
			}

			

			string encryptedMessage = cipher.Encrypt(InMessage);

			
			textBoxForDeCipher.Text = encryptedMessage;
		}

		private void DecryptButton_Click(object sender, RoutedEventArgs e)
		{
			int selectedIndex = ComboBox.SelectedIndex;

			string A = TextBox1.Text;
			string B = TextBox2.Text;
			string C = TextBox3.Text;
			string gaslo = TextBox4.Text;

			string InMessage = textBoxForCipher.Text;
			bool isUkrainianAlphabet = UK.IsChecked == true;

			TrithemiusCipher cipher = new TrithemiusCipher(isUkrainianAlphabet);

			bool isKeyValid1 = cipher.isValidateKeyCoeff(A);
			bool isKeyValid2 = cipher.isValidateKeyCoeff(B);
			bool isKeyValid3 = cipher.isValidateKeyCoeff(C);
			bool isGasloValid = cipher.IsValidateKeyGaslo(gaslo);
			bool inMessageValid = cipher.IsValidateIn(InMessage);

			if (!inMessageValid)
			{
				MessageBox.Show("Неправильне вхідне повідомлення! Використання символів, яких НЕМАЄ у алфавіті!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}

			int a, b, c;

			if (selectedIndex == 0)
			{
				if (!isKeyValid1 || !isKeyValid2)
				{
					MessageBox.Show("Ключ невідповідний!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				bool isa = int.TryParse(A, out a);
				bool isb = int.TryParse(B, out b);

				int[] linearCoefficients = { a, b };
				cipher.linearCoefficients = linearCoefficients;
			}
			else if (selectedIndex == 1)
			{
				if (!isKeyValid1 || !isKeyValid2 || !isKeyValid3)
				{
					MessageBox.Show("Ключ невідповідний!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				bool isa = int.TryParse(A, out a);
				bool isb = int.TryParse(B, out b);
				bool isc = int.TryParse(C, out c);

				int[] nonLinearCoefficients = { a, b, c };
				cipher.nonLinearCoefficients = nonLinearCoefficients;
			}
			else if (selectedIndex == 2)
			{
				if (!isGasloValid)
				{
					MessageBox.Show("Ключ невідповідний!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

				cipher.key = gaslo;
			}

			string decryptedMessage = cipher.Decrypt(InMessage);

			textBoxForDeCipher.Text = decryptedMessage;
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
			var attackWindow = new TrithemiusAttack();
			attackWindow.Show();

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

		
	}


}

