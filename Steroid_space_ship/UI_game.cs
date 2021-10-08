using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steroid_space_ship
{
    public partial class UI_game : Form
    {
        public int[,] matrix = new int[20, 40];
        int timer;
        int count;
        UI_menu menu;
        public UI_game(UI_menu _menu)
        {
            menu = _menu;
            InitializeComponent();
        }

        private void UI_game_Load(object sender, EventArgs e)
        {
            matrix[10, 10] = 3;
            matrix[13, 16] = 1;
            Asteroid aster = new Asteroid();
            aster.f();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    PictureBox pic = new PictureBox
                    {
                        Name = $"{i}_{j}",
                        Size = new Size(20, 20),
                        Location = new Point(20 * i, 20 * j),
                        BackColor = Color.Transparent,
                    };
                    gamepanel.Controls.Add(pic);
                }
            }
        }

        private void UI_game_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Show();
        }

        private void go_Click(object sender, EventArgs e)
        {
            panel_pause.Visible = false;
            timer1.Start();
        }
        public void UI_game_KeyDown(object sender, KeyEventArgs e)
        {
            if (e == null)
            {
                panel_pause.Visible = true;
                panel_pause.Location = new Point(0, 0);
                timer1.Stop();
                mainTimer.Stop();
            }
            else if (panel_pause.Visible == true)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    panel_pause.Visible = false;
                    timer1.Start();
                    mainTimer.Start();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                panel_pause.Visible = true;
                panel_pause.Location = new Point(0, 0);
                timer1.Stop();
                mainTimer.Stop();
            }
        }

        private void menuexit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void score_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lifetime.Text = $"Время игры: {timer.ToString()}";
            scoregame.Text = $"Счёт игры: {count.ToString()}";
            timer++;

        }

        private void lifetime_Click(object sender, EventArgs e)
        {

        }

        private void panel_pause_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gamepanel_Paint(object sender, PaintEventArgs e)
        {

           
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    switch (matrix[i, j])
                    {
                        case 0:
                            PictureBox pic2 = gamepanel.Controls[$"{i}_{j}"] as PictureBox;
                            pic2.BackColor = Color.Transparent;
                            break;
                        case 1:
                            PictureBox pic3 = gamepanel.Controls[$"{i}_{j}"] as PictureBox;
                            pic3.BackColor = Color.Blue;
                            break;
                        case 2:
                            PictureBox pic = gamepanel.Controls[$"{i}_{j}"] as PictureBox;
                            pic.BackColor = Color.White;
                            break;
                        case 3:
                            PictureBox pic1 = gamepanel.Controls[$"{i}_{j}"] as PictureBox;
                            pic1.BackColor = Color.Yellow;
                            break;
                    }
                }
            }
        }

    }
}
