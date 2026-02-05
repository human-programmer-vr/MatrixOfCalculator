using System;

namespace MatrixOfCalculator.Classes
{
    public class AutomaticsInputDataToMatrix
    {
        private static Random _rand = new Random();

        /// <summary>
        /// Автоматическое заполнение массива данными
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] AutoInput(double[,] matrix)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++)
                    matrix[x, y] = _rand.Next(-30, 30);

            return matrix;
        }
    }
}