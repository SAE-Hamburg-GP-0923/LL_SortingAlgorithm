using System.Runtime.CompilerServices;

namespace LL_SortingAlgorithm
{
    internal class Program
    {

        static int[] usedArray;
        private static int randomArrayLength = 10;

        static void Main(string[] args)
        {

            ChooseCustomArray();
            int userChoice = ChooseSortingAlgorithm(1, 3);
            switch (userChoice)
            {
                case 1:
                    usedArray.BubbleSort();
                    break;
                case 2:
                    usedArray.MergeSort();
                    break;
                case 3:
                    usedArray.QuickSort(0, usedArray.Length - 1);
                    break;
            }
            int printChoice = ChoosePrintMethod(1, 3);
            switch (printChoice)
            {
                case 1:
                    Console.WriteLine("Du hast Aufsteigend gewählt! Hier ist dein Array:");
                    break;
                case 2:
                    Console.WriteLine("Du hast Absteigend gewählt! Hier ist dein Array:");
                    usedArray.SortDecending();
                    break;
                case 3:
                    Console.WriteLine("Du hast Zick-Zack gewählt! Hier ist dein Array:");
                    usedArray.SortZigZag();
                    break;
            }
            Print();
        }

        private static int ChoosePrintMethod(int _minInput, int _maxInput)
        {
            while (true)
            {
                Console.WriteLine("Wähle die Ausgabemethode!");
                Console.WriteLine("[1] - Aufsteigend");
                Console.WriteLine("[2] - Absteigend");
                Console.WriteLine("[3] - Zick-Zack");
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int intInput) && intInput >= _minInput && intInput <= _maxInput)
                {
                    return intInput;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Bitte gebe einen Wert in dem angezeigten Bereich ein!");
                }
            }
        }

        private static int ChooseSortingAlgorithm(int _minInput, int _maxInput)
        {
            while (true)
            {
                Console.WriteLine("Wähle den Algorithmus mit dem du sortieren möchtest!");
                Console.WriteLine("[1] - Bubblesort");
                Console.WriteLine("[2] - Mergesort");
                Console.WriteLine("[3] - Quicksort");
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int intInput) && intInput >= _minInput && intInput <= _maxInput)
                {
                    return intInput;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Bitte gebe einen Wert in dem angezeigten Bereich ein!");
                }
            }
        }

        static void ChooseCustomArray()
        {
            bool validInput = false;
            while (!validInput)
            {

                Console.WriteLine("Möchtest du ein eigenes Array anlegen oder ein zufälliges bekommen?");
                Console.WriteLine("(Y/N)");
                ConsoleKeyInfo userInput = Console.ReadKey(true);
                switch (userInput.Key)
                {
                    case ConsoleKey.Y:
                        validInput = true;
                        usedArray = CreateUserArray();
                        break;
                    case ConsoleKey.N:
                        validInput = true;
                        usedArray = CreateRandomArray();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Bitte drücke entweder (Y) oder (N)!");
                        break;
                }
            }
        }

        private static int[] CreateUserArray()
        {
            usedArray = ChooseArrayLenght(1, 10);
            usedArray = ChooseArrayContent(1, 100);
            return usedArray;
        }

        private static int[] ChooseArrayContent(int _minInput, int _maxInput)
        {
            bool validInput;
            int[] tempArray = new int[usedArray.Length];
            for (int i = 0; i < usedArray.Length; i++)
            {
                validInput = false;
                while (!validInput)
                {
                    Console.WriteLine($"Gebe die gewünschte Zahl für die Position {i + 1} ein!");
                    Console.WriteLine($"Die Zahl muss zwischen {_minInput} und {_maxInput} liegen!");
                    var userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out int intInput) && intInput >= _minInput && intInput <= _maxInput)
                    {
                        validInput = true;
                        tempArray[i] = intInput;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Bitte gebe einen Wert in dem angezeigten Bereich ein!");
                    }
                }
            }
            return tempArray;
        }

        private static int[] ChooseArrayLenght(int _min, int _max)
        {
            while (true)
            {
                Console.WriteLine($"Gebe die größe des zu sortierenden Arrays ein! Maximalwert ist {_max}!");
                var userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int intInput) && intInput >= _min && intInput <= _max)
                {
                    return new int[intInput];
                }
                else
                {
                    Console.WriteLine("Bitte gebe keinen Wert ein der größer als der Maximalwert oder niedriger als 0 ist!");
                }
            }
        }

        private static int[] CreateRandomArray()
        {
            Random random = new Random();
            int[] randomArray = new int[randomArrayLength];
            for (int i = 0; i < randomArrayLength; i++)
            {
                randomArray[i] = random.Next(1, 101);
            }
            return randomArray;
        }

        static void Print()
        {
            foreach (int i in usedArray)
            {
                Console.Write(i + " ");
            }
        }
    }
}