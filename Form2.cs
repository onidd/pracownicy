using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pracownicy
{
    public partial class Form2 : Form
    {
        private string imie;
        private string nazwisko;
        private string wiek;
        private string stanowisko;
        private Form1 form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Skiper");
            comboBox1.Items.Add("Szerogowy");
            comboBox1.Items.Add("Kowalski");
            comboBox1.Items.Add("Rico");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.imie = imie;
            form1.nazwisko = nazwisko;
            form1.wiek = wiek;
            form1.stanowisko = stanowisko;
            form1.adduser();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            imie = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            nazwisko = textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            wiek = textBox3.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(comboBox1.SelectedItem != null) {
                stanowisko = comboBox1.SelectedItem.ToString();
            }
        }

     
    }
}
