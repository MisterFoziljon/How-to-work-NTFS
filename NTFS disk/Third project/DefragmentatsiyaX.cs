using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Third_project
{
    internal class DefragmentatsiyaX
    {
        private Button[] button;

        public DefragmentatsiyaX(Button [] button)
        {
            this.button = button;
        }

        public int count_transparent_button(Button [] button)
        {
            int transparent_count = 0;
            
            for (int i = 0;i < all_real_buttons(button);i++)
                if(button[i].BackColor==Color.Transparent && button[i].Text!="")
                    transparent_count++;
        
            return transparent_count;
        }

        public int all_real_buttons(Button[] button)
        {
            for (int i = 0; i < button.Length; i++)
                if (button[i].BackColor == Color.Transparent && button[i+1].BackColor == Color.Transparent)
                    return i;
            return 0;
        }

        public Button [] Defragmentation()
        {
            while (count_transparent_button(button)>0)
            {
                for(int i = 0; i < all_real_buttons(button); i++)
                {
                    if(button[i].BackColor == Color.Transparent)
                    {
                        if (Convert.ToInt32(button[i].Text)>Convert.ToInt32(button[all_real_buttons(button)-1].Text))
                        {
                            int last = Convert.ToInt32(button[i].Text) - Convert.ToInt32(button[all_real_buttons(button) - 1].Text);

                            button[i].BackColor = button[all_real_buttons(button) - 1].BackColor;
                            button[i].Text = button[all_real_buttons(button) - 1].Text;
                            for (int j = all_real_buttons(button)-1; j >= i + 2; j--)
                            {
                                button[j].BackColor = button[j-1].BackColor;
                                button[j].Text= button[j-1].Text;
                            }
                            button[i + 1].BackColor = Color.Transparent;
                            button[i + 1].Text = last.ToString();
                            break;
                        }
                        
                        else if (Convert.ToInt32(button[i].Text) < Convert.ToInt32(button[all_real_buttons(button) - 1].Text))
                        {
                            int last = Convert.ToInt32(button[all_real_buttons(button) - 1].Text)-Convert.ToInt32(button[i].Text);
                            button[i].BackColor = button[all_real_buttons(button) - 1].BackColor;
                            button[all_real_buttons(button) - 1].Text=last.ToString();
                            break;
                        }

                        else
                        {
                            button[i].BackColor = button[all_real_buttons(button) - 1].BackColor;
                            button[i].Text = button[all_real_buttons(button) - 1].Text;
                            button[all_real_buttons(button) - 1].Text = "";
                            button[all_real_buttons(button) - 1].BackColor = Color.Transparent;
                            break;
                        }
                    }
                }
            }

            for(int i=0;i<all_real_buttons(button)-1;i++)
            {
                if(button[i].BackColor==button[i+1].BackColor)
                {
                    button[i].Text=Convert.ToString(Convert.ToInt32(button[i].Text) + Convert.ToInt32(button[i+1].Text));
                    for(int j=i+1;j<all_real_buttons(button)-1;j++)
                    {
                        button[j].BackColor = button[j+1].BackColor;
                        button[j].Text = button[j+1].Text;
                    }
                    button[all_real_buttons(button) - 1].Text = "";
                    button[all_real_buttons(button) - 1].BackColor = Color.Transparent;
                    
                    i--;
                }
            }
            
            return button;
        }
    }
}
