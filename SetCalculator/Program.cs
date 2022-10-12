using System;
using System.Collections.Generic;

namespace SetCalculator
{
	class Universum
    {
		private int lowerBoundary, upperBoundary;
		public int LowerBoundary
        {
			get
            {
				return this.lowerBoundary;
            }
			set
            {
				this.lowerBoundary = value;
            }
        }
		public int UpperBoundary
        {
			get
            {
				return this.upperBoundary;
            }
			set
            {
				this.upperBoundary = value;
            }
        }

		// конструктор без параметров
		public Universum()
        {
			this.InputBoundaryUniversum();
        }

		// констуктор копирования
		public Universum(Universum temp)
        {
			this.lowerBoundary = temp.LowerBoundary;
			this.upperBoundary = temp.UpperBoundary;
        }

		// функция ввода границ универсума
		public void InputBoundaryUniversum()
		{
			string buf;

			// переменные для проверки границ универсума (верхняя больше нижней, обе положительные и целочисленные)
			bool isCorrectUpperBoundaryInput, isCorrectLowerBoundaryInput, isUpperMoreThanLower = false, isNotPositiveBoundary = false;
			do
			{
				Console.Write("Введите нижнюю границу универсума: ");
				buf = Console.ReadLine();
				isCorrectLowerBoundaryInput = Int32.TryParse(buf, out this.lowerBoundary);
				Console.Write("Введите верхнюю границу универсума: ");
				buf = Console.ReadLine();
				isCorrectUpperBoundaryInput = Int32.TryParse(buf, out this.upperBoundary);
				if (!isCorrectUpperBoundaryInput || !isCorrectLowerBoundaryInput)
				{
					if (!isCorrectUpperBoundaryInput && !isCorrectLowerBoundaryInput)
					{
						Console.WriteLine("Ошибка: значения нижней и верхней границ универсума не соответствует типу unsigned integer");
					}
					else if (!isCorrectUpperBoundaryInput)
					{
						Console.WriteLine("Ошибка: значение верхней границы универсума не соответствует типу unsigned integer");
					}
					else
					{
						Console.WriteLine("Ошибка: значение нижней границы универсума не соответствует типу unsigned integer");
					}
				}
				else
				{
					isNotPositiveBoundary = (this.LowerBoundary <= 0 || this.UpperBoundary <= 0);
					isUpperMoreThanLower = this.UpperBoundary >= this.LowerBoundary;
					if (!isUpperMoreThanLower || isNotPositiveBoundary)
					{
						if (isNotPositiveBoundary)
						{
							Console.WriteLine("Ошибка: одна из границ меньше или равна 0");
						}
						else if (!isUpperMoreThanLower)
						{
							Console.WriteLine("Ошибка: значение нижней границы универсума больше верхней границы");
						}
					}
				}
			} while (!isCorrectUpperBoundaryInput || !isCorrectLowerBoundaryInput || !isUpperMoreThanLower || isNotPositiveBoundary);
		}
	}

	class Set
    {
		private string nameSet;
		private List<int> elementsSet;
		public Set()
        {
			this.nameSet = "";
			this.elementsSet = null;
        }
		public Set(string name, List<int> elem)
        {
			this.nameSet = name;
			for (int i = 0; i < elem.Count; ++i)
            {
				this.elementsSet.Add(elem[i]);
            }
        }
		public Set(Set temp)
        {
			this.nameSet = temp.nameSet;
        }

    }

    class Program
    {
		static void Main(string[] args)
        {
			Universum universum = new Universum();
			Console.WriteLine("Boundaries: " + universum.LowerBoundary + " : " + universum.UpperBoundary);

        }
    }
}
