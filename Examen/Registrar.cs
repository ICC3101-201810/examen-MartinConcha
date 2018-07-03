using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    [Serializable()]
    public partial class Registrar : Form
    {
        public Registrar()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.Text = "Registo Nuevo Usuario";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            this.Close();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = textBox1.Text;
            string nombre = textBox2.Text;
            string clave = textBox3.Text;
            int contador = 0;
            foreach (Usuario us in Metodos.usuarios)
            {
                if (us._Usuario == usuario && us.Clave == clave)
                {
                    contador++;
                    MessageBox.Show("Usuario ya existente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox3.Text = "";
                    break;
                }
            }
            if (contador == 0)
            {
                Usuario u = new Usuario(usuario, nombre, clave, 0);
                Metodos.usuarios.Add(u);
                MessageBox.Show("Usuario creado satisfactoriamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 form = new Form1();
                this.Hide();
                form.Show();
            }
            
        }
    }
}
