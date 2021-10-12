using System;
using System.IO;
namespace ConsoleApp7
{
    class Example
    {
        public string line1 = "asdad";
        public string[] holder;
        public void Info()
        {
            string line="";
            for (int i=0;i<holder.Length-1;i++)
            {
                if (holder[0]!=null)
                {
                    line += holder[i] + '|';
                }
            }
            if (holder[0]!=null)
            {
                line += holder[holder.Length - 1];
                Console.WriteLine(line);
            }
        }
    }

    class Program
    {
        static void Swap<type>(ref type ar1, ref type ar2)
        {
            type temp;
            temp = ar1;
            ar1 = ar2;
            ar2 = temp;
        }

        static void same_av(Example[] exp)
        {
            for (int i=0;i<exp.Length-1;i++)
            {
                for (int j=i+1;j<exp.Length-1;j++)
                {
                    if (exp[i].holder[0]!=null)
                    {
                        if (exp[i].holder[5]==exp[j].holder[5])
                        {
                            exp[i].Info();
                            exp[j].Info();
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
        static void Info(Example[] exp)
        {
            for (int i=0;i<exp.Length;i++)
            {
                if (exp[i] != null)
                {
                    
                    exp[i].Info();
                }
            }
        }
        static void Clear(ref Example[] exp)
        {
            for (int i=0; i<exp.Length;i++)
            {
                for (int j=i+1;j<exp.Length;j++)
                {
                    if (exp[i]==exp[j])
                    {
                        exp[j].holder[0] = null;
                    }
                }
            }
            string path = @"C:\files\progs\Base.txt";
            using (StreamWriter st=new StreamWriter(path,false))
            {
                for(int i=0; i<exp.Length;i++)
                {
                    string line = "";
                    for (int j = 0; i < exp[i].holder.Length - 1; i++)
                    {
                        if (exp[i].holder[0] != null)
                        {
                            line += exp[i].holder[j] + '|';
                        }
                    }
                    if (exp[i].holder[0] != null)
                    {
                        line += exp[i].holder[exp[i].holder.Length - 1];
                        st.WriteLine(line);
                    }
                }
            }
        }
        static void min_max(Example[] exp)
        {
            double min = Convert.ToDouble(exp[0].holder[5]);
            double max = 0;
            int pos_min = 0;
            int pos_max = 0;
            double temp;
            for (int i=0;i<exp.Length;i++)
            {
                for (int j=0;j<exp[i].holder.Length;j++)
                {
                    temp = Convert.ToDouble(exp[i].holder[j]);
                    if (max < temp)
                    {
                        max = temp;
                        pos_max = i;
                    }
                    if (min>temp)
                    {
                        min = temp;
                        pos_min = i;
                    }
                }
            }
            Console.WriteLine("Ячейка с максимальным значением");
            exp[pos_max].Info();
            Console.WriteLine("Ячейка с минимальным значением");
            exp[pos_min].Info();
        }
        static void search_name(Example[] exp)
        {
            string searching_name = Console.ReadLine();
            int count = 0;
            for (int i=0;i<exp.Length;i++)
            {
                if (searching_name==exp[i].holder[0])
                {
                    exp[i].Info();
                }
                else
                {
                    count += 1;
                }
            }
            if (count==exp.Length)
            {
                Console.WriteLine("Человека с таким именем нет в базе данных");
            }
        }
        static void Add(ref Example[] exp)
        {
            int length = exp.Length + 1;
            Array.Resize<Example>(ref exp, length);
            Console.WriteLine("Введите информацию, которую хотите добавить вставляя между элементами базы данных | ");
            int count = 0;
            exp[length - 1] = new Example { line1 = exp[0].line1, holder = exp[length - 1].line1.Split("|") };
            while(count!=4)
            {
                string add = Console.ReadLine();
                string[] add_holder = add.Split("|");

                if (add_holder.Length==9)
                {
                    count = 0;
                    double dub;
                    int num;
                    DateTime date;
                    bool par = double.TryParse(add_holder[5],out dub);
                    if (par == true)
                    {
                        count += 1;
                        exp[length - 1].holder[5] = add_holder[5];
                    }
                    par = int.TryParse(add_holder[8], out num);
                    if (par==true)
                    {
                        count += 1;
                        exp[length - 1].holder[8] = add_holder[8];
                    }
                    par = DateTime.TryParse(add_holder[1], out date);
                    if (par==true)
                    {
                        count += 1;
                        exp[length - 1].holder[1] = add_holder[1];
                    }
                    par = int.TryParse(add_holder[4], out num);
                    if (par == true)
                    {
                        count += 1;
                        exp[length - 1].holder[4] = add_holder[4];
                    }
                    if (count!=4)
                    {
                        Console.WriteLine("Строка введена неверно. Повторите ввод");
                    }
                    exp[length-1].holder[0] = add_holder[0];
                    exp[length-1].holder[2] = add_holder[2];
                    exp[length - 1].holder[3] = add_holder[3];
                    exp[length - 1].holder[7] = add_holder[6];
                    exp[length - 1].holder[6] = add_holder[7];
                }
                else
                {
                    Console.WriteLine("Строка введена неверно. Повторите ввод");
                }
            }
            string path = @"C:\files\progs\Base.txt";
            int i = length - 1;
            using (StreamWriter st=new StreamWriter(path))
            {
                if (exp[i]!=null)
                {
                    if  (exp[i].holder[0] != null)
                    {
                        st.WriteLine($"{exp[i].holder[0]}|{exp[i].holder[1]}|{exp[i].holder[2]}|{exp[i].holder[3]}|{exp[i].holder[4]}|{exp[i].holder[6]}|{exp[i].holder[7]}|{exp[i].holder[8]}|");
                    }

                }
            }
        }

        static void Delete(ref Example[] exp)
        {
            string path = @"C:\files\progs\Base.txt";
            Console.WriteLine("Выберите какой элемент удалить");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer <= exp.Length)
            {
                if (answer >= 0)
                {
                    exp[answer].holder[0] = null;
                }
            }
            using (StreamWriter st = new StreamWriter(path, false))
            {
                for (int i = 0; i < exp.Length; i++)
                {
                    if (exp[i] != null)
                    {
                        if (exp[i].holder[0] != null)
                        {
                            st.WriteLine($"{exp[i].holder[0]}|{exp[i].holder[1]}|{exp[i].holder[2]}|{exp[i].holder[3]}|{exp[i].holder[4]}|{exp[i].holder[6]}|{exp[i].holder[7]}|{exp[i].holder[8]}|");
                        }

                    }
                }
            }
        }
        static void av_sort(Example[] exp)
        {
            for (int i = 0; i < exp.Length - 1; i++)
            {
                for (int j = 0; j < exp.Length - i - 1; j++)
                {
                    if (Convert.ToDouble(exp[j].holder[5]) > Convert.ToDouble(exp[j + 1].holder[5]))
                    {
                        Swap<string>(ref exp[j].holder[5], ref exp[j + 1].holder[5]);
                    }

                }
            }
            for (int i=0;i<exp.Length;i++)
            {
                exp[i].Info();
            }
        }
        static void Date_search(Example[] exp)
        {
            Console.WriteLine("Введите искомую дату рождения в формате ДД.ММ.ГГГГ");
            string ans = "";
            bool par = false;
            int count = 0;
            DateTime ans_date = new DateTime(2001, 1, 1);
            while (par == false)
            {
                ans = Console.ReadLine();
                if (ans != null)
                {
                    DateTime test;
                    bool pari = DateTime.TryParse(ans, out test);
                    if (pari == true)
                    {
                        ans_date = Convert.ToDateTime(ans);
                        par = true;
                    }
                    else
                    {
                        Console.WriteLine("Неправильный ввод даты! Повторите ввод:");
                    }
                }

            }
            count = 0;
            for (int i = 0; i < exp.Length; i++)
            {
                if (exp[i]!=null)
                {
                    if (exp[i].holder[0]!=null)
                    {
                        if (Convert.ToDateTime(exp[i].holder[1]) == ans_date)
                        {
                            exp[i].Info();
                        }
                        else
                        {
                            count += 1;
                        }
                    }
                    else
                    {
                        count += 1;
                    }
                }
                else
                {
                    count += 1;
                }
            }
        }
        static void Main(string[] args)
        {
            string path = @"C:\files\progs\Base_backup.txt";
            string read="";
            using (StreamReader st= new StreamReader(path))
            {
                string line;
                while ((line=st.ReadLine())!=null)
                {
                    read += line + "||";
                }
            }
            string[] hold = read.Split("||");
            Example[] exp= new Example[hold.Length];
            for (int i=0;i<hold.Length-1;i++)
            {
                string line = hold[i];
                exp[i] = new Example { line1 = line, holder=line.Split("|") };
            }
            int ans = Convert.ToInt32(Console.ReadLine());
            switch (ans)
            {
                case 1:
                    Info(exp);
                    break;
                case 3:
                    min_max(exp);
                    break;
                case 2:
                    Clear(ref exp);
                    break;
                case 4:
                    search_name(exp);
                    break;
            }
            string l;
            Console.WriteLine(exp[0].holder[0].ToString());
            for (int i=0;i<exp[0].holder.Length;i++)
            {
                Console.WriteLine(exp[0].holder[0].ToString());
            }
        }
    }
}
