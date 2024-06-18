using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSystem.KnapsackProblem
{
	public class KnapsackProblem
	{
		public List<int> privateKey { get; set; }
		public List<int> publicKey { get; set; }
		public int mod;
		public int t;
		public int length ;

		public KnapsackProblem(string message)
		{
            var Bmessage = StringToBinary(message);
            length = Bmessage.Count;
        }


		public List<int> GenerateSuperIncreasingSequence(int length, int startValue)
		{
			List<int> sequence = new List<int>();
			Random rnd = new Random();
			int current = startValue;

			sequence.Add(current);

			for (int i = 1; i < length; i++)
			{
				
				int sum = 0;
				foreach (int num in sequence)
				{
					sum += num;
				}

				current = sum + rnd.Next(1, 10);
				sequence.Add(current);
			}

			return sequence;
		}
		public void GenerateKeys()
		{
			
			privateKey = GenerateSuperIncreasingSequence(length: length, startValue: 1);
			int sum = 0;
			foreach (int num in privateKey)
				sum += num;

			
			Random rnd = new Random();
			mod = sum + rnd.Next(3, 100); 
			t = rnd.Next(2, mod); 

			
			publicKey = new List<int>();
			foreach (int num in privateKey)
			{
				publicKey.Add((num * t) % mod);
			}
		}
		public int EncryptMessage(string message)
		{
			var binary = StringToBinary(message);
			return Encrypt(binary);
		}

		public string DecryptMessage(int encryptedMessage)
		{
			var binary = Decrypt(encryptedMessage);
			return BinaryToString(binary);
		}


		public int Encrypt(List<int> message)
		{
			if (message.Count != publicKey.Count)
				throw new ArgumentException("Message length must be equal to the key length.");

			int sum = 0;
			for (int i = 0; i < message.Count; i++)
			{
				sum += message[i] * publicKey[i];
			}

			return sum;
		}

		public List<int> Decrypt(int encryptedMessage)
		{
			
			int inverseMult = ModInverse(t, mod);
			int originalSum = (encryptedMessage * inverseMult) % mod;

			List<int> decryptedMessage = new List<int>();
			for (int i = privateKey.Count - 1; i >= 0; i--)
			{
				if (originalSum >= privateKey[i])
				{
					decryptedMessage.Insert(0, 1);
					originalSum -= privateKey[i];
				}
				else
				{
					decryptedMessage.Insert(0, 0);
				}
			}

			return decryptedMessage;
		}

        public int ModInverse(int t, int m)
        {
            
            t = ((t % m) + m) % m;

            int a = t, b = m;
            int x0 = 0, x1 = 1;

            while (a > 1)
            {
                int q = a / b;
                int tmp = b;
                b = a % b;
                a = tmp;

                int tmp2 = x0;
                x0 = x1 - q * x0;
                x1 = tmp2;
            }

            
            if (a == 1)
            {
                return ((x1 % m) + m) % m;
            }
            else
            {
               
                throw new Exception("No modular inverse");
            }
        }
        public List<int> StringToBinary(string message)
		{
			return string.Join("", Encoding.UTF8.GetBytes(message).SelectMany(b => Convert.ToString(b, 2).PadLeft(8, '0'))).Select(c => c == '1' ? 1 : 0).ToList();
		}

		public string BinaryToString(List<int> binary)
		{
			var bytes = new byte[binary.Count / 8];
			for (int i = 0; i < binary.Count; i += 8)
			{
				bytes[i / 8] = Convert.ToByte(new string(binary.Skip(i).Take(8).Select(b => b == 1 ? '1' : '0').ToArray()), 2);
			}
			return Encoding.UTF8.GetString(bytes);
		}
	}
}
