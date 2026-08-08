using MatrixOfCalculator.Classes;
using System;

namespace MatrixOfCalculator
{
    public class Matrix
    {
        public static float[,] matrixOne, matrixTwo, destinationMatrix;

        public static float[,] MultiplicateNumberOnMatrix(float[,] matrix, int multiplicate)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++)
                    matrix[x, y] = (int)(matrix[x, y] * multiplicate);

            return matrix;
        }

        public static float[,] ReverseMatrix(float[,] sourceMatrix, int det = 0)
        {
            destinationMatrix = new float[sourceMatrix.GetLength(0), sourceMatrix.GetLength(1)];

            if (sourceMatrix.Length == 4)
                det = FindDeterminantTwoOnTwo(sourceMatrix);
            else if (sourceMatrix.Length == 9)
                det = FindDeterminantThreeOnThree(sourceMatrix);
            else if (sourceMatrix.Length == 16)
                det = FindDeterminantFourOnFour(sourceMatrix);

            if (det == 0)
                return sourceMatrix;

            destinationMatrix = FindMinorForMatrix(sourceMatrix);
            FindAlgebraicAdditions(ref destinationMatrix);
            DivisionMatrixOnDeterminant(det);

            return TransposeMatrix(destinationMatrix);
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

        private static int FindDeterminantFourOnFour(float[,] matrix)
        {
            return (int)
                (
                matrix[0, 0] * Math.Pow(-1, 2) * FindDeterminantThreeOnThree(
                    new float[,]
                    {
                        { matrix[1, 1], matrix[1, 2], matrix[1, 3] },
                        { matrix[2, 1], matrix[2, 2], matrix[2, 3] },
                        { matrix[3, 1], matrix[3, 2], matrix[3, 3] },
                    }) +
                matrix[1, 0] * Math.Pow(-1, 3) * FindDeterminantThreeOnThree(
                        new float[,]
                        {
                            { matrix[0, 1], matrix[0, 2], matrix[0, 3] },
                            { matrix[2, 1], matrix[2, 2], matrix[2, 3] },
                            { matrix[3, 1], matrix[3, 2], matrix[3, 3] },
                        }
                    ) +
                matrix[2, 0] * Math.Pow(-1, 4) * FindDeterminantThreeOnThree(
                        new float[,]
                        {
                            { matrix[0, 1], matrix[0, 2], matrix[0, 3] },
                            { matrix[1, 1], matrix[1, 2], matrix[1, 3] },
                            { matrix[3, 1], matrix[3, 2], matrix[3, 3] },
                        }
                    ) +
                matrix[3, 0] * Math.Pow(-1, 5) * FindDeterminantThreeOnThree(
                        new float[,]
                        {
                            { matrix[0, 1], matrix[0, 2], matrix[0, 3] },
                            { matrix[1, 1], matrix[1, 2], matrix[1, 3] },
                            { matrix[2, 1], matrix[2, 2], matrix[2, 3] },
                        }
                    )
                );
        }

        private static float[,] FindMinorForMatrix(float[,] matrix)
        {
            float[,] temp = new float[matrix.GetLength(0), matrix.GetLength(1)];

            if (matrix.Length == 4)
                FindMinorForMatrixTwoOnTwo(matrix, ref temp);
            else if (matrix.Length == 9)
                FindMinorForMatrixThreeOnThree(matrix, ref temp);
            else if (matrix.Length == 16)
                FindMinorForMatrixFourOnFour(matrix, ref temp);

            return temp;
        }

        private static float[,] FindMinorForMatrixTwoOnTwo(float[,] matrix, ref float[,] temp)
        {
            for (int x = matrix.GetLength(0) - 1, j = 0; x >= 0; x--, j++)
                for (int y = matrix.GetLength(1) - 1, k = 0; y >= 0; y--, k++)
                    temp[j, k] = matrix[x, y];

            return temp;
        }

        private static float[,] FindMinorForMatrixThreeOnThree(float[,] matrix, ref float[,] temp)
        {
            temp = InputAndOutputDataToMatrix.HandleInput(matrix,
                (matrix[1, 1] * matrix[2, 2]) - (matrix[1, 2] * matrix[2, 1]),
                (matrix[1, 0] * matrix[2, 2]) - (matrix[2, 0] * matrix[1, 2]),
                (matrix[1, 0] * matrix[2, 1]) - (matrix[1, 1] * matrix[2, 0]),
                (matrix[0, 1] * matrix[2, 2]) - (matrix[0, 2] * matrix[2, 1]),
                (matrix[0, 0] * matrix[2, 2]) - (matrix[0, 2] * matrix[2, 0]),
                (matrix[0, 0] * matrix[2, 1]) - (matrix[0, 1] * matrix[2, 0]),
                (matrix[0, 1] * matrix[1, 2]) - (matrix[0, 2] * matrix[1, 1]),
                (matrix[0, 0] * matrix[1, 2]) - (matrix[0, 2] * matrix[1, 0]),
                (matrix[0, 0] * matrix[1, 1]) - (matrix[0, 1] * matrix[1, 0]));

            return temp;
        }

        private static float[,] FindMinorForMatrixFourOnFour(float[,] matrix, ref float[,] temp)
        {
            return temp = new float[,] {
                {
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                            { matrix[1, 1], matrix[1, 2], matrix[1, 3] },
                            { matrix[2, 1], matrix[2, 2], matrix[2, 3] },
                            { matrix[3, 1], matrix[3, 2], matrix[3, 3] }
                        }
                    ),
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                            { matrix[1, 0], matrix[1, 2], matrix[1, 3] },
                            { matrix[2, 0], matrix[2, 2], matrix[2, 3] },
                            { matrix[3, 0], matrix[3, 2], matrix[3, 3] }
                        }
                    ),
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                            { matrix[1, 0], matrix[1, 1], matrix[1, 3] },
                            { matrix[2, 0], matrix[2, 1], matrix[2, 3] },
                            { matrix[3, 0], matrix[3, 1], matrix[3, 3] }
                        }
                    ),
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                            { matrix[1, 0], matrix[1, 1], matrix[1, 2] },
                            { matrix[2, 0], matrix[2, 1], matrix[2, 2] },
                            { matrix[3, 0], matrix[3, 1], matrix[3, 2] }
                        }
                    )
                },
                {
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                            { matrix[0, 1], matrix[0, 2], matrix[0, 3] },
                            { matrix[2, 1], matrix[2, 2], matrix[2, 3] },
                            { matrix[3, 1], matrix[3, 2], matrix[3, 3] }
                        }
                    ),
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                           { matrix[0, 0], matrix[0, 2], matrix[0, 3] },
                           { matrix[2, 0], matrix[2, 2], matrix[2, 3] },
                           { matrix[3, 0], matrix[3, 2], matrix[3, 3] }
                       }
                    ),
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                            { matrix[0, 0], matrix[0, 1], matrix[0, 3] },
                            { matrix[2, 0], matrix[2, 1], matrix[2, 3] },
                            { matrix[3, 0], matrix[3, 1], matrix[3, 3] }
                        }
                    ),
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                            { matrix[0, 0], matrix[0, 1], matrix[0, 2] },
                            { matrix[2, 0], matrix[2, 1], matrix[2, 2] },
                            { matrix[3, 0], matrix[3, 1], matrix[3, 2] }
                        }
                    )
                },
                {
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                            { matrix[0, 1], matrix[0, 2], matrix[0, 3] },
                            { matrix[1, 1], matrix[1, 2], matrix[1, 3] },
                            { matrix[3, 1], matrix[3, 2], matrix[3, 3] }
                        }
                    ),
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                            { matrix[0, 0], matrix[0, 2], matrix[0, 3] },
                            { matrix[1, 0], matrix[1, 2], matrix[1, 3] },
                            { matrix[3, 0], matrix[3, 2], matrix[3, 3] }
                        }
                    ),
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                            { matrix[0, 0], matrix[0, 1], matrix[0, 3] },
                            { matrix[1, 0], matrix[1, 1], matrix[1, 3] },
                            { matrix[3, 0], matrix[3, 1], matrix[3, 3] }
                        }
                    ),
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                            { matrix[0, 0], matrix[0, 1], matrix[0, 2] },
                            { matrix[1, 0], matrix[1, 1], matrix[1, 2] },
                            { matrix[3, 0], matrix[3, 1], matrix[3, 2] }
                        }
                    )
                },
                {
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                            { matrix[0, 1], matrix[0, 2], matrix[0, 3] },
                            { matrix[1, 1], matrix[1, 2], matrix[1, 3] },
                            { matrix[2, 1], matrix[2, 2], matrix[2, 3] }
                        }
                    ),
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                            {matrix[0, 0], matrix[0, 2], matrix[0, 3] },
                            {matrix[1, 0], matrix[1, 2], matrix[1, 3] },
                            {matrix[2, 0], matrix[2, 2], matrix[2, 3] }
                        }
                    ),
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                            {matrix[0, 0], matrix[0, 1], matrix[0, 3] },
                            {matrix[1, 0], matrix[1, 1], matrix[1, 3] },
                            {matrix[2, 0], matrix[2, 1], matrix[2, 3] }
                        }
                    ),
                    FindDeterminantThreeOnThree (
                        new float[,]
                        {
                            { matrix[0, 0], matrix[0, 1], matrix[0, 2] },
                            { matrix[1, 0], matrix[1, 1], matrix[1, 2] },
                            { matrix[2, 0], matrix[2, 1], matrix[2, 2] }
                        }
                        )
                },
            };
        }

        private static float[,] FindAlgebraicAdditions(ref float[,] matrix)
        {
            for (int x = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++)
                    if ((x + y) % 2 != 0)
                        matrix[x, y] *= -1;

            return matrix;
        }

        private static void DivisionMatrixOnDeterminant(int det)
        {
            for (int x = 0; x < destinationMatrix.GetLength(0); x++)
                for (int y = 0; y < destinationMatrix.GetLength(1); y++)
                    destinationMatrix[x, y] /= det;
        }

        public static float[,] TransposeMatrix(float[,] matrix)
        {
            destinationMatrix = new float[matrixOne.GetLength(0), matrixOne.GetLength(1)];

            for (int x = 0; x < matrix.GetLength(0); x++)
                for (int y = 0; y < matrix.GetLength(1); y++)
                    destinationMatrix[y, x] = matrix[x, y];

            return destinationMatrix;
        }

        public static float[,] AdditionMatrix(float[,] matrixOne, float[,] matrixTwo)
        {
            destinationMatrix = new float[matrixOne.GetLength(0), matrixOne.GetLength(1)];

            for (int x = 0; x < matrixOne.GetLength(0); x++)
                for (int y = 0; y < matrixOne.GetLength(1); y++)
                    destinationMatrix[x, y] = matrixOne[x, y] + matrixTwo[x, y];

            return destinationMatrix;
        }

        public static float[,] SubstractionMatrix(float[,] matrixOne, float[,] matrixTwo)
        {
            destinationMatrix = new float[matrixOne.GetLength(0), matrixOne.GetLength(1)];

            for (int x = 0; x < matrixTwo.GetLength(0); x++)
                for (int y = 0; y < matrixTwo.GetLength(1); y++)
                    destinationMatrix[x, y] = matrixTwo[x, y] - matrixOne[x, y];

            return destinationMatrix;
        }

        public static float[,] MultiplicateBothMatrix(float[,] matrixOne, float[,] matrixTwo)
        {
            return matrixOne.Length == 4 ? MultiplyElementsMatrixTwoOnTwo(matrixOne, matrixTwo) :
                matrixOne.Length == 9 ? MultiplyMatrixThreeOnThree(matrixOne, matrixTwo) :
                matrixOne.Length == 16 ? MultiplyMatrixFourOnFour(matrixOne, matrixTwo) : null;
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