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
    public partial class Juego : Form
    {
        public static GameBoard gameboard = new GameBoard();
        public static Food food = new Food();
        public static Pacman pacman1 = new Pacman();
        public static Ghost ghost = new Ghost();
        public static Usuario player;
        public static HighScore highscore = new HighScore();
        public Juego(Usuario us)
        {
            player = us;
            InitializeComponent();
        }
        

        public void SetupGame(int Level)
        {
            Tuple<int, int> PacmanStartCoordinates = gameboard.InitialiseBoardMatrix(Level);
            player.CreatePlayerDetails(this);
            highscore.CreateHighScore(this);
            food.CreateFoodImages(this);
            ghost.CreateGhostImage(this);
            pacman1.CreatePacmanImage(this, PacmanStartCoordinates.Item1, PacmanStartCoordinates.Item2);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Up: pacman1.nextDirection = 1; pacman1.MovePacman(1); break;
                case Keys.Right: pacman1.nextDirection = 2; pacman1.MovePacman(2); break;
                case Keys.Down: pacman1.nextDirection = 3; pacman1.MovePacman(3); break;
                case Keys.Left: pacman1.nextDirection = 4; pacman1.MovePacman(4); break;
            }
        }
    }
}
