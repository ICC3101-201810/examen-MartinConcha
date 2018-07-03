using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Examen
{
    [Serializable()]
    public class Usuario
    {
        private string usuario;
        private string nombre;
        private string clave;
        private int puntaje;

        public string _Usuario { get => usuario; set => usuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Clave { get => clave; set => clave = value; }
        public int Puntaje { get => puntaje; set => puntaje = value; }

        public Usuario(string usuario, string nombre, string clave, int puntaje)
        {
            this.usuario = usuario;
            this.nombre = nombre;
            this.clave = clave;
            this.puntaje = puntaje;
        }

        private const int MaxLives = 1;
        public int Score = 0;
        public int Lives = 3;
        public Label ScoreText = new Label();

        public void CreatePlayerDetails(Form formInstance)
        {
            ScoreText.ForeColor = System.Drawing.Color.White;
            ScoreText.Font = new System.Drawing.Font("Folio XBd BT", 14);
            ScoreText.Top = 23;
            ScoreText.Left = 30;
            ScoreText.Height = 20;
            ScoreText.Width = 100;
            formInstance.Controls.Add(ScoreText);
            ScoreText.BringToFront();
            UpdateScore(0);
        }

        public void UpdateScore(int amount = 1)
        {
            Score += amount;
            ScoreText.Text = Score.ToString();
            if (Score > Juego.highscore.Score) { Juego.highscore.UpdateHighScore(Score); }
        }

        public void LoseLife()
        {
            
        }
    }
}
