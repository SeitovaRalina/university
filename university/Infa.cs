using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace university
{
    class Infa
    {
        // из файлов
        public List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            string path = @"C:\Users\seito\source\repos\university\university\Преподы.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                int cnt = int.Parse(reader.ReadLine());
                for (int i = 0; i < cnt; i++)
                {
                    string[] ticha = reader.ReadLine().Split();
                    string line1 = reader.ReadLine();
                    List<string> groups = line1.Split().ToList();
                    string line2 = reader.ReadLine();
                    List<string> students = line2.Split().ToList();
                    teachers.Add(new Teacher(ticha[0], ticha[1], ticha[2], groups, students));
                }
            }
            return teachers;
        }
        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            string path = @"C:\Users\seito\source\repos\university\university\Студенты.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                int cnt = int.Parse(reader.ReadLine());
                for (int i = 0; i < cnt; i++)
                {
                    string[] FIO = reader.ReadLine().Split();
                    string group = reader.ReadLine();
                    string[] subjects = reader.ReadLine().Split();
                    Dictionary<string, int> s = new Dictionary<string, int>();
                    for (int j = 0; j < subjects.Length - 1; j = j + 2)
                    {
                        int mark = int.Parse(subjects[j + 1]);
                        if (mark == 0 || mark == 2)
                        {
                            s.Add(subjects[j], mark);
                        }
                    }
                    students.Add(new Student(FIO[0], FIO[1], FIO[2], group, s));
                }
            }
            return students;
        }
        public List<Boss> GetBosses()
        {
            List<Boss> bs = new List<Boss>();
            string path = @"C:\Users\seito\source\repos\university\university\Управление.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                int cnt = int.Parse(reader.ReadLine());
                for (int i = 0; i < cnt; i++)
                {
                    string[] FIO = reader.ReadLine().Split();
                    List<string> id = reader.ReadLine().Split().ToList();
                    bs.Add(new Boss(FIO[0], FIO[1], FIO[2], id));
                }
            }
            return bs;
        }
        public List<Rab> GetRabs()
        {
            List<Rab> rabs = new List<Rab>();
            string path = @"C:\Users\seito\source\repos\university\university\Работники.txt";
            using (StreamReader reader = new StreamReader(path))
            {
                int cnt = int.Parse(reader.ReadLine());
                for (int i = 0; i < cnt; i++)
                {
                    string[] FIO = reader.ReadLine().Split();
                    string job = reader.ReadLine();
                    rabs.Add(new Rab(FIO[0], FIO[1], FIO[2], job));
                }
            }
            return rabs;
        }
    }
    class Select : Infa
    {
        public void Do_orders(List<string> a)
        {
            //связать идентификатор приказа и ФИО босса
            foreach (Boss boss in GetBosses())
            {
                foreach (string p in boss.id_orders)
                {
                    foreach (string i in a)
                    {
                        if (p[0] == char.Parse(i)) boss.Prikaz(p);
                    }
                }
            }
        }
        //вводится фамилия преподователя и предмет, который нужен, чтобы посмотреть каким студентам надо сдать долг/назначить пересдачу
        public void Deptors(Teacher teacher, string sub)
        {

            foreach (string g in teacher.groups)
            {
                foreach (Student student in GetStudents())
                {
                    if (student.group == g) //если препод ведет у этой группы
                    {
                        foreach (var s in student.depts)
                        {
                            if (sub == s.Key)
                            {
                                student.Lox(s.Value);
                            }
                        }
                    }
                }
            }
        }
        public void Dolg(Student student)
        {
            bool flag = false;
            foreach (Teacher teacher in GetTeachers())
            {
                foreach (string grup in teacher.groups)
                {
                    if (student.group == grup)
                    {
                        foreach (string subj in teacher.subjects)
                        {
                            foreach (var s in student.depts)
                            {
                                if (s.Key == subj)
                                {
                                    flag = true;
                                    Console.WriteLine($"{subj} - {s.Value} \t| подойти к {teacher.PrintFIO()} ");
                                }
                            }
                        }
                    }
                }
            }
            if (!flag) Console.WriteLine("Ура! У вас нет задолженностей:)");
        }

    }
    class Menu : Select
    {
        public void I_boss (string f)
        {
            Console.WriteLine();
            bool flag = false;
            foreach (Boss boss in GetBosses())
            {
                if (f == boss.F)
                {
                    flag = true;
                    boss.Print();
                    Console.WriteLine();
                    boss.Orders();
                }
            }
            if (!flag) Console.WriteLine("Такого сотрудника нет среди управляющего персонала.");
        }
        public void I_prepod(string f)
        {
            Console.WriteLine();
            bool flag = false;
            foreach (Teacher teacher in GetTeachers())
            {
                if (f == teacher.F)
                {
                    flag = true;
                    teacher.Print();
                    Console.WriteLine();
                    Console.WriteLine("1. Посмотреть на приказы");
                    Console.WriteLine("2. Список должников по определенному предмету");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("!Выбор осуществляется с помощью цифр! Выберите 1 или 2: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (number == 1)
                    {
                        Console.WriteLine("\t\t Приказы для преподователей");
                        List<string> list = new List<string>() { "t", "h", "a" };
                        Do_orders(list);
                    }
                    else if (number == 2)
                    {
                        Console.Write("Введите предмет: ");
                        string subject = Console.ReadLine();
                        Deptors(teacher, subject);
                    }
                }
            }
            if (!flag) Console.WriteLine("Такого сотрудника нет среди преподавательского состава.");
        }
        public void I_student(string f)
        {
            Console.WriteLine();
            bool flag = false;
            foreach (Student student in GetStudents())
            {
                if (f == student.F)
                {
                    flag = true;
                    student.Print();
                    Console.WriteLine();
                    Console.WriteLine("1. Посмотреть на приказы");
                    Console.WriteLine("2. Взглянуть на долги");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("!Выбор осуществляется с помощью цифр! Выберите 1 или 2: ");
                    Console.ForegroundColor = ConsoleColor.White;
                    int number = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    if (number == 1)
                    {
                        Console.WriteLine("\t\t Приказы для студентов");
                        List<string> list = new List<string>() { "s", "h", "a" };
                        Do_orders(list);
                    }
                    else if (number == 2)
                    {
                        Dolg(student);
                    }
                }
            }
            if (!flag) Console.WriteLine("Такого студента в универстите нет.");
        }
        public void I_rab(string f)
        {
            Console.WriteLine();
            bool flag = false;
            foreach (Rab rab in GetRabs())
            {
                if (f == rab.F)
                {
                    flag = true;
                    rab.Print();
                    rab.Print_job();
                    Console.WriteLine();
                    Console.WriteLine("\t\t Приказы для обслуживающего персонала");
                    List<string> list = new List<string>() {"r", "a" };
                    Do_orders(list);
                }
            }
            if (!flag) Console.WriteLine("Такого сотрудника нет среди обслуживающего персонала.");
        }
    }
}   