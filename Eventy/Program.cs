using System;

namespace Eventy
{
    class Program
    {
        static void Main(string[] args)
        {
            // EVENTY
            Student student = new Student();

            // Podpięcie/Subskrybcja (jeśli ktoś wywołuje event, moja podpięta metoda się wykona)
            student.DatabaseCall += Student_DatabaseCall;
            student.DatabaseCall += Student_DatabaseCall1;

            student.DatabaseCall -= Student_DatabaseCall1;

            // Potrzebne info o łączeniu się klasy Student z bazą
            student.SetName("Seba");

            Console.ReadKey();
        }

        private static void Student_DatabaseCall1()
        {
            Console.WriteLine("Halo");
        }

        private static void Student_DatabaseCall()
        {
            Console.WriteLine("O, klasa Student łączy się z bazą, najs");
        }
    }
}
