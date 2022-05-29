using System;

namespace Eventy
{
    public class Student
    {
        public string Name { get; private set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Pesel { get; set; }
        public string PhoneNumber { get; set; }

        // Event (event musi być jakimś delegatem)
        public event Action DatabaseCall;
        // GOOD TO KNOW, 'event' nadaje dodatkowych funkcjonalności delegatom
        //{
        //    add
        //    {
        //        Console.WriteLine("KTOŚ PODPINA");
        //        DatabaseCall += value;
        //    }
        //    remove
        //    {
        //        Console.WriteLine("KTOŚ ODPINA");
        //        DatabaseCall -= value;
        //    }
        //}

        public void SetName(string name)
        {
            string invalidName = GetInvalidNameFromDb();

            if (name == invalidName)
            {
                Console.WriteLine("Panu dziękujemy");
                return;
            }

            Name = name;
        }

        private string GetInvalidNameFromDb()
        {
            // Wywołanie eventu
            DatabaseCall?.Invoke();

            //if (DatabaseCall != null)
            //{
            //    DatabaseCall.Invoke();
            //}

            return "Seba";
        }
    }
}