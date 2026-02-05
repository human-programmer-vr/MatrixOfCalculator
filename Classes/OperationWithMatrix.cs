using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MatrixOfCalculator.Classes
{
    public class OperationWithMatrix
    {
        private static double[,] _temp;

        /// <summary>
        /// Заполнение данных матрицы через ручной ввод данных
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double[,] HandleInput(double[,] matrix, params double[] input)
        {
            for (int x = 0, index = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++, index++)
                    matrix[x, y] = input[index];

            return matrix;
        }

        /// <summary>
        /// Умножает матрицу на введённое число
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="multiplicate"></param>
        /// <returns></returns>
        public static double[,] MultiplicateNumberOnMatrix(double[,] matrix, int multiplicate)
        {
            _temp = new double[matrix.GetLength(0), matrix.GetLength(1)];

            for (int x = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++)
                    _temp[x,y] = matrix[x, y] * multiplicate;

            return _temp;
        }

        /// <summary>
        /// Находит определитель матрицы 2-го порядка
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static double FindDeterminantTwoOnTwo(double[,] matrix)
        {
            return (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);
        }

        /// <summary>
        /// Находит определитель матрицы 3-го порядка
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static double FindDeterminantThreeOnThree(double[,] matrix)
        {
            return 
                matrix[0, 0] * matrix[1, 1] * matrix[2, 2] +
                matrix[0, 1] * matrix[1, 2] * matrix[2, 0] +
                matrix[1, 0] * matrix[2, 1] * matrix[0, 2] -
                matrix[0, 2] * matrix[1, 1] * matrix[2, 0] -
                matrix[0, 1] * matrix[1, 0] * matrix[2, 2] -
                matrix[1, 2] * matrix[2, 1] * matrix[0, 0];
        }

        /// <summary>
        /// Находит обратную матрицу
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] ReverseMatrix(double[,] matrix)
        {
            _temp = new double[matrix.GetLength(0), matrix.GetLength(1)];

            if (matrix.Length != 4 && matrix.Length != 9)
                return matrix;

            double determinant = 0;

            if (matrix.Length == 4)
            {
                determinant = FindDeterminantTwoOnTwo(matrix);

                if (determinant == 0)
                    return _temp;

               _temp = TransposeMatrix(matrix);
            }
            
            if (matrix.Length == 9)
            {
                determinant = FindDeterminantThreeOnThree(matrix);

                if (determinant == 0)
                    return matrix;

                _temp = TransposeMatrix(matrix);

                double firstNumber = (matrix[1, 1] * matrix[2, 2]) - (matrix[1, 2] * matrix[2, 1]);
                double secondNumber = (matrix[1, 0] * matrix[2, 2]) - (matrix[2, 0] * matrix[1, 2]);
                double thirdNumber = (matrix[1, 0] * matrix[2, 1]) - (matrix[1, 1] * matrix[2, 0]);

                double fourthNumber = (matrix[0, 1] * matrix[2, 2]) - (matrix[0, 2] * matrix[2, 1]);
                double fifthumber = (matrix[0, 0] * matrix[2, 2]) - (matrix[0, 2] * matrix[2, 0]);
                double sixthNumber = (matrix[0, 0] * matrix[2, 1]) - (matrix[0, 1] * matrix[2, 0]);

                double seventhNumber = (matrix[0, 1] * matrix[1, 2]) - (matrix[0, 2] * matrix[1, 1]);
                double eighthNumber = (matrix[0, 0] * matrix[1, 2]) - (matrix[0, 2] * matrix[1, 0]);
                double ninethNumber = (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]);

                _temp = HandleInput(matrix, firstNumber, secondNumber, thirdNumber, fourthNumber, 
                    fifthumber, sixthNumber, seventhNumber, eighthNumber, ninethNumber);
            }

            for (int x = 0; x < _temp.GetLength(0); x++)
                for (int y = 0; y < _temp.GetLength(1); y++)
                    if((x + y) % 2 != 0)
                        _temp[x, y] *= -1; 

            for (int x = 0; x < _temp.GetLength(0); x++)
                for (int y = 0; y < _temp.GetLength(1); y++)
                    _temp[x, y] /= determinant; 

            return _temp;
        }

        /// <summary>
        /// Транспонирует матрицу (меняя строки и столбцы между собой)
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public static double[,] TransposeMatrix(double[,] matrix)
        {
            _temp = new double[matrix.GetLength(0), matrix.GetLength(1)];

            for (int x = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++)
                    _temp[y, x] = matrix[x, y];

            return _temp;
        }

        /// <summary>
        /// Складывает элементы матрицы между собой
        /// </summary>
        /// <param name="matrixOne"></param>
        /// <param name="matrixTwo"></param>
        /// <returns></returns>
        public static double[,] AdditionMatrix(double[,] matrixOne, double[,] matrixTwo)
        {
            _temp = new double[matrixOne.GetLength(0), matrixOne.GetLength(1)];

            for (int x = 0; x < matrixOne.GetLength(0); x++)
                for (int y = 0; y < matrixOne.GetLength(1); y++)
                    _temp[x, y] = matrixOne[x, y] + matrixTwo[x, y];

            return _temp;
        }

        /// <summary>
        /// Вычитает элементы матрицы между собой
        /// </summary>
        /// <param name="matrixOne"></param>
        /// <param name="matrixTwo"></param>
        /// <returns></returns>
        public static double[,] SubstractionMatrix(double[,] matrixOne, double[,] matrixTwo)
        {
            _temp = new double[matrixOne.GetLength(0), matrixOne.GetLength(1)];

            for (int x = 0; x < matrixTwo.GetLength(0); x++)
                for (int y = 0; y < matrixTwo.GetLength(1); y++)
                    _temp[x, y] = matrixTwo[x, y] - matrixOne[x, y];

            return _temp;
        }

        /// <summary>
        /// Умножает элементы матрицы между собой
        /// </summary>
        /// <param name="matrixOne"></param>
        /// <param name="matrixTwo"></param>
        /// <returns></returns>
        public static double[,] MultiplicateMatrix(double[,] matrixOne, double[,] matrixTwo)
        {
            _temp = new double[matrixOne.GetLength(0), matrixOne.GetLength(1)];

            if (matrixOne.Length == 4)
            {
                double firstNumber = matrixOne[0, 0] * matrixTwo[0, 0] + matrixOne[0, 1] * matrixTwo[1, 0];
                double secondNumber = matrixOne[0, 0] * matrixTwo[0, 1] + matrixOne[0, 1] * matrixTwo[1, 1];
                double thirdNumber = matrixOne[1, 0] * matrixTwo[0, 0] + matrixOne[1, 1] * matrixTwo[1, 0];
                double fourthNumber = matrixOne[1, 0] * matrixTwo[0, 1] + matrixOne[1, 1] * matrixTwo[1, 1];

                return HandleInput(_temp, firstNumber, secondNumber, thirdNumber, fourthNumber);
            }

            if (matrixOne.Length == 9)
            {
                double firstNumber = matrixOne[0, 0] * matrixTwo[0, 0] + matrixOne[0, 1] * matrixTwo[1, 0] + matrixOne[0, 2] * matrixTwo[2, 0];
                double secondNumber = matrixOne[0, 0] * matrixTwo[0, 1] + matrixOne[0, 1] * matrixTwo[1, 1] + matrixOne[0, 2] * matrixTwo[2, 1];
                double thirdNumber = matrixOne[0, 0] * matrixTwo[0, 2] + matrixOne[0, 1] * matrixTwo[1, 2] + matrixOne[0, 2] * matrixTwo[2, 2];

                double fourthNumber = matrixOne[1, 0] * matrixTwo[0, 0] + matrixOne[1, 1] * matrixTwo[1, 0] + matrixOne[1, 2] * matrixTwo[2, 0];
                double fifthNumber = matrixOne[1, 0] * matrixTwo[0, 1] + matrixOne[1, 1] * matrixTwo[1, 1] + matrixOne[1, 2] * matrixTwo[2, 1];
                double sixteenNumber = matrixOne[1, 0] * matrixTwo[0, 2] + matrixOne[1, 1] * matrixTwo[1, 2] + matrixOne[1, 2] * matrixTwo[2, 2];

                double seventeenNumber = matrixOne[2, 0] * matrixTwo[0, 0] + matrixOne[2, 1] * matrixTwo[1, 0] + matrixOne[2, 2] * matrixTwo[2, 0];
                double eigteenNumber = matrixOne[2, 0] * matrixTwo[0, 1] + matrixOne[2, 1] * matrixTwo[1, 1] + matrixOne[2, 2] * matrixTwo[2, 1];
                double nineteenNumber = matrixOne[2, 0] * matrixTwo[0, 2] + matrixOne[2, 1] * matrixTwo[1, 2] + matrixOne[2, 2]* matrixTwo[2, 2];

                return HandleInput(_temp, firstNumber, secondNumber, thirdNumber, fourthNumber, fifthNumber, sixteenNumber, seventeenNumber, eigteenNumber, nineteenNumber);
            }

            if (matrixOne.Length == 16) 
            {
                double firstNumber = matrixOne[0, 0] * matrixTwo[0, 0] + matrixOne[0, 1] * matrixTwo[1, 0] + matrixOne[0, 2] * matrixTwo[2, 0] + matrixOne[0, 3] * matrixTwo[3, 0];
                double secondNumber = matrixOne[0, 0] * matrixTwo[0, 1] + matrixOne[0, 1] * matrixTwo[1, 1] + matrixOne[0, 2] * matrixTwo[2, 1] + matrixOne[0, 3] * matrixTwo[3, 1];
                double thirdNumber = matrixOne[0, 0] * matrixTwo[0, 2] + matrixOne[0, 1] * matrixTwo[1, 2] + matrixOne[0, 2] * matrixTwo[2, 2] + matrixOne[0, 3] * matrixTwo[3, 2];
                double fourthNumber = matrixOne[0, 0] * matrixTwo[0, 3] + matrixOne[0, 1] * matrixTwo[1, 3] + matrixOne[0, 2] * matrixTwo[2, 3] + matrixOne[0, 3] * matrixTwo[3, 3];

                double fifthNumber = matrixOne[1, 0] * matrixTwo[0, 0] + matrixOne[1, 1] * matrixTwo[1, 0] + matrixOne[1, 2] * matrixTwo[2, 0] + matrixOne[1, 3] * matrixTwo[3, 0];             
                double sixthNumber = matrixOne[1, 0] * matrixTwo[0, 1] + matrixOne[1, 1] * matrixTwo[1, 1] + matrixOne[1, 2] * matrixTwo[2, 1] + matrixOne[1, 3] * matrixTwo[3, 1];                
                double seventeenNumber = matrixOne[1, 0] * matrixTwo[0, 2] + matrixOne[1, 1] * matrixTwo[1, 2] + matrixOne[1, 2] * matrixTwo[2, 2] + matrixOne[1, 3] * matrixTwo[3, 2];
                double eigteenNumber = matrixOne[1, 0] * matrixTwo[0, 3] + matrixOne[1, 1] * matrixTwo[1, 3] + matrixOne[1, 2] * matrixTwo[2, 3] + matrixOne[1, 3] * matrixTwo[3, 3];

                double nineteenNumber = matrixOne[2, 0] * matrixTwo[0, 0] + matrixOne[2, 1] * matrixTwo[1, 0] + matrixOne[2, 2] * matrixTwo[2, 0] + matrixOne[2, 3] * matrixTwo[3, 0];
                double tenthNumber = matrixOne[2, 0] * matrixTwo[0, 1] + matrixOne[2, 1] * matrixTwo[1, 1] + matrixOne[2, 2] * matrixTwo[2, 1] + matrixOne[2, 3] * matrixTwo[3, 1];
                double eleventhNumber = matrixOne[2, 0] * matrixTwo[0, 2] + matrixOne[2, 1] * matrixTwo[1, 2] + matrixOne[2, 2] * matrixTwo[2, 2] + matrixOne[2, 3] * matrixTwo[3, 2];
                double twelveNumber = matrixOne[2, 0] * matrixTwo[0, 3] + matrixOne[2, 1] * matrixTwo[1, 3] + matrixOne[2, 2] * matrixTwo[2, 3] + matrixOne[2, 3] * matrixTwo[3, 3];

                double thirteenNumber = matrixOne[3, 0] * matrixTwo[0, 0] + matrixOne[3, 1] * matrixTwo[1, 0] + matrixOne[3, 2] * matrixTwo[2, 0] + matrixOne[3, 3] * matrixTwo[3, 0];
                double fourteenNumber = matrixOne[3, 0] * matrixTwo[0, 1] + matrixOne[3, 1] * matrixTwo[1, 1] + matrixOne[3, 2] * matrixTwo[2, 1] + matrixOne[3, 3] * matrixTwo[3, 1];
                double fifteenNumber = matrixOne[3, 0] * matrixTwo[0, 2] + matrixOne[3, 1] * matrixTwo[1, 2] + matrixOne[3, 2] * matrixTwo[2, 2] + matrixOne[3, 3] * matrixTwo[3, 2];
                double sixteenNumber = matrixOne[3, 0] * matrixTwo[0, 3] + matrixOne[3, 1] * matrixTwo[1, 3] + matrixOne[3, 2] * matrixTwo[2, 3] + matrixOne[3, 3] * matrixTwo[3, 3];

                return HandleInput(_temp, firstNumber, secondNumber, thirdNumber, fourthNumber, fifthNumber, sixthNumber, seventeenNumber, eigteenNumber, 
                    nineteenNumber, tenthNumber, eleventhNumber, twelveNumber, thirteenNumber, fourteenNumber, fifteenNumber, sixteenNumber);
            }

            return null;
        }
    }
}