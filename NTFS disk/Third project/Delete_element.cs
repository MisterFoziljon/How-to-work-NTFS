using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Third_project
{
    internal class Delete_element
    {
        private Button[] buttons;
        private int index;
        private int all;

        public Delete_element(Button[] buttons, int index,int all)
        {
            this.buttons = buttons;
            this.index = index;
            this.all = all;
        }

        public Button[] btn_del()
        {
            int sanagich = 0;
            for(int i=0;i<all;i++)
            {
                if (sanagich == all)
                    break;
                sanagich++;
                if(buttons[i].BackColor == Color.Transparent && buttons[i+1].BackColor == Color.Transparent && buttons[i].Text!="" && buttons[i+1].Text!="") 
                { 
                    buttons[i].Text = Convert.ToString(Convert.ToInt32(buttons[i].Text) + Convert.ToInt32(buttons[i + 1].Text));
                    for (int j = i + 1; j < all; j++)
                    {
                        buttons[j].Text = buttons[j + 1].Text;
                        buttons[j].BackColor = buttons[j + 1].BackColor;
                    }
                    i -= 1;
                }
            }
            for (int i = 0; i < all; i++)
            {
                if (buttons[i].BackColor == Color.Transparent && buttons[i + 1].BackColor == Color.Transparent && buttons[i].Text != "" && buttons[i + 1].Text == "")
                    buttons[i].Text = "";
               
            }

            return buttons;
        }

        public int btn_data_del()
        {
            int data = 0;
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].BackColor == Color.Transparent && buttons[i + 1].BackColor == Color.Transparent)
                {
                    data = i;
                    break;
                }
            }
            return data;
        }
    }
}
