using System;

class Program
{
    struct Lyceum_s
    {
        public string surname;
        public string group;
        public string[] grade;
    }
    enum subjects
    {
        математика = 1,
        русский,
        английский,
        физика,
        програмирование
    }
    static void transfer(Lyceum_s[] lyc, string surname)
    {
        int num = -1;
        for (int i = 0; i < lyc.Length; i++)
        {
            if (lyc[i].surname == surname) num = i;
        }
        if (num != -1)
        {
            string nxt = "";
            string gr_n = Convert.ToString(lyc[num].group[lyc[num].group.Length - 1]);
            for (int i = 0; i < lyc[num].group.Length; i++)
            {
                if (lyc[num].group[i] != '.') nxt += lyc[num].group[i];
                else { break; }
            }
            lyc[num].group = Convert.ToString(Convert.ToInt32(nxt) + 1);
            if (lyc[num].group == "12") Console.WriteLine($"Ученик {lyc[num].surname} выпустился из ЛИТ 1533");
            else
            {
                lyc[num].group = lyc[num].group + "." + gr_n;
                Console.WriteLine($"Ученик {lyc[num].surname} переведен из группы {Convert.ToInt32(nxt) + "." + gr_n} в группу {lyc[num].group}");
            }
        }
        else
        {
            Console.WriteLine("Ученик с указанной фамилией не учится в ЛИТ 1533");
        }
    }
    static void add_mark(Lyceum_s[] lyc, string mark, string surname, int num)
    {
        int std = -1;
        for (int i = 0; i < lyc.Length; i++)
        {
            if (lyc[i].surname == surname) std = i;
        }
        if (std == -1) Console.WriteLine("Такого ученика нет");
        else
        {
            lyc[std].grade[num] += mark;
            Console.WriteLine($"Ученику {lyc[std].surname}, группы {lyc[std].group} добавлена оценка {mark } по предмету {(subjects)Enum.GetValues(typeof(subjects)).GetValue(num)}, теперь его оценки выглядят так: {lyc[std].grade[num]} ");

        }
    }
    static void add_std(int n, out Lyceum_s[] lyc)
    {
        lyc = new Lyceum_s[n];
        for (int i = 0; i < lyc.Length; i++)
        {
            Lyceum_s stud;
            Console.WriteLine("Введите фамилию лицеиста:");
            stud.surname = Console.ReadLine();
            Console.WriteLine("Введите группу лицеиста:");
            stud.group = Console.ReadLine();
            stud.grade = new string[5];
            for (int j = 0; j < 5; j++)
            {
                Console.WriteLine($"Введите строку из оценок по предмету {(subjects)Enum.GetValues(typeof(subjects)).GetValue(j)}");
                stud.grade[j] = Console.ReadLine();
            }
            lyc[i] = stud;
        }

    }
    static double excel_std(string grade)
    {
        double avg_mark = 0;
        for (int j = 0; j < grade.Length; j++)
        {
            avg_mark += Int32.Parse(Convert.ToString(grade[j]));
        }
        avg_mark /= grade.Length;
        return avg_mark;

    }
    static void std_sub_ex(Lyceum_s[] lyc, int num)
    {
        bool end = true;
        Console.WriteLine($"Ученики, являющиеся отличниками и хорошистами по предмету {(subjects)Enum.GetValues(typeof(subjects)).GetValue(num)}: ");
        for (int i = 0; i < lyc.Length; i++)
        {

            if (excel_std((lyc[i].grade)[num]) >= 4.0)
            {
                Console.WriteLine($"{lyc[i].surname}, группа {lyc[i].group}");
                end = false;
            }
        }
        if (end)
        {
            Console.WriteLine("Таких нет");
        }
    }
    static void same_mark(Lyceum_s[] lyc, int num)
    {
        for (int i = 0; i < lyc.Length; i++)
        {
            for (int j = 0; j < lyc.Length; j++)
                if (Math.Abs(excel_std(lyc[i].grade[num]) - excel_std(lyc[j].grade[num])) < 0.1) { 
                    Console.WriteLine($"У учеников {lyc[i].surname} группы {lyc[i].group} и ученика {lyc[j].surname} группы {lyc[j].group} имеют одинаковый балл {Math.Round(excel_std(lyc[i].grade[num]), 2)} по предмету {(subjects)Enum.GetValues(typeof(subjects)).GetValue(num)}"); 
                }
        }
    }
    static void std_gr(Lyceum_s[] lyc, string group)
    {
        Console.WriteLine($"Все студенты группы {group}");
        for (int i = 0; i < lyc.Length; i++)
        {
            if (lyc[i].group == group) Console.WriteLine($"{lyc[i].surname}");
        }
    }
    static void refer(Lyceum_s[] lyc, string surname)
    {
        int n = -1;
        for (int i = 0; i < lyc.Length; i++)
        {
            if (lyc[i].surname == surname) n = i;
        }

        if (n != -1)
        {
            int gr;
            if (lyc[n].group[1] == '.')
            {
                gr = Int32.Parse(Convert.ToString(lyc[n].group[0]));
            }
            else
            {
                gr = Int32.Parse(Convert.ToString(lyc[n].group[0]) + Convert.ToString(lyc[n].group[1]));
            }
            Console.WriteLine($"Дана {lyc[n].surname}");
            Console.WriteLine($"обучающаяся в {lyc[n].group}  классе.");
            Console.WriteLine($"Дата окончания обучения 30 июня {2023 + 11 - gr}");
        }
        else
        {
            Console.WriteLine("Ученик с таким именем не обучается в ЛИТ 1533");
        }
    }
    public static void Main()
    {

        int p = 0;
        foreach (var x in Enum.GetNames(typeof(subjects)))
        {

            Console.WriteLine($"{p}: {x}");
            p++;
        }
        Console.WriteLine("Введите количество учеников, обучающихся в ЛИТ 1533:");
        int n = int.Parse(Console.ReadLine());
        Lyceum_s[] lyc = new Lyceum_s[n];
        add_std(n, out lyc);
        Console.WriteLine("Введите номер предмета, отличников и хорошистов вы хотите увидеть, список предметов указан выше");
        int num = int.Parse(Console.ReadLine());
        std_sub_ex(lyc, num);
        Console.WriteLine("Введите группу, учеников которой вы хотите найти ");
        string group = Console.ReadLine();
        std_gr(lyc, group);
        Console.WriteLine("Введите фамилию студента, которому надо добавить оценку");
        string surn = Console.ReadLine();
        Console.WriteLine("Введите номер предмета, по которому ученик получил оценку");
        int num1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите оценку, которую получил ученик");
        string mark = Console.ReadLine();
        add_mark(lyc, mark, surn, num1);
        Console.WriteLine("Введите фамилию ученика, справку которого нужно получить справку ");
        string surn2 = Console.ReadLine();
        refer(lyc, surn2);
        Console.WriteLine("Введите фамилию ученика, которого надо перевести на класс старше");
        string surn3 = Console.ReadLine();
        transfer(lyc, surn3);
        Console.WriteLine("Введите номер предмета, по которому у учеников должен быть одинаковый балл");
        int num3 = int.Parse(Console.ReadLine());
        same_mark(lyc, num3);
    }
}
