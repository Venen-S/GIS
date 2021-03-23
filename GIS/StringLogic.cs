using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace GIS
{
    public static class StringLogic
    {
        /// <summary>
        /// Получение хэша строки по SHA 256 алгоритму
        /// </summary>
        /// <param name="str"></param>
        /// <returns>хэш строки</returns>
        internal static string Sha256HashString(string str)
        {
            byte[] data = Encoding.Default.GetBytes(str);
            var result = new SHA256Managed().ComputeHash(data);

            return BitConverter.ToString(result).Replace("-", "").ToLower();
        }

        /// <summary>
        /// Перестановка слов в строке в обратном порядке
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        internal static string StringReverse(string str)
        {
            string[] reverse = str.Split(' ');
            Array.Reverse(reverse);
            string coup = String.Empty;
            for (int i = 0; i < reverse.Length; i++)
            {
                coup += reverse[i] + " ";
            }

            return coup;
        }

        /// <summary>
        /// Получение всех символов в строке (в т.ч. и пробелов) и подсчет количества каждого символа
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Возвращает словарь из чаров и интов</returns>
        internal static Dictionary<char, int> NumberSymbols(string str)
        {
            var result = str
                .GroupBy(s => s)
                .ToDictionary(g => g.Key, g => g.Count());

            return result;
        }
    }
}