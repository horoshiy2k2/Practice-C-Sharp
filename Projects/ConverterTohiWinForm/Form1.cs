using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConverterTohiWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int sys1 = 10, sys2 = 2; // через чекбоксы

        private void Sys2RB1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                sys1 = 2;
                TBNum1.Text = "";
                labelHelp.Text = "0 1";
            }
        }

        private void Sys8RB1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                sys1 = 8;
                TBNum1.Text = "";
                labelHelp.Text = "0 1 2 3 4 5 6 7";
            }
        }

        private void Sys16RB1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                sys1 = 16;
                TBNum1.Text = "";
                labelHelp.Text = "0 1 2 3 4 5 6 7 8 9 A B C D E F";
            }
        }

        private void Sys10RB1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                sys1 = 10;
                TBNum1.Text = "";
                labelHelp.Text = "0 1 2 3 4 5 6 7 8 9";
            }
        }

        private void Sys2RB2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                sys2 = 2;
                TBNum1.Text = "";
            }
        }

        private void Sys8RB2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                sys2 = 8;
                TBNum1.Text = "";
            }
        }

        private void Sys10RB2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                sys2 = 10;
                TBNum1.Text = "";
            }
        }

        private void Sys16RB2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                sys2 = 16;
                TBNum1.Text = "";
            }            
        }

        private void TBOther1_TextChanged(object sender, EventArgs e)
        {
            TBNum1.Text = "";
            TextBox textbox1 = sender as TextBox;
            string strSys1 = textbox1.Text;
            int temp;
            bool isInt = Int32.TryParse(strSys1, out temp);
            if (isInt && temp > 1 && temp < 20 && temp != 4 && temp != 3)
            {
                sys1 = temp;
                MessageBox.Show($"{sys1}");
            } else if (strSys1 != "")
            {
                textbox1.Text = ""; // очищаем строку
                MessageBox.Show("Введена недопустимая система счисления");
            }
            
        }

        private void Sys777RB1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                sys1 = 777; // рим
                TBNum1.Text = "";
                labelHelp.Text = "I-1 V-5 X-10 L-50 C-100 D-500 M-1000";
            }
        }

        //на вход подаётся корректная 100% строка. Не надо проверок
        private static readonly Dictionary<char, int> romanDigits =
        new Dictionary<char, int> {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public static int ConvertFromRimToM(string s)
        {
            int total = 0;
            int prev = 0;
            foreach (char c in s)
            {
                int curr = romanDigits[c];
                total += curr < prev ? -curr : curr; // правило вычитания, сложения
                prev = curr;
            }
            return total;
        }


        public static string[] Rim = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I", " " };
        public static int[] Arab = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1, 0 };

        public static string ConvertFromMToRim(int N)
        {
            string S = "";
            int I = 0;
            while (N > 0)
            {
                while (Arab[I] <= N)
                {
                    S += Rim[I];
                    N -= Arab[I];
                }
                I++;
            }
            return S;
        }

        private void Sys777RB2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                sys2 = 777; // рим
                TBNum1.Text = "";

            }
        }






        // сделать так, чтобы по циферке переводил в другую систему счисления, а принимало строки
        private void Num1_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox1 = sender as TextBox; // приведение к типу текстбокс

            string strNum1 = textbox1.Text;
            if (strNum1 != "" && sys1 != 777 && sys2 != 777)
            {
                try
                {
                    long temp;
                    temp = Convert.ToInt64(strNum1, sys1); // сделать ограничение на ввод максимального значения
                    num2Label.Text = Convert.ToString(temp, sys2);
                }
                catch (OverflowException)
                {
                    textbox1.Text = strNum1.Substring(0, strNum1.Length - 1); // удаляем только что введённый символ
                    MessageBox.Show("Достигнут лимит количества цифр");
                }
                catch (FormatException)
                {
                    textbox1.Text = strNum1.Substring(0, strNum1.Length - 1);
                    MessageBox.Show("Неверный формат числа");
                }

            }
            else if (strNum1 != "" && sys1 == 777 && sys2 != 777) //перевод из римской
            {
                int temp;
                temp = ConvertFromRimToM(strNum1); // в 10
                num2Label.Text = Convert.ToString(temp, sys2);
            }
            else if (strNum1 != "" && sys1 != 777 && sys2 == 777) //перевод в римскую
            {
                try
                {
                    int temp;
                    temp = Convert.ToInt32(strNum1, sys1);
                    if (temp > 100000)
                    {
                        textbox1.Text = strNum1.Substring(0, strNum1.Length - 1); // удаляем только что введённый символ
                        MessageBox.Show("Превышено максимальное число, которое можно записать с помощью римской системы счисления");
                    } else
                    {
                        num2Label.Text = ConvertFromMToRim(temp);
                    }
                    
                }
                catch (OverflowException)
                {
                    textbox1.Text = strNum1.Substring(0, strNum1.Length - 1); // удаляем только что введённый символ
                    MessageBox.Show("Достигнут лимит количества цифр");
                }
                catch (FormatException)
                {
                    textbox1.Text = strNum1.Substring(0, strNum1.Length - 1);
                    MessageBox.Show("Неверный формат числа");
                }
            }
            else if (strNum1 != "" && sys1 == sys2)
            {
                num2Label.Text = strNum1;
            } else
            {
                num2Label.Text = "";
            }
            

            
            

        }

    }
}
