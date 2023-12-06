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
            
                Console.WriteLine("введите букву");
                string login = Console.ReadLine().ToLower();
                List<string> result= InfoUser(login);
                foreach(string item in result)
                {
                if(Convert.ToInt32(result) > 0) 
                { 
                Console.WriteLine(item);
                }
                else
                {
                    Console.WriteLine($"Пользователей, чья фамилия начинается с буквы {login} не существует");
                }
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
                        string[] arr = line.ToLower().Trim().Split(',');
                        string log = arr[0].Trim();                    
                        int n = log.IndexOf(login);
                        if (n==0)
                        {                            
                            lines.Add(line);
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
                        if (log == login) { 
                        return true;
                        }
                    }

                }
                return false;
            }
        }
    }

