using System;
using System.Collections.Generic;

namespace lab_05_cw
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //List<int> nums = new List<int>();

            //// STRINGI
            //ObservableList1<string> names = new ObservableList1<string>();
            //names.Add("Seba");
            //names.Add("Daniel");
            //names.Add("Arek");
            //names.Add("Zbigniew");
            //names.Add("Jan");

            //string name = names[4];
            //names[4] = "asdad";
            //names[2] = "gggg";
            //names[1] = "ffsdf";

            //string myName = names.Get(10);
            //names.Set(5, "Daniel");


            //// INTY
            //ObservableList1<int> numbers = new ObservableList1<int>();
            //numbers.Add(666);
            //numbers[4] = 2;
            //numbers[2] = 1;
            //numbers[1] = 4;
            //int myNumber = numbers.Get(2);
            //numbers.Set(5, 10);

            //// BOOLE
            //ObservableList1<bool> thoughts = new ObservableList1<bool>();
            //thoughts.Add(true);
            //thoughts[4] = true;
            //thoughts[2] = false;
            //thoughts[1] = true;
            //bool trueOrFalse = thoughts.Get(2);
            //thoughts.Set(5, false);

            //List<int> numbers = new List<int> { 1, 2, 3, 4 };

            //// Pobranie wartości indexerem
            //int number = numbers[2];

            //// Ustawienie wartości indexerem
            //numbers[2] = 69;

            ObservableList1<string> names = new ObservableList1<string>();
            names.Added += () => Console.WriteLine("Dodano");
            names.Removed += () => Console.WriteLine("Usunięto");
            names.Updated += () => Console.WriteLine("Kolekcja zmodyfikowana");
            //names.Updated += () =>
            //{
            //    Console.WriteLine("Kolekcja zmodyfikowana");
            //    Console.WriteLine("Kolejna linia kodu");
            //};

            while (true)
            {
                Console.WriteLine("1. Dodaj");
                Console.WriteLine("2. Wyświetl");
                Console.WriteLine("3. Usuń");

                string option = null;
                while (true)
                {
                    Console.Write("Opcja: ");
                    option = Console.ReadLine(); 
                    if (option == "1" || option == "2" || option == "3")
                    {
                        break;
                    }
                }

                switch (option)
                {
                    case "1":
                        Console.Write("Podaj imię: ");
                        string name = Console.ReadLine();
                        names.Add(name);
                        break;
                    case "2":
                        for (int i = 0; i < names.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}. {names[i]}");
                        }
                        break;
                    case "3":
                        Console.Write("Podaj imię do usunięcia: ");
                        int nameToRemove = Convert.ToInt32(Console.ReadLine());
                        names.RemoveAt(nameToRemove);
                        break;
                }

                Console.WriteLine();
                Console.Write("Naciśnij klawisz aby wrócić...");
                Console.ReadKey();
                Console.Clear();
            }

        }
    }

    public class ObservableList1<T>
    {
        public int Count => _list.Count;

        private List<T> _list = new List<T>();

        public event Action Added;
        public event Action Updated;
        public event Action Removed;

        public void Add(T item)
        {
            _list.Add(item);
            Added?.Invoke();
            Updated?.Invoke();
        }

        public T Get(int index)
        {
            return _list[index];
        }

        public void Set(int index, T item)
        {
            _list[index] = item;
            Updated?.Invoke();
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
            Removed?.Invoke();
            Updated?.Invoke();
        }

        public T this[int index]
        {
            get => _list[index];
            set 
            {
                _list[index] = value;
                Updated?.Invoke();
            }
        }

        // Poniżej tylko przykład jak można setter zapisywać
        private int myVar;

        public int MyProperty
        {
            get
            {
                Console.WriteLine();
                return myVar;
            }
         // set => myVar = value;
            set
            {
                Console.WriteLine();
                myVar = value;
            }
        }

    }
}