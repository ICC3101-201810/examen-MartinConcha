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
    public partial class Menu : Form
    {
        Usuario current;
        Form1 parentWindow;
        public Menu(Usuario u, Form1 parentWindow)
        {
            this.parentWindow = parentWindow;
            this.current = u;
            InitializeComponent();
            this.CenterToScreen();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Juego juego = new Juego(current);
            juego.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            parentWindow.Show();
            base.OnClosed(e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LeaderBoard lb = new LeaderBoard();
            lb.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos guardados satisfactoriamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Metodos.Serializar();
        }
    }
}
