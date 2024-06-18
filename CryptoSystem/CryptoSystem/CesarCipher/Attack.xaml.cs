using System;
using System.Collections.Generic;
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
	public partial class Attack : Window
	{

		private string _alphabet;
		private string _inputText;
		private bool _isUkrainianAlphabet;
		public Attack(string inputText, bool isUkrainianAlphabet)
		{
			InitializeComponent();
			_alphabet = isUkrainianAlphabet
					? "абвгґдеєжзиіїйклмнопрстуфхцчшщьюяАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ0123456789!@#$%^&*()_+-="
					: "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=";
			_inputText = inputText;

			_isUkrainianAlphabet = isUkrainianAlphabet;


		}

		private string Decrypt(string input, int shift)
		{

			StringBuilder result = new StringBuilder();

			foreach (char symbol in input)
			{
				int position = _alphabet.IndexOf(symbol);

				if (position == -1)
				{
					result.Append(symbol);
				}
				else
				{
					int shiftedPosition = (position - shift + _alphabet.Length) % _alphabet.Length;
					if (shiftedPosition < 0)
					{
						shiftedPosition += _alphabet.Length;
					}

					result.Append(_alphabet[shiftedPosition]);
				}
			}

			return result.ToString();
		}



		private void Attacka(object sender, RoutedEventArgs e)
		{
			if (!string.IsNullOrEmpty(_inputText))
			{
				StringBuilder results = new StringBuilder();


				int possibleKeys = _alphabet.Length;

				for (int i = 0; i < possibleKeys; i++)
				{
					string decryptedText = Decrypt(_inputText, i);
					results.AppendLine($"Key: {i}, Decrypted Text: {decryptedText}");
				}

				attackBox.Text = results.ToString();
			}
			else
			{
				MessageBox.Show("Please enter encrypted text first.");
			}
		}
		private void ModifyAttacka(object sender, RoutedEventArgs e)
		{
			string key1 = value1.Text;
			string key2 = value2.Text;

			if (ValidateKey(key1, _isUkrainianAlphabet) && ValidateKey(key2, _isUkrainianAlphabet))
			{
				int key1AsInt = int.Parse(key1);
				int key2AsInt = int.Parse(key2);

				if (!string.IsNullOrEmpty(_inputText))
				{
					StringBuilder results = new StringBuilder();




					for (int i = key1AsInt; i < key2AsInt; i++)
					{
						string decryptedText = Decrypt(_inputText, i);
						results.AppendLine($"Key: {i}, Decrypted Text: {decryptedText}");
					}

					attackBox.Text = results.ToString();
				}
				else
				{
					MessageBox.Show("Please enter encrypted text first.");
				}


			}
			else
			{
				MessageBox.Show("Please enter both keys first.");
			}
		}

		public bool ValidateKey(string key, bool isUkrainianAlphabet)
		{

			_alphabet = isUkrainianAlphabet
			  ? "абвгґдеєжзиіїйклмнопрстуфхцчшщьюяАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ0123456789!@#$%^&*()_+-="
			  : "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=";

			int maxKey = _alphabet.Length - 1;

			return int.TryParse(key, out int keyAsInt) && keyAsInt >= 0 && keyAsInt <= maxKey;
		}
	}



}
