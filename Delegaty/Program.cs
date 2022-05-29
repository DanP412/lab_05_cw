using Eventy;
using System;
using System.Linq;

namespace Delegaty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // DELEGATY

            string name = "Seba";
            bool isHungry = true;

            // Action = void
            Action actionWithLambda = new Action(() => { Console.WriteLine("Odpalenie z metodki anonimowej"); });
            actionWithLambda.Invoke();

            Action actionWithMethod = new Action(Test);
            actionWithMethod.Invoke();

            TestWithArguments("Mój parametr");
            Action<string> actionWithMethodWithArguments = new Action<string>(TestWithArguments);
            actionWithMethodWithArguments.Invoke("Mój parametr");

            Func<int> func = new Func<int>(() => 5);
            int funcResult = func.Invoke();
            Console.WriteLine($"Wynik metody anonimowej to: {funcResult}");

            Console.WriteLine("\n");

            Student student = new Student
            {
                Surname = "Ziobro",
                Age = 50,
                Pesel = "1234567",
                PhoneNumber = "123 456 789"
            };

            //student.DatabaseCall += () =>
            //{
            //    Console.WriteLine("DATABASE CALL");
            //    Console.WriteLine("DATABASE CALL");
            //    Console.WriteLine("DATABASE CALL");
            //};

            student.SetName("Zbigniew");

            DisplayStudentInfo(student, phoneNumber => Console.WriteLine($"+48 {phoneNumber}"));
            Console.WriteLine();
            DisplayStudentInfo(student, phoneNumber => Console.WriteLine($"+48 {string.Join(string.Empty, phoneNumber.Take(3))} {string.Join(string.Empty, phoneNumber.Skip(3).Take(3))} {string.Join(string.Empty, phoneNumber.Skip(6).Take(3))}"));

            Console.ReadKey();
        }

        private static void Test()
        {
            Console.WriteLine("Odpalam test");
        }

        private static void TestWithArguments(string stringArg)
        {
            Console.WriteLine($"Odpalam test, a argumentem jest: {stringArg}");
        }

        private static void DisplayStudentInfo(Student student, Action<string> phoneNumberDisplay)
        {
            Console.WriteLine($"Name: {student.Name}");
            Console.WriteLine($"Surname: {student.Surname}");
            Console.WriteLine($"Age: {student.Age}");
            Console.WriteLine($"Pesel: {student.Pesel}");
            //Console.WriteLine($"Phone Number: {student.Pesel}");
            //Console.WriteLine($"Phone Number: {student.Pesel}");
            phoneNumberDisplay.Invoke(student.PhoneNumber);
        }
    }
}
