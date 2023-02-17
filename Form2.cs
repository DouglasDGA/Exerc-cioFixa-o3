using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercíciosDeFixação3
{
    public partial class Form2 : System.Windows.Forms.Form
    {
        SqlConnection conn = new SqlConnection("Data Source=OSA0625215W10-1;Initial Catalog=FIXACAO_000;Integrated Security=True");
        SqlCommand comando = new SqlCommand();
        SqlDataReader dr;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comando.Connection = conn;
            CarregarLista();
        }

        private void CarregarLista()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();

            conn.Open();
            comando.CommandText = "select * from EXERCICIO3";
            dr = comando.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[0].ToString());
                    listBox2.Items.Add(dr[1].ToString());
                    listBox3.Items.Add(dr[2].ToString());
                    listBox4.Items.Add(dr[3].ToString());
                    listBox5.Items.Add(dr[4].ToString());
                    listBox6.Items.Add(dr[5].ToString());
                }
            }
            conn.Close();
        }

        private void Alinhar(object sender)
        {
            ListBox l = sender as ListBox;
            if (l.SelectedIndex != -1)
            {
                listBox1.SelectedIndex = l.SelectedIndex;
                listBox2.SelectedIndex = l.SelectedIndex;
                listBox3.SelectedIndex = l.SelectedIndex;
                listBox4.SelectedIndex = l.SelectedIndex;
                listBox5.SelectedIndex = l.SelectedIndex;
                listBox6.SelectedIndex = l.SelectedIndex;

                textBox1.Text = listBox1.SelectedItem.ToString();
                textBox2.Text = listBox2.SelectedItem.ToString();
                textBox3.Text = listBox3.SelectedItem.ToString();
                textBox4.Text = listBox4.SelectedItem.ToString();
                textBox5.Text = listBox5.SelectedItem.ToString();
                textBox6.Text = listBox6.SelectedItem.ToString();
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Alinhar(sender);
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Alinhar(sender);
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Alinhar(sender);
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            Alinhar(sender);
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            Alinhar(sender);
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            Alinhar(sender);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox2.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            comando.CommandText = "insert into EXERCICIO3(nome,endereco,datanascimento,telefone,email) values ('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
            comando.ExecuteNonQuery();
            conn.Close();
            CarregarLista();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox2.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            comando.CommandText = "update EXERCICIO3 set nome = '" + textBox2.Text + "',endereco = '" + textBox3.Text + "',datanascimento = '" + textBox4.Text + "',telefone = '" + textBox5.Text + "',email = '" + textBox6.Text + "'where codigo = '" + listBox1.SelectedItem.ToString() + "'";
            comando.ExecuteNonQuery();
            conn.Close();
            CarregarLista();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox2.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("DESEJA REALMENTE EXCLUIR ??", "CORFIRMAÇÃO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                conn.Open();
                comando.CommandText = "delete from EXERCICIO3 where codigo = '" + textBox1.Text + "'";
                comando.ExecuteNonQuery();
                conn.Close();
                CarregarLista();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox2.Focus();
                MessageBox.Show("Dados Excluídos !!!", "Confirmado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Dados Não Excluídos !!!", "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'fIXACAO_000DataSet.EXERCICIO3'. Você pode movê-la ou removê-la conforme necessário.
            this.eXERCICIO3TableAdapter.Fill(this.fIXACAO_000DataSet.EXERCICIO3);

        }
    }
}
