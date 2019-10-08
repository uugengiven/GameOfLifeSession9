using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bertleblip;

namespace MyForm
{
    public partial class Form1 : Form
    {
        GameOfLife game;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new GameOfLife(200, 200);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            game.GoNextGen();

            Bitmap pictureGrid = new Bitmap(game.Width, game.Height);
            for (int i = 0; i < game.Height; i++)
            {
                for (int j = 0; j < game.Width; j++)
                {
                    if (game.grid[i, j])
                    {
                        pictureGrid.SetPixel(j, i, Color.AntiqueWhite);
                    }
                    else
                    {
                        pictureGrid.SetPixel(j, i, Color.DarkCyan);
                    }
                }
            }

            pictureBox1.Image = pictureGrid;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            game.GoNextGen();

            Bitmap pictureGrid = new Bitmap(game.Width, game.Height);
            for (int i = 0; i < game.Height; i++)
            {
                for (int j = 0; j < game.Width; j++)
                {
                    if (game.grid[i, j])
                    {
                        pictureGrid.SetPixel(j, i, Color.AntiqueWhite);
                    }
                    else
                    {
                        pictureGrid.SetPixel(j, i, Color.DarkCyan);
                    }
                }
            }

            pictureBox1.Image = pictureGrid;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
