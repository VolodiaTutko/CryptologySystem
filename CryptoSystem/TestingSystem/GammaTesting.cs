using CryptoSystem.GamaCipher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem
{
      public class GammaTesting
    {
        [Theory]
        [InlineData("hello world")]
        public void EncryptAndDecrypt_ShouldReturnOriginalMessage(string key)
        {
            var cipher = new BinaryGammingCipher(key.Length);
            string originalMessage = "hello world";

            string encryptedMessage = cipher.Encrypt(originalMessage);
            string decryptedMessage = cipher.Decrypt(encryptedMessage);

            Assert.Equal(originalMessage, decryptedMessage);
        }

        [Theory]
        [InlineData("secretkey")]
        [InlineData("randomkey")]
        [InlineData("longrandomkey")]
        public void EncryptAndDecrypt_ShouldReturnOriginalMessageForDifferentKeyLengths(string key)
        {
            var cipher = new BinaryGammingCipher(key.Length);
            string originalMessage = "Hello, world!";

            string encryptedMessage = cipher.Encrypt(originalMessage);
            string decryptedMessage = cipher.Decrypt(encryptedMessage);

            Assert.Equal(originalMessage, decryptedMessage);
        }

        [Theory]
        [InlineData("key123")]
        public void EncryptAndDecrypt_ShouldReturnOriginalMessageForSingleCharacter(string key)
        {
            var cipher = new BinaryGammingCipher(key.Length);
            string originalMessage = "A";

            string encryptedMessage = cipher.Encrypt(originalMessage);
            string decryptedMessage = cipher.Decrypt(encryptedMessage);

            Assert.Equal(originalMessage, decryptedMessage);
        }

        [Theory]
        [InlineData("key123")]
        public void EncryptAndDecrypt_ShouldReturnOriginalMessageForNumericCharacters(string key)
        {
            var cipher = new BinaryGammingCipher(key.Length);
            string originalMessage = "12345";

            string encryptedMessage = cipher.Encrypt(originalMessage);
            string decryptedMessage = cipher.Decrypt(encryptedMessage);

            Assert.Equal(originalMessage, decryptedMessage);
        }

        [Theory]
        [InlineData("key123")]
        public void EncryptAndDecrypt_ShouldReturnOriginalMessageForSpecialCharacters(string key)
        {
            var cipher = new BinaryGammingCipher(key.Length);
            string originalMessage = "!@#$%";

            string encryptedMessage = cipher.Encrypt(originalMessage);
            string decryptedMessage = cipher.Decrypt(encryptedMessage);

            Assert.Equal(originalMessage, decryptedMessage);
        }

        [Theory]
        [InlineData("key123")]
        public void EncryptAndDecrypt_ShouldReturnOriginalMessageForEmptyString(string key)
        {
            var cipher = new BinaryGammingCipher(key.Length);
            string originalMessage = "";

            string encryptedMessage = cipher.Encrypt(originalMessage);
            string decryptedMessage = cipher.Decrypt(encryptedMessage);

            Assert.Equal(originalMessage, decryptedMessage);
        }

        [Theory]
        [InlineData("key123")]
        public void EncryptAndDecrypt_ShouldReturnOriginalMessageForWhitespaceString(string key)
        {
            var cipher = new BinaryGammingCipher(key.Length);
            string originalMessage = "    ";

            string encryptedMessage = cipher.Encrypt(originalMessage);
            string decryptedMessage = cipher.Decrypt(encryptedMessage);

            Assert.Equal(originalMessage, decryptedMessage);
        }

        [Theory]
        [InlineData("key123")]
        public void EncryptAndDecrypt_ShouldReturnOriginalMessageForVeryLongString(string key)
        {
            var cipher = new BinaryGammingCipher(key.Length);
            string originalMessage = new string('a', 100000);

            string encryptedMessage = cipher.Encrypt(originalMessage);
            string decryptedMessage = cipher.Decrypt(encryptedMessage);

            Assert.Equal(originalMessage, decryptedMessage);
        }

        [Theory]
        [InlineData("key123")]
        public void EncryptAndDecrypt_ShouldReturnOriginalMessageForRepeatedKeyCharacters(string key)
        {
            var cipher = new BinaryGammingCipher(key.Length);
            string originalMessage = "abcde";

            string encryptedMessage = cipher.Encrypt(originalMessage);
            string decryptedMessage = cipher.Decrypt(encryptedMessage);

            Assert.Equal(originalMessage, decryptedMessage);
        }




    }

}
