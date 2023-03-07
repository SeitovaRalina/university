using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace university
{
    class Person
    {
        public string? F { get; set; }
        public string? I { get; set; } = null;
        public string? O { get; set; } = null;
        public void Print() 
        {
            Console.WriteLine($"Здравствуйте, {F} {I} {O}");
        }
        public string PrintFIO()
        {
            return $"{F} {I} {O}";
        }
    }
    class Student : Person
    {
        public string group { get; set; }
        public Dictionary<string, int> depts { get; set; }
        public Student(string F, string I, string O, string group, Dictionary<string, int> depts)
        {
            this.F = F;
            this.I = I;
            this.O = O;
            this.group = group;
            this.depts = depts;
        }
        public void Lox(int mark)
        {
            if (mark == 0)
                Console.WriteLine($"{group} | {F} {I} {O} | долг");
            else
                Console.WriteLine($"{group} | {F} {I} {O} | пересдача");
        }
    }
    class Teacher : Person
    {
        public List<string> groups { get; set; }
        public List<string> subjects { get; set; }
        public Teacher(string F, string I, string O, List<string> groups, List<string> subjects)
        {
            this.F = F;
            this.I = I;
            this.O = O;
            this.groups = groups;
            this.subjects = subjects;
        }
    }
    class Boss : Person
    {
        public List<string> id_orders { get; set; }
        private Dictionary<string, string> orders = new Dictionary<string, string>()
        {
            ["t1"] = "Определиться с датой и принять задолженности у студентов",
            ["t2"] = "Подготовить отчет к 08.03.2023",
            ["s1"] = "Зарегистрироваться на сайте LeaderID",
            ["s2"] = "Сделать лабораторную работу по программированию",
            ["s3"] = "Похихикать с мемов про Звёздную",
            ["h1"] = "Придти на концерт, посвященный 8 марту",
            ["h2"] = "Присоединиться к серверу OmSTU AMCS и прислать своего питомца в pmifi-pets",
            ["r1"] = "Разобрать новогоднюю елку и снять гирлянды, пришла весна!",
            ["r2"] = "Помыть 2 этаж 8-го корпуса, кто-то пролил сок и рассыпал макароны",
            ["a1"] = "Хорошо покушать в кафе главного корпуса!",
            ["a2"] = "Вкусно покушать в столовой 6-го корпуса!",
            ["a3"] = "Отменно покушать в буфете 8-го корпуса!"
        };
        public Boss(string F, string I, string O, List<string> id)
        {
            this.F = F;
            this.I = I;
            this.O = O;
            id_orders = id;
        }
        public void Prikaz(string id)
        {
            Console.WriteLine($"{F} {I} {O} выдал(а) приказ: \"{orders[id]}\"");
        }
        public void Orders()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\t\t\t\t\t\t- Выданные приказы -");
            Console.ForegroundColor = ConsoleColor.White;
            int i = 1;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\t Обозначения: для t - учителей, s - студентов, h - учителей и студентов, r - работников, a - всех");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (string id in id_orders)
            {
                Console.WriteLine($"{i}. {id} - {orders[id]}");
                i++;
            }
        }
    }
    class Rab : Person
    {
        string job;
        public Rab(string F, string I, string O, string job)
        {
            this.F = F;
            this.I = I;
            this.O = O;
            this.job = job;
        }
        public void Print_job()
        {
            Console.WriteLine($"В ОмГТУ вы работаете по професии: {job}");
        }
    }
}
