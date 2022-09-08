﻿using System;
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
    public partial class Calc : Form
    {
        float a,b;
        int operation = 0;
        string oldOperation;
        bool sign = true;
        bool reload = false;
        bool action = false;
        int lastOparaion; //1 - число, 2 - знак операции
        string r, bs;

        public Calc()
        {
            InitializeComponent();
        }

        public void numberBtn_Click(object sender, EventArgs e)
        {
            string number = ((Button)sender).Text;
            if (reload)
            {
                textBox1.Text = number;                
                reload = false;
            } else if (lastOparaion == 2) 
            {
                textBox1.Text = number;
                reload = false;
                action = true;
            } else if (action) {
                textBox1.Text += number;
                reload = false;
                action = true;
            } else
            {
                textBox1.Text += number;
                r += number;                
            }
            lastOparaion = 1;
        }

        public void clearInputs(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
            r = "";
            oldOperation = "";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (sign)
            {
                textBox1.Text = "-" + textBox1.Text;
                sign = false;
                if (r.Length == 0)
                {
                    r = "-" + r;
                }
                else if (r[0] != '-')
                {
                    r = "-" + r;
                }
            }
            else
            {
                textBox1.Text = textBox1.Text.Replace("-", "");
                sign = true;
                r = r.Replace("-", "");
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (lastOparaion != 2 || action)
            {
                oldOperation += textBox1.Text + '+';
                a = float.Parse(textBox1.Text);               
                sign = true;
                oparetionAction();                 
                action = false; 
            } else
            {
                oldOperation = oldOperation.Remove(oldOperation.Length - 1) + '+';
            }
            label1.Text = oldOperation;
            lastOparaion = 2;
            operation = 1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (lastOparaion != 2)
            {
                oldOperation += textBox1.Text + '-';
                a = float.Parse(textBox1.Text);              
                sign = true;
                oparetionAction();
                action = false;
            }
            else
            {
                oldOperation = oldOperation.Remove(oldOperation.Length - 1) + '-';
            }
            label1.Text = oldOperation;
            lastOparaion = 2;
            operation = 2;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (lastOparaion != 2)
            {
                oldOperation += textBox1.Text + '/';
                a = float.Parse(textBox1.Text);               
                sign = true;
                oparetionAction();
                action = false;
            }
            else
            {
                oldOperation = oldOperation.Remove(oldOperation.Length - 1) + '/';
            }
            label1.Text = oldOperation;
            operation = 4;
            lastOparaion = 2;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (lastOparaion != 2)
            {
                oldOperation += textBox1.Text + '*';
                a = float.Parse(textBox1.Text);                
                sign = true;
                oparetionAction();
                action = false;
            }
            else
            {
                oldOperation = oldOperation.Remove(oldOperation.Length - 1) + '*';
            }
            label1.Text = oldOperation;
            operation = 3;
            lastOparaion = 2;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            r = r.Remove(0, 1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            oparetionAction();
            label1.Text = "";
            oldOperation = "";
        }

        public string divideAction(float a1, float a2)
        {
            string rs = "";
            if (a2 == 0)
            {
                rs = "Деление на ноль невозможно";
            }
            else
            {
                float frs = a1 / a2;
                rs = frs.ToString();              
            }
            return rs;
        }

        public float multiplyAction(float a1, float a2)
        {
            float rs = a1 * a2;
            return rs;
        }

        public float addAction(float a1, float a2)
        {
            float rs = a1 + a2;
            return rs;
        }

        public float subtractionAction(float a1, float a2) { 
            float rs = a1 - a2;
            return rs;
        }

        public void oparetionAction()
        {

            switch (operation)
            {
                case 1:                   
                    b = addAction(float.Parse(r), a);
                    Console.WriteLine(r);
                    Console.WriteLine(a);
                    r = b.ToString();
                    textBox1.Text = b.ToString();
                    operation = 0;
                    reload = true;                   
                    break;
                case 2:                    
                    b = subtractionAction(float.Parse(r), a);
                    Console.WriteLine(r);
                    Console.WriteLine(a);
                    r = b.ToString();
                    textBox1.Text = b.ToString();
                    operation = 0;
                    reload = true;                    
                    break;
                case 3:                   
                    b = multiplyAction(float.Parse(r), a);
                    Console.WriteLine(r);
                    Console.WriteLine(a);
                    r = b.ToString();
                    textBox1.Text = b.ToString();
                    operation = 0;
                    reload = true;                   
                    break;
                case 4:
                    bs = divideAction(float.Parse(r), a);
                    Console.WriteLine(r);
                    Console.WriteLine(a);
                    b = float.Parse(bs.ToString());
                    r = b.ToString();
                    textBox1.Text = b.ToString();
                    operation = 0;
                    reload = true;                   
                    break;
                default:
                    break;
            }
        }
    }
}
