using System;
using System.Text.RegularExpressions;

namespace BarberShop
{
	public static class ValidationCheck
	{
		const string EncpKey = "R0h1!X@mR1N";
		const string EncpPass = "FeviQuick";
		public static Byte [] DoTheEncryption (String Textfield)
		{
			var salt = ToByteArray (EncpKey);
			var bytes = Crypto.EncryptAes (Textfield, EncpPass, salt);
			return bytes;
		}

		public static String DoTheDecyption (Byte [] bytes)
		{
			var salt = ToByteArray (EncpKey);
			var Depstring = Crypto.DecryptAes (bytes, EncpPass, salt);
			return Depstring;
		}

		public static bool EmailValidation (string emailAddress)
		{

			Regex regex = new Regex (@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
			Match match = regex.Match (emailAddress);
			if (match.Success) {
				return true;
			} else {
				return false;
			}

		}

		public static bool MobileNumValidation (String MobileNumber)
		{
			Regex mobilePattern = new Regex (@"^[1-9]\d{10}$");
			return !mobilePattern.IsMatch (MobileNumber);
		}

		public static bool PasswordValidation (string PassCode)
		{
			if (PassCode.Length >= 8 && PassCode.Length <= 16) {
				return true;
			} else {
				return false;
			}

		}

		public static byte [] ToByteArray (string value)
		{
			char [] charArr = value.ToCharArray ();
			byte [] bytes = new byte [charArr.Length];
			for (int i = 0; i < charArr.Length; i++) {
				byte current = Convert.ToByte (charArr [i]);
				bytes [i] = current;
			}
			return bytes;
		}
	}
}
