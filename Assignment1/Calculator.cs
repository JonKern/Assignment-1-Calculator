using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment1
{
    public partial class Calculator : Form
    {
        double result = 0.0;
        string operations = "";
        bool IsOperation = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            this.ActiveControl = NumField;
        }

        private void NumField_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            NumField.Text = "0";
            result = 0;
        }

        private void ClearEntry_Click(object sender, EventArgs e)
        {
            NumField.Text = "0";
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (NumField.TextLength > 0)
            {
                NumField.Text = NumField.Text.Substring(0, (NumField.TextLength - 1));
                if (NumField.TextLength == 0)
                {
                    NumField.Text = "0";
                }
            }
        }

        private void Square_Click(object sender, EventArgs e)
        {
            NumField.Text = (double.Parse(NumField.Text) * double.Parse(NumField.Text)).ToString();
        }

        private void SquareRoot_Click(object sender, EventArgs e)
        {
            if (double.Parse(NumField.Text) >= 0)
            {
                NumField.Text = Math.Sqrt(double.Parse(NumField.Text)).ToString();
            }
            else
            {
                MessageBox.Show("The square root of a negative real number is imaginary.");
            }
        }
        private void Inverse_Click(object sender, EventArgs e)
        {
            NumField.Text = (1/ double.Parse(NumField.Text)).ToString();
        }
       
        private void ChangeSign_Click(object sender, EventArgs e)
        {
            if (NumField.Text != "0")
            {
                if (NumField.Text.Contains("-"))
                {
                    NumField.Text = NumField.Text.Trim('-');
                }
                else
                {
                    NumField.Text = "-" + NumField.Text;
                }
            }
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            switch (operations)
                {
                 case "/":
                    if (double.Parse(NumField.Text) != 0)
                    {
                        NumField.Text = (result / double.Parse(NumField.Text)).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Cannot divide by 0.");
                    }
                    break;
                case "*":
                    NumField.Text = (result * double.Parse(NumField.Text)).ToString();
                    break;
                case "-":
                    NumField.Text = (result - double.Parse(NumField.Text)).ToString();
                    break;
                case "+":
                    NumField.Text = (result + double.Parse(NumField.Text)).ToString();
                    break;
                case "xʸ":
                    NumField.Text = Math.Pow(result, double.Parse(NumField.Text)).ToString();
                    break;
                default:
                    break;
                }
                result = double.Parse(NumField.Text);
                operations = "";            
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if ((NumField.Text == "0") || (IsOperation))
            {
                NumField.Clear();
            }

            IsOperation = false;
            Button CalcButtons = (Button)sender;

            if (CalcButtons.Text == ".")
            {
                if (!NumField.Text.Contains("."))
                {
                    NumField.Text += CalcButtons.Text;
                }
            }
            else
            {
                NumField.Text += CalcButtons.Text;
            }
            this.ActiveControl = NumField;
            NumField.SelectionLength = 0;
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button CalcButtons = (Button)sender;

            if (result != 0)
            {
                Equal.PerformClick();
                IsOperation = true;
                operations = CalcButtons.Text;
                NumField.Text = result + " " + operations;
            }
            else
            {
                operations = CalcButtons.Text;
                result = double.Parse(NumField.Text);
                IsOperation = true;
                NumField.Text = result + " " + operations;
            }
            this.ActiveControl = NumField;
            NumField.SelectionLength = 0;
        }

        private void Calculator_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if ((NumField.Text == "0") || (IsOperation))
            {
                NumField.Clear();
            }
            switch (e.KeyChar.ToString())
            {                
                case "0":
                    Num0.PerformClick();
                    break;
                case "1":
                    Num1.PerformClick();
                    break;
                case "2":
                    Num2.PerformClick();
                    break;
                case "3":
                    Num3.PerformClick();
                    break;
                case "4":
                    Num4.PerformClick();
                    break;
                case "5":
                    Num5.PerformClick();
                    break;
                case "6":
                    Num6.PerformClick();
                    break;
                case "7":
                    Num7.PerformClick();
                    break;
                case "8":
                    Num8.PerformClick();
                    break;
                case "9":
                    Num9.PerformClick();
                    break;
                case "/":
                    Divide.PerformClick();
                    break;
                case "*":
                    Multiply.PerformClick();
                    break;
                case "-":
                    Subtract.PerformClick();
                    break;
                case "+":
                    Add.PerformClick();
                    break;
                case "=":
                    Equal.PerformClick();
                    break;
                case "\n": // Handles the Enter key
                    Equal.PerformClick();
                    break;
                case "\b": // Handles the BackSpace key (delete)
                    Delete.PerformClick();
                    break;
                default:
                    return;
            }
        }

        private void NumsSymbs_MouseEnter(object sender, EventArgs e)
        {
            Button CalcButtons = (Button)sender;
            CalcButtons.BackColor = Color.FromArgb(155, 155, 155);
        }

        private void Equals_MouseEnter(object sender, EventArgs e)
        {
            Button CalcButtons = (Button)sender;
            CalcButtons.BackColor = Color.FromArgb(89, 111, 255);
        }

        private void Clear_MouseEnter(object sender, EventArgs e)
        {
            Button CalcButtons = (Button)sender;
            CalcButtons.BackColor = Color.FromArgb(255, 178, 102);
        }

        private void Nums_MouseLeave(object sender, EventArgs e)
        {
            Button CalcButtons = (Button)sender;
            CalcButtons.BackColor = Color.FromArgb(26, 26, 26);
        }

        private void Symbols_MouseLeave(object sender, EventArgs e)
        {
            Button CalcButtons = (Button)sender;
            CalcButtons.BackColor = Color.FromArgb(72, 72, 72);
        }

        private void Clear_MouseLeave(object sender, EventArgs e)
        {
            Button CalcButtons = (Button)sender;
            CalcButtons.BackColor = Color.FromArgb(231, 125, 20);
        }

        private void Equals_MouseLeave(object sender, EventArgs e)
        {
            Button CalcButtons = (Button)sender;
            CalcButtons.BackColor = Color.FromArgb(71, 102, 137);
        }
    }
}
