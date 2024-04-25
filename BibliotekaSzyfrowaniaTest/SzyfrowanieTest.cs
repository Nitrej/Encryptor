using BibliotekaSzyfrowania;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BibliotekaSzyfrowaniaTest
{
    [TestClass]
    public class SzyfrowanieTest
    {
        private ISzyfrowanie szyfrowanie;

        [TestInitialize]
        public void Setup()
        {
            szyfrowanie = new Szyfrowanie();
        }

        [TestMethod]
        public void DecryptInvalidCipherText()
        {
            string cipherText = "This is a secret message";
            string password = "password";
            string result;

            int errorCode = szyfrowanie.Decrypt(cipherText, password, out result);

            Assert.AreEqual(2, errorCode);
        }

        [TestMethod]
        public void DecryptEmptyPassword()
        {
            string cipherText = "This is a secret message";
            string password = "";
            string result;

            int errorCode = szyfrowanie.Decrypt(cipherText, password, out result);

            Assert.AreEqual(1, errorCode);
        }

        [TestMethod]
        public void DecryptValidInput()
        {
            string password = "password";
            string plainText = "This is a secret message";
            string encryptedText;
            szyfrowanie.Encrypt(plainText, password, out encryptedText);
            string result;

            int errorCode = szyfrowanie.Decrypt(encryptedText, password, out result);

            Assert.AreEqual(0, errorCode);
            Assert.AreEqual(plainText, result);
        }

        [TestMethod]
        public void DecryptFromFileInvalidInputFile()
        {
            string inputFile = "C///";
            string outputFile = "C:/test.txt";
            string password = "password";

            int errorCode = szyfrowanie.DecryptFromFile(inputFile, outputFile, password);
            Assert.IsFalse(!(Convert.ToBoolean(errorCode)),"Poprawny plik wejściowy");
        }
        [TestMethod]
        public void EncryptToFileValidInput()
        {
            string inputFile = "inputFile.txt";
            string outputFile = "outputFile.txt";
            string password = "password";
            File.WriteAllText(inputFile, "This is a secret message");

            int errorCode = szyfrowanie.EncryptToFile(inputFile, outputFile, password);

            Assert.AreEqual(0, errorCode);
            Assert.IsTrue(File.Exists(outputFile),"Plik outputFile nie powstał");
        }

        [TestMethod]
        public void DecryptFromFileValidInputFile()
        {
            string inputFile = "inputFile.txt";
            string outputFile = "outputFile.txt";
            string password = "password";
            File.WriteAllText(inputFile, "This is a secret message");
            szyfrowanie.EncryptToFile(inputFile, outputFile, password);

            int errorCode = szyfrowanie.DecryptFromFile(outputFile, inputFile, password);
            string decryptedText = File.ReadAllText(inputFile);

            Assert.AreEqual(0, errorCode);
            Assert.AreEqual("This is a secret message", decryptedText);
        }
    }
}
