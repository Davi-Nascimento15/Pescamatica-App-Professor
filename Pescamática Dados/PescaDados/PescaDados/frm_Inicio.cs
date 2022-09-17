using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PescaDados
{
    public partial class frm_Inicio : Form
    {
        private Questoes Q;
        int ind = 0;
        List<Questoes> QLista = new List<Questoes>();
        public frm_Inicio()
        {
            InitializeComponent();
        }
        private void frm_Inicio_Load(object sender, EventArgs e)
        {
            frm_Abertura A = new frm_Abertura();
            A.ShowDialog();
            string[] Line = System.IO.File.ReadAllLines(@"Dados\BaseDados1.txt");
            int i = 0;
            if (Line.Length > 0)
            {
                while (i < Line.Length)
                {
                    Q = new Questoes();
                    Q.Pergunta = Line[i];
                    Q.Alternativa1 = int.Parse(Line[i + 1]);
                    Q.Alternativa2 = int.Parse(Line[i + 2]);
                    Q.Alternativa3 = int.Parse(Line[i + 3]);
                    Q.Alternativa4 = int.Parse(Line[i + 4]);
                    Q.Alternativa5 = int.Parse(Line[i + 5]);
                    Q.Alternativa6 = int.Parse(Line[i + 6]);
                    Q.Alternativa7 = int.Parse(Line[i + 7]);
                    Q.Reposta = int.Parse(Line[i + 8]);
                    i += 9;
                    QLista.Add(Q);
                }
            }
        }
        private void cmd_Salvar_Click(object sender, EventArgs e)
        {
                int aux = 0;
                foreach (Control item in Controls)
                {
                    foreach (Control item1 in Controls)
                    {
                        if ((item1 is TextBox) && (item1.Text == ""))
                        {
                            aux++;
                        }
                    }
                }
            if (aux == 0)
            {
                if (cmd_Salvar.Text == "SALVAR")
                {
                    Q = new Questoes();
                    Q.Pergunta = txt1.Text;
                    Q.Alternativa1 = int.Parse(txt2.Text);
                    Q.Alternativa2 = int.Parse(txt3.Text);
                    Q.Alternativa3 = int.Parse(txt4.Text);
                    Q.Alternativa4 = int.Parse(txt5.Text);
                    Q.Alternativa5 = int.Parse(txt6.Text);
                    Q.Alternativa6 = int.Parse(txt7.Text);
                    Q.Alternativa7 = int.Parse(txt8.Text);
                    Q.Reposta = int.Parse(txt9.Text);
                    QLista.Add(Q);
                    foreach (Control item in Controls)
                    {
                        if (item is TextBox)
                        {
                            item.Text = "";
                        }
                    }
                } else if (cmd_Salvar.Text == "ALTERAR")
                {
                    QLista.RemoveAt(ind);
                    Q = new Questoes();
                    Q.Pergunta = txt1.Text;
                    Q.Alternativa1 = int.Parse(txt2.Text);
                    Q.Alternativa2 = int.Parse(txt3.Text);
                    Q.Alternativa3 = int.Parse(txt4.Text);
                    Q.Alternativa4 = int.Parse(txt5.Text);
                    Q.Alternativa5 = int.Parse(txt6.Text);
                    Q.Alternativa6 = int.Parse(txt7.Text);
                    Q.Alternativa7 = int.Parse(txt8.Text);
                    Q.Reposta = int.Parse(txt9.Text);
                    QLista.Insert(ind, Q);
                }
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Dados\BaseDados1.txt"))
                {
                    for (int i = 0; i < QLista.Count; i++)
                    {
                        file.WriteLine(QLista[i].Pergunta);
                        file.WriteLine(QLista[i].Alternativa1);
                        file.WriteLine(QLista[i].Alternativa2);
                        file.WriteLine(QLista[i].Alternativa3);
                        file.WriteLine(QLista[i].Alternativa4);
                        file.WriteLine(QLista[i].Alternativa5);
                        file.WriteLine(QLista[i].Alternativa6);
                        file.WriteLine(QLista[i].Alternativa7);
                        file.WriteLine(QLista[i].Reposta);
                    }
                }
            }
            else
            {
                MessageBox.Show("Não é permitido deixar campos em branco!!");
            }
        }
        private void cmd_Carregar_Click(object sender, EventArgs e)
        {
            if (cmd_Carregar.Text == "CARREGAR")
            {
                if (QLista.Count > 0)
                {
                    cmd_Ant.Visible = true;
                    cmd_Prox.Visible = true;
                    lbl_Pos.Visible = true;
                    txt1.Text = QLista[ind].Pergunta;
                    txt2.Text = QLista[ind].Alternativa1.ToString();
                    txt3.Text = QLista[ind].Alternativa2.ToString();
                    txt4.Text = QLista[ind].Alternativa3.ToString();
                    txt5.Text = QLista[ind].Alternativa4.ToString();
                    txt6.Text = QLista[ind].Alternativa5.ToString();
                    txt7.Text = QLista[ind].Alternativa6.ToString();
                    txt8.Text = QLista[ind].Alternativa7.ToString();
                    txt9.Text = QLista[ind].Reposta.ToString();
                    lbl_Pos.Text = (ind + 1) + "/" + (QLista.Count);
                    cmd_Ant.Enabled = false;
                    cmd_Salvar.Text = "ALTERAR";
                    cmd_Carregar.Text = "CANCELAR";
                    cmd_Excluir.Visible = true;
                    cmd_Excluir.Enabled = true;
                    if (QLista.Count > 1)
                    {
                        cmd_Prox.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Não há nenhum registro, favor cadastrar!!!");
                }
            }
            else
            {
                foreach (Control item in Controls)
                {
                    if(item is TextBox)
                    {
                        item.Text = "";
                    }
                }
                cmd_Salvar.Text = "SALVAR";
                cmd_Carregar.Text = "CARREGAR";
                cmd_Prox.Visible = false;
                cmd_Ant.Visible = false;
                lbl_Pos.Visible = false;
                cmd_Excluir.Enabled = false;
                cmd_Excluir.Visible = false;
                ind = 0;
            }
        }

        private void cmd_Prox_Click(object sender, EventArgs e)
        {
            if ((ind+1)< QLista.Count)
            {
                ind++;
                txt1.Text = QLista[ind].Pergunta;
                txt2.Text = QLista[ind].Alternativa1.ToString();
                txt3.Text = QLista[ind].Alternativa2.ToString();
                txt4.Text = QLista[ind].Alternativa3.ToString();
                txt5.Text = QLista[ind].Alternativa4.ToString();
                txt6.Text = QLista[ind].Alternativa5.ToString();
                txt7.Text = QLista[ind].Alternativa6.ToString();
                txt8.Text = QLista[ind].Alternativa7.ToString();
                txt9.Text = QLista[ind].Reposta.ToString();
                lbl_Pos.Text = (ind + 1) + "/" + (QLista.Count);
            }
            if (QLista.Count==1)
            {
                cmd_Ant.Enabled = false;
                cmd_Prox.Enabled = false;
            }
            else
            {
                cmd_Ant.Enabled = true;
            }
        }
        private void cmd_Ant_Click(object sender, EventArgs e)
        {
            if (ind > 0)
            {
                ind--;
                txt1.Text = QLista[ind].Pergunta;
                txt2.Text = QLista[ind].Alternativa1.ToString();
                txt3.Text = QLista[ind].Alternativa2.ToString();
                txt4.Text = QLista[ind].Alternativa3.ToString();
                txt5.Text = QLista[ind].Alternativa4.ToString();
                txt6.Text = QLista[ind].Alternativa5.ToString();
                txt7.Text = QLista[ind].Alternativa6.ToString();
                txt8.Text = QLista[ind].Alternativa7.ToString();
                txt9.Text = QLista[ind].Reposta.ToString();
                lbl_Pos.Text = (ind + 1) + "/" + (QLista.Count);
            }
            else
            {
                cmd_Ant.Enabled = false;
            }
        }

        private void cmd_Excluir_Click(object sender, EventArgs e)
        {
            QLista.RemoveAt(ind);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Dados\BaseDados1.txt"))
            {
                for (int i = 0; i < QLista.Count; i++)
                {
                    file.WriteLine(QLista[i].Pergunta);
                    file.WriteLine(QLista[i].Alternativa1);
                    file.WriteLine(QLista[i].Alternativa2);
                    file.WriteLine(QLista[i].Alternativa3);
                    file.WriteLine(QLista[i].Alternativa4);
                    file.WriteLine(QLista[i].Alternativa5);
                    file.WriteLine(QLista[i].Alternativa6);
                    file.WriteLine(QLista[i].Alternativa7);
                    file.WriteLine(QLista[i].Reposta);
                }
            }
            if (QLista.Count > 0)
            {
                txt1.Text = QLista[ind].Pergunta;
                txt2.Text = QLista[ind].Alternativa1.ToString();
                txt3.Text = QLista[ind].Alternativa2.ToString();
                txt4.Text = QLista[ind].Alternativa3.ToString();
                txt5.Text = QLista[ind].Alternativa4.ToString();
                txt6.Text = QLista[ind].Alternativa5.ToString();
                txt7.Text = QLista[ind].Alternativa6.ToString();
                txt8.Text = QLista[ind].Alternativa7.ToString();
                txt9.Text = QLista[ind].Reposta.ToString();
                lbl_Pos.Text = (ind + 1) + "/" + (QLista.Count);
            }
            else
            {
                foreach (Control item in Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
                cmd_Salvar.Text = "SALVAR";
                cmd_Carregar.Text = "CARREGAR";
                cmd_Prox.Visible = false;
                cmd_Ant.Visible = false;
                lbl_Pos.Visible = false;
                cmd_Excluir.Enabled = false;
                cmd_Excluir.Visible = false;
                ind = 0;
            }
        }

        private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txt4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txt5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txt6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txt7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txt8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void txt9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}