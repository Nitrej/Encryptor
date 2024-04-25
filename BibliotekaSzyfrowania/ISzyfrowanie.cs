using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BibliotekaSzyfrowania
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ISzyfrowanie
    {
        [OperationContract]
        int Encrypt(string plainText, string password, out string result);

        [OperationContract]
        int Decrypt(string cipherText, string password, out string result);

        [OperationContract]
        int EncryptToFile(string inputFile, string outputFile, string password);

        [OperationContract]
        int DecryptFromFile(string inputFile, string outputFile, string password);
    }

}
