using System;
using System.IO;

namespace Lab_2._2
{
    class Program
    {
        static void Swap<type>(ref type ar1, ref type ar2)
        {
            type temp;
            temp = ar1;
            ar1 = ar2;
            ar2 = temp;
        }
        static void same_av(string[] name_base, DateTime[] birth_base, string[] inst_base, string[] group_base, int[] course_base, double[] av_mark_base, string[] form_base, string[] level_base, int[] ows_base)
        {
            for (int i = 0; i < name_base.Length; i++)
            {
                for (int j = i; j < name_base.Length; j++)
                {
                    if (av_mark_base[i] == av_mark_base[j])
                    {
                        Console.WriteLine($"{name_base[j]}|{birth_base[j]}|{inst_base[j]}|{group_base[j]}|{course_base[j]}|{av_mark_base[j]}|{form_base[j]}|{level_base[j]}|{ows_base[j]}");
                    }
                }
            }
        }
        static void clear(ref string[] name_base, ref DateTime[] birth_base, ref string[] inst_base, ref string[] group_base, ref int[] course_base, ref double[] av_mark_base, ref string[] form_base, ref string[] level_base, ref int[] ows_base)
        {
            for (int i = 0; i < name_base.Length; i++)
            {
                for (int j = i + 1; j < name_base.Length; j++)
                {
                    if (name_base[i] == name_base[j])
                    {
                        name_base[j] = null;
                    }
                }
            }
            string path = @"C:\files\progs\Base.txt";
            using (StreamWriter st = new StreamWriter(path, false))
            {
                for (int i = 0; i < name_base.Length; i++)
                {
                    if (name_base[i] != null)
                    {
                        if (name_base[i] != " ")
                        {
                            st.WriteLine($"{name_base[i]}|{birth_base[i]}|{inst_base[i]}|{group_base[i]}|{course_base[i]}|{av_mark_base[i]}|{form_base[i]}|{level_base[i]}|{ows_base[i]}");
                        }

                    }
                }
            }
        }
        static void min_max(string[] name_base, DateTime[] birth_base, string[] inst_base, string[] group_base, int[] course_base, double[] av_mark_base, string[] form_base, string[] level_base, int[] ows_base)
        {
            double min = av_mark_base[0];
            double max = 0;
            int pos_min = 0;
            int pos_max = 0;
            for (int t = 0; t < av_mark_base.Length; t++)
            {
                if (min > av_mark_base[t] && name_base[t] != null)
                {
                    min = av_mark_base[t];
                    pos_min = t;
                }
                if (max < av_mark_base[t] && name_base[t] != null)
                {
                    max = av_mark_base[t];
                    pos_max = t;
                }
            }
            Console.WriteLine("Ячейка с макисмальным средним баллом аттестата:");
            int i = pos_max;
            Console.WriteLine($"{name_base[i]}|{birth_base[i]}|{inst_base[i]}|{group_base[i]}|{course_base[i]}|{av_mark_base[i]}|{form_base[i]}|{level_base[i]}|{ows_base[i]}");
            i = pos_min;
            Console.WriteLine("Ячейка с минимальным средним баллом аттестата:");
            Console.WriteLine($"{name_base[i]}|{birth_base[i]}|{inst_base[i]}|{group_base[i]}|{course_base[i]}|{av_mark_base[i]}|{form_base[i]}|{level_base[i]}|{ows_base[i]}");

        }
        static void name_search(string[] name_base, DateTime[] birth_base, string[] inst_base, string[] group_base, int[] course_base, double[] av_mark_base, string[] form_base, string[] level_base, int[] ows_base)
        {
            string searching_name = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < name_base.Length; i++)
            {
                if (name_base[i].Contains(searching_name) == true)
                {
                    Console.WriteLine($"{name_base[i]}|{birth_base[i]}|{inst_base[i]}|{group_base[i]}|{course_base[i]}|{av_mark_base[i]}|{form_base[i]}|{level_base[i]}|{ows_base[i]}"); ;
                }
                else
                {
                    count += 1;
                }
            }
            if (count == name_base.Length)
            {
                Console.WriteLine("Человека с таким именем нет в базе данных");
            }
        }
        static void Add(ref string[] name_base, ref DateTime[] birth_base, ref string[] inst_base, ref string[] group_base, ref int[] course_base, ref double[] av_mark_base, ref string[] form_base, ref string[] level_base, ref int[] ows_base)
        {
            int length = name_base.Length + 1;
            Array.Resize<string>(ref name_base, length);
            Array.Resize<DateTime>(ref birth_base, length);
            Array.Resize<string>(ref inst_base, length);
            Array.Resize<string>(ref group_base, length);
            Array.Resize<int>(ref course_base, length);
            Array.Resize<double>(ref av_mark_base, length);
            Array.Resize<string>(ref form_base, length);
            Array.Resize<string>(ref level_base, length);
            Array.Resize<int>(ref ows_base, length);
            Console.WriteLine("Введите информацию, которую хотите добавить вставляя между элементами базы данных |");
            int count = 0;
            while (count != 4)
            {
                string add = Console.ReadLine();
                string[] add_holder = add.Split("|");

                if (add_holder.Length == 9)
                {
                    count = 0;
                    double doub;
                    int num;
                    DateTime date;
                    bool par = double.TryParse(add_holder[5], out doub);
                    if (par == true)
                    {
                        count += 1;
                        av_mark_base[length - 1] = Convert.ToDouble(add_holder[5]);

                    }
                    par = int.TryParse(add_holder[8], out num);
                    if (par == true)
                    {
                        count += 1;
                        ows_base[length - 1] = Convert.ToInt32(add_holder[8]);
                    }
                    par = DateTime.TryParse(add_holder[1], out date);
                    if (par == true)
                    {
                        count += 1;
                        birth_base[length - 1] = Convert.ToDateTime(add_holder[1]);
                    }
                    par = int.TryParse(add_holder[4], out num);
                    if (par == true)
                    {
                        count += 1;
                        course_base[length - 1] = Convert.ToInt32(add_holder[4]);
                    }
                    if (count != 4)
                    {
                        Console.WriteLine("Строка введена неверно. Повторите ввод");
                    }
                    name_base[length - 1] = add_holder[0];
                    inst_base[length - 1] = add_holder[2];
                    group_base[length - 1] = add_holder[3];
                    form_base[length - 1] = add_holder[6];
                    level_base[length - 1] = add_holder[7];
                }
                else
                {
                    Console.WriteLine("Строка введена неверно. Повторите ввод");
                }

            }

            string path = @"C:\files\progs\Base.txt";
            int i = length - 1;
            using (StreamWriter st = new StreamWriter(path, true))
            {
                st.WriteLine($"{name_base[i]}|{birth_base[i]}|{inst_base[i]}|{group_base[i]}|{course_base[i]}|{av_mark_base[i]}|{form_base[i]}|{level_base[i]}|{ows_base[i]}");
            }

        }
        static void Delete(ref string[] name_base, ref DateTime[] birth_base, ref string[] inst_base, ref string[] group_base, ref int[] course_base, ref double[] av_mark_base, ref string[] form_base, ref string[] level_base, ref int[] ows_base)
        {
            string path = @"C:\files\progs\Base.txt";
            Console.WriteLine("Выберите какой элемент удалить");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer <= name_base.Length)
            {
                if (answer >= 0)
                {
                    name_base[answer] = null;
                }
            }
            using (StreamWriter st = new StreamWriter(path, false))
            {
                for (int i = 0; i < name_base.Length - 1; i++)
                {
                    if (name_base[i] != null)
                    {
                        st.WriteLine($"{name_base[i]}|{birth_base[i]}|{inst_base[i]}|{group_base[i]}|{course_base[i]}|{av_mark_base[i]}|{form_base[i]}|{level_base[i]}|{ows_base[i]}");
                    }
                }
            }

        }
        static void av_Sort(string[] name_base, DateTime[] birth_base, string[] inst_base, string[] group_base, int[] course_base, double[] av_mark_base, string[] form_base, string[] level_base, int[] ows_base)
        {
            for (int i = 0; i < name_base.Length - 1; i++)
            {
                for (int j = 0; j < name_base.Length - i - 1; j++)
                {
                    if (birth_base[j] > birth_base[j + 1])
                    {
                        Swap<DateTime>(ref birth_base[j], ref birth_base[j + 1]);
                        Swap<String>(ref name_base[j], ref name_base[j + 1]);
                        Swap<double>(ref av_mark_base[j], ref av_mark_base[j + 1]);
                        Swap<int>(ref course_base[j], ref course_base[j + 1]);
                        Swap<string>(ref inst_base[j], ref inst_base[j + 1]);
                        Swap<string>(ref group_base[j], ref group_base[j + 1]);
                        Swap<string>(ref form_base[j], ref form_base[j + 1]);
                        Swap<string>(ref level_base[j], ref level_base[j + 1]);
                        Swap<int>(ref ows_base[j], ref ows_base[j + 1]);
                    }

                }
            }
            for (int i = 1; i < name_base.Length; i++)
            {
                Console.WriteLine($"{name_base[i]}|{birth_base[i]}|{inst_base[i]}|{group_base[i]}|{course_base[i]}|{av_mark_base[i]}|{form_base[i]}|{level_base[i]}|{ows_base[i]}");
            }
        }
        static void date_Search(string[] name_base, DateTime[] birth_base, string[] inst_base, string[] group_base, int[] course_base, double[] av_mark_base, string[] form_base, string[] level_base, int[] ows_base)
        {
            Console.WriteLine("Введите искомую дату рождения в формате ДД.ММ.ГГГГ");
            string ans = "";
            bool par = false;
            int count = 0;
            DateTime ans_date=new DateTime(2001,1,1);
            while (par == false)
            {
                ans = Console.ReadLine();
                if (ans != null)
                {
                    DateTime test;
                    bool pari = DateTime.TryParse(ans,out test);
                    if (pari==true)
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
            for (int i = 0; i < name_base.Length - 1; i++)
            {
                if (ans_date == birth_base[i])
                {
                    Console.WriteLine($"{name_base[i]}|{birth_base[i]}|{inst_base[i]}|{group_base[i]}|{course_base[i]}|{av_mark_base[i]}|{form_base[i]}|{level_base[i]}|{ows_base[i]}");
                }
                else
                {
                    count += 1;
                }
            }
            if (count == (name_base.Length))
            {
                Console.WriteLine("Человека с такой датой рождения нет");
            }
        }
        static void Info(string[] name_base, DateTime[] birth_base, string[] inst_base, string[] group_base, int[] course_base, double[] av_mark_base, string[] form_base, string[] level_base, int[] ows_base)
        {
            for (int i = 0; i < name_base.Length; i++)
            {
                if (name_base[i] != null)
                {
                    Console.WriteLine($"{name_base[i]}|{birth_base[i]}|{inst_base[i]}|{group_base[i]}|{course_base[i]}|{av_mark_base[i]}|{form_base[i]}|{level_base[i]}|{ows_base[i]}");
                }
            }
        }
        static void Menu()
        {
            string path = @"C:\files\progs\Base.txt";
            string reader = "";
            using (StreamReader s = new StreamReader(path))
            {
                string f;
                while ((f = s.ReadLine()) != null)
                {
                    reader += f + "/";
                }
            }
            string[] holder = reader.Split("/");
            string[] name_base = new string[holder.Length];
            DateTime[] birth_base = new DateTime[holder.Length];
            string[] inst_base = new string[holder.Length];
            string[] group_base = new string[holder.Length];
            int[] course_base = new int[holder.Length];
            double[] av_mark_base = new double[holder.Length];
            string[] form_base = new string[holder.Length];
            string[] level_base = new string[holder.Length];
            int[] ows_base = new int[holder.Length];
            for (int i = 0; i < holder.Length - 1; i++)
            {
                string[] holder_person = holder[i].Split("|");
                name_base[i] = holder_person[0];
                inst_base[i] = holder_person[2];
                group_base[i] = holder_person[3];
                course_base[i] = Convert.ToInt32(holder_person[4]);
                av_mark_base[i] = Convert.ToDouble(holder_person[5]);
                birth_base[i] = Convert.ToDateTime(holder_person[1]);
                form_base[i] = holder_person[6];
                level_base[i] = holder_person[7];
                ows_base[i] = Convert.ToInt32(holder_person[8]);

            }
            Console.WriteLine("Выберите что вы хотите сделать: 1-Вывести базу данных. 2-Найти человека по дате рождения. 3-Отсортировать по дате рождения 4-Удалить элемент 5-Завершить работу");
            bool end = false;
            while (end == false)
            {
                string modes = Console.ReadLine();
                int num;
                bool pars = int.TryParse(modes, out num);
                if (pars == true)
                {
                    int mode = Convert.ToInt32(modes);
                    if (mode == 1)
                    {
                        Info(name_base, birth_base, inst_base, group_base, course_base, av_mark_base, form_base, level_base, ows_base);
                    }
                    else
                    {
                        if (mode == 2)
                        {
                            date_Search(name_base, birth_base, inst_base, group_base, course_base, av_mark_base, form_base, level_base, ows_base);
                        }
                        else
                        {
                            if (mode == 3)
                            {
                                av_Sort(name_base, birth_base, inst_base, group_base, course_base, av_mark_base, form_base, level_base, ows_base);
                            }
                            else
                            {
                                if (mode == 4)
                                {
                                    Delete(ref name_base, ref birth_base, ref inst_base, ref group_base, ref course_base, ref av_mark_base, ref form_base, ref level_base, ref ows_base);
                                    Info(name_base, birth_base, inst_base, group_base, course_base, av_mark_base, form_base, level_base, ows_base);
                                }
                                else
                                {
                                    if (mode == 5)
                                    {
                                        end = true;
                                    }
                                    else
                                    {
                                        if (mode == 6)
                                        {
                                            Add(ref name_base, ref birth_base, ref inst_base, ref group_base, ref course_base, ref av_mark_base, ref form_base, ref level_base, ref ows_base);
                                        }
                                        else
                                        {
                                            if (mode == 7)
                                            {
                                                min_max(name_base, birth_base, inst_base, group_base, course_base, av_mark_base, form_base, level_base, ows_base);
                                            }
                                            else
                                            {
                                                if (mode == 8)
                                                {
                                                    clear(ref name_base, ref birth_base, ref inst_base, ref group_base, ref course_base, ref av_mark_base,ref form_base,ref level_base,ref ows_base);
                                                }
                                                else
                                                {
                                                    if (mode == 9)
                                                    {
                                                        same_av(name_base, birth_base, inst_base, group_base, course_base, av_mark_base, form_base, level_base, ows_base);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                }
                            }

                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
