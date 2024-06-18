using CryptoSystem.CesarCipher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

	
	public partial class TrithemiusAttack : Window
	{
		private string _alphabet;
		private bool _isUkrainianAlphabet;
		public TrithemiusAttack()
		{
			InitializeComponent();

			UK.IsChecked = true;

			bool isUkrainianAlphabet = UK.IsChecked == true;

			_isUkrainianAlphabet = isUkrainianAlphabet;

			_alphabet = isUkrainianAlphabet
					? "абвгґдеєжзиіїйклмнопрстуфхцчшщьюяАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ0123456789!@#$%^&*()_+-= ,"
					: "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-= ,";
		}

		private void Attacka(object sender, RoutedEventArgs e)
		{
			string originalMessage = NoCiepherBox.Text;
			string encryptedMessage = CiepherBox.Text;

			int selectedIndex = ComboBox.SelectedIndex;

			TrithemiusCipher cipher = new TrithemiusCipher(_isUkrainianAlphabet);

			if (selectedIndex == 0)
			{
				int[] linearCoefficients = { 0, 0 };
				cipher.linearCoefficients = linearCoefficients;

				for (int a = 0; a < 100; a++)
				{
					for (int b = 0; b < 100; b++)
					{
						cipher.linearCoefficients[0] = a;
						cipher.linearCoefficients[1] = b;

						string encrypted = cipher.Encrypt(originalMessage);

						if (encrypted == encryptedMessage)
						{
							MessageBox.Show($"Знайдено ймовірні коефіцієнти ключа :\nA = {a}, B = {b}");
							return;
						}
					}
				}
			}

			else if (selectedIndex == 1)
			{
				int[] nonLinearCoefficients = { 0, 0, 0 };
				cipher.nonLinearCoefficients = nonLinearCoefficients;

				for (int a = 0; a < 100; a++)
				{
					for (int b = 0; b < 100; b++)
					{
						for (int c = 0; c < 100; c++)
						{
							cipher.nonLinearCoefficients[0] = a;
							cipher.nonLinearCoefficients[1] = b;
							cipher.nonLinearCoefficients[2] = c;

							string encrypted = cipher.Encrypt(originalMessage);

							if (encrypted == encryptedMessage)
							{
								MessageBox.Show($"Знайдено ймовірні коефіцієнти ключа :\nA = {a}, B = {b}, C = {c}");
								return;
							}
						}
					}
				}
			}
			else if (selectedIndex == 2)
			{
				List<int> indexDifferences = new List<int>();

				for (int i = 0; i < originalMessage.Length; i++)
				{
					int originalIndex = _alphabet.IndexOf(originalMessage[i]);
					int encryptedIndex = _alphabet.IndexOf(encryptedMessage[i]);

					indexDifferences.Add(encryptedIndex - originalIndex);
				}

				if (indexDifferences.Count > 0)
				{
					StringBuilder gasloFinded = new StringBuilder();

					foreach (var difference in indexDifferences)
					{
						gasloFinded.Append(GetCharAtIndex(difference));
					}

					MessageBox.Show($"Знайдено гасло: {gasloFinded.ToString()}");

				}
				else
				{
					MessageBox.Show("Не вдалося знайти відповідне значення. Спробуйте інші варіанти.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}

		}
		private char GetCharAtIndex(int index)
		{
			if (index >= 0 && index < _alphabet.Length)
			{
				return _alphabet[index];
			}
			else
			{
				return '\0';
			}
		}

		public string AttackWithFrequencyTable(string encryptedMessage, List<FrequencyItem> frequencyTable)
		{
			
			frequencyTable = frequencyTable.OrderByDescending(item => item.Frequency).ToList();

			
			Dictionary<char, char> mapping = new Dictionary<char, char>();

			for (int i = 0; i < Math.Min(frequencyTable.Count, _alphabet.Length); i++)
			{
				mapping[frequencyTable[i].Symbol] = _alphabet[i];
			}

			
			string decryptedMessage = string.Empty;
			foreach (char c in encryptedMessage)
			{
				if (mapping.ContainsKey(c))
				{
					decryptedMessage += mapping[c];
				}
				else
				{
					decryptedMessage += c; 
				}
			}

			return decryptedMessage;
		}
	}


}



