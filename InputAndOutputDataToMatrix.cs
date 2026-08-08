using System;
using System.Text;
using System.Windows.Forms;

namespace MatrixOfCalculator.Classes
{
    public class InputAndOutputDataToMatrix 
    {
        private static Random _rand = new Random();
        private static StringBuilder _stringBuilder = new StringBuilder();

        public static float[,] HandleInput(float[,] matrix, params float[] data)
        {
            for (int x = 0, index = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++, index++)
                    matrix[x, y] = data[index];

            return matrix;
        }

        public static float[,] AutoInput(float[,] matrix)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++)
                    matrix[x, y] = _rand.Next(-30, 30);

            return matrix;
        }

        public static void AutoInputBothMatrix(float[,] matrixOne, float[,] matrixTwo)
        {
            AutoInput(matrixOne);
            AutoInput(matrixTwo);
        }

        public static void OutputData(float[,] matrix, TextBox output)
        {
            UserInterface.ClearOutputWindow(output, _stringBuilder);

            for (int x = 0; x < matrix.GetLength(0); x++)
            {
                for (int y = 0; y < matrix.GetLength(1); y++)
                    _stringBuilder.Append(Math.Round(matrix[x, y], 2) + "\t");

                _stringBuilder.AppendLine();
            }

            output.Text = _stringBuilder.ToString();
        }
    }
}
