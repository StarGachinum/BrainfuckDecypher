using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private int fieldWithTextIndex;//BF = 0 Normal = 1

        public Form1()
        {
            InitializeComponent(); 
        }

        public void FindFieldWithText()
        {
            CheckIfDebil();
            if (brainfuckTextField.Text != "")
            {
                fieldWithTextIndex = 0;
            }
            else
            {
                fieldWithTextIndex = 1;
            }
        }
        public void CheckIfDebil()
        {
            if (brainfuckTextField.Text != "" && normalTextField.Text != "")
            {
                brainfuckTextField.Text = "";
                normalTextField.Text = "";
                MessageBox.Show("Are you OK?");
            }
        }

        private void decypherButton_Click(object sender, EventArgs e)
        {
            FindFieldWithText();
            ChooseDecypher();
        }

        private void ChooseDecypher()
        {
            if (fieldWithTextIndex == 0)
            {
                normalTextField.Text = ConvertToNormal(brainfuckTextField.Text, normalTextField.Text);
                brainfuckTextField.Text = "";
            }
            else
            {
                brainfuckTextField.Text = ConvertToBrainfuck(normalTextField.Text, brainfuckTextField.Text);
                normalTextField.Text = "";
            }
        }

        private string ConvertToBrainfuck(string from, string to)
        {
            byte[] ASCIIcodes = Encoding.ASCII.GetBytes(from);
            int length = ASCIIcodes.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < ASCIIcodes[i]; j++)
                {
                    to += "+";
                }
                to += ".>";
            }
            return to;
        }

        private string ConvertToNormal(string from, string to)
        {
            string[] bfCells = from.Split('>');
            int length = bfCells.Length;
            byte[] acsiiCodes = new byte[length];
            for (int i = 0; i < length; i++)
            {
                byte acsiiCode = 0;
                foreach (char cha in bfCells[i])
                {
                    if (cha == '+')
                        acsiiCode++;
                }
                acsiiCodes[i] = acsiiCode;
            }

            to += Encoding.ASCII.GetString(acsiiCodes);
            return to;

        }
    }
}
