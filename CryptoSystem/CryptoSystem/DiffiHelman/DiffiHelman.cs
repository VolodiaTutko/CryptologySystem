using System;
using System.Numerics;

namespace DiffiHelman
{
    public class DiffieHellman
    {
        public BigInteger _prime;
        public BigInteger _generator;

        public BigInteger _privateKey;
        public BigInteger _publicKey;

        public DiffieHellman()
        {

        }

        public BigInteger PublicKey
        {
            get { return _publicKey; }
        }

        public BigInteger GeneratePrivateValue()
        {
            Random rnd = new Random();
            _privateKey = new BigInteger(rnd.Next(1, (int)_prime));
            return _privateKey;
        }

        public BigInteger CalcPublicKey(BigInteger privateKey)
        {
            return BigInteger.ModPow(_generator, privateKey, _prime);
        }

        public BigInteger GenerateSharedSecret(BigInteger otherPublicKey)
        {
            BigInteger sharedSecret = BigInteger.ModPow(otherPublicKey, _privateKey, _prime);
            return sharedSecret;
        }
    }
}