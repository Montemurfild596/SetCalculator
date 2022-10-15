using System;
using System.Collections.Generic;

namespace SetCalculator
{
	class Set
    {
		private string name;
		private List<int> elementsSet;
		public Set()
        {
			this.name = "";
			this.elementsSet = new List<int>();
        }
		public Set(string name, List<int> elem)
        {
			this.name = name;
			for (int i = 0; i < elem.Count; ++i)
            {
				this.elementsSet.Add(elem[i]);
            }
        }
		public Set(Set temp)
        {
			this.name = temp.name;
        }

		// размер множества
		public int GetSize()
        {
			return this.elementsSet.Count;
        }

		// заполнение множества с помощью датчика случайных чисел
		public void RandomFilling(int a, int b)
        {
			Console.Write("Введите имя множества: ");
			this.name = Console.ReadLine();
			int size;
			bool isExistToInterval, isPositive;
			do
			{
				size = Functions.InputTypeInteger("Введите размер множества: ");
				isExistToInterval = (size <= (b - a + 1));
				isPositive = size >= 0;
				if (!isExistToInterval)
                {
					Console.WriteLine("Ошибка: введённое значение количества элементов множества превышает разность границ");
                }
				else if (!isPositive)
                {
					Console.WriteLine("Ошибка: введённое значение количества элементов множества отрицательное");
                }
			} while (!isPositive || !isExistToInterval);
			Random rnd = new Random();
			int temp = rnd.Next(a, b + 1);
			for (int i = 0; i < size; ++i)
            {
				if (i != 0)
				{
					bool isExistInSet;
					do
					{
						isExistInSet = false;
						temp = rnd.Next(a, b + 1);
						Console.WriteLine("Start: " + temp);
						for (int j = 0; j < i && !isExistInSet; ++j)
                        {
							Console.Write(elementsSet[j] + " ");
							if (this.elementsSet[j] == temp)
                            {
								isExistInSet = true;
                            }
                        }
						Console.WriteLine();
						Console.WriteLine(temp);
					} while (isExistInSet);
					this.elementsSet.Add(temp);
					Console.WriteLine("Добавлен элемент");
				}
				else this.elementsSet.Add(temp);
			}
        }

		// заполнение множества пользователем
		public void UserFilling(int a, int b)
        {
			Console.Write("Введите имя множества: ");
			this.name = Console.ReadLine();
			int size, temp;
			bool isExistToInterval, isPositive;
			do
			{
				size = Functions.InputTypeInteger("Введите размер множества: ");
				isExistToInterval = (size <= (b - a + 1));
				isPositive = size >= 0;
				if (!isExistToInterval)
				{
					Console.WriteLine("Ошибка: введённое значение количества элементов множества превышает разность границ");
				}
				else if (!isPositive)
				{
					Console.WriteLine("Ошибка: введённое значение количества элементов множества отрицательное");
				}
			} while (!isPositive || !isExistToInterval);
			for (int i = 0; i < size; ++i)
            {
				if (i != 0)
                {
					bool isExistInSet = false;
					do
					{
						temp = Functions.InputValueInIntegerRange(a, b);
						for (int j = 0; j < i && !isExistInSet; ++j)
						{
							isExistInSet = (this.elementsSet[j] == temp);
						}
					} while (isExistInSet);
					this.elementsSet.Add(temp);
				}
				else
                {
					this.elementsSet.Add(Functions.InputValueInIntegerRange(a, b));
                }
            }
		}

		public void RangeFilling(int a, int b)
        {
			this.name = "U";
			for (int i = a; i <= b; ++i)
            {
				this.elementsSet.Add(i);
            }
        }

		// вывод множества на экран
		public void Print()
        {
			Console.Write(this.name + " : ");
			if (this.GetSize() != 0)
            {
				foreach (int temp in this.elementsSet)
                {
					Console.Write(temp + " ");
                }
				Console.WriteLine();
            } 
			else
            {
				Console.WriteLine("Пустое множество");
            }
        }
    }

	class Functions
    {

		// ввод целого числа
		public static int InputTypeInteger(string message)
		{
			int n;
			string buf;
			bool isCorrectInput = false;
			do
			{
				Console.Write(message);
				buf = Console.ReadLine();
				isCorrectInput = Int32.TryParse(buf, out n);
				if (!isCorrectInput)
				{
					Console.WriteLine("Ошибка: введённое значение не соответствует типу integer");
				}
			} while (!isCorrectInput);
			return n;
		}

		// функция ввода границ универсума
		public static void InputBoundaryUniversum(out int lowerBoundary, out int upperBoundary)
		{
			string buf;

			// переменные для проверки границ универсума (верхняя больше нижней, обе положительные и целочисленные)
			bool isCorrectUpperBoundaryInput, isCorrectLowerBoundaryInput, isUpperMoreThanLower = false, isNotPositiveBoundary = false, isNotAllRight = false;
			do
			{
				Console.Write("Введите нижнюю границу универсума: ");
				buf = Console.ReadLine();
				isCorrectLowerBoundaryInput = Int32.TryParse(buf, out lowerBoundary);
				Console.Write("Введите верхнюю границу универсума: ");
				buf = Console.ReadLine();
				isCorrectUpperBoundaryInput = Int32.TryParse(buf, out upperBoundary);
				if (!isCorrectUpperBoundaryInput || !isCorrectLowerBoundaryInput)
				{
					if (!isCorrectUpperBoundaryInput && !isCorrectLowerBoundaryInput)
					{
						Console.WriteLine("Ошибка: значения нижней и верхней границ универсума не соответствует типу integer");
					}
					else if (!isCorrectUpperBoundaryInput)
					{
						Console.WriteLine("Ошибка: значение верхней границы универсума не соответствует типу integer");
					}
					else
					{
						Console.WriteLine("Ошибка: значение нижней границы универсума не соответствует типу integer");
					}
				}
				else
				{
					isNotPositiveBoundary = (lowerBoundary <= 0 || upperBoundary <= 0);
					isUpperMoreThanLower = upperBoundary >= lowerBoundary;
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
				isNotAllRight = !isCorrectUpperBoundaryInput || !isCorrectLowerBoundaryInput || !isUpperMoreThanLower || isNotPositiveBoundary;
			} while (isNotAllRight);
		}
		public static int InputValueInIntegerRange(int a, int b)
        {
			int result;
			bool isExistRange = false;
			do
			{
				result = Functions.InputTypeInteger("Введите значение нового элемента множества, лежащего в отрезке [" + a + "; " + b + "] : ");
				isExistRange = result <= b && result >= a;
				if (!isExistRange)
                {
					Console.WriteLine("Ошибка: введённое значение не принадлежит заданному отрезку");
                }
			} while (!isExistRange);
			return result;
        }
	}

    class Program
    {
		static void Main(string[] args)
        {
			int lowerBoundary, upperBoundary;
			Functions.InputBoundaryUniversum(out lowerBoundary, out upperBoundary);
			Set a = new Set(), b = new Set(), c = new Set();
			a.RandomFilling(lowerBoundary, upperBoundary);
			b.UserFilling(lowerBoundary, upperBoundary);
			c.RangeFilling(lowerBoundary, upperBoundary);
			a.Print();
			b.Print();
			c.Print();

        }
		
	}
}
