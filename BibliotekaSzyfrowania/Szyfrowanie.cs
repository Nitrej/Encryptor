using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;

namespace BibliotekaSzyfrowania
{
    public class Szyfrowanie : ISzyfrowanie
    {
        public int Decrypt(string cipherText, string password, out string result)
        {
            
            string plainText = null;
            result = "";
            byte[] cipherBytes;
            if (password == "")
            {
                return 1;
            }
            try
            {
                cipherBytes = Convert.FromBase64String(cipherText);
            }
            catch (Exception ex)
            {
                return 2;
            }
            try
            {
                using (Aes aesAlgorythm = Aes.Create())
                {
                    Rfc2898DeriveBytes keyDerivation = new Rfc2898DeriveBytes(password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                    aesAlgorythm.Key = keyDerivation.GetBytes(32);
                    aesAlgorythm.IV = keyDerivation.GetBytes(16);

                    ICryptoTransform decryptor = aesAlgorythm.CreateDecryptor(aesAlgorythm.Key, aesAlgorythm.IV);
                    
                    using (MemoryStream memoryStream = new MemoryStream(cipherBytes))
                    {
                            
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                                    
                            using (StreamReader streamReader = new StreamReader(cryptoStream))
                            {
                                plainText = streamReader.ReadToEnd();
                            }
                        }

                    }
  
                }
            }catch(Exception ex)
            {
                return 2;
            }
            result = plainText;
            return 0;
        }

        public int DecryptFromFile(string inputFile, string outputFile, string password)
        {
            if (password == "")
            {
                return 1;
            }
            if (inputFile == "")
            {
                return 2;
            }
            if (outputFile == "")
            {
                return 3;
            }
            try
            {
                using (FileStream inputFileStream = new FileStream(inputFile, FileMode.Open,FileAccess.Read))
                {
                    try
                    {
                        using (FileStream outputFileStream = new FileStream(outputFile, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            using (Aes aesAlgorythm = Aes.Create())
                            {
                                Rfc2898DeriveBytes keyDerivation = new Rfc2898DeriveBytes(password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                                aesAlgorythm.Key = keyDerivation.GetBytes(32);
                                aesAlgorythm.IV = keyDerivation.GetBytes(16);

                                ICryptoTransform decryptor = aesAlgorythm.CreateDecryptor(aesAlgorythm.Key, aesAlgorythm.IV);
                                try
                                {
                                    using (CryptoStream cryptoStream = new CryptoStream(inputFileStream, decryptor, CryptoStreamMode.Read))
                                    {
                                        cryptoStream.CopyTo(outputFileStream);
                                    }
                                }catch(Exception ex)
                                {
                                    inputFileStream.Close();
                                    outputFileStream.Close();
                                    return 6;
                                }
                                
                            }
                            inputFileStream.Close();
                            outputFileStream.Close();
                            return 0;
                        } 
                    }catch(Exception ex)
                    {
                        inputFileStream.Close();
                        return 5;
                    }
                    
                }
            }catch(Exception ex)
            {
                return 4;
            }
        }

        public int Encrypt(string plainText, string password, out string result)
        {
            byte[] encryptedBytes;

            result = "";
            if (password == "")
            {
                return 1;
            }

            using (Aes aesAlgorythm = Aes.Create())
            {
                Rfc2898DeriveBytes keyDerivation = new Rfc2898DeriveBytes(password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                aesAlgorythm.Key = keyDerivation.GetBytes(32);
                aesAlgorythm.IV = keyDerivation.GetBytes(16);

                ICryptoTransform encryptor = aesAlgorythm.CreateEncryptor(aesAlgorythm.Key, aesAlgorythm.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                    }
                    encryptedBytes = memoryStream.ToArray();
                }
            }
            result = Convert.ToBase64String(encryptedBytes);
            return 0;
        }

        public int EncryptToFile(string inputFile, string outputFile, string password)
        {
            if (password == "")
            {
                return 1;
            }
            if (inputFile == "")
            {
                return 2;
            }
            if (outputFile == "")
            {
                return 3;
            }
            try
            {
                using (FileStream inputFileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                {
                    try
                    {
                        using (FileStream outputFileStream = new FileStream(outputFile, FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            using (Aes aesAlgorythm = Aes.Create())
                            {
                                Rfc2898DeriveBytes keyDerivation = new Rfc2898DeriveBytes(password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                                aesAlgorythm.Key = keyDerivation.GetBytes(32);
                                aesAlgorythm.IV = keyDerivation.GetBytes(16);

                                ICryptoTransform encryptor = aesAlgorythm.CreateEncryptor(aesAlgorythm.Key, aesAlgorythm.IV);

                                using (CryptoStream cryptoStream = new CryptoStream(outputFileStream, encryptor, CryptoStreamMode.Write))
                                {
                                    inputFileStream.CopyTo(cryptoStream);
                                }
                            }
                            outputFileStream.Close();
                        }
                        inputFileStream.Close();
                        
                        return 0;
                    }catch(Exception ex)
                    {
                        inputFileStream.Close();
                        return 5;
                    }
                }
            }catch(Exception ex)
            {
                return 4;
            }
        }
    }
}
