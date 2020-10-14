using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BaseDeDatos603
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connection = "datasource=localhost;port=3306;username=root;password=;database=prueba1";
            string query = "SELECT * FROM datos";
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                conectionDatabase.Open();
                reader = databaseCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        //Console.WriteLine(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + " "+reader.GetString(3));
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);

                    }
                }
                else
                {
                    Console.WriteLine("No hay datos existentes bro :'v");
                }
                conectionDatabase.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GuardarUsuario()
        {
            string connection = "datasource=localhost;port=3306;username=root;password=;database=prueba1";
            string query = "INSERT INTO datos(`id`, `apellido`, `nombre`, `correo`) VALUES (NULL, '" + textBox1.Text + "', '" + textBox3.Text + "', '" + textBox2.Text + "')";
            MySqlConnection conectionDatabase = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, conectionDatabase);
            databaseCommand.CommandTimeout = 60;

            try
            {
                conectionDatabase.Open();
                MySqlDataReader reader1 = databaseCommand.ExecuteReader();
                MessageBox.Show("Registro exitoso");
                conectionDatabase.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void MostrarUsuario()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=prueba1;";
            string query = "SELECT * FROM datos";
            MySqlConnection databaseConnection = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        var ListViewItems = new ListViewItem(row);
                        listView1.Items.Add(ListViewItems);
                    }

                }
                else
                {
                    Console.WriteLine("No se encontro nada");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void Buscar()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=prueba1;";
            string query = "SELECT * FROM datos where id= '" + textBox4.Text + "'";
            MySqlConnection databaseConnection = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        // var ListViewItems = new ListViewItems(row);
                        textBox1.Text = row[1];
                        textBox2.Text = row[2];
                        textBox3.Text = row[3];
                    }
                }
                else
                {
                    Console.WriteLine("Ningun registro coincide");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void ModificarDato()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=prueba1;";
            string query = "UPDATE `datos` SET `apellido`='" + textBox1.Text + "',`nombre`='" + textBox2.Text + "',`correo`='" + textBox3.Text + "' WHERE id = '" + textBox4.Text + "' ";
            MySqlConnection databaseConnection = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;


            try
            {
                databaseConnection.Open();
                MySqlDataReader myRead = commandDatabase.ExecuteReader();
                MessageBox.Show("Registro Modificado");
                databaseConnection.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BorrarDato()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=prueba1;";
            string query = "DELETE FROM datos WHERE id= '" + textBox4.Text + "'";
            MySqlConnection databaseConnection = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                MySqlDataReader myRead = commandDatabase.ExecuteReader();
                MessageBox.Show("El registro ha sido eliminado permanentemente.");
                databaseConnection.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    

                private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {// Guardar Dato
            if (textBox1.Text == "")
            {
                MessageBox.Show("No tienes nombre");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("No tienes Apellido");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("No pusiste correo");
            }
            else
            {

                GuardarUsuario();
                MostrarUsuario();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//Actualizar
            MostrarUsuario();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Buscar();
            MostrarUsuario();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {//Modoficar
            if (textBox1.Text == "")
            {
                MessageBox.Show("No puede haber registros vacios");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("No puede haber registros vacios");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("No puede haber registros vacios");
            }
            else
            {

                ModificarDato();
                MostrarUsuario();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            BorrarDato();
            MostrarUsuario();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
