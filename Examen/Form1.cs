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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.Text = "Bienvenido";
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registrar r = new Registrar();
            this.Hide();
            r.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int contador = 0;
            foreach (Usuario u in Metodos.usuarios)
            {
                if (textBox1.Text == u._Usuario && textBox2.Text == u.Clave)
                {
                    contador++;
                    Menu m = new Menu(u, this);
                    this.Hide();
                    m.Show();
                    break;
                }
            }
            if (contador == 0)
            {
                MessageBox.Show("Usuario no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            textBox1.Text = "";
            textBox2.Text = "";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Metodos.Serializar();
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LeaderBoard lb = new LeaderBoard();
            lb.Show();
        }
    }
}
