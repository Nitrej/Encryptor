﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KlientEncryptor.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.ServiceModel.Samples", ConfigurationName="ServiceReference1.ISzyfrowanie")]
    public interface ISzyfrowanie {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/Encrypt", ReplyAction="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/EncryptResponse")]
        KlientEncryptor.ServiceReference1.EncryptResponse Encrypt(KlientEncryptor.ServiceReference1.EncryptRequest request);
        
        // CODEGEN: Trwa generowanie kontraktu komunikatu, ponieważ operacja ma wiele wartości zwracanych.
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/Encrypt", ReplyAction="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/EncryptResponse")]
        System.Threading.Tasks.Task<KlientEncryptor.ServiceReference1.EncryptResponse> EncryptAsync(KlientEncryptor.ServiceReference1.EncryptRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/Decrypt", ReplyAction="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/DecryptResponse")]
        KlientEncryptor.ServiceReference1.DecryptResponse Decrypt(KlientEncryptor.ServiceReference1.DecryptRequest request);
        
        // CODEGEN: Trwa generowanie kontraktu komunikatu, ponieważ operacja ma wiele wartości zwracanych.
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/Decrypt", ReplyAction="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/DecryptResponse")]
        System.Threading.Tasks.Task<KlientEncryptor.ServiceReference1.DecryptResponse> DecryptAsync(KlientEncryptor.ServiceReference1.DecryptRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/EncryptToFile", ReplyAction="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/EncryptToFileResponse")]
        int EncryptToFile(string inputFile, string outputFile, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/EncryptToFile", ReplyAction="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/EncryptToFileResponse")]
        System.Threading.Tasks.Task<int> EncryptToFileAsync(string inputFile, string outputFile, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/DecryptFromFile", ReplyAction="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/DecryptFromFileResponse")]
        int DecryptFromFile(string inputFile, string outputFile, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/DecryptFromFile", ReplyAction="http://Microsoft.ServiceModel.Samples/ISzyfrowanie/DecryptFromFileResponse")]
        System.Threading.Tasks.Task<int> DecryptFromFileAsync(string inputFile, string outputFile, string password);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Encrypt", WrapperNamespace="http://Microsoft.ServiceModel.Samples", IsWrapped=true)]
    public partial class EncryptRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Microsoft.ServiceModel.Samples", Order=0)]
        public string plainText;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Microsoft.ServiceModel.Samples", Order=1)]
        public string password;
        
        public EncryptRequest() {
        }
        
        public EncryptRequest(string plainText, string password) {
            this.plainText = plainText;
            this.password = password;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="EncryptResponse", WrapperNamespace="http://Microsoft.ServiceModel.Samples", IsWrapped=true)]
    public partial class EncryptResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Microsoft.ServiceModel.Samples", Order=0)]
        public int EncryptResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Microsoft.ServiceModel.Samples", Order=1)]
        public string result;
        
        public EncryptResponse() {
        }
        
        public EncryptResponse(int EncryptResult, string result) {
            this.EncryptResult = EncryptResult;
            this.result = result;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Decrypt", WrapperNamespace="http://Microsoft.ServiceModel.Samples", IsWrapped=true)]
    public partial class DecryptRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Microsoft.ServiceModel.Samples", Order=0)]
        public string cipherText;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Microsoft.ServiceModel.Samples", Order=1)]
        public string password;
        
        public DecryptRequest() {
        }
        
        public DecryptRequest(string cipherText, string password) {
            this.cipherText = cipherText;
            this.password = password;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DecryptResponse", WrapperNamespace="http://Microsoft.ServiceModel.Samples", IsWrapped=true)]
    public partial class DecryptResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Microsoft.ServiceModel.Samples", Order=0)]
        public int DecryptResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://Microsoft.ServiceModel.Samples", Order=1)]
        public string result;
        
        public DecryptResponse() {
        }
        
        public DecryptResponse(int DecryptResult, string result) {
            this.DecryptResult = DecryptResult;
            this.result = result;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISzyfrowanieChannel : KlientEncryptor.ServiceReference1.ISzyfrowanie, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SzyfrowanieClient : System.ServiceModel.ClientBase<KlientEncryptor.ServiceReference1.ISzyfrowanie>, KlientEncryptor.ServiceReference1.ISzyfrowanie {
        
        public SzyfrowanieClient() {
        }
        
        public SzyfrowanieClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SzyfrowanieClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SzyfrowanieClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SzyfrowanieClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        KlientEncryptor.ServiceReference1.EncryptResponse KlientEncryptor.ServiceReference1.ISzyfrowanie.Encrypt(KlientEncryptor.ServiceReference1.EncryptRequest request) {
            return base.Channel.Encrypt(request);
        }
        
        public int Encrypt(string plainText, string password, out string result) {
            KlientEncryptor.ServiceReference1.EncryptRequest inValue = new KlientEncryptor.ServiceReference1.EncryptRequest();
            inValue.plainText = plainText;
            inValue.password = password;
            KlientEncryptor.ServiceReference1.EncryptResponse retVal = ((KlientEncryptor.ServiceReference1.ISzyfrowanie)(this)).Encrypt(inValue);
            result = retVal.result;
            return retVal.EncryptResult;
        }
        
        public System.Threading.Tasks.Task<KlientEncryptor.ServiceReference1.EncryptResponse> EncryptAsync(KlientEncryptor.ServiceReference1.EncryptRequest request) {
            return base.Channel.EncryptAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        KlientEncryptor.ServiceReference1.DecryptResponse KlientEncryptor.ServiceReference1.ISzyfrowanie.Decrypt(KlientEncryptor.ServiceReference1.DecryptRequest request) {
            return base.Channel.Decrypt(request);
        }
        
        public int Decrypt(string cipherText, string password, out string result) {
            KlientEncryptor.ServiceReference1.DecryptRequest inValue = new KlientEncryptor.ServiceReference1.DecryptRequest();
            inValue.cipherText = cipherText;
            inValue.password = password;
            KlientEncryptor.ServiceReference1.DecryptResponse retVal = ((KlientEncryptor.ServiceReference1.ISzyfrowanie)(this)).Decrypt(inValue);
            result = retVal.result;
            return retVal.DecryptResult;
        }
        
        public System.Threading.Tasks.Task<KlientEncryptor.ServiceReference1.DecryptResponse> DecryptAsync(KlientEncryptor.ServiceReference1.DecryptRequest request) {
            return base.Channel.DecryptAsync(request);
        }
        
        public int EncryptToFile(string inputFile, string outputFile, string password) {
            return base.Channel.EncryptToFile(inputFile, outputFile, password);
        }
        
        public System.Threading.Tasks.Task<int> EncryptToFileAsync(string inputFile, string outputFile, string password) {
            return base.Channel.EncryptToFileAsync(inputFile, outputFile, password);
        }
        
        public int DecryptFromFile(string inputFile, string outputFile, string password) {
            return base.Channel.DecryptFromFile(inputFile, outputFile, password);
        }
        
        public System.Threading.Tasks.Task<int> DecryptFromFileAsync(string inputFile, string outputFile, string password) {
            return base.Channel.DecryptFromFileAsync(inputFile, outputFile, password);
        }
    }
}
