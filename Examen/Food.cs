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
    public class Food
    {
        public PictureBox[,] FoodImage = new PictureBox[30, 27];
        public int Amount = 0;

        private const int cherry = 10;
        private const int grape = 50;

        public void CreateFoodImages(Form formInstance)
        {
            for (int y = 0; y < 30; y++)
            {
                for (int x = 0; x < 27; x++)
                {
                    if (Juego.gameboard.Matrix[y, x] == 1 || Juego.gameboard.Matrix[y, x] == 2)
                    {
                        FoodImage[y, x] = new PictureBox();
                        FoodImage[y, x].Name = "FoodImage" + Amount.ToString();
                        FoodImage[y, x].SizeMode = PictureBoxSizeMode.AutoSize;
                        FoodImage[y, x].Location = new Point(x * 16 - 1, y * 16 + 47);
                        if (Juego.gameboard.Matrix[y, x] == 1)
                        {
                            FoodImage[y, x].Image = Properties.Resources.cherry;
                            Amount++;
                        }
                        else
                        {
                            FoodImage[y, x].Image = Properties.Resources.tile114;
                        }
                        formInstance.Controls.Add(FoodImage[y, x]);
                        FoodImage[y, x].BringToFront();

                    }
                }
            }
        }

        public void EatCherry(int x, int y)
        {
            FoodImage[x, y].Visible = false;
            Juego.gameboard.Matrix[x, y] = 0;
            Juego.player.UpdateScore(cherry);
        }

        public void EatGrape(int x, int y)
        {
            FoodImage[x, y].Visible = false;
            Juego.gameboard.Matrix[x, y] = 0;
            Juego.player.UpdateScore(grape);
        }
    }
}
