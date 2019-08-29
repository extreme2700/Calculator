using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Double resultVal = 0;
        String operPerform = "";
        bool isOperPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            if (textBoxResult.Text == "0" || isOperPerformed)
            {
                textBoxResult.Clear();
            }

            isOperPerformed = false;
            Button button=(Button)sender;
            if (button.Text == ".")
            {
                if (!textBoxResult.Text.Contains("."))
                {
                    textBoxResult.Text = textBoxResult.Text + button.Text;
                }
            }
            else
                textBoxResult.Text = textBoxResult.Text + button.Text; 
        }

        private void operationClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (resultVal != 0)
            {
                buttonEquals.PerformClick();
                operPerform = button.Text;
                labelCurrOper.Text = resultVal + " " + operPerform;
                isOperPerformed = true;
            }
            else
            {
                operPerform = button.Text;
                resultVal = Double.Parse(textBoxResult.Text);
                labelCurrOper.Text = resultVal + " " + operPerform;
                isOperPerformed = true;
            }
        }

        private void ButtonClearEntry_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "0";
            resultVal = 0;
        }

        private void ButtonEquals_Click(object sender, EventArgs e)
        {
            switch(operPerform)
            {
                case "+":
                    textBoxResult.Text = (resultVal + Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "-":
                    textBoxResult.Text = (resultVal - Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "*":
                    textBoxResult.Text = (resultVal * Double.Parse(textBoxResult.Text)).ToString();
                    break;
                case "/":
                    textBoxResult.Text = (resultVal / Double.Parse(textBoxResult.Text)).ToString();
                    break;
                default:
                    break;
            }

            resultVal = Double.Parse(textBoxResult.Text);
            labelCurrOper.Text = "";
        }
    }
}
