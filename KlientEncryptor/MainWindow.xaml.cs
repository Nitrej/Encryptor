using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceProcess;
using System.Text;
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
using KlientEncryptor.ServiceReference1;
using static KlientEncryptor.MainWindow;

namespace KlientEncryptor
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        

        public SzyfrowanieClient szyfrowanieClient = new SzyfrowanieClient();
        
        public MainWindow()
        {
            InitializeComponent();
            IsServiceOn();
            szyfrowanieClient = new SzyfrowanieClient();
        }

        public void ZaszyfrujText(object sender, RoutedEventArgs e)
        {
            if (!IsPasswordStrong(passwordBoxText.Password))
            {
                MessageBox.Show("Hasło musi zawierać minimum 8 znaków, w tym przynajmniej : jedną małą literę, jedną dużą literę, jedną cyfrę i jeden znak specjalny(!@#$%^&*()-_=+)", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string result;
            IsServiceOn();
            int code = szyfrowanieClient.Encrypt(plainText.Text, passwordBoxText.Password, out result);
            if (code != 0)
            {
                ReadResponseText(code);
                return;
            }
            resultText.Text = result;
        }

        public void OdszyfrujText(object sender, RoutedEventArgs e)
        {
            if (!IsPasswordStrong(passwordBoxText.Password))
            {
                MessageBox.Show("Hasło musi zawierać minimum 8 znaków, w tym przynajmniej : jedną małą literę, jedną dużą literę, jedną cyfrę i jeden znak specjalny(!@#$%^&*()-_=+)", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            string result;
            IsServiceOn();
            int code = szyfrowanieClient.Decrypt(plainText.Text, passwordBoxText.Password, out result);
            if (code != 0)
            {
                ReadResponseText(code);
                return;
            }
            resultText.Text = result;
        }

        public void ZaszyfrujPlik(object sender, RoutedEventArgs e)
        {
            if (!IsPasswordStrong(passwordBoxFile.Password))
            {
                MessageBox.Show("Hasło musi zawierać minimum 8 znaków, w tym przynajmniej : jedną małą literę, jedną dużą literę, jedną cyfrę i jeden znak specjalny(!@#$%^&*()-_=+)", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            IsServiceOn();
            int code = szyfrowanieClient.EncryptToFile(inputFilePath.Text, outputFilePath.Text, passwordBoxFile.Password);
            ReadResponseFile(code);
        }

        public void OdszyfrujPlik(object sender, RoutedEventArgs e)
        {
            if (!IsPasswordStrong(passwordBoxFile.Password))
            {
                MessageBox.Show("Hasło musi zawierać minimum 8 znaków, w tym przynajmniej : jedną małą literę, jedną dużą literę, jedną cyfrę i jeden znak specjalny(!@#$%^&*()-_=+)", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            IsServiceOn();
            int code = szyfrowanieClient.DecryptFromFile(inputFilePath.Text, outputFilePath.Text, passwordBoxFile.Password);
            ReadResponseFile(code);
        }

        public void searchForInputFilePath(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {

                inputFilePath.Text = dialog.FileName;
            }
        }

        public void searchForOutputFilePath(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text documents (.txt)|*.txt";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                outputFilePath.Text = dialog.FileName;
            }
        }

        public static void ReadResponseText(int code)
        {
            switch (code)
            {
                case 1:
                    MessageBox.Show("Hasło nie może być puste!", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case 2:
                    MessageBox.Show("Podano złe hasło!", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static void ReadResponseFile(int code)
        {
            switch (code)
            {
                case 0:
                    MessageBox.Show("Operacja przebiegła pomyślnie", "Sukcess", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                case 1:
                    MessageBox.Show("Hasło nie może być puste!", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case 2:
                    MessageBox.Show("Ścieszka do pliku źródłowego nie może być pusta!", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case 3:
                    MessageBox.Show("Ścieszka do pliku wynikowego nie może być pusta!", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case 4:
                    MessageBox.Show("Nieprawidłowa ścieszka do pliku żródłowego!", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case 5:
                    MessageBox.Show("Nieprawidłowa ścieszka do pliku wynikowego!", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case 6:
                    MessageBox.Show("Podano złe hasło!", "Bląd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();

            }
        }

        public static bool IsPasswordStrong(string password)
        {
            int minLength = 8;
            int minLowercase = 1;
            int minUppercase = 1;
            int minDigits = 1;
            int minSpecialChars = 1;
            string specialChars = "!@#$%^&*()-_=+";

            if (password.Length < minLength)
                return false;

            if (password.Count(char.IsLower) < minLowercase)
                return false;

            if (password.Count(char.IsUpper) < minUppercase)
                return false;

            if (password.Count(char.IsDigit) < minDigits)
                return false;

            if (password.Count(c => specialChars.Contains(c)) < minSpecialChars)
                return false;

            return true;
        }

        public void IsServiceOn()
        {
            ServiceController encryptorService;
            try
            {
                encryptorService = new ServiceController("EncryptorService");
                if (encryptorService.Status != ServiceControllerStatus.Running)
                {
                    var dialogResult = MessageBox.Show("Usługa Encryptor nie jest uruchomiona. Czy chcesz ją teraz uruchomić?", "Błąd", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        try
                        {
                            encryptorService.Start();
                            encryptorService.WaitForStatus(ServiceControllerStatus.Running);
                            MessageBox.Show("Usługa Encryptor została pomyślnie uruchomiona.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (InvalidOperationException ex)
                        {
                            var d = MessageBox.Show("Nie udało się uruchomić usługi Encryptor. Błąd: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                            if(d == MessageBoxResult.OK)
                                Application.Current.Shutdown();
                        }
                    }
                    else if (dialogResult == MessageBoxResult.No)
                    {
                        Application.Current.Shutdown();
                    }
                }
            }
            catch (Exception ex)
            {
                var d = MessageBox.Show("Wystąpił błąd podczas sprawdzania stanu usługi Encryptor. Błąd: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                if(d == MessageBoxResult.OK)
                    Application.Current.Shutdown();
            }
        }
    }
}
