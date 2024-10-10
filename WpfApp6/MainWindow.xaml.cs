using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfApp6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void FindTwins_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputN.Text, out int N))           // получить введенное значение N
            {
               ResultBlock.Text = "";         // очищение текстового блока для результатов
               var twinPrimes = FindPrimeTwins(N);      // нахождение простых чисел-близнецов

                if (twinPrimes.Any())        // в случае нахождения пары выведет результат
                {
                    foreach (var pair in twinPrimes)
                    {
                        ResultBlock.Text += $"({pair.Item1}, {pair.Item2})\n";
                    }
                }
                else
                {
                    ResultBlock.Text = "Числа-близнецы не найдены.";
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите число.");        //для неверного ввода
            }
        }

        private List<Tuple<int, int>> FindPrimeTwins(int N)        // создание метод для поиска простых чисел-близнецов до N
        {
            List<int> primes = GetPrimes(N);
            List<Tuple<int, int>> twinPrimes = new List<Tuple<int, int>>();

            for (int i = 0; i < primes.Count - 1; i++)
            {
                if (primes[i + 1] - primes[i] == 2)
                {
                    twinPrimes.Add(Tuple.Create(primes[i], primes[i + 1]));
                }
            }
            return twinPrimes;
        }

        private List<int> GetPrimes(int N)             // создание метода для нахождения простых чисел до N
        {
            bool[] isPrime = new bool[N + 1];
            for (int i = 2; i <= N; i++)
            {
                isPrime[i] = true;
            }

            for (int i = 2; i * i <= N; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= N; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }

            List<int> primes = new List<int>();
            for (int i = 2; i <= N; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }
            return primes;
        }
    }
}
