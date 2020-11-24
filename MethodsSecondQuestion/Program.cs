using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MethodsSecondQuestion
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задача №2.
            // 2.1. Создать метод, принимающий текст и возвращающий слово, содержащее минимальное количество букв.
            // 2.2. Создать метод, принимающий текст и возвращающий слово(слова) с максимальным количеством букв.
            // Примечание: слова в тексте могут быть разделены символами (пробелом, точкой, запятой)
            // Пример: Текст: "А ББ ВВВ ГГГГ ДДДД ДД ЕЕ ЖЖ ЗЗЗ"
            // 1. Ответ: А
            // 2. Ответ: ГГГГ, ДДДД

            // Решение задачи 2.

            //Текст, из которого будем возвращать слово, содержащее минимальное количество букв.
            string text = "А ББ ВВВ ГГГГ Т ДДДД ДД ЕЕ ЖЖ ЗЗЗ";
            Console.WriteLine(text);

            // Возвращение в переменную самого короткого слова при помощи созданного метода
            string minSymbol = MinSymbolText(text);

            Console.Write("\nСлово, содержащее минимальное количество букв: ");
            Console.Write($">>{minSymbol}<<");

            // Возвращение в строчный массив самых длинных(длинного) слов(слова) 
            string[] maxSymbol = MaxSymbolText(text);

            Console.WriteLine("\nСлово или слова, содержащие максимальное количество букв: ");

            PrintArray(maxSymbol);

            Console.ReadKey();

        }


        /// <summary>
        /// Метод, принимающий текст и возвращающий слово, содержащее минимальное количество букв (первое его вхождение).
        /// </summary>
        /// <param name = "text" ></ param >
        /// < returns ></ returns >
        private static string MinSymbolText(string text)
        {
            // Создает массив символов для последующего разбиения строки
            char[] separator = { '.', ',', ' ' };

            // Разбивает строку в новый строчный массив через метод "split" с ипользованием сепаратора
            string[] newText = text.Split(separator);

            // Создает переменную для последующего хранения минимального количества символов слова
            int minLength = newText[0].Length;

            // Создает переменную в которую положит минимальное слово
            string minSymbol = newText[0];

            int row = newText.Length;

            for (int i = 0; i < row; i++)
            {
                if (newText[i].Length <= minLength && newText[i].Length != 0)
                {
                    minLength = newText[i].Length;
                }
            }

            for (int i = 0; i < row; i++)
            {
                if (newText[i].Length == minLength)
                {
                    minSymbol = newText[i];
                    break;
                }
            }

            return minSymbol;
        }

        /// <summary>
        /// Метод, принимающий текст и возвращающий слово(слова) с максимальным количеством букв.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private static string[] MaxSymbolText(string text)
        {
            // Создает массив символов для последующего разбиения строки
            char[] separator = { '.', ',', ' ' };

            // Разбивает строку в новый строчный массив через метод "split" с ипользованием сепаратора
            string[] newText = text.Split(separator);

            // Создает переменную для последующего хранения масимального коливества символов слова
            int maxChar = 1;

            int row = newText.Length;

            // Цикл для поиска максимально длинного слова 
            for (int i = 0; i < row; i++)
            {
                if (newText[i].Length > maxChar)
                {
                    maxChar = newText[i].Length;
                }
            }

            // Создает счетик и цикл в котором считает число слов с максимальным количеством элементов,
            // для того чтобы узнать величину возвращаемого массива
            int counter = 0;
            for (int i = 0; i < row; i++)
            {
                if (maxChar == newText[i].Length)
                {
                    counter++;
                }
            }

            // Инициализирует массив, в который будут добавляться масимально длинные слова 
            string[] result = new string[counter];
            counter = 0;

            for (int i = 0; i < row; i++)
            {
                if (maxChar == newText[i].Length)
                {
                    result[counter] = newText[i];
                    counter++;
                }
            }

            return result;
        }

        /// <summary>
        /// Метод, печатающий строковый массив
        /// </summary>
        /// <param name="arr"></param>
        private static void PrintArray(string[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($">>{item}<<");
            }
        }

    }
}
