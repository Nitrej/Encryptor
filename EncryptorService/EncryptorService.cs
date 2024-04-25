using BibliotekaSzyfrowania;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace EncryptorService
{
    public partial class EncryptorService : ServiceBase
    {
        private ServiceHost serviceHost = null;
        public EncryptorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            serviceHost = new ServiceHost(typeof(Szyfrowanie));
            try
            {
                serviceHost.AddServiceEndpoint(typeof(ISzyfrowanie), new WSHttpBinding(), "Encryptor");

                serviceHost.Open();
            }
            catch (CommunicationException ce)
            {
                serviceHost.Abort();
            }
        }

        protected override void OnStop()
        {
            if (serviceHost != null)
                serviceHost.Close();
        }
    }
}
