using KlientEncryptor;
using BibliotekaSzyfrowania;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Moq;
using static KlientEncryptor.MainWindow;

namespace KlientEncryptorTest
{
    [TestClass]
    public class MainWindowTest
    {
        [TestMethod]
        public void IsPasswordStrongValidPassword()
        {
            string validPassword = "zaq1@WSX";

            bool result = MainWindow.IsPasswordStrong(validPassword);

            Assert.IsTrue(result,"Hasło zbyt słabe");
        }

        [TestMethod]
        public void IsPasswordStrongInvalidPassword()
        {            
            string invalidPassword = "123";

            bool result = MainWindow.IsPasswordStrong(invalidPassword);

            Assert.IsFalse(result,"Hasło zbyt mocne");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReadResponseTextThrowExeption()
        {
            MainWindow.ReadResponseText(-1);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReadResponseFileThrowExeption()
        {
            MainWindow.ReadResponseFile(8);
        }
        [TestMethod]
        public void IsPasswordStrongMultiPassword()
        {
            string[] paswords = {"","123","zaq1@WSX","Hasło1","T3$tyTeSTy","Bardzo trudne hasło", "md/D-9YcA92" };
            int sum = 0;
            int expectedSum = 3;

            foreach (string pasword in paswords)
            {
                if(MainWindow.IsPasswordStrong(pasword)) sum++;
            }

            Assert.AreEqual(sum, expectedSum);
        }
    }
}
