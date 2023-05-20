/*
    Name: Christian Jay Putol
    Date Created: 3/19/2023
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Operators
{
    public partial class Form1 : Form
    {
        double accumulator = 0.0;
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            lblResult.Visible = true;

            string input = txtBoxValue.Text.Trim();
            char op;
            double operand;
            ScanData(input, out op, out operand);
            DoNextOperation(op, operand, ref accumulator);

            counter++;
            if (op != 'q' && counter <= 1)
            {
                lblResult.Text = $"result so far is {accumulator:N1}";
            }
            else if (op == 'q' || op == 'Q')
            {
                lblResult.Text = $"Final result is {accumulator:N1}";
                txtBoxValue.Enabled = false;
                btnCalculate.Enabled = false;
            }
            else if (op != 'q' && counter > 1)
            {
                lblResult.Text = $"the result so far is {accumulator:N1}";
            }

        }

        private void ScanData(string input, out char op, out double operand)
        {
            op = ' ';
            operand = 0;
            try
            {
                string[] tokens = input.Split(' ');
                op = char.Parse(tokens[0]);
                operand = double.Parse(tokens[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    

        private void DoNextOperation(char op, double operand, ref double accumulator)
        {
            switch (op)
            { 
                case '+': accumulator += operand; break;
                case '-': accumulator -= operand; break;
                case '*': accumulator *= operand; break;
                case '/': accumulator /= operand; break;
                case '^': accumulator = Math.Pow(accumulator, operand); break;
                case 'q': case 'Q':  break;
                default:
                    counter = 0;
                    MessageBox.Show("The valid operators are \n + add \n - minus \n * multiply \n / division \n ^ root \n q for quit","Invalid",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblResult.Text = "Error";
                    lblResult.Visible = false;
                    txtBoxValue.Enabled = true;
                    btnCalculate.Enabled = true;
                break;
            }
            txtBoxValue.Clear();
            
        }

        private void txtBoxValue_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblValue_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            counter = 0;
            accumulator = 0.0;
            lblResult.Text = "0";
            lblResult.Visible = false;
            txtBoxValue.Enabled = true;
            btnCalculate.Enabled = true;
        }
    }
}
