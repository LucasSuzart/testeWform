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
//using MySql.Data.MySqlClient;

namespace testeWform

{
    public partial class Form1 : Form   
    {
       private SqlConnection Conexao;
        private string data_source = "server=MEGAWARE-W240HU;database=db_agenda;user id=sa;pwd=123456";
        public Form1()
        {
            InitializeComponent();
            txtNome.Focus();
            txtTelefone.Focus();

            lstContatos.View = View.Details;
            lstContatos.LabelEdit = true;
            lstContatos.AllowColumnReorder = true;
            lstContatos.FullRowSelect = true;
            lstContatos.GridLines = true;
           //stContatos.Columns.Add("ID",140, HorizontalAlignment.Left);
            lstContatos.Columns.Add("Nome", 140, HorizontalAlignment.Left);
            lstContatos.Columns.Add("E-mail", 140, HorizontalAlignment.Left);
            lstContatos.Columns.Add("Telefone", 30, HorizontalAlignment.Left);

        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                //criar conexao com o MySql

                // executar o comando Insert 

                // string data_source = "data_source=localhost;username=root;password=;database=db_agenda";
                SqlCommand cmd = new SqlCommand();
                Conexao = new SqlConnection(data_source);
                Conexao.Open();

                
                txtNome.Text = txtNome.Text.ToUpper();
                txtEmail.Text = txtEmail.Text.ToUpper();
               // string sql = "INSERT INTO contatos (nome,email,telefone)" + "VALUES" + "('" + txtNome.Text + "','" + txtEmail.Text + "','" + txtTelefone.Text + "')";

               // SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conexao;


                cmd.CommandText = "INSERT INTO contatos (nome,email,telefone)" + "VALUES" +
                                   "(@nome,@email,@telefone)";


                cmd.Prepare();
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@telefone", txtTelefone.Text);

                cmd.ExecuteNonQuery();



                //cmd.CommandText = "INSERT INTO contatos (nome,email,telefone)" + "VALUES" +
                // "('" + txtNome.Text + "','" + txtEmail.Text + "','" + txtTelefone.Text + "')";

               // Conexao.Open();
                //comando.ExecuteReader();
              cmd.ExecuteReader();
               // MessageBox.Show("deu certo");


            }
            catch (SqlException ex) {

                MessageBox.Show("Erro " + ex.Number + " ocorreu: " + ex.Message,
        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }




            finally
            {
                Conexao.Close();
            }

            
            }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                                
                // string data_source = "data_source=localhost;username=root;password=;database=db_agenda";
                Conexao = new SqlConnection(data_source);

                //string sql = "INSERT INTO contatos (nome,email,telefone)" + "VALUES" + "('" + txtNome.Text + "','" + txtEmail.Text + "','" + txtTelefone.Text + "')";
                string q = "'%" + txtBuscar.Text + "%'";

                string buscar = "select * " +
                                "From contatos" +
                                " WHERE nome LIKE " + q + "OR email LIKE " + q;

                Conexao.Open();
                SqlCommand comando = new SqlCommand(buscar, Conexao);

                
                SqlDataReader reader = comando.ExecuteReader();

                lstContatos.Items.Clear();

                while (reader.Read())

                {
                    string[] row =
                    {
                        //Convert.ToString.reader.GetString(0),
               reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3),
                };
                  var linha_listview = new ListViewItem(row);
                    lstContatos.Items.Add(linha_listview);
                    //MessageBox.Show(buscar);

                }
            }


            catch (Exception ex)
            {


                MessageBox.Show(ex.Message);
            }




            finally
            {
                Conexao.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            


        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Sair_Click(object sender, EventArgs e)
        {
            Close();
        }
    }   

            }


        

        

       
