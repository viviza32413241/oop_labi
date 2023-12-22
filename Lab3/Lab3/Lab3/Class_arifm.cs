using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    // Похідний клас для арифметичної прогресії
    class Class_arifm : Class_base
    {
        public Class_arifm(int n) : base(n)
        {
        }

        // Перевизначення властивості Step
        public override int Step
        {
            get { return base.Step; }
            set { base.Step = value; }
        }

        // Реалізація методу для пошуку суми
        public override int sum(int k)
        {
            int sum = 0;
            for (int i = 0; i < k; i++)
            {
                sum += k_elem(i + 1);
            }
            return sum;
        }

        // Реалізація методу для пошуку k-го елемента
        public override int k_elem(int k)
        {
            return FirstElement + (k - 1) * Step;
        }

        // Метод для пошуку наступного елемента
        private int next(int prev, int step)
        {
            return prev + step;
        }

        // Метод, що генерує масив N елементів послідовності
        public void array_value()
        {
            int current = FirstElement;
            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = current;
                current = next(current, Step);
            }
        }
    }
}
