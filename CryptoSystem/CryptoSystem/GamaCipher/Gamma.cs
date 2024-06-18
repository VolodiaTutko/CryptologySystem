using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoSystem.GamaCipher
{
    public class BinaryGammingCipher
    {
        public string key { get; set; }
        private Random random;


        public BinaryGammingCipher(int keyLength)
        {
            random = new Random();
            key = GenerateRandomKey(keyLength);
        }
        public string Encrypt(string message)
        {
            ValidateKey();
            ValidateMessage(message);
            StringBuilder encryptedMessage = new StringBuilder();
            string binaryKey = StringToBinary(key);
            int keyLength = binaryKey.Length;

            for (int i = 0; i < message.Length; i++)
            {
                char charToEncrypt = message[i];
                string binaryChar = Convert.ToString(charToEncrypt, 2).PadLeft(8, '0');
                int keyIndex = i % keyLength;
                string encryptedChar = BinaryXOR(binaryChar, binaryKey[keyIndex].ToString());
                encryptedMessage.Append(encryptedChar);
            }

            return encryptedMessage.ToString();
        }

        public string Decrypt(string encryptedMessage)
        {
            ValidateKey();
            ValidateEncryptedMessage(encryptedMessage);
            StringBuilder decryptedMessage = new StringBuilder();
            string binaryKey = StringToBinary(key);
            int keyLength = binaryKey.Length;

            for (int i = 0; i < encryptedMessage.Length; i += 8)
            {

                string binaryChar = encryptedMessage.Substring(i, 8);
                int keyIndex = i / 8 % keyLength;
                string decryptedChar = BinaryXOR(binaryChar, binaryKey[keyIndex].ToString());
                decryptedMessage.Append((char)Convert.ToInt32(decryptedChar, 2));

            }

            return decryptedMessage.ToString();
        }

        private string StringToBinary(string input)
        {
            StringBuilder binaryString = new StringBuilder();

            foreach (char c in input)
            {
                string binaryChar = Convert.ToString(c, 2).PadLeft(8, '0');
                binaryString.Append(binaryChar);
            }

            return binaryString.ToString();
        }

        private string BinaryXOR(string binaryStr1, string binaryStr2)
        {
            int maxLength = Math.Max(binaryStr1.Length, binaryStr2.Length);
            binaryStr1 = binaryStr1.PadLeft(maxLength, '0');
            binaryStr2 = binaryStr2.PadLeft(maxLength, '0');

            StringBuilder result = new StringBuilder();

            for (int i = 0; i < maxLength; i++)
            {
                result.Append((char)(((binaryStr1[i] - '0') ^ (binaryStr2[i] - '0')) + '0'));
            }

            return result.ToString();
        }

        private string GenerateRandomKey(int keyLength)
        {
            StringBuilder keyBuilder = new StringBuilder();
            for (int i = 0; i < keyLength; i++)
            {
                char randomChar = (char)random.Next(32, 127);
                keyBuilder.Append(randomChar);
            }
            return keyBuilder.ToString();
        }

        private void ValidateKey()
        {
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Key cannot be null or empty.");
            }
        }

        private void ValidateMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Message cannot be null or empty.");
            }
        }

        private void ValidateEncryptedMessage(string encryptedMessage)
        {
            if (string.IsNullOrEmpty(encryptedMessage) || encryptedMessage.Length % 8 != 0)
            {
                MessageBox.Show("Invalid encrypted message format.");
            }
        }
    }
}
