using System.Numerics;
using Xunit;
using FluentAssertions;
using DiffiHelman;

namespace TestingSystem
{
    public class DiffieHellmanTests
    {
        [Fact]
        public void GeneratePrivateValue_ShouldBeLessThanPrime()
        {

            var dh = new DiffieHellman { _prime = 23 };
            var privateKey = dh.GeneratePrivateValue();
            privateKey.Should().BeGreaterThan(0);
            privateKey.Should().BeLessThan(dh._prime);
        }

        [Fact]
        public void GeneratePrivateValue_ShouldGenerateDifferentValues()
        {
           
            var dh = new DiffieHellman { _prime = 23 };
            var privateKey1 = dh.GeneratePrivateValue();
            var privateKey2 = dh.GeneratePrivateValue();

           
            privateKey1.Should().NotBe(privateKey2);
        }

        [Theory]
        [InlineData(5, 6, 23)]
        public void CalcPublicKey_ShouldCalculateCorrectly(int generator, int privateKey, int prime)
        {
            var dh = new DiffieHellman { _generator = generator, _prime = prime };

           
            var publicKey = dh.CalcPublicKey(privateKey);

           
            var expectedPublicKey = BigInteger.ModPow(generator, privateKey, prime);
            publicKey.Should().Be(expectedPublicKey);
        }

        [Fact]
        public void GenerateSharedSecret_ShouldCalculateCorrectly()
        {
            
            var prime = 23;
            var generator = 5;
            var dh1 = new DiffieHellman { _generator = generator, _prime = prime };
            var dh2 = new DiffieHellman { _generator = generator, _prime = prime };
            var privateKey1 = dh1.GeneratePrivateValue();
            var privateKey2 = dh2.GeneratePrivateValue();
            var publicKey1 = dh1.CalcPublicKey(privateKey1);
            var publicKey2 = dh2.CalcPublicKey(privateKey2);

            
            var secret1 = dh1.GenerateSharedSecret(publicKey2);
            var secret2 = dh2.GenerateSharedSecret(publicKey1);

            
            secret1.Should().Be(secret2);
        }

        [Fact]
        public void PublicKey_GetterShouldReturnCorrectValue()
        {
           
            var dh = new DiffieHellman { _publicKey = BigInteger.One };

            
            var publicKey = dh.PublicKey;

            
            publicKey.Should().Be(BigInteger.One);
        }

        [Fact]
        public void CalcPublicKey_WithZeroPrivateKey_ShouldReturnOne()
        {
            
            var dh = new DiffieHellman { _generator = 5, _prime = 23 };

           
            var result = dh.CalcPublicKey(0);

            
            result.Should().Be(BigInteger.One);
        }

        [Fact]
        public void GenerateSharedSecret_WithZeroOtherPublicKey_ShouldReturnZero()
        {
            
            var dh = new DiffieHellman { _generator = 5, _prime = 23, _privateKey = 6 };

           
            var secret = dh.GenerateSharedSecret(0);

           
            secret.Should().Be(BigInteger.Zero);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(22)]
        public void GeneratePrivateValue_WithPrime23_ShouldNotExceedRange(int iteration)
        {
            
            var dh = new DiffieHellman { _prime = 23 };

            
            var privateKey = dh.GeneratePrivateValue();

            
            privateKey.Should().BeGreaterThan(0);
            privateKey.Should().BeLessThan(23);
        }

        [Fact]
        public void GenerateSharedSecret_ShouldReturnOne_WhenPublicKeysAreOnes()
        {
            
            var dh = new DiffieHellman { _generator = 5, _prime = 23, _privateKey = 1 };

            var secret = dh.GenerateSharedSecret(1);

            
            secret.Should().Be(BigInteger.One);
        }

        
    }

}