using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string imagePath = "C:\\Users\\DELL\\Desktop\\Test\\Test.txt";
            string encryptedImagePath = "C:\\Users\\DELL\\Desktop\\Test\\Encrypt\\encryptedImage.enc";
            string decryptedImagePath = "C:\\Users\\DELL\\Desktop\\Test\\Decrypt\\decryptedImage.txt";

            string key = "Aitech$32123r2322344232352524234"; // Replace with a strong and secure key
            EncryptImage(imagePath, encryptedImagePath, key);
            DecryptImage(encryptedImagePath, decryptedImagePath, key);

            Console.WriteLine("Image encrypted and decrypted successfully.");
        }

        static void EncryptImage(string inputPath, string outputPath, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);

                byte[] staticIV = new byte[aesAlg.IV.Length];
                aesAlg.IV.CopyTo(staticIV, 0);

                using (FileStream inputFile = new FileStream(inputPath, FileMode.Open))
                using (FileStream outputFile = new FileStream(outputPath, FileMode.Create))
                {
                    outputFile.Write(aesAlg.IV, 0, aesAlg.IV.Length);

                    using (CryptoStream cryptoStream = new CryptoStream(outputFile, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        inputFile.CopyTo(cryptoStream);
                    }
                }
            }
        }

        static void DecryptImage(string inputPath, string outputPath, string key)
        {
            using (Aes aesAlg = Aes.Create())
            {

                aesAlg.Key = Encoding.UTF8.GetBytes(key);

                byte[] staticIV = new byte[aesAlg.IV.Length];
                aesAlg.IV.CopyTo(staticIV, 0);

                using (FileStream inputFile = new FileStream(inputPath, FileMode.Open))
                {
                    byte[] iv = new byte[aesAlg.IV.Length];
                    inputFile.Read(iv, 0, iv.Length);
                    aesAlg.IV = iv;

                    using (FileStream outputFile = new FileStream(outputPath, FileMode.Create))
                    using (CryptoStream cryptoStream = new CryptoStream(inputFile, aesAlg.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        cryptoStream.CopyTo(outputFile);
                    }
                }
            }
        }
    }
}
