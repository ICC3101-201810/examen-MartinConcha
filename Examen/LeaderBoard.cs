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
    public partial class LeaderBoard : Form
    {
        public LeaderBoard()
        {
            InitializeComponent();
            this.CenterToScreen();
        }

        private void LeaderBoard_Load(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            foreach (Usuario u in Metodos.usuarios)
            {
                ListViewItem item = new ListViewItem();
                item = listView1.Items.Add(u.Nombre);
                item.SubItems.Add(u.Puntaje.ToString());
            }
        }
    }
}
