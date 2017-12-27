using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example
{
    class Program
    {
        public class PersonCompare : IEqualityComparer<Person>
        {
            public bool Equals(Person a, Person b)
            {
                return a.Age == b.Age && a.Name == b.Name;
            }

            public int GetHashCode(Person obj)
            {
                return obj.GetHashCode();
            }
        }

        public class Person
        {
            public int Age { get; set; }
            public string Name { get; set; }

            //public override bool Equals(object obj)
            //{
            //    Person p1 = obj as Person;
            //    if (p1 == null)
            //    {
            //        return false;
            //    }
            //    return p1.Age == this.Age && p1.Name == this.Name;
            //}

            public static bool operator ==(Person a, Person b)
            {
                return a.Age == b.Age && a.Name == b.Name;
            }

            public static bool operator !=(Person a, Person b)
            {
                return a.Age != b.Age || a.Name != b.Name;
            }
        }

        static void Main(string[] args)
        {
            int num1 = 100;
            int num2 = 100;
            Console.WriteLine(num1.Equals(num2));

            PersonCompare pCompare = new PersonCompare();

            Person p1 = new Person();
            Person p2 = new Person();
            Console.WriteLine($"Normal {p1.Equals(p2)}"); //Normal Compare
            Console.WriteLine($"pCompare {pCompare.Equals(p1, p2)}"); //Used IEqualityComparer Interface

            string s1 = "Hello";
            string s2 = "Hello";

            Console.WriteLine(s1.Equals(s2));

            Console.ReadKey();
        }
    }
}
