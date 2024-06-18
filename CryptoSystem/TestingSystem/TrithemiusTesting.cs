using CryptoSystem.TritemiusCipher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem
{
	public class TrithemiusTesting
	{
		[Theory]
		[InlineData(true, "пароль", new int[] { 1, 2 })]
		[InlineData(true, "Львів", new int[] { 1, 2, 3 })]
		[InlineData(true, "Володя")]
		public void EncryptAndDecrypt_ShouldReturnOriginalMessage(bool isUkrainianAlphabet, string key, int[] coefficients = null)
		{
			
			TrithemiusCipher cipher = new TrithemiusCipher(isUkrainianAlphabet, key, coefficients);
			string originalMessage = "Привіт, світ!";

			
			string encryptedMessage = cipher.Encrypt(originalMessage);
			string decryptedMessage = cipher.Decrypt(encryptedMessage);

			
			Assert.Equal(originalMessage, decryptedMessage);
		}

		[Theory]
		[InlineData(true, "пароль")]
		public void EncryptAndDecrypt_WithEmptyMessage_ShouldReturnEmptyMessage(bool isUkrainianAlphabet, string key)
		{
			
			TrithemiusCipher cipher = new TrithemiusCipher(isUkrainianAlphabet, key);
			string originalMessage = "";

			
			string encryptedMessage = cipher.Encrypt(originalMessage);
			string decryptedMessage = cipher.Decrypt(encryptedMessage);

			
			Assert.Equal(originalMessage, decryptedMessage);
		}

		[Theory]
		[InlineData(true, "пароль")]
		public void EncryptAndDecrypt_WithSingleCharacterMessage_ShouldReturnOriginalMessage(bool isUkrainianAlphabet, string key)
		{
			
			TrithemiusCipher cipher = new TrithemiusCipher(isUkrainianAlphabet, key);
			string originalMessage = "а";

			
			string encryptedMessage = cipher.Encrypt(originalMessage);
			string decryptedMessage = cipher.Decrypt(encryptedMessage);

			
			Assert.Equal(originalMessage, decryptedMessage);
		}

		[Theory]
		[InlineData(true, "пароль")]
		public void EncryptAndDecrypt_WithLongMessage_ShouldReturnOriginalMessage(bool isUkrainianAlphabet, string key)
		{
			
			TrithemiusCipher cipher = new TrithemiusCipher(isUkrainianAlphabet, key);
			string originalMessage = "Довге повідомлення для тестування шифрування та дешифрування";

			
			string encryptedMessage = cipher.Encrypt(originalMessage);
			string decryptedMessage = cipher.Decrypt(encryptedMessage);

			
			Assert.Equal(originalMessage, decryptedMessage);
		}

		[Theory]
		[InlineData(true, "пароль")]
		public void EncryptAndDecrypt_WithSpecialCharacters_ShouldReturnOriginalMessage(bool isUkrainianAlphabet, string key)
		{
			
			TrithemiusCipher cipher = new TrithemiusCipher(isUkrainianAlphabet, key);
			string originalMessage = "Привіт, світ! Тестуємо шифрування з спеціальними символами: @#$%^&*()_+-=";

		
			string encryptedMessage = cipher.Encrypt(originalMessage);
			string decryptedMessage = cipher.Decrypt(encryptedMessage);

			Assert.Equal(originalMessage, decryptedMessage);
		}

		[Theory]
		[InlineData(true, "пароль")]
		public void EncryptAndDecrypt_WithDifferentAlphabets_ShouldReturnOriginalMessage(bool isUkrainianAlphabet, string key)
		{
			
			TrithemiusCipher cipher1 = new TrithemiusCipher(isUkrainianAlphabet, key);
			TrithemiusCipher cipher2 = new TrithemiusCipher(isUkrainianAlphabet, key);
			string originalMessage = "Привіт, світ!";

			
			string encryptedMessage1 = cipher1.Encrypt(originalMessage);
			string decryptedMessage1 = cipher1.Decrypt(encryptedMessage1);
			string encryptedMessage2 = cipher2.Encrypt(originalMessage);
			string decryptedMessage2 = cipher2.Decrypt(encryptedMessage2);

			
			Assert.Equal(originalMessage, decryptedMessage1);
			Assert.Equal(originalMessage, decryptedMessage2);
		}

		[Theory]
		[InlineData(true, "пароль")]
		public void EncryptAndDecrypt_WithDifferentKeys_ShouldReturnOriginalMessage(bool isUkrainianAlphabet, string key)
		{
			
			TrithemiusCipher cipher1 = new TrithemiusCipher(isUkrainianAlphabet, key);
			TrithemiusCipher cipher2 = new TrithemiusCipher(isUkrainianAlphabet, "password");
			string originalMessage = "Привіт, світ!";

			
			string encryptedMessage1 = cipher1.Encrypt(originalMessage);
			string decryptedMessage1 = cipher1.Decrypt(encryptedMessage1);
			string encryptedMessage2 = cipher2.Encrypt(originalMessage);
			string decryptedMessage2 = cipher2.Decrypt(encryptedMessage2);

		
			Assert.Equal(originalMessage, decryptedMessage1);
			Assert.Equal(originalMessage, decryptedMessage2);
		}

		[Theory]
		[InlineData(true, "пароль")]
		public void EncryptAndDecrypt_WithNullCoefficients_ShouldReturnOriginalMessage(bool isUkrainianAlphabet, string key)
		{
			
			TrithemiusCipher cipher = new TrithemiusCipher(isUkrainianAlphabet, key);
			string originalMessage = "Привіт, світ!";

			
			string encryptedMessage = cipher.Encrypt(originalMessage);
			string decryptedMessage = cipher.Decrypt(encryptedMessage);

			
			Assert.Equal(originalMessage, decryptedMessage);
		}

		[Theory]
		[InlineData(false, "password", new int[] { 2, 3 })]
		[InlineData(false, "password", new int[] { 3, 4, 5 })]
		[InlineData(false, "password")]
		public void EncryptAndDecrypt_WithLinearCoefficients_ShouldReturnOriginalMessage(bool isUkrainianAlphabet, string key, int[] coefficients = null)
		{
			// Arrange
			TrithemiusCipher cipher = new TrithemiusCipher(isUkrainianAlphabet, key, coefficients);
			string originalMessage = "Hello, world!";

			// Act
			string encryptedMessage = cipher.Encrypt(originalMessage);
			string decryptedMessage = cipher.Decrypt(encryptedMessage);

			// Assert
			Assert.Equal(originalMessage, decryptedMessage);
		}

		[Theory]
		[InlineData(false, "password")]
		public void EncryptAndDecrypt_WithEmptyMessage_ShouldReturnEmptyMessageEN(bool isUkrainianAlphabet, string key)
		{
			// Arrange
			TrithemiusCipher cipher = new TrithemiusCipher(isUkrainianAlphabet, key);
			string originalMessage = "";

			// Act
			string encryptedMessage = cipher.Encrypt(originalMessage);
			string decryptedMessage = cipher.Decrypt(encryptedMessage);

			// Assert
			Assert.Equal(originalMessage, decryptedMessage);
		}

		[Theory]
		[InlineData(false, "password")]
		public void EncryptAndDecrypt_WithSingleCharacterMessage_ShouldReturnOriginalMessageEN(bool isUkrainianAlphabet, string key)
		{
			// Arrange
			TrithemiusCipher cipher = new TrithemiusCipher(isUkrainianAlphabet, key);
			string originalMessage = "a";

			// Act
			string encryptedMessage = cipher.Encrypt(originalMessage);
			string decryptedMessage = cipher.Decrypt(encryptedMessage);

			// Assert
			Assert.Equal(originalMessage, decryptedMessage);
		}
	}
}
