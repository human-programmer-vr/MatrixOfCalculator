using MatrixOfCalculator.Classes;

namespace MatrixOfCalculator
{
    public class Matrix
    {
        public static float[,] _matrixOne, _matrixTwo, _temp;

        public static float[,] MultiplicateNumberOnMatrix(float[,] matrix, int multiplicate)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++)
                    matrix[x, y] = (int)(matrix[x, y] * multiplicate);

            return matrix;
        }

        public static float[,] ReverseMatrix(float[,] matrix, float det = 0)
        {
            _temp = new float[matrix.GetLength(0), matrix.GetLength(1)];

            _temp = TransposeMatrix(matrix);

            if (matrix.Length == 4)
            {                
                det = FindDeterminantTwoOnTwo(matrix) == 0 ? 0 : FindDeterminantTwoOnTwo(matrix);

                if (det == 0)
                    return _temp;
            }

            if (matrix.Length == 9)
            {
                det = FindDeterminantThreeOnThree(matrix) == 0 ? 0 : FindDeterminantThreeOnThree(matrix);

                if (det == 0)
                    return _temp;

                _temp = InputAndOutputDataToMatrix.HandleInput(matrix,
                    (matrix[1, 1] * matrix[2, 2]) - (matrix[1, 2] * matrix[2, 1]),
                    (matrix[1, 0] * matrix[2, 2]) - (matrix[2, 0] * matrix[1, 2]),
                    (matrix[1, 0] * matrix[2, 1]) - (matrix[1, 1] * matrix[2, 0]),
                    (matrix[0, 1] * matrix[2, 2]) - (matrix[0, 2] * matrix[2, 1]),
                    (matrix[0, 0] * matrix[2, 2]) - (matrix[0, 2] * matrix[2, 0]),
                    (matrix[0, 0] * matrix[2, 1]) - (matrix[0, 1] * matrix[2, 0]),
                    (matrix[0, 1] * matrix[1, 2]) - (matrix[0, 2] * matrix[1, 1]),
                    (matrix[0, 0] * matrix[1, 2]) - (matrix[0, 2] * matrix[1, 0]),
                    (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]));
            }

            for (int x = 0; x < _temp.GetLength(0); x++)
                for (int y = 0; y < _temp.GetLength(1); y++)
                    if ((x + y) % 2 != 0)
                        _temp[x, y] *= -1;

            for (int x = 0; x < _temp.GetLength(0); x++)
                for (int y = 0; y < _temp.GetLength(1); y++)
                    _temp[x, y] /= det;

            return _temp;
        }

        public static float[,] TransposeMatrix(float[,] matrix)
        {
            _temp = new float[_matrixOne.GetLength(0), _matrixOne.GetLength(1)];

            for (int x = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++)
                    _temp[y, x] = matrix[x, y];

            return _temp;
        }

        public static float[,] AdditionMatrix(float[,] matrixOne, float[,] matrixTwo)
        {
            _temp = new float[matrixOne.GetLength(0), matrixOne.GetLength(1)];

            for (int x = 0; x < matrixOne.GetLength(0); x++)
                for (int y = 0; y < matrixOne.GetLength(1); y++)
                    _temp[x, y] = matrixOne[x, y] + matrixTwo[x, y];

            return _temp;
        }

        public static float[,] SubstractionMatrix(float[,] matrixOne, float[,] matrixTwo)
        {
            _temp = new float[matrixOne.GetLength(0), matrixOne.GetLength(1)];

            for (int x = 0; x < matrixTwo.GetLength(0); x++)
                for (int y = 0; y < matrixTwo.GetLength(1); y++)
                    _temp[x, y] = matrixTwo[x, y] - matrixOne[x, y];

            return _temp;
        }

        public static float[,] MultiplicateBothMatrix(float[,] matrixOne, float[,] matrixTwo)
        {
            if (matrixOne.Length == 4)
                return MultiplyElementsMatrixTwoOnTwo(matrixOne, matrixTwo);

            if (matrixOne.Length == 9)
                return MultiplyMatrixThreeOnThree(matrixOne, matrixTwo);

            if (matrixOne.Length == 16)
                return MultiplyMatrixFourOnFour(matrixOne, matrixTwo);

            return null;
        }

        private static int FindDeterminantTwoOnTwo(float[,] matrix)
        {
            return (int)((matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]));
        }

        private static int FindDeterminantThreeOnThree(float[,] matrix)
        {
            return (int)
                (matrix[0, 0] * matrix[1, 1] * matrix[2, 2] +
                matrix[0, 1] * matrix[1, 2] * matrix[2, 0] +
                matrix[1, 0] * matrix[2, 1] * matrix[0, 2] -
                matrix[0, 2] * matrix[1, 1] * matrix[2, 0] -
                matrix[0, 1] * matrix[1, 0] * matrix[2, 2] -
                matrix[1, 2] * matrix[2, 1] * matrix[0, 0]);
        }

        private static float[,] MultiplyElementsMatrixTwoOnTwo(float[,] matrixOne, float[,] matrixTwo)
        {
            return InputAndOutputDataToMatrix.HandleInput(matrixOne,
                matrixOne[0, 0] * matrixTwo[0, 0] + matrixOne[0, 1] * matrixTwo[1, 0],
                matrixOne[0, 0] * matrixTwo[0, 1] + matrixOne[0, 1] * matrixTwo[1, 1],
                matrixOne[1, 0] * matrixTwo[0, 0] + matrixOne[1, 1] * matrixTwo[1, 0],
                matrixOne[1, 0] * matrixTwo[0, 1] + matrixOne[1, 1] * matrixTwo[1, 1]);
        }

        private static float[,] MultiplyMatrixThreeOnThree(float[,] matrixOne, float[,] matrixTwo)
        {
            return InputAndOutputDataToMatrix.HandleInput(matrixOne,
                matrixOne[0, 0] * matrixTwo[0, 0] + matrixOne[0, 1] * matrixTwo[1, 0] + matrixOne[0, 2] * matrixTwo[2, 0],
                matrixOne[0, 0] * matrixTwo[0, 1] + matrixOne[0, 1] * matrixTwo[1, 1] + matrixOne[0, 2] * matrixTwo[2, 1],
                matrixOne[0, 0] * matrixTwo[0, 2] + matrixOne[0, 1] * matrixTwo[1, 2] + matrixOne[0, 2] * matrixTwo[2, 2],
                matrixOne[1, 0] * matrixTwo[0, 0] + matrixOne[1, 1] * matrixTwo[1, 0] + matrixOne[1, 2] * matrixTwo[2, 0],
                matrixOne[1, 0] * matrixTwo[0, 1] + matrixOne[1, 1] * matrixTwo[1, 1] + matrixOne[1, 2] * matrixTwo[2, 1],
                matrixOne[1, 0] * matrixTwo[0, 2] + matrixOne[1, 1] * matrixTwo[1, 2] + matrixOne[1, 2] * matrixTwo[2, 2],
                matrixOne[2, 0] * matrixTwo[0, 0] + matrixOne[2, 1] * matrixTwo[1, 0] + matrixOne[2, 2] * matrixTwo[2, 0],
                matrixOne[2, 0] * matrixTwo[0, 1] + matrixOne[2, 1] * matrixTwo[1, 1] + matrixOne[2, 2] * matrixTwo[2, 1],
                matrixOne[2, 0] * matrixTwo[0, 2] + matrixOne[2, 1] * matrixTwo[1, 2] + matrixOne[2, 2] * matrixTwo[2, 2]);
        }

        private static float[,] MultiplyMatrixFourOnFour(float[,] matrixOne, float[,] matrixTwo)
        {
            return InputAndOutputDataToMatrix.HandleInput(matrixOne,
                matrixOne[0, 0] * matrixTwo[0, 0] + matrixOne[0, 1] * matrixTwo[1, 0] + matrixOne[0, 2] * matrixTwo[2, 0] + matrixOne[0, 3] * matrixTwo[3, 0],
                matrixOne[0, 0] * matrixTwo[0, 1] + matrixOne[0, 1] * matrixTwo[1, 1] + matrixOne[0, 2] * matrixTwo[2, 1] + matrixOne[0, 3] * matrixTwo[3, 1],
                matrixOne[0, 0] * matrixTwo[0, 2] + matrixOne[0, 1] * matrixTwo[1, 2] + matrixOne[0, 2] * matrixTwo[2, 2] + matrixOne[0, 3] * matrixTwo[3, 2],
                matrixOne[0, 0] * matrixTwo[0, 3] + matrixOne[0, 1] * matrixTwo[1, 3] + matrixOne[0, 2] * matrixTwo[2, 3] + matrixOne[0, 3] * matrixTwo[3, 3],
                matrixOne[1, 0] * matrixTwo[0, 0] + matrixOne[1, 1] * matrixTwo[1, 0] + matrixOne[1, 2] * matrixTwo[2, 0] + matrixOne[1, 3] * matrixTwo[3, 0],
                matrixOne[1, 0] * matrixTwo[0, 1] + matrixOne[1, 1] * matrixTwo[1, 1] + matrixOne[1, 2] * matrixTwo[2, 1] + matrixOne[1, 3] * matrixTwo[3, 1],
                matrixOne[1, 0] * matrixTwo[0, 2] + matrixOne[1, 1] * matrixTwo[1, 2] + matrixOne[1, 2] * matrixTwo[2, 2] + matrixOne[1, 3] * matrixTwo[3, 2],
                matrixOne[1, 0] * matrixTwo[0, 3] + matrixOne[1, 1] * matrixTwo[1, 3] + matrixOne[1, 2] * matrixTwo[2, 3] + matrixOne[1, 3] * matrixTwo[3, 3],
                matrixOne[2, 0] * matrixTwo[0, 0] + matrixOne[2, 1] * matrixTwo[1, 0] + matrixOne[2, 2] * matrixTwo[2, 0] + matrixOne[2, 3] * matrixTwo[3, 0],
                matrixOne[2, 0] * matrixTwo[0, 1] + matrixOne[2, 1] * matrixTwo[1, 1] + matrixOne[2, 2] * matrixTwo[2, 1] + matrixOne[2, 3] * matrixTwo[3, 1],
                matrixOne[2, 0] * matrixTwo[0, 2] + matrixOne[2, 1] * matrixTwo[1, 2] + matrixOne[2, 2] * matrixTwo[2, 2] + matrixOne[2, 3] * matrixTwo[3, 2],
                matrixOne[2, 0] * matrixTwo[0, 3] + matrixOne[2, 1] * matrixTwo[1, 3] + matrixOne[2, 2] * matrixTwo[2, 3] + matrixOne[2, 3] * matrixTwo[3, 3],
                matrixOne[3, 0] * matrixTwo[0, 0] + matrixOne[3, 1] * matrixTwo[1, 0] + matrixOne[3, 2] * matrixTwo[2, 0] + matrixOne[3, 3] * matrixTwo[3, 0],
                matrixOne[3, 0] * matrixTwo[0, 1] + matrixOne[3, 1] * matrixTwo[1, 1] + matrixOne[3, 2] * matrixTwo[2, 1] + matrixOne[3, 3] * matrixTwo[3, 1],
                matrixOne[3, 0] * matrixTwo[0, 2] + matrixOne[3, 1] * matrixTwo[1, 2] + matrixOne[3, 2] * matrixTwo[2, 2] + matrixOne[3, 3] * matrixTwo[3, 2]);
        }
    }
}