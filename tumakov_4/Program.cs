using System;

namespace tumakov_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();
        }

        #region Упражнение 5.1

        public static void Task1()
        {
            Console.WriteLine("Упражнение 5.1 - Возвращает наибольшее из двух целых чисел");
            Console.WriteLine("Введите два целых числа: ");

            if (!int.TryParse(Console.ReadLine(), out var num1) || !int.TryParse(Console.ReadLine(), out var num2))
            {
                Console.WriteLine("Ошибка: неверный ввод");
                return;
            }

            Console.WriteLine($"Наибольшее из двух чисел - это {GetMax(num1, num2)}");
            Console.ReadKey();
        }

        /// <summary>Выводит наибольшее из двух чисел</summary>
        /// <param name="num1">Первое число для сравнения</param>
        /// <param name="num2">Второе число для сравнения</param>
        /// <returns>Наибольшее число</returns>
        public static int GetMax(int num1, int num2)
        {
            return num1 > num2 ? num1 : num2;
        }

        #endregion

        #region Упражнение 5.2

        public static void Task2()
        {
            Console.WriteLine("Упражнение 5.2 - Меняет местами значения двух параметров");
            Console.WriteLine("Введите два числа: ");

            var isNum1 = int.TryParse(Console.ReadLine(), out var num1);
            var isNum2 = int.TryParse(Console.ReadLine(), out var num2);

            if (!isNum1 || !isNum2)
            {
                Console.WriteLine("Ошибка: неверный ввод");
                return;
            }

            Swap(ref num1, ref num2);

            Console.WriteLine($"Значения после обмена: num1 = {num1}, num2 = {num2}");
            Console.ReadKey();
        }

        /// <summary>Меняет местами два числа</summary>
        /// <param name="num1">Первое число</param>
        /// <param name="num2">Второе число</param>
        public static void Swap(ref int num1, ref int num2)
        {
            var copy = num1;
            num1 = num2;
            num2 = copy;
        }

        #endregion

        #region Упражнение 5.3

        public static void Task3()
        {
            Console.WriteLine("Упражнение 5.3 - Вычисление факториала с помощью checked");
            Console.WriteLine("Введите число: ");

            if (!int.TryParse(Console.ReadLine(), out var number) || number < 0)
            {
                Console.WriteLine("Ошибка: неверный ввод");
                return;
            }

            if (!Factorial(number, out long result))
            {
                Console.WriteLine("Произошло переполнение, дальнейшие расчёты ошибочны");
            }
            else
            {
                Console.WriteLine($"{number}! = {result}");
            }

            Console.ReadKey();
        }

        /// <summary>Вычисляет факториал числа</summary>
        /// <param name="num">Число, для которого факториал вычисляется</param>
        /// <param name="fact">Результат, факториал числа</param>
        /// <returns>true, если вычисление прошло успешно, false при переполнении</returns>
        public static bool Factorial(int num, out long fact)
        {
            fact = 1;
            try
            {
                checked
                {
                    for (int i = 2; i <= num; i++)
                    {
                        fact *= i;
                    }
                }

                return true;
            }
            catch (OverflowException)
            {
                return false;
            }
        }

        #endregion

        #region Упражнение 5.4

        public static void Task4()
        {
            Console.WriteLine("Упражнение 5.4 - Рекурсивный метод вычисления факториала");
            Console.WriteLine("Введите число: ");

            if (!int.TryParse(Console.ReadLine(), out var number) || number < 0)
            {
                Console.WriteLine("Ошибка: неверный ввод");
                return;
            }

            try
            {
                var factorial = Factorial(number);
                Console.WriteLine($"{number}! = {factorial}");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Произошло переполнение, дальнейшие расчёты ошибочны");
            }

            Console.ReadKey();
        }

        /// <summary>Вычисление факториала через рекурсию</summary>
        /// <param name="number">Число, для которого вычисляется факториал</param>
        /// <returns>Результат вычисления, факториал числа</returns>
        public static long Factorial(int number)
        {
            if (number <= 1)
            {
                return 1;
            }
            checked
            {
                return number * Factorial(number - 1);
            }
        }

        #endregion

        #region Домашнее задание 5.1

        public static void Task5()
        {
            Console.WriteLine("Домашнее задание 5.1 - Вычислить НОД для двух и трёх чисел");
            Console.WriteLine("Введите три числа: ");

            if (!int.TryParse(Console.ReadLine(), out var num1) || !int.TryParse(Console.ReadLine(), out var num2) || !int.TryParse(Console.ReadLine(), out var num3) ||
                num1 <= 0 || num2 <= 0)
            {
                Console.WriteLine("Ошибка: неверный ввод");
                return;
            }

            Console.WriteLine($"НОД для двух чисел:\n{num1} и {num2} равен {EuclidAlgorhitm(num1, num2)}\n{num2} и {num3} равен {EuclidAlgorhitm(num2, num3)}" +
                $"\n{num3} и {num1} равен {EuclidAlgorhitm(num3, num1)}");
            Console.WriteLine($"НОД для трёх чисел {num1}, {num2}, и {num3} равен {EuclidAlgorhitm(num1, num2, num3)}");
            Console.ReadKey();
        }

        /// <summary>Вычисление НОД двух чисел</summary>
        /// <param name="num1">Первое число</param>
        /// <param name="num2">Второе число</param>
        /// <returns>Наибольший общий делитель (НОД) двух чисел</returns>
        public static int EuclidAlgorhitm(int num1, int num2)
        {
            while (num2 != 0)
            {
                var copy = num2;
                num2 = num1 % num2;
                num1 = copy;
            }

            return num1;
        }

        /// <summary>Вычисление НОД трёх чисел</summary>
        /// <param name="num1">Первое число</param>
        /// <param name="num2">Второе число</param>
        /// <param name="num3">Третье число</param>
        /// <returns>Наибольший общий делитель (НОД) трёх чисел</returns>
        public static int EuclidAlgorhitm(int num1, int num2, int num3)
        {
            return EuclidAlgorhitm(EuclidAlgorhitm(num1, num2), num3);
        }

        #endregion

        #region Домашнее задание 5.2

        public static void Task6()
        {
            Console.WriteLine("Домашнее задание 5.2 - Вычислить значение n-го числа ряда Фибоначчи");
            Console.WriteLine("Введите номер числа: ");

            if (!int.TryParse(Console.ReadLine(), out var number) || number <= 0)
            {
                Console.WriteLine("Ошибка: неверный ввод");
                return;
            }

            Console.WriteLine($"F({number}) = {Fibonacci(number)}");
            Console.ReadKey();
        }

        /// <summary>Вычисляет значения n-ого числа ряда Фибоначчи</summary>
        /// <param name="number">n-ое число</param>
        /// <returns>Значение числа n в ряде Фибоначчи</returns>
        public static int Fibonacci(int number)
        {
            if (number <= 2)
            {
                return 1;
            }

            return Fibonacci(number - 1) + Fibonacci(number - 2);
        }

        #endregion
    }
}