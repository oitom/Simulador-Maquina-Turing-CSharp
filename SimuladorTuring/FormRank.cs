using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SimuladorTuring
{
    public partial class FormRank : Form
    {
        public FormRank()
        {
            InitializeComponent();
        }

        private void FormRank_Load(object sender, EventArgs e)
        {
            Carregar();   
        }
        public void Carregar()
        {
            //***********************************************************************************//
            StreamReader arq = new StreamReader(@"G:\IFSP\Tecnologo\1º-MOD\HCT\Turing\SimuladorTuring\Rank.txt", Encoding.Default);
            Dictionary<string, string> Dados = new Dictionary<string, string>();

            string Linha = "";
            int igual = 0;

            try
            {
                while ((Linha = arq.ReadLine().ToString()) != null)
                {
                    string[] dados = Linha.Split(';');
                    //dados[0]= Nome, dados[1]= tempo

                    if (dados[0].TrimEnd() != "" && dados[1].TrimEnd() != "")
                    {
                        if (Dados.Count > 0)
                        {
                            // percorre o dicionario e verifica se já existe uma pontuação do mesmo jogador
                            foreach (string chave in Dados.Keys)
                            {
                                // Deixa sempre a ultima pontuação do jogador
                                if (dados[0] == chave)
                                {
                                    Dados.Remove(chave); 
                                    break;
                                }
                            }
                            Dados.Add(dados[0].TrimEnd(), dados[1].TrimEnd());
                        }
                        else
                            Dados.Add(dados[0].TrimEnd(), dados[1].TrimEnd());
                    }
                }

                
            }
            catch(Exception e)
            {
                string erro = e.ToString();
            }
            finally
            {
                Dados = Dados.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }

            int i = 0;
            foreach (string chave in Dados.Keys)
            {
                switch (i)
                { 
                    case 0:
                        txtNome1.Text = " "+chave; txtTempo1.Text = Dados[chave];
                        break;
                    case 1:
                        txtNome2.Text = " "+chave; txtTempo2.Text = Dados[chave];
                        break;
                    case 2:
                        txtNome3.Text = " "+chave; txtTempo3.Text = Dados[chave];
                        break;
                    case 3:
                        txtNome4.Text = " "+chave; txtTempo4.Text = Dados[chave];
                        break;
                    case 4:
                        txtNome5.Text = " "+chave; txtTempo5.Text = Dados[chave];
                        break;
                    case 5:
                        txtNome6.Text = " "+chave; txtTempo6.Text = Dados[chave];
                        break;
                    case 6:
                        txtNome7.Text = " "+chave; txtTempo7.Text = Dados[chave];
                        break;
                    case 7:
                        txtNome8.Text = " "+chave; txtTempo8.Text = Dados[chave];
                        break;
                    case 8:
                        txtNome9.Text = " "+chave; txtTempo9.Text = Dados[chave];
                        break;
                    case 9:
                        txtNome10.Text = " "+chave; txtTempo10.Text = Dados[chave];
                        break;
                }
                i++;
            }

        }

    }
}
