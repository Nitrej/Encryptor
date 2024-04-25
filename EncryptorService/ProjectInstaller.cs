using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace EncryptorService
{
    [RunInstaller(true)]
    public class ProjectInstaller : Installer
    {
        public ServiceProcessInstaller process;
        public ServiceInstaller service;

        public ProjectInstaller()
        {
            process = new ServiceProcessInstaller();
            process.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();

            service.ServiceName = "EncryptorService";
            service.DisplayName = "Encryptor";
            service.Description = "Usługa umożliwiająca działanie aplikacji Encryptor.";

            service.StartType = ServiceStartMode.Automatic;

            Installers.Add(process);
            Installers.Add(service);

            service.AfterInstall += ServiceAfterInstall;
            service.BeforeInstall += ServiceBeforeUninstall;
        }
        private void ServiceAfterInstall(object sender, InstallEventArgs e)
        {
            using (ServiceController sc = new ServiceController(service.ServiceName))
            {
                sc.Start();
            }
        }
        private void ServiceBeforeUninstall(object sender, InstallEventArgs e)
        {
            using (ServiceController sc = new ServiceController(service.ServiceName))
            {
                if (sc.Status == ServiceControllerStatus.Running || sc.Status == ServiceControllerStatus.Paused)
                {
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped);
                }
            }
        }

    }
}
