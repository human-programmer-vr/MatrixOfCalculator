using MatrixOfCalculator.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MatrixOfCalculator.Forms
{
    public partial class MatrixCalculation : Form
    {
        private double[,] _matrixOne, _matrixTwo, _temp;

        public MatrixCalculation()
        {
            InitializeComponent();
        }

        private void CloseWindow_Click(object sender, EventArgs e)
        {
            this.Close();
        } 

        private void bBack_Click(object sender, EventArgs e)
        {
            if (inHandle.Checked)
            {
                if (sizeTwoOnTwo.Checked)
                    WorkWithForms.SetForm(currentDesign: gOperationMatrix, chooseDesign: gInputDataToMatrixTwoOnTwo);

                if (sizeThreeToThree.Checked)
                    WorkWithForms.SetForm(currentDesign: gOperationMatrix, chooseDesign: gInputDataToMatrixThreeOnThree);

                if (sizeFourToFour.Checked)
                    WorkWithForms.SetForm(currentDesign: gOperationMatrix, chooseDesign: gInputDataToMatrixFourOnFour);
            }
            else
                WorkWithForms.SetForm(currentDesign: gOperationMatrix, chooseDesign: gHomeWindow);
        }
        private void bBаck_Click(object sender, EventArgs e)
        {
            WorkWithForms.SetForm(currentDesign: gResultCalculation, chooseDesign: gOperationMatrix);
        }
        private void bReturn_Click(object sender, EventArgs e)
        {
            WorkWithForms.SetForm(currentDesign: gResultCalculation, chooseDesign: gHomeWindow);
            WorkWithForms.SetFormAndCloseExist(gHomeWindow, gInputDataToMatrixTwoOnTwo, gInputDataToMatrixThreeOnThree, gInputDataToMatrixFourOnFour);
        }
        private void bPrevious_Click(object sender, EventArgs e)
        {
            WorkWithForms.SetForm(currentDesign: gInputDataToMatrixFourOnFour, chooseDesign: gHomeWindow);
        }
        private void bBehind_Click(object sender, EventArgs e)
        {
            WorkWithForms.SetFormAndCloseExist(gHomeWindow, gInputDataToMatrixTwoOnTwo, gInputDataToMatrixThreeOnThree, gInputDataToMatrixFourOnFour);
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            if (bCreateMatrix.BackColor == Color.FromArgb(192, 255, 192))
            {
                if (inHandle.Checked)
                {
                    if (sizeTwoOnTwo.Checked)
                        WorkWithForms.SetForm(currentDesign: gHomeWindow, chooseDesign: gInputDataToMatrixTwoOnTwo);

                    if (sizeThreeToThree.Checked)
                        WorkWithForms.SetForm(currentDesign: gHomeWindow, chooseDesign: gInputDataToMatrixThreeOnThree);

                    if (sizeFourToFour.Checked)
                        WorkWithForms.SetForm(currentDesign: gHomeWindow, chooseDesign: gInputDataToMatrixFourOnFour);
                }

                if (inAutomatic.Checked)
                {
                    if (sizeTwoOnTwo.Checked)
                    {
                        AutomaticsInputDataToMatrix.AutoInput(_matrixOne = new double[2, 2]);
                        WorkWithForms.SetForm(currentDesign: gHomeWindow, chooseDesign: gOperationMatrix);
                    }

                    if (sizeThreeToThree.Checked)
                    {
                        AutomaticsInputDataToMatrix.AutoInput(_matrixOne = new double[3, 3]);
                        WorkWithForms.SetForm(currentDesign: gHomeWindow, chooseDesign: gOperationMatrix);
                    }

                    if (sizeFourToFour.Checked)
                    {
                        AutomaticsInputDataToMatrix.AutoInput(_matrixOne = new double[4, 4]);
                        WorkWithForms.SetForm(currentDesign: gHomeWindow, chooseDesign: gOperationMatrix);
                    }
                }

                WorkWithForms.ViewElement(currentElement: pOperationsWithTwoMatrix, nextElement: pOperationsWithOneMatrix);
            }

            if (bCreateBothMatrix.BackColor == Color.FromArgb(192, 255, 192))
            {
                if (inHandle.Checked)
                {
                    if (sizeTwoOnTwo.Checked)
                        WorkWithForms.SetForm(currentDesign: gHomeWindow, chooseDesign: gInputDataToMatrixTwoOnTwo);

                    if (sizeThreeToThree.Checked)
                        WorkWithForms.SetForm(currentDesign: gHomeWindow, chooseDesign: gInputDataToMatrixThreeOnThree);

                    if (sizeFourToFour.Checked)
                        WorkWithForms.SetForm(currentDesign: gHomeWindow, chooseDesign: gInputDataToMatrixFourOnFour);
                }

                if (inAutomatic.Checked)
                {
                    if (sizeTwoOnTwo.Checked)
                    {
                        AutomaticsInputDataToMatrix.AutoInput(_matrixOne = new double[2, 2]);
                        AutomaticsInputDataToMatrix.AutoInput(_matrixTwo = new double[2, 2]);

                        WorkWithForms.SetForm(currentDesign: gHomeWindow, chooseDesign: gOperationMatrix);
                    }

                    if (sizeThreeToThree.Checked)
                    {
                        AutomaticsInputDataToMatrix.AutoInput(_matrixOne = new double[3, 3]);
                        AutomaticsInputDataToMatrix.AutoInput(_matrixTwo = new double[3, 3]);

                        WorkWithForms.SetForm(currentDesign: gHomeWindow, chooseDesign: gOperationMatrix);
                    }

                    if (sizeFourToFour.Checked)
                    {
                        AutomaticsInputDataToMatrix.AutoInput(_matrixOne = new double[4, 4]);
                        AutomaticsInputDataToMatrix.AutoInput(_matrixTwo = new double[4, 4]);

                        WorkWithForms.SetForm(currentDesign: gHomeWindow, chooseDesign: gOperationMatrix);
                    }
                }
                
                WorkWithForms.ViewElement(currentElement: pOperationsWithOneMatrix, nextElement: pOperationsWithTwoMatrix);
            }            
        }
        private void bMain_Click(object sender, EventArgs e)
        {
            WorkWithForms.SetForm(currentDesign: gResultCalculation, chooseDesign: gHomeWindow);
        }
        
        private void bNеxt_Click(object sender, EventArgs e)
        {
            _temp = OperationWithMatrix.MultiplicateNumberOnMatrix(_matrixOne, tInputField.Text.CheckIntOrDefault());
            WorkWithForms.SetForm(currentDesign: gOperationMatrix, chooseDesign: gResultCalculation);

            UtilityTools.Notification();
            UtilityTools.OutputData(_temp, tOutputData);
        }

        private void bContinue_Click(object sender, EventArgs e)
        {
            if (bCreateMatrix.BackColor == Color.FromArgb(192, 255, 192))
            {
                OperationWithMatrix.HandleInput(_matrixOne = new double[2, 2], tInput1.Text.CheckIntOrDefault(), tInput2.Text.CheckIntOrDefault(),
                    tInput3.Text.CheckIntOrDefault(), tInput4.Text.CheckIntOrDefault());

                UtilityTools.ClearInput(tInput1, tInput2, tInput3, tInput4);

                pOperationsWithOneMatrix.Visible = gOperationMatrix.Visible = true;
            }

            if (bCreateBothMatrix.BackColor == Color.FromArgb(192, 255, 192))
            {
                if (_matrixOne == null)
                {
                    OperationWithMatrix.HandleInput(_matrixOne = new double[2, 2], tInput1.Text.CheckIntOrDefault(), tInput2.Text.CheckIntOrDefault(),
                        tInput3.Text.CheckIntOrDefault(), tInput4.Text.CheckIntOrDefault());

                    UtilityTools.ClearInput(tInput1, tInput2, tInput3, tInput4);
                    WorkWithForms.SetForm(currentDesign: gHomeWindow, chooseDesign: gInputDataToMatrixTwoOnTwo);
                    
                    return;
                }

                if (UtilityTools.CheckExistData(_matrixOne) != _matrixOne.Length)
                {
                    OperationWithMatrix.HandleInput(_matrixTwo = new double[2, 2], tInput1.Text.CheckIntOrDefault(), tInput2.Text.CheckIntOrDefault(),
                        tInput3.Text.CheckIntOrDefault(), tInput4.Text.CheckIntOrDefault());

                    UtilityTools.ClearInput(tInput1, tInput2, tInput3, tInput4);
                }

                pOperationsWithTwoMatrix.Visible = gOperationMatrix.Visible = true;
            }

            gOperationMatrix.Parent = this;
            gInputDataToMatrixTwoOnTwo.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (bCreateMatrix.BackColor == Color.FromArgb(192, 255, 192))
            {
                OperationWithMatrix.HandleInput(_matrixOne = new double[3, 3], textBox1.Text.CheckIntOrDefault(), textBox2.Text.CheckIntOrDefault(), textBox3.Text.CheckIntOrDefault(),
                    textBox4.Text.CheckIntOrDefault(), textBox5.Text.CheckIntOrDefault(), textBox6.Text.CheckIntOrDefault(), textBox7.Text.CheckIntOrDefault(),
                    textBox8.Text.CheckIntOrDefault(), textBox9.Text.CheckIntOrDefault());

                UtilityTools.ClearInput(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9);

                pOperationsWithOneMatrix.Visible = gOperationMatrix.Visible = true;
            }

            if (bCreateBothMatrix.BackColor == Color.FromArgb(192, 255, 192))
            {
                if (_matrixOne == null)
                {
                    OperationWithMatrix.HandleInput(_matrixOne = new double[3, 3], textBox1.Text.CheckIntOrDefault(), textBox2.Text.CheckIntOrDefault(), textBox3.Text.CheckIntOrDefault(),
                        textBox4.Text.CheckIntOrDefault(), textBox5.Text.CheckIntOrDefault(), textBox6.Text.CheckIntOrDefault(), textBox7.Text.CheckIntOrDefault(),
                        textBox8.Text.CheckIntOrDefault(), textBox9.Text.CheckIntOrDefault());

                    UtilityTools.ClearInput(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9);
                    WorkWithForms.SetForm(currentDesign: gHomeWindow, chooseDesign: gInputDataToMatrixThreeOnThree);

                    return;
                }

                if (UtilityTools.CheckExistData(_matrixOne) != _matrixOne.Length)
                {
                    OperationWithMatrix.HandleInput(_matrixTwo = new double[3, 3], textBox1.Text.CheckIntOrDefault(), textBox2.Text.CheckIntOrDefault(), textBox3.Text.CheckIntOrDefault(),
                        textBox4.Text.CheckIntOrDefault(), textBox5.Text.CheckIntOrDefault(), textBox6.Text.CheckIntOrDefault(), textBox7.Text.CheckIntOrDefault(),
                        textBox8.Text.CheckIntOrDefault(), textBox9.Text.CheckIntOrDefault());

                    UtilityTools.ClearInput(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9);
                }

                pOperationsWithTwoMatrix.Visible = gOperationMatrix.Visible = true;
            }
            
            gOperationMatrix.Parent = this;
            gInputDataToMatrixThreeOnThree.Visible = false;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (bCreateMatrix.BackColor == Color.FromArgb(192, 255, 192))
            {
                OperationWithMatrix.HandleInput(_matrixOne = new double[4, 4], textBox10.Text.CheckIntOrDefault(), textBox11.Text.CheckIntOrDefault(), textBox12.Text.CheckIntOrDefault(),
                    textBox13.Text.CheckIntOrDefault(), textBox14.Text.CheckIntOrDefault(), textBox15.Text.CheckIntOrDefault(), textBox16.Text.CheckIntOrDefault(),
                    textBox17.Text.CheckIntOrDefault(), textBox18.Text.CheckIntOrDefault(), textBox19.Text.CheckIntOrDefault(), textBox20.Text.CheckIntOrDefault(),
                    textBox21.Text.CheckIntOrDefault(), textBox22.Text.CheckIntOrDefault(), textBox23.Text.CheckIntOrDefault(), textBox24.Text.CheckIntOrDefault(),
                    textBox25.Text.CheckIntOrDefault());

                UtilityTools.ClearInput(textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, 
                    textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25);

                pOperationsWithOneMatrix.Visible = gOperationMatrix.Visible = true;
            }

            if (bCreateBothMatrix.BackColor == Color.FromArgb(192, 255, 192))
            {
                if (_matrixOne == null)
                {
                    OperationWithMatrix.HandleInput(_matrixOne = new double[4, 4], textBox10.Text.CheckIntOrDefault(), textBox11.Text.CheckIntOrDefault(), textBox12.Text.CheckIntOrDefault(),
                        textBox13.Text.CheckIntOrDefault(), textBox14.Text.CheckIntOrDefault(), textBox15.Text.CheckIntOrDefault(), textBox16.Text.CheckIntOrDefault(),
                        textBox17.Text.CheckIntOrDefault(), textBox18.Text.CheckIntOrDefault(), textBox19.Text.CheckIntOrDefault(), textBox20.Text.CheckIntOrDefault(),
                        textBox21.Text.CheckIntOrDefault(), textBox22.Text.CheckIntOrDefault(), textBox23.Text.CheckIntOrDefault(), textBox24.Text.CheckIntOrDefault(),
                        textBox25.Text.CheckIntOrDefault());

                    UtilityTools.ClearInput(textBox10, textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, 
                        textBox17, textBox18, textBox19, textBox20, textBox21, textBox22, textBox23, textBox24, textBox25);
                    
                    WorkWithForms.SetForm(currentDesign: gHomeWindow, chooseDesign: gInputDataToMatrixFourOnFour);

                    return;
                }

                if (UtilityTools.CheckExistData(_matrixOne) != _matrixOne.Length)
                {
                    OperationWithMatrix.HandleInput(_matrixTwo = new double[4, 4], textBox10.Text.CheckIntOrDefault(), textBox11.Text.CheckIntOrDefault(), textBox12.Text.CheckIntOrDefault(),
                        textBox13.Text.CheckIntOrDefault(), textBox14.Text.CheckIntOrDefault(), textBox15.Text.CheckIntOrDefault(), textBox16.Text.CheckIntOrDefault(),
                        textBox17.Text.CheckIntOrDefault(), textBox18.Text.CheckIntOrDefault(), textBox19.Text.CheckIntOrDefault(), textBox20.Text.CheckIntOrDefault(),
                        textBox21.Text.CheckIntOrDefault(), textBox22.Text.CheckIntOrDefault(), textBox23.Text.CheckIntOrDefault(), textBox24.Text.CheckIntOrDefault(),
                        textBox25.Text.CheckIntOrDefault());

                    UtilityTools.ClearInput(tInput1, tInput2, tInput3, tInput4);
                }

                pOperationsWithTwoMatrix.Visible = gOperationMatrix.Visible = true;
            }

            gOperationMatrix.Parent = this;
            gInputDataToMatrixFourOnFour.Visible = false;
        }

        /// <summary>
        /// Активация поле ввода множителя для матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bMultiplicationMatrixOnNumber_Click(object sender, EventArgs e)
        {
            tInputField.Clear();

            if (tInputField.Visible != false)
                tInputField.Visible = false;
            else
                tInputField.Visible = true;
        }

        /// <summary>
        /// Переключатель работы с одной матрицей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bCreateMatrix_Click(object sender, EventArgs e)
        {
            if (!bCreateBothMatrix.BackColor.Name.StartsWith("White"))
            {
                bCreateMatrix.BackColor = Color.White;
                return;
            }

            UtilityTools.Change(bCreateMatrix);
        }
       
        /// <summary>
        /// Переключатель работы с двумя матрицами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bCreateBothMatrix_Click(object sender, EventArgs e)
        {
            if (!bCreateMatrix.BackColor.Name.StartsWith("White"))
            {
                bCreateBothMatrix.BackColor = Color.White;
                return;
            }

            UtilityTools.Change(bCreateBothMatrix);
        }

        /// <summary>
        /// Меняет местами строку и столбец матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bTransposeMatrix_Click(object sender, EventArgs e)
        {
            _temp = OperationWithMatrix.TransposeMatrix(_matrixOne);
            WorkWithForms.SetForm(currentDesign: gOperationMatrix, chooseDesign: gResultCalculation);

            UtilityTools.Notification();
            UtilityTools.OutputData(_temp, tOutputData);
        }

        /// <summary>
        /// Складывает матрицы между собой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bAdditionMatrix_Click(object sender, EventArgs e)
        {
            _temp = OperationWithMatrix.AdditionMatrix(_matrixOne, _matrixTwo);
            WorkWithForms.SetForm(currentDesign: gOperationMatrix, chooseDesign: gResultCalculation);

            UtilityTools.Notification();
            UtilityTools.OutputData(_temp, tOutputData);
        }

        /// <summary>
        /// Вычитает матрицы между собой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSubtractionMatrix_Click(object sender, EventArgs e)
        {
            _temp = OperationWithMatrix.SubstractionMatrix(_matrixOne, _matrixTwo);
            WorkWithForms.SetForm(currentDesign: gOperationMatrix, chooseDesign: gResultCalculation);

            UtilityTools.Notification();
            UtilityTools.OutputData(_temp, tOutputData);
        }

        /// <summary>
        /// Умножает матрицы между собой
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bMultiplicateMatrix_Click(object sender, EventArgs e)
        {
            _temp = OperationWithMatrix.MultiplicateMatrix(_matrixOne, _matrixTwo);
            WorkWithForms.SetForm(currentDesign: gOperationMatrix, chooseDesign: gResultCalculation);

            UtilityTools.Notification();
            UtilityTools.OutputData(_temp, tOutputData);
        }

        /// <summary>
        /// Находит обратную матрицу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bFindReverseMatrix_Click(object sender, EventArgs e)
        {
            _temp = OperationWithMatrix.ReverseMatrix(_matrixOne);
            WorkWithForms.SetForm(currentDesign: gOperationMatrix, chooseDesign: gResultCalculation);
            
            UtilityTools.Notification();
            UtilityTools.OutputData(_temp, tOutputData);
        }

        /// <summary>
        /// Блокирует ввод букв в поле ввода
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tInput1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validation.OnlyNumbers(sender, e);
        }
    }
}