using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string login=String.Empty;
            List<string> result = InfoUser(login);
            foreach (string item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        /// <summary>
        /// вывод строки о пользователе
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>Строка в формате:
        /// Фамилия,Имя Отчество,логин, Пароль,Роль
        /// </returns>
        private static List<string> InfoUser(string login)
        {
            List<string> lines = new List<string>();
            using (StreamReader sr = new StreamReader("Пользователи.csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] arr = line.Trim().Split(',');
                    string log = arr[3].Trim();
                    string n = "qwertyuiopasdfghjklzxcvbnm";
                    string m = n.ToUpper();
                    int a = 0;
                    string specialsymbols = "!#$%&'()*+-./:;<=>?@[]^_`{|}~";
                    string numbers = "0123456789";
                    if (log.Length >= 6)
                    {
                        a++;
                    }
                    if (a == 1)
                    {
                        foreach (char item in n)
                        {
                            if (log.Contains(item))
                            {
                                a++;
                            }
                        }
                    }
                    if (a == 2)
                    {
                        foreach (char item2 in m)
                        {
                            if (log.Contains(item2))
                            {
                                a++;
                            }
                        }
                    }
                    if (a == 3)
                    {
                        foreach (char item3 in specialsymbols)
                        {
                            if (log.Contains(item3))
                            {
                                a++;
                            }
                        }
                    }
                    if (a == 4)
                    {
                        foreach (char item4 in numbers)
                        {
                            if (log.Contains(item4))
                            {
                                lines.Add(line);
                            }
                        }
                    }
                }
            }
            return lines;
        }

        /// <summary>
        /// Поисквсе информа об этом пользователе
        /// </summary>
        /// <param name="login">Логин</param>
        /// <param name="password">Пароль</param>
        /// <returns>
        /// bool
        /// </returns>
        private static bool FindUser(string login)
        {
            using (StreamReader sr = new StreamReader("Пользователи.csv"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] arr = line.ToLower().Trim().Split(',');
                    string log = arr[4].Trim();
                    Console.WriteLine(line);
                    int n = log.IndexOf(login);
                    if (log == login)
                    {
                        return true;
                    }
                }

            }
            return false;
        }
    }
}

