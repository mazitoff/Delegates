using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        delegate void GetMessage(); // 1. Объявляем делегат
        delegate int Operation(int x, int y);
        static void del01()
        {
            GetMessage del; // 2. Создаем переменную делегата
            if (DateTime.Now.Hour < 12)
            {
                del = GoodMorning; // 3. Присваиваем этой переменной адрес метода
            }
            else
            {
                del = GoodEvening;
            }
            del(); // 4. Вызываем метод
        }

        static void del02()
        {
            // присваивание адреса метода через контруктор
            Operation del = new Operation(Add); // делегат указывает на метод Add
            int result = del.Invoke(4, 5);
            Console.WriteLine(result);

            del = Multiply; // теперь делегат указывает на метод Multiply
            result = del.Invoke(4, 5);
            Console.WriteLine(result);
        }

        static void del03()
        {
            if (DateTime.Now.Hour < 12)
            {
                Show_Message(GoodMorning);
            }
            else
            {
                Show_Message(GoodEvening);
            }
        }
        static void del04()
        {
            // создаем банковский счет
            Account account = new Account(200);
            // Добавляем в делегат ссылку на метод Show_Message
            // а сам делегат передается в качестве параметра метода RegisterHandler
            account.RegisterHandler(new Account.AccountStateHandler(Show_Message));
            // Два раза подряд пытаемся снять деньги
            account.Withdraw(100);
            account.Withdraw(150);
        }

        static List<int> Filter(List<int> list)
        {
            List<int> result = new List<int>();
            foreach (var item in list)
            {
                Console.WriteLine(item);
                if(item % 2 == 0)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        static void del_01()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 6 };
            var result = Filter(list);
            IEnumarableExtension.Print(result);
            list.Print();      //  это возможно после установки this в  public static void Print(this List<int> list) в class IEnumarableExtension
        }

        static void Main(string[] args)
        {
            //del01();
            Console.WriteLine("*****************************************************");
            //del02();
            Console.WriteLine("*****************************************************");
            //del03();
            Console.WriteLine("*****************************************************");
            //del04();
            Console.WriteLine("*****************************************************");
            del_01();
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*****************************************************");
            Console.WriteLine("*****************************************************");
            Console.ReadLine();

            

        }
        private static void GoodMorning()
        {
            Console.WriteLine("Good Morning");
        }
        private static void GoodEvening()
        {
            Console.WriteLine("Good Evening");
        }

        private static int Add(int x, int y)
        {
            return x + y;
        }
        private static int Multiply(int x, int y)
        {
            return x * y;
        }
        private static void Show_Message(GetMessage _del)
        {
            _del.Invoke();
        }
        private static void Show_Message(String message)
        {
            Console.WriteLine(message);
        }
    }
}

