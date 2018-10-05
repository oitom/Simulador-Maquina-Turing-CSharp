using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimuladorTuring
{
    public partial class Form2 : Form
    {
        string tempo = "";
        public string Name = "";

        public Form2(string temp)
        {
            tempo = temp;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBoxTempo.Text = tempo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            Name = textBoxNome.Text;
            this.Close();
        }
    }
}
