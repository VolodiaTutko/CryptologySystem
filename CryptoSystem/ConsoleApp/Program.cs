using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

public class RSA
{
    public BigInteger PublicKey { get;  set; }
    public BigInteger PrivateKey { get;  set; }
    public BigInteger N { get; set; }

    public BigInteger _phi { get; set; }

    public void GenerateKeys(int keySize)
    {
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            BigInteger p = GeneratePrime(keySize / 2, rng);
            BigInteger q = GeneratePrime(keySize / 2, rng);
            N = p * q;
            BigInteger phi = (p - 1) * (q - 1);

            _phi = phi;

            PublicKey = 65537;
            PrivateKey = ModInverse(PublicKey, phi);
        }
    }

    public  BigInteger CalcPrivateKey()
    {
       
        return ModInverse(PublicKey, _phi);
    }
    public static BigInteger ModInverse(BigInteger a, BigInteger m)
    {
        BigInteger m0 = m, t, q;
        BigInteger x0 = 0, x1 = 1;

        if (m == 1)
            return 0;

        while (a > 1)
        {
            q = a / m;
            t = m;
            m = a % m; a = t;
            t = x0;
            x0 = x1 - q * x0;
            x1 = t;
        }

        return x1 < 0 ? x1 + m0 : x1;
    }

    public BigInteger GeneratePrime(int bits, RandomNumberGenerator rng)
    {
        byte[] bytes = new byte[(bits + 7) / 8];
        BigInteger number;

        do
        {
            rng.GetBytes(bytes);
            bytes[bytes.Length - 1] &= (byte)(0xFF >> (bytes.Length * 8 - bits));
            number = new BigInteger(bytes);
        }
        while (!IsProbablyPrime(number, rng));  

        return number;
    }

    public bool IsProbablyPrime(BigInteger number, RandomNumberGenerator rng, int certainty = 10)
    {
        if (number == 2 || number == 3)
            return true;
        if (number < 2 || number % 2 == 0)
            return false;

        BigInteger d = number - 1;
        int s = 0;

        while (d % 2 == 0)
        {
            d /= 2;
            s += 1;
        }

        for (int i = 0; i < certainty; i++)
        {
            BigInteger a = RandomSmallInteger(2, number - 2, rng);
            BigInteger x = BigInteger.ModPow(a, d, number);
            if (x == 1 || x == number - 1)
                continue;

            for (int r = 1; r < s; r++)
            {
                x = BigInteger.ModPow(x, 2, number);
                if (x == 1) return false;
                if (x == number - 1) break;
            }

            if (x != number - 1) return false;
        }

        return true;
    }


    public BigInteger RandomSmallInteger(BigInteger min, BigInteger max, RandomNumberGenerator rng)
    {
        BigInteger range = max - min;
        byte[] bytes = new byte[range.ToByteArray().Length];
        BigInteger result;

        do
        {
            rng.GetBytes(bytes);
            result = new BigInteger(bytes);
        }
        while (result < min || result > max);

        return result;
    }

    public BigInteger Encrypt(BigInteger message)
    {
        return BinPow(message, PublicKey, N);
    }

    public BigInteger Decrypt(BigInteger message)
    {
        return BinPow(message, PrivateKey, N);
    }

    public BigInteger BinPow(BigInteger baseValue, BigInteger exponent, BigInteger modulus)
    {
        BigInteger result = 1;
        baseValue = baseValue % modulus;

        while (exponent > 0)
        {
            if (exponent % 2 == 1) 
                result = (result * baseValue) % modulus;

            exponent = exponent >> 1;

            if (exponent == 0)
                break;

            baseValue = (baseValue * baseValue) % modulus;
        }

        return result;
    }

}
class Program
{
    static void Main()
    {
        RSA rsa = new RSA();
        rsa.GenerateKeys(1024); 

        rsa.PublicKey = 6553;
        rsa.PrivateKey = rsa.CalcPrivateKey();

        Console.WriteLine("Public Key: " + rsa.PublicKey+"\n");
        Console.WriteLine("Private Key: " + rsa.PrivateKey+"\n");
        Console.WriteLine("N: " + rsa.N + "\n");

        string originalText = "Hello, world!";

        
        byte[] bytes = Encoding.UTF8.GetBytes(originalText);

       
        BigInteger message = new BigInteger(bytes);
        BigInteger encrypted = rsa.Encrypt(message);
        BigInteger decrypted = rsa.Decrypt(encrypted);

        byte[] decryptedBytes = decrypted.ToByteArray();

       
        string decryptedText = Encoding.UTF8.GetString(decryptedBytes);



        Console.WriteLine("Original Text: " + decryptedText + "\n");
        Console.WriteLine("Original: " + message+"\n");
        Console.WriteLine("Encrypted: " + encrypted + "\n");
        Console.WriteLine("Decrypted: " + decrypted + "\n");
        Console.WriteLine("Decrypted Text: " + decryptedText + "\n");
    }
}