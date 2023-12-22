using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    // Базовий клас для числової послідовності
    abstract class Class_base
    {
        protected int[] sequence; // Захищений масив послідовності
        private int firstElement; // Перший елемент послідовності
        private int step; // Крок послідовності

        // Конструктор базового класу
        protected Class_base(int n)
        {
            sequence = new int[n];
        }

        // Властивість для читання та запису першого елемента
        public int FirstElement
        {
            get { return firstElement; }
            set { firstElement = value; }
        }

        // Віртуальна властивість для читання та запису кроку
        public virtual int Step
        {
            get { return step; }
            set { step = value; }
        }

        // Метод, що повертає елементи масиву
        public int[] return_elements()
        {
            return sequence;
        }

        // Абстрактний метод для пошуку суми
        public abstract int sum(int k);

        // Абстрактний метод для пошуку k-го елемента
        public abstract int k_elem(int k);
    }
}
