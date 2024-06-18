using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSystem.TritemiusCipher
{
	public class TrithemiusCipher
	{
		private string alphabet;
		public string key;
		public int[] linearCoefficients; //                 k = Ap + B; 
		public int[] nonLinearCoefficients; //        k = Ap^2 + Bp + C 

		public TrithemiusCipher(bool isUkrainianAlphabet, string key = null, int[] linearCoefficients = null, int[] nonLinearCoefficients = null)
		{
			this.alphabet = isUkrainianAlphabet
				? "абвгґдеєжзиіїйклмнопрстуфхцчшщьюяАБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ0123456789!@#$%^&*()_+-=,: "
				: "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=,: ";

			this.key = key;
			this.linearCoefficients = linearCoefficients;
			this.nonLinearCoefficients = nonLinearCoefficients;

		
		}

		public string Encrypt(string message)
		{
			StringBuilder encryptedMessage = new StringBuilder();

			for (int i = 0; i < message.Length; i++)
			{
				char encryptedChar = EncryptChar(message[i], i);
				encryptedMessage.Append(encryptedChar);
			}

			return encryptedMessage.ToString();
		}

		public string Decrypt(string encryptedMessage)
		{
			StringBuilder decryptedMessage = new StringBuilder();

			for (int i = 0; i < encryptedMessage.Length; i++)
			{
				char decryptedChar = DecryptChar(encryptedMessage[i], i);
				decryptedMessage.Append(decryptedChar);
			}

			return decryptedMessage.ToString();
		}

		private char EncryptChar(char c, int position)
		{
			int shift;

			if (linearCoefficients != null && linearCoefficients.Length == 2)
			{
				shift = linearCoefficients[0] * position + linearCoefficients[1];
			}
			else if (nonLinearCoefficients != null && nonLinearCoefficients.Length == 3)
			{
				shift = nonLinearCoefficients[0] * position * position + nonLinearCoefficients[1] * position + nonLinearCoefficients[2];
			}
			else
			{
				int keyIndex = position % key.Length;
				int keyCharIndex = alphabet.IndexOf(key[keyIndex]);
				shift = keyCharIndex;
			}

			while (shift < 0)
			{
				shift += alphabet.Length;
			}

			
			int encryptedIndex = (alphabet.IndexOf(c) + shift) % alphabet.Length;
			if (encryptedIndex < 0)
			{
				encryptedIndex += alphabet.Length;
			}

			return alphabet[encryptedIndex];
		}

		private char DecryptChar(char c, int position)
		{
			int shift;

			if (linearCoefficients != null && linearCoefficients.Length == 2)
			{
				shift = linearCoefficients[0] * position + linearCoefficients[1];
			}
			else if (nonLinearCoefficients != null && nonLinearCoefficients.Length == 3)
			{
				shift = nonLinearCoefficients[0] * position * position + nonLinearCoefficients[1] * position + nonLinearCoefficients[2];
			}
			else
			{
				int keyIndex = position % key.Length;
				int keyCharIndex = alphabet.IndexOf(key[keyIndex]);
				shift = keyCharIndex;
			}

			while (shift < 0)
			{
				shift += alphabet.Length;
			}

			int decryptedIndex = (alphabet.IndexOf(c) - shift + alphabet.Length) % alphabet.Length;

			
			decryptedIndex = (decryptedIndex + alphabet.Length) % alphabet.Length;

			return alphabet[decryptedIndex];
		}
		public bool isValidateKeyCoeff(string key)
		{
			
			int intValue;
			bool isValid = int.TryParse(key, out intValue);

			return isValid;
		}

		public bool IsValidateKeyGaslo(string key)
		{
			
			HashSet<char> alphabetSet = new HashSet<char>(alphabet);

			foreach (char c in key)
			{
				if (!alphabetSet.Contains(c))
				{
					return false;
				}
			}
			return true;
		}

		public bool IsValidateIn(string inputMessage)
		{

			HashSet<char> alphabetSet = new HashSet<char>(alphabet);

			foreach (char c in inputMessage)
			{
				if (!alphabetSet.Contains(c))
				{
					return false;
				}
			}
			return true;
		}

		public bool IsValidateOut(string decodeMessage)
		{

			HashSet<char> alphabetSet = new HashSet<char>(alphabet);

			foreach (char c in decodeMessage)
			{
				if (!alphabetSet.Contains(c))
				{
					return false;
				}
			}
			return true;
		}

	}


}
