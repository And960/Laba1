using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
        m1:
            Console.WriteLine("Введите с какого числа формировать числа Фибоначчи ");
            string zz = Console.ReadLine();
            Console.WriteLine("Введите размер массива ");
            string n = Console.ReadLine();
            int n1 = 0;
            int zz1 = 0;
            bool r = int.TryParse(n, out n1);
            if (r == true)
            {
                bool r1 = int.TryParse(zz, out zz1);
                if (r == true)
                {
                    Console.WriteLine("Заполним массив числами ");
                    Raschet he = new Raschet(n1, zz1);
                    he.massiv();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Это не число");
                    Console.ReadKey();
                    goto m1;

                }
            }
            else
            {
                Console.WriteLine("Это не число");
                Console.ReadKey();
                goto m1;
            }
            
            Console.WriteLine("Заполним массив из файла ");
            string path = @"D:\student.txt";
            if (!File.Exists(path))
            {
                Console.WriteLine($"Файл {path} не существует! Дальнейшая работа не возможна...");

                Console.ReadKey();
                return;
            }
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
            {
                //считываем первую строку - в ней записано число объектов, записанных в файле
                string ItemsCountStr = sr.ReadLine();
                int n2 = 0;
                bool r1 = int.TryParse(ItemsCountStr, out n2);
                if (r1 == true)
                {
                    Console.WriteLine("Введите с какого числа формировать числа Фибоначчи ");
                    string zzz = Console.ReadLine();
                    int zzz1 = 0;
                    bool r11 = int.TryParse(zzz, out zzz1);
                    if (r11 == true)
                    {
                        Raschet hes = new Raschet(n2, zzz1);
                        hes.massiv();
                        Console.WriteLine();
                        int a = hes.Count;
                        Console.WriteLine("Количество элементов в массиве равных от 10 до 100 :{0} ", a);
                        Console.WriteLine();
                        int summa = hes.Modul();
                        Console.WriteLine("Сумма элементов,расположенных левее минимального по модулю элемента : {0}", summa);
                    }
                    else
                    {
                        Console.WriteLine("Это не число");
                        Console.ReadKey();
                        goto m1;

                    }
                }
                else
                {
                    Console.WriteLine("В строке файла не число");
                    Console.ReadKey();
                    return;
                }
                Console.WriteLine('\n' + "Для повтора нажмите любую клавишу." + '\n' + "Для завершения программы нажмите Enter.");
                string p = Console.ReadLine();
                if (p != "")
                    goto m1;
                Console.WriteLine("количества элементов массива в диапазоне от 10 до 100");
                
            }
        }
        class Raschet
        {
            int[] value;
            public Raschet(int n, int zz)//заполним массив  числами Фибоначчи
            {
                value = new int[n];

                int perv = zz;
                int vtor = zz+1;
                int sum = 0;
                for (int k = 0; k < value.Length; k++)
                {
                    value[k] = perv;
                    sum = perv + vtor;
                    perv = vtor;
                    vtor = sum;
                }

            }
            public int Count//задание 3-свойство
            {
                get
                {
                    int s = 0;
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (value[i] > 10 && value[i] < 100)
                            s++;
                    }
                    return s;
                }
            }
            public int Modul()//задание 4-метод
            {
                int min = 0;
                for (int i = 0; i < value.Length; i++)
                {
                    if (Math.Abs(value[i]) < Math.Abs(value[min]))
                        min = i;
                }
                Console.WriteLine("Минимальное по модулю число в этом массиве : {0}", value[min]);
                int summa = 0;
                for (int i = 0; i < min; i++)
                {
                    summa += Math.Abs(value[i]);
                }
                return summa;
            }

            public void massiv()
            {
                for (int i = 0; i < value.Length; i++)
                {
                    Console.Write(value[i] + " ");
                }
                Console.WriteLine();

            }

        }
    }
}
