using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Examen
{
    public class Pacman
    {
        public int xCoordinate = 0;
        public int yCoordinate = 0;
        private int xStart = 0;
        private int yStart = 0;
        public int currentDirection = 0;
        public int nextDirection = 0;
        public PictureBox PacmanImage = new PictureBox();
        private ImageList PacmanImages = new ImageList();
        private Timer timer = new Timer();

        private int imageOn = 0;

        public Pacman()
        {
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);

            PacmanImages.Images.Add(Properties.Resources.pacman_down);
            PacmanImages.Images.Add(Properties.Resources.pacman_up);
            PacmanImages.Images.Add(Properties.Resources.pacman_left);
            PacmanImages.Images.Add(Properties.Resources.pacman_right);

            PacmanImages.ImageSize = new Size(27, 28);

        }

        public void CreatePacmanImage(Form formInstance, int StartXCoordinate, int StartYCoordinate)
        {
            // Create Pacman Image
            xStart = StartXCoordinate;
            yStart = StartYCoordinate;
            PacmanImage.Name = "PacmanImage";
            PacmanImage.SizeMode = PictureBoxSizeMode.AutoSize;
            Set_Pacman();
            formInstance.Controls.Add(PacmanImage);
            PacmanImage.BringToFront();
        }

        public void MovePacman(int direction)
        {
            bool CanMove = check_direction(nextDirection);
            if (!CanMove) { CanMove = check_direction(currentDirection); direction = currentDirection; } else { direction = nextDirection; }
            if (CanMove) { currentDirection = direction; }

            if (CanMove)
            {
                switch (direction)
                {
                    case 1: PacmanImage.Top -= 16; yCoordinate--; break;
                    case 2: PacmanImage.Left += 16; xCoordinate++; break;
                    case 3: PacmanImage.Top += 16; yCoordinate++; break;
                    case 4: PacmanImage.Left -= 16; xCoordinate--; break;
                }
                currentDirection = direction;
                UpdatePacmanImage();
                CheckPacmanPosition();
                Juego.ghost.CheckForPacman();
            }
        }

        private void CheckPacmanPosition()
        {
            switch (Juego.gameboard.Matrix[yCoordinate, xCoordinate])
            {
                case 1: Juego.food.EatCherry(yCoordinate, xCoordinate); break;
                case 2: Juego.food.EatGrape(yCoordinate, xCoordinate); break;
            }
        }

        private void UpdatePacmanImage()
        {
            PacmanImage.Image = PacmanImages.Images[((currentDirection - 1) * 4) + imageOn];
            imageOn++;
            if (imageOn > 3) { imageOn = 0; }
        }

        private bool check_direction(int direction)
        {
            switch (direction)
            {
                case 1: return direction_ok(xCoordinate, yCoordinate - 1);
                case 2: return direction_ok(xCoordinate + 1, yCoordinate);
                case 3: return direction_ok(xCoordinate, yCoordinate + 1);
                case 4: return direction_ok(xCoordinate - 1, yCoordinate);
                default: return false;
            }
        }

        private bool direction_ok(int x, int y)
        {
            // Check if board space can be used
            if (x < 0) { xCoordinate = 27; PacmanImage.Left = 429; return true; }
            if (x > 27) { xCoordinate = 0; PacmanImage.Left = -5; return true; }
            if (Juego.gameboard.Matrix[y, x] < 4) { return true; } else { return false; }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            MovePacman(currentDirection);
        }

        public void Set_Pacman()
        {
            PacmanImage.Image = Properties.Resources.pacman_right;
            currentDirection = 0;
            nextDirection = 0;
            xCoordinate = xStart;
            yCoordinate = yStart;
            PacmanImage.Location = new Point(xStart * 16 - 3, yStart * 16 + 43);
        }
    }
}
