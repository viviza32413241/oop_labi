using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class OneDimensionalArray
    {
        private int[] elements;

        public OneDimensionalArray(int[] elements)
        {
            this.elements = elements;
        }


        // Перевизначення оператора "+" для суми двох одновимірних масивів
        public static OneDimensionalArray operator +(OneDimensionalArray array1, OneDimensionalArray array2)
        {

            int maxLength = Math.Max(array1.elements.Length, array2.elements.Length);
            int[] result = new int[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                int value1 = (i < array1.elements.Length && array1.elements[i] != null) ? array1.elements[i] : 0;
                int value2 = (i < array2.elements.Length && array2.elements[i] != null) ? array2.elements[i] : 0;

                result[i] = value1 + value2;
            }

            return new OneDimensionalArray(result);
        }

        // Перевизначення оператора "*" для множення всіх елементів на число С
        public static OneDimensionalArray operator *(OneDimensionalArray array, int C)
        {
            int[] result = new int[array.elements.Length];

            for (int i = 0; i < array.elements.Length; i++)
            {
                result[i] = array.elements[i] * C;
            }

            return new OneDimensionalArray(result);
        }

        // Перевизначення оператора "--" для зменшення всіх елементів на 4
        public static OneDimensionalArray operator --(OneDimensionalArray array)
        {
            int[] result = new int[array.elements.Length];

            for (int i = 0; i < array.elements.Length; i++)
            {
                result[i] = array.elements[i] - 4;
            }

            return new OneDimensionalArray(result);
        }

        // Перевизначення оператора "==" для порівняння двох одновимірних масивів
        public static bool operator ==(OneDimensionalArray array1, OneDimensionalArray array2)
        {
            if (array1.elements.Length != array2.elements.Length) return false;

            for (int i = 0; i < array1.elements.Length; i++)
            {
                if (array1.elements[i] != array2.elements[i]) return false;
            }

            return true;
        }

        // Перевизначення оператора "!=" для порівняння двох одновимірних масивів
        public static bool operator !=(OneDimensionalArray array1, OneDimensionalArray array2)
        {
            return !(array1 == array2);
        }

        // Перевизначення методу Equals для порівняння об'єктів
        public override bool Equals(object obj)
        {
            if (obj is OneDimensionalArray)
            {
                return this == (OneDimensionalArray)obj;
            }

            return false;
        }
        public override string ToString()
        {
            return "[" + string.Join(", ", this.elements) + "]";
        }

        public static void testAddArray()
        {
            OneDimensionalArray array1 = new OneDimensionalArray(new int[] { 3, 2, 4 });
            OneDimensionalArray array2 = new OneDimensionalArray(new int[] { 2, 4, 8 });

            OneDimensionalArray result = array1 + array2;

            OneDimensionalArray expected = new OneDimensionalArray(new int[] { 5, 6, 12 });

            if (expected.Equals(result)) Console.WriteLine("[№1] Тест пройдено успiшно!");

            Console.WriteLine("- Массив 1: {0}", array1.ToString());
            Console.WriteLine("- Массив 2: {0}", array2.ToString());
            Console.WriteLine("- Результат: {0}", result.ToString());

        }

        public static void testMultiplicationArray()
        {
            OneDimensionalArray array = new OneDimensionalArray(new int[] { 3, 2, 4 });

            OneDimensionalArray result = array * 2;

            OneDimensionalArray expected = new OneDimensionalArray(new int[] { 6, 4, 8 });

            if (expected.Equals(result)) Console.WriteLine("[№2] Тест пройдено успiшно!");

            Console.WriteLine("- Массив: {0}", array.ToString());
            Console.WriteLine("- Результат: {0}", result.ToString());
            Console.WriteLine("- Очiкувано: {0}", expected.ToString());
        }

        public static void testDecrementArray()
        {
            OneDimensionalArray array = new OneDimensionalArray(new int[] { 8, 9, 5 });

            OneDimensionalArray result = array;
            --result;
            OneDimensionalArray expected = new OneDimensionalArray(new int[] { 4, 5, 1 });

            if (expected.Equals(result)) Console.WriteLine("[№3] Тест пройдено успiшно!");

            Console.WriteLine("- Массив: {0}", array.ToString());
            Console.WriteLine("- Результат: {0}", result.ToString());
            Console.WriteLine("- Очiкувано: {0}", expected.ToString());
        }

        public static void testEqualArray()
        {
            OneDimensionalArray array1 = new OneDimensionalArray(new int[] { 3, 2, 4, 1 });
            OneDimensionalArray array2 = new OneDimensionalArray(new int[] { 3, 2, 4, 1 });

            bool result = array1 == array2;

            if (result) Console.WriteLine("[№4] Тест пройдено успiшно!");

            Console.WriteLine("- Массив 1: {0}", array1.ToString());
            Console.WriteLine("- Массив 2: {0}", array2.ToString());
            Console.WriteLine("- Результат: {0}", result.ToString());
        }
    }
}