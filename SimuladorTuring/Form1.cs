using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SimuladorTuring
{
    

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        int i = 1;

        string A = "01000001", Adica = "010_0_01";
        string L = "01001100", Ldica = "010_1_0_";
        string Adica1 = "010_0_0_";
        string Ndica1 = "01_0_1_0";
        
        string T = "01010100", Tdica = "01_1_1_0";
        string U = "01010101", Udica = "0__1_10_";
        string R = "01010010", Rdica = "0_01__1_";
        string I = "01001001", Idica = "01__1_0_";
        string N = "01001110", Ndica = "0___1__0";
        string G = "01000111", Gdica = "0__0_1__";

        int mili= 0, seg = 0, min= 0;
        int contUm = 0, contDois = 0;

        // ***********************************************************//
        private string strPathFile = @"G:\IFSP\Tecnologo\1º-MOD\HCT\Turing\SimuladorTuring\Rank.txt";


        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            if (i != 8)
                trackBarCabeçote.Value = i++;
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            if (i != 1)
            {
                i--;
                trackBarCabeçote.Value = i-1;
            }
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            switch(trackBarCabeçote.Value)
            {
                case 0:
                    textBox1.Text = "0";
                    break;
                case 1:
                    textBox2.Text = "0";
                    break;
                case 2:
                    textBox3.Text = "0";
                    break;
                case 3:
                    textBox4.Text = "0";
                    break;
                case 4:
                    textBox5.Text = "0";
                    break;
                case 5:
                    textBox6.Text = "0";
                    break;
                case 6:
                    textBox7.Text = "0";
                    break;
                case 7:
                    textBox8.Text = "0";
                    break;
            }
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            switch (trackBarCabeçote.Value)
            {
                case 0:
                    textBox1.Text = "1";
                    break;
                case 1:
                    textBox2.Text = "1";
                    break;
                case 2:
                    textBox3.Text = "1";
                    break;
                case 3:
                    textBox4.Text = "1";
                    break;
                case 4:
                    textBox5.Text = "1";
                    break;
                case 5:
                    textBox6.Text = "1";
                    break;
                case 6:
                    textBox7.Text = "1";
                    break;
                case 7:
                    textBox8.Text = "1";
                    break;
            }
        }

        private void buttonVerificar_Click(object sender, EventArgs e)
        {
            string Letra = textBox1.Text + textBox2.Text + textBox3.Text + textBox4.Text + textBox5.Text + textBox6.Text + textBox7.Text + textBox8.Text;
            
            if (labelDica.Text == Adica)
            {
                if (Letra == A)
                {
                    label_A.ForeColor = Color.Green;
                    labelDica.Visible = true;
                    labelDica.Text = Ldica;
                    Limpar();
                    
                }

            }
            if (labelDica.Text == Ldica)
            {
                if (Letra == L)
                {
                    label_L.ForeColor = Color.Green;
                    labelDica.Visible = true;
                    labelDica.Text = Adica1;
                    Limpar();
                }

            }
            if (labelDica.Text == Adica1)
            {
                if (Letra == A)
                {
                    label_A2.ForeColor = Color.Green;
                    labelDica.Visible = true;
                    labelDica.Text = Ndica1;
                    Limpar();
                }

            }
            if (labelDica.Text == Ndica1)
            {
                if (Letra == N)
                {
                    label_N2.ForeColor = Color.Green;
                    labelDica.Visible = true;
                    labelDica.Text = Tdica;
                    Limpar();
                }

            }

            if (labelDica.Text == Tdica)
            {
                if (Letra == T)
                {
                    label_T.ForeColor = Color.Green;
                    labelDica.Visible = true;
                    labelDica.Text = Udica;
                    Limpar();
                }

            }
            if (labelDica.Text == Udica)
            {
                if (Letra == U)
                {
                    label_U.ForeColor = Color.Green;
                    labelDica.Text = Rdica;
                    Limpar();
                }

            }
            if (labelDica.Text == Rdica)
            {
                if (Letra == R)
                {
                    label_R.ForeColor = Color.Green;
                    labelDica.Text = Idica;
                    Limpar();
                }

            }
            if (labelDica.Text == Idica)
            {
                if (Letra == I)
                {
                    label_I.ForeColor = Color.Green;
                    labelDica.Text = Ndica;
                    Limpar();
                }

            }
            if (labelDica.Text == Ndica)
            {
                if (Letra == N)
                {
                    label_N.ForeColor = Color.Green;
                    labelDica.Text = Gdica;
                    Limpar();
                }

            }
            if (labelDica.Text == Gdica)
            {
                if (Letra == G)
                {
                    label_G.ForeColor = Color.Green;
                    Limpar();
                    timer.Dispose();

                    Form2 cadastro = new Form2(labelClock.Text);
                    cadastro.ShowDialog();
                    
                    string nome = cadastro.Name;
                    string tempo = labelClock.Text;

                    if (File.Exists(strPathFile))
                    {
                        using (StreamWriter sw = File.AppendText(strPathFile))
                        {
                            sw.WriteLine("\n"+nome+";"+tempo);
                        }
                    }

                    FormRank Rank = new FormRank();
                    Rank.ShowDialog();

                    Limpar();
                    Parar();
                    buttonInciar.Image = Properties.Resources.play;
                    labelClock.Text = "00:00:00";
                 }

            }

        }

       
        private void timer_Tick(object sender, EventArgs e)
        {
            contUm++;
            min =  (contUm / 3600);
            seg =  (contUm % 3600) / 60;
            mili = (contUm % 3600) % 60;

            labelClock.Text = string.Format("{0:#,0#}:{1:#,0#}:{2:#,0#}", min, seg, mili);
        }

        private void buttonInciar_Click(object sender, EventArgs e)
        {
        
            Iniciar();
            label1.Visible = true;
            labelDica.Visible = true;
            contDois++;
            if (contDois % 2 == 1)
            {
                timer.Start();
                buttonInciar.Image = Properties.Resources.stop;
                
            }
            else
            {
                Limpar();
                Parar();
            }
        }

        public void Iniciar()
        {
            buttonRank.Enabled = false;
            buttonLeft.Enabled = true;
            buttonOne.Enabled = true;
            buttonRight.Enabled = true;
            buttonVerificar.Enabled = true;
            buttonZero.Enabled = true;
            labelDica.Text = Adica;
            buttonDICA.Visible = true; ;
            buttonDICA.Text = "Dica";
        }
        public void Parar()
        {
            seg = 0; mili = 0; min = 0; contUm = 0;
            buttonRank.Enabled = true;
            buttonLeft.Enabled = false;
            buttonOne.Enabled = false;
            buttonRight.Enabled = false;
            buttonVerificar.Enabled = false;
            buttonZero.Enabled = false;
            labelDica.Text = "";
            labelDica.Visible = false;
            label1.Visible = false;
            buttonDICA.Visible = false;
            panelDica.Visible = false;
            
            labelClock.Text = "00:00:00";
            label_A2.ForeColor = Color.Gray;
            label_L.ForeColor = Color.Gray;
            label_A.ForeColor = Color.Gray;
            label_N2.ForeColor = Color.Gray;

            label_T.ForeColor = Color.Gray;
            label_U.ForeColor = Color.Gray;
            label_R.ForeColor = Color.Gray;
            label_I.ForeColor = Color.Gray;
            label_N.ForeColor = Color.Gray;
            label_G.ForeColor = Color.Gray;
            timer.Dispose();
            buttonInciar.Image = Properties.Resources.play;
        }
        
        public void Limpar()
        {
            textBox1.Text = ""; 
            textBox2.Text = ""; 
            textBox3.Text = ""; 
            textBox4.Text = ""; 
            textBox5.Text = "";
            textBox6.Text = ""; 
            textBox7.Text = ""; 
            textBox8.Text = ""; 
            trackBarCabeçote.Value = 0;
            i = 1;
        }

        private void buttonRank_Click(object sender, EventArgs e)
        {
            FormRank Rank = new FormRank();
            Rank.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (buttonDICA.Text == "Dica")
            {
                panelDica.Visible = true; buttonDICA.Text = "Fechar";
            }
            else
            {
                panelDica.Visible = false; buttonDICA.Text = "Dica";
            }
        }

     }
}
