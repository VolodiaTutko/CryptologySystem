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
	public partial class Premium : Window
	{

		private string _XMLData;
		private string _XMLCryptoData;
		private string _XMLDeCryptoData;
		public Premium()
		{
			InitializeComponent();
		}

		private void OpenFile_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			//openFileDialog.Filter = "XML Files (*.xml)|*.xml|(*.txt)|*.txt|All Files (*.*)|*.*";

			if (openFileDialog.ShowDialog() == true)
			{
				string filePath = openFileDialog.FileName;

				try
				{
					using (StreamReader reader = new StreamReader(filePath))
					{
						string fileContent = reader.ReadToEnd();
						_XMLData = fileContent;
						MessageBox.Show("Файл успішно відкрито.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Помилка відкриття файлу: {ex.Message}");
				}
			}
		}

		private void SaveCryptoFile_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			//saveFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";

			if (saveFileDialog.ShowDialog() == true)
			{
				string filePath = saveFileDialog.FileName;

				try
				{
					using (StreamWriter writer = new StreamWriter(filePath))
					{

						writer.Write(_XMLCryptoData);
						MessageBox.Show("XML файл успішно збережено.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Помилка збереження файлу: {ex.Message}");
				}
			}
		}
		private void SaveDeCryptoFile_Click(object sender, RoutedEventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";

			if (saveFileDialog.ShowDialog() == true)
			{
				string filePath = saveFileDialog.FileName;

				try
				{
					using (StreamWriter writer = new StreamWriter(filePath))
					{

						writer.Write(_XMLDeCryptoData);
						MessageBox.Show("XML файл успішно збережено.");
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show($"Помилка збереження файлу: {ex.Message}");
				}
			}
		}
		private void Encrypt_Click(object sender, RoutedEventArgs e)
		{

			string inputText = _XMLData;

			var cipher = new XmlSymmetricCipher(false);


			string key = keyBox.Text;

			if (cipher.ValidateKey(key, isUkrainianAlphabet: false))
			{
				int shift = int.Parse(key);


				string encryptedText = cipher.EncryptXml(inputText, shift);


				_XMLCryptoData = encryptedText;
				MessageBox.Show("XML файл успішно зашифровано.");
			}
			else
			{
				MessageBox.Show("Invalid key. Please enter a valid numeric key.");
			}
		}

		private void Decrypt_Click(object sender, RoutedEventArgs e)
		{
			string inputText = _XMLData;

			var cipher = new XmlSymmetricCipher(false);


			string key = keyBox.Text;

			if (cipher.ValidateKey(key, isUkrainianAlphabet: false))
			{
				int shift = int.Parse(key);


				string decryptedText = cipher.DecryptXml(inputText, shift);


				_XMLDeCryptoData = decryptedText;
				MessageBox.Show("XML файл успішно розшифровано.");
			}
			else
			{
				MessageBox.Show("Invalid key. Please enter a valid numeric key.");
			}
		}



	}

	public class XmlSymmetricCipher
	{
		private string alphabet;

		public XmlSymmetricCipher(bool isUkrainianAlphabet)
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

		public string EncryptXml(string xmlInput, int shift)
		{
			StringBuilder result = new StringBuilder();

			foreach (char symbol in xmlInput)
			{
				int position = alphabet.IndexOf(symbol);

				if (position == -1)
				{
					result.Append(symbol);
				}
				else
				{
					int shiftedPosition = (position + shift) % alphabet.Length;

					char shiftedSymbol = alphabet[shiftedPosition];
					result.Append(shiftedSymbol);
				}
			}

			return result.ToString();
		}

		public string DecryptXml(string encryptedXmlInput, int shift)
		{
			return EncryptXml(encryptedXmlInput, -shift);
		}
	}
}
