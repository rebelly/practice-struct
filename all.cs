using System;

namespace ConsoleApp1
{
    struct Lesson
    {
        public int classroom;
        public string t_name;
        public string group;
        public string lesson;
        public int num;

    }
    class Program
    {
        enum lesson
        {
            математика,
            русский_язык,
            окружающий_мир,
            чтение,

        }

        static void output_tt(lesson[] mas)
        {
            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine(mas.Length);
            }
        }


        static void iniz_tt(out lesson[] mas)
            
        {
            Lesson les;
            for (int i = 0; i < 6; i++)
            {
                les.classroom = int.Parse(Console.ReadLine());
                les.t_name = (Console.ReadLine());
                les.group = (Console.ReadLine());
                
                les.classroom = int.Parse(Console.ReadLine());
                les.classroom = int.Parse(Console.ReadLine());
                mas[i] = les;
            }

        }
        static void Main(string[] args)


        {
            
        }
    }
}
