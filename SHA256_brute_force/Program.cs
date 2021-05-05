using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SHA256_brute_force
{
	class Program {
		public static void Main (string[] args) {
			Console.Write("Enter a plain text string you want to encode into a hash value for the algorithm to decrypt: ");
			string hash = sha256_hash(Console.ReadLine());
			string guess = "";
			int finalStringVal = 0;
			int startTime = (int)DateTime.Now.Subtract(new DateTime(1970,1,1,0,0,0)).TotalSeconds;

			for (int i = 0; i > -1; i++)
			{
				guess = sha256_hash(Int32ToString(i,36));
				Console.WriteLine(guess + " "+Int32ToString(i,36));
				if (guess == hash)
				{
					finalStringVal = i;
					break;
				}
			}

			int stopTime = (int)DateTime.Now.Subtract(new DateTime(1970,1,1,0,0,0)).TotalSeconds;
			Console.WriteLine("Found value. Value is: " + Int32ToString(finalStringVal,36));
			Console.WriteLine("Hash: " + guess);
			Console.WriteLine("Total number of hashes: "+finalStringVal);
			Console.WriteLine("Time it took: "+(stopTime-startTime)+" seconds");
			if(stopTime - startTime == 0) stopTime++; // prevents division by 0
			Console.WriteLine("Hashing speed: "+finalStringVal/(stopTime-startTime)+" hashes per second");
		}
		public static String sha256_hash(string value) // I didn't write this function, and I can't find the original author
		{
			StringBuilder Sb = new StringBuilder();
			using (var hash = SHA256.Create())            
			{
				Encoding enc = Encoding.UTF8;
				Byte[] result = hash.ComputeHash(enc.GetBytes(value));

				foreach (Byte b in result)
				{
					Sb.Append(b.ToString("x2"));
				}
			}

			return Sb.ToString();
		}
		public static string Int32ToString(int value, int toBase) // I didn't write this function either, and I can't find the original author
		{
			string result = string.Empty;
			do
			{
				result = "0123456789abcdefghijklmnopqrstuvwxyz"[value % toBase] + result;
				value /= toBase;
			}
			while (value > 0);

			return result;
		}
	}
}
