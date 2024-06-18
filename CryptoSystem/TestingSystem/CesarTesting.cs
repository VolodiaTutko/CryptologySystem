using CryptoSystem.CesarCipher;

namespace TestingSystem
{
	public class CesarTesting
	{
		[Theory]
		[InlineData(true, "0", true)] // Valid Ukrainian key
		[InlineData(false, "226", true)] // Invalid Ukrainian key
		[InlineData(true, "0", false)] // Valid English key
		[InlineData(false, "80", false)] // Invalid English key
		public void ValidateKey_Validations(bool expectedResult, string key, bool isUkrainianAlphabet)
		{

			var symmetricCipher = new SymmetricCipher(isUkrainianAlphabet);


			bool result = symmetricCipher.ValidateKey(key, isUkrainianAlphabet);


			Assert.Equal(expectedResult, result);
		}

		[Theory]
		[InlineData("—‚≥Ú", 1, true, "“„øÛ")]
		[InlineData("WORLD", 5, false, "1TWQI")]
		[InlineData("“≈—“", 10, true, "ﬂÃﬁﬂ")]
		[InlineData("TEST", 20, false, "$Y#$")]
		public void Encrypt_ValidCases(string input, int shift, bool isUkrainianAlphabet, string expectedResult)
		{

			var symmetricCipher = new SymmetricCipher(isUkrainianAlphabet);


			string result = symmetricCipher.Encrypt(input, shift);


			Assert.Equal(expectedResult, result);
		}

		[Theory]
		[InlineData("“„øÛ", 1, true, "—‚≥Ú")]
		[InlineData("1TWQI", 5, false, "WORLD")]
		[InlineData("ﬂÃﬁﬂ", 10, true, "“≈—“")]
		[InlineData("$Y#$", 20, false, "TEST")]
		public void Decrypt_ValidCases(string input, int shift, bool isUkrainianAlphabet, string expectedResult)
		{

			var symmetricCipher = new SymmetricCipher(isUkrainianAlphabet);


			string result = symmetricCipher.Decrypt(input, shift);


			Assert.Equal(expectedResult, result);
		}
	}
}