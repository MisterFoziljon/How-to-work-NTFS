using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.DataFormats;

namespace Third_project
{
    internal class Insert_element
    {
        private Button[] buttons;
        private Button button;
        private int all;

        public Insert_element(Button[] buttons, Button button, int all)
        {
            this.buttons = buttons;
            this.button = button;
            this.all = all;
        }

        public Button[]btn_insert()
        {
            int son = 0;
            for(int i=0;i<all;i++)
                if(buttons[i].BackColor==Color.Transparent && buttons[i].Text != "")
                    son++;
            if(son==0)
            {
                buttons[all].Text = button.Text;
                buttons[all].BackColor = button.BackColor;
            }

            else
            {
                Format format= new Format();
                int[] index=new int [son];
                string umumiy = button.Text;
                for(int i=0;i<all;i++)
                {
                    if (buttons[i].BackColor == Color.Transparent && buttons[i].Text != "" && tenpercent(umumiy,buttons[i].Text))
                    {
                        if(Convert.ToInt32(button.Text) > Convert.ToInt32(buttons[i].Text))
                        {
                            buttons[i].BackColor = button.BackColor;
                            button.Text = Convert.ToString(Convert.ToInt32(button.Text) - Convert.ToInt32(buttons[i].Text));
                        }

                        else if (Convert.ToInt32(button.Text) < Convert.ToInt32(buttons[i].Text))
                        {
                            for(int j=all;j>i+1;j--)
                            {
                                buttons[j].Text = buttons[j - 1].Text;
                                buttons[j].BackColor=buttons[j-1].BackColor;
                            }
                            buttons[i+1].Text = Convert.ToString(Convert.ToInt32(buttons[i].Text) - Convert.ToInt32(button.Text));
                            buttons[i+1].BackColor=Color.Transparent;
                            buttons[i].Text = button.Text;
                            buttons[i].BackColor=button.BackColor;
                            button.Text = "0";
                            break;
                        }

                        else
                        {
                            buttons[i].Text = button.Text;
                            buttons[i].BackColor=button.BackColor;
                            button.Text = "0";
                            break;
                        }
                    }
                }
                if(Convert.ToInt32(button.Text)>0)
                {
                    for(int i=0;i<buttons.Length;i++)
                    {
                        if(buttons[i].BackColor==Color.Transparent && buttons[i+1].BackColor == Color.Transparent)
                        {
                            buttons[i].Text = button.Text;
                            buttons[i].BackColor = button.BackColor;
                            break;
                        }
                    }
                }

            }
            return buttons;
        }

        public int btn_data_insert()
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

        public bool tenpercent(string text1,string text2)
        {
            long x1=Convert.ToInt64(text1);
            long x2 = Convert.ToInt64(text2);

            if(x1/10>x2)
                return false;
            return true;
        }
    }
}
