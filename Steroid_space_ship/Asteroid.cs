using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steroid_space_ship
{
    class Asteroid
    {
        public void f()
        {
            Timer Timer1 = new Timer();//Таймер отвечающий за спавн пули раз в пол секунды
            Timer1.Interval = 400;
            Timer1.Enabled = true;
            Timer1.Tick += new EventHandler(Timer1_Tick);

            //UI_menu.form.matrix[0, 0] = 1;
            //UI_menu.form.matrix[10, 10] = 1;
        }
        Random r = new Random();
        
        private void Timer1_Tick(object Sender, EventArgs o)
        {

            UI_menu.form.matrix[r.Next(0, 20), 0] = 2;
            for (int i = 39; i >= 0; i--)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (i==39 && UI_menu.form.matrix[j, i] == 2)
                    {
                        UI_menu.form.matrix[j, i] = 0;
                    }
                    if (UI_menu.form.matrix[j, i] == 2)
                    {
                        if (UI_menu.form.matrix[j, i + 1] == 3)
                        {
                            UI_menu.form.matrix[j, i + 1] = 0;
                        }
                        else if (UI_menu.form.matrix[j, i + 1] == 1)
                        {
                            UI_menu.form.UI_game_KeyDown(null, null);
                        }
                        else
                        {
                            UI_menu.form.matrix[j, i + 1] = 2;
                        }
                       
                        UI_menu.form.matrix[j, i] = 0;
                    }
                }
            }
        }
    }
}