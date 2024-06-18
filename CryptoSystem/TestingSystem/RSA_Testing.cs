using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using RSA;

namespace TestingSystem
{
    public class RSA_Testing
    {
        [Fact]
        public void EncryptAndDecrypt()
        {
            
            RSA_Ciepher rsa = new RSA_Ciepher();
            rsa.GenerateKeys(1024);
            BigInteger originalMessage = new BigInteger(new byte[] { 1, 2, 3, 4 });

           
            BigInteger encryptedMessage = rsa.Encrypt(originalMessage);
            BigInteger decryptedMessage = rsa.Decrypt(encryptedMessage);

            
            Assert.Equal(originalMessage, decryptedMessage);
        }

        [Fact]
        public void GenerateKeys_CorrectPublicKeyAndPrivateKey()
        {

            RSA_Ciepher rsa = new RSA_Ciepher();
            int keySize = 1024;

           
            rsa.GenerateKeys(keySize);

           
            Assert.True(rsa.PublicKey > 0);
            Assert.True(rsa.PrivateKey > 0);
            Assert.True(rsa.N > 0);
        }

        [Fact]
        public void ModInverse_CorrectModInverse()
        {
           
            BigInteger a = 7;
            BigInteger m = 40;

           
            BigInteger result = RSA_Ciepher.ModInverse(a, m);

            
            Assert.Equal(23, result);
        }

        [Fact]
        public void IsProbablyPrime_CorrectPrimeCheck()
        {
           
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            BigInteger prime = 7919; 

           
            bool isPrime = RSA_Ciepher.IsProbablyPrime(prime, rng);

            
            Assert.True(isPrime);
        }

        [Fact]
        public void Encrypt_ReturnsDifferentValuesForDifferentMessages()
        {
            
            RSA_Ciepher rsa = new RSA_Ciepher();
            rsa.GenerateKeys(1024);
            BigInteger message1 = new BigInteger(new byte[] { 1, 2, 3, 4 });
            BigInteger message2 = new BigInteger(new byte[] { 5, 6, 7, 8 });

           
            BigInteger encryptedMessage1 = rsa.Encrypt(message1);
            BigInteger encryptedMessage2 = rsa.Encrypt(message2);

           
            Assert.NotEqual(encryptedMessage1, encryptedMessage2);
        }

        
        [Fact]
        public void GeneratePrime_ReturnsPrimeNumber()
        {
            
            RSA_Ciepher rsa = new RSA_Ciepher();
            int keySize = 1024;

           
            BigInteger prime = rsa.GeneratePrime(keySize / 2, RandomNumberGenerator.Create());

           
            Assert.True(RSA_Ciepher.IsProbablyPrime(prime, RandomNumberGenerator.Create()));
        }

        [Fact]
        public void RandomSmallInteger_ReturnsNumberInRange()
        {
           
            BigInteger min = 1000;
            BigInteger max = 2000;

            
            BigInteger random = RSA_Ciepher.RandomSmallInteger(min, max, RandomNumberGenerator.Create());

            
            Assert.True(random >= min && random <= max);
        }
    }
}

