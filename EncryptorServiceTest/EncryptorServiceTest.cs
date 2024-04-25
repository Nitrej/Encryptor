using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Threading.Tasks;
using EncryptorService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceProcess;

namespace EncryptorServiceTest
{
    [TestClass]
    public class EncryptorServiceTest
    {
        [TestMethod]
        public void EncryptorServiceServiceName()
        {
            EncryptorService.EncryptorService encryptorService = new EncryptorService.EncryptorService();
            Assert.IsTrue(encryptorService.ServiceName == "EncryptorService","Poprawna nazwa usługi");
        }

        [TestMethod]
        public void EncryptorServiceNotNull()
        {
            EncryptorService.EncryptorService encryptorService = new EncryptorService.EncryptorService();

            Assert.IsNotNull(encryptorService);
        }
        [TestMethod]
        public void EncryptorServiceServiceNameOnBoth()
        {
            EncryptorService.EncryptorService encryptorService = new EncryptorService.EncryptorService();
            EncryptorService.ProjectInstaller projectInstaller = new ProjectInstaller();
            Assert.AreEqual(encryptorService.ServiceName,projectInstaller.service.ServiceName);
        }
    }
}
