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
        double result = 0;
        string operations = "";
        bool IsOperation = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
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
            if (double.Parse(NumField.Text) > 0)
            {
                NumField.Text = NumField.Text.Substring(0, (NumField.TextLength - 1));
            }
        }
        private void Square_Click(object sender, EventArgs e)
        {
            NumField.Text = (double.Parse(NumField.Text) * double.Parse(NumField.Text)).ToString();
        }

        private void SquareRoot_Click(object sender, EventArgs e)
        {
            NumField.Text = Math.Sqrt(double.Parse(NumField.Text)).ToString();

        }
        private void Inverse_Click(object sender, EventArgs e)
        {
            NumField.Text = (1/ double.Parse(NumField.Text)).ToString();
        }
       
        private void ChangeSign_Click(object sender, EventArgs e)
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

        private void Equal_Click(object sender, EventArgs e)
        {
            switch(operations)
            {
                case "/":
                    NumField.Text = (result / double.Parse(NumField.Text)).ToString();
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
                case "+/-":
                    NumField.Text = (1 / double.Parse(NumField.Text)).ToString();
                    break;
                case "xʸ":
                    NumField.Text = Math.Pow(result, double.Parse(NumField.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = double.Parse(NumField.Text);
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
                    NumField.Text = NumField.Text + CalcButtons.Text;
                }
            }
            else
            {
                NumField.Text = NumField.Text + CalcButtons.Text;
            }            
        }

        private void Operator_Click(object sender, EventArgs e)
        {
            Button CalcButtons = (Button)sender;
            operations = CalcButtons.Text;
            result = double.Parse(NumField.Text);
            IsOperation = true;
        }

        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            if ((NumField.Text == "0") || (IsOperation))
            {
                NumField.Clear();
            }
            switch ((int)e.KeyValue)
            {
                case '1':
                    NumField.Text = NumField.Text + "1";
                    break;
                case '2':
                    NumField.Text = NumField.Text + "2";
                    break;
                case '3':
                    NumField.Text = NumField.Text + "3";
                    break;
                case '4':
                    NumField.Text = NumField.Text + "4";
                    break;
                case '5':
                    NumField.Text = NumField.Text + "5";
                    break;
                case '6':
                    NumField.Text = NumField.Text + "6";
                    break;
                case '7':
                    NumField.Text = NumField.Text + "7";
                    break;
                case '8':
                    NumField.Text = NumField.Text + "8";
                    break;
                case '9':
                    NumField.Text = NumField.Text + "9";
                    break;
                default:
                    return;
            }
        }
    }
}
