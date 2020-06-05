using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace ProgAnalys
{
    class Activity //класс методов
    {
        public static List<Data> bigdata = new List<Data>(); //глобальный список для рассчета 
        public static List<Data> resultdata = new List<Data>(); //глобальный список для вывода
        public static bool Check(string filetext)
        {
            try // отлов ошибок
            {
                string[] years = filetext.Split(new char[] { '~' }, StringSplitOptions.RemoveEmptyEntries); //расшифровка строк
                int s = years.Length;
                List<Data> data = new List<Data>();
                for (int i = 0; i < s; i++)
                {
                    string[] prde = years[i].Split(new char[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                    int p = prde.Length;
                    for (int j = 1; j < p; j++)
                    {
                        string[] pr = prde[j].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                        data.Add(new Data() { year = i + 1, product = pr[0], demand = Convert.ToDouble(pr[1]) });
                    }

                }

                bigdata.Clear(); //чистим глобальный список 
                bigdata = data; //заполняем
                if (bigdata.Count == 0) // отлов ошибок 2
                {
                    MessageBox.Show("Ошибка! Исходные данные неверны");
                    return (false);
                }
                else { return (true); }
            }
            catch
            {
                MessageBox.Show("Ошибка! Исходные данные неверны");
                return (false);
            }

        }
        public static void System ()
        {
            double demand1;

            var result = bigdata.GroupBy(p => p.product); //группируем список для работы
            List<Data> rdata = new List<Data>();

            foreach (var g in result) //рассчет системы
            {

                double s1, s2, s3, s4, s5;
                int n = 0;
                int q = 0;
                s1 = 0;
                s2 = 0;
                s3 = 0;
                s4 = 0;
                s5 = 0;
                int i = 0;
                Console.WriteLine(g.Key);
                foreach (var t in g)
                {
                    i = t.year;
                    s1 = (i * i) + s1;
                    s2 = t.demand + s2;
                    s3 = (i * t.demand) + s3;
                    s4 = (i * i * i * i) + s4;
                    s5 = ((i * i) * t.demand) + s5;
                    n++;
                }

                double a0, a1, a2;

                //и решение уравнения

                a1 = s3 / s1;

                double det = (n * s4) - (s1 * s1);
                a0 = ((s2*s4) - (s1*s5)) / (det);
                a2 = ((n * s5) - (s2 * s1)) / (det);

                for (q = 1; q < 6; q++)
                {
                    demand1 = a0 + (a1 * q) + (a2 * (q * q));
                    rdata.Add(new Data { demand = demand1, product = g.Key, year = q });
                }

                
                
            }

            resultdata.Clear(); //очищаем результирующий список

            resultdata = rdata; //записываем
        }



    }
}
