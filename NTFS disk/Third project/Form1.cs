using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Third_project
{

    public partial class Form1 : Form
    {
        private Button[] buttons = new Button[100];
        private int posx = 250, posy = 55;
        private Color[] colours = new Color[100];
        private int selected_index = -1;
        private string[] TypeofFiles = { "*.gif", "*.jpg", "*.bmp", "*.raw", "*.png", "*.psd", "*.xcf", "*.ai", "*.cdr", "*.raw", "*.cr2", "*.nef", "*.orf", "*.sr2", "*.WEBM", "*.MPG", "*.MP2", "*.MPEG", "*.MPE", "*.MPV", "*.OGG", "*.MP4", "*.M4P", "*.M4V", "*.AVI", "*.WMV", "*.MOV", "*.QT", "*.FLV", "*.SWF" };
        private string[] FileName = { "long", "established", "fact", "that", "a", "reader", "will", "be", "distracted", "by", "the", "readable", "content", "page", "when", "looking", "less", "its", "layout", "The", "point", "using", "Lorem", "Ipsum", "that", "has", "more", "normal", "distribution", "letters" };
        private string[] FileSize;
        private int data_soni = 0;
        private int color_index=40;
        private int button_soni=60;
        private string[,] full_data = null;
        private long xotira_hajmi = 0;

        private long umumiy_xotira()
        {
            xotira_hajmi = 0;
            for (int i=0;i<data_soni;i++)
                xotira_hajmi+=Convert.ToInt32(buttons[i].Text);
            return xotira_hajmi;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            data_soni = Convert.ToInt32(comboBox1.SelectedItem);
            Jadval_tuliq.RowCount = data_soni;
            Rezultat.RowCount = data_soni;
            FileSize=new string[data_soni];
            long check = 0;
            Format format = new Format();
            for (int i = 0; i < data_soni; i++)
            {
                buttons[i].BackColor = colours[color_index];
                buttons[i].Text = FileSize[i] = (5+new Random().Next(10*(i+3)%100)).ToString();
                check+=Convert.ToInt64(buttons[i].Text);
                /*
                if(check>Convert.ToSingle(Xotira_hajmi.Text.Split(' ')[0]))
                {
                    label10.Text = (check - Convert.ToInt32(buttons[i].Text)).ToString() + " MB";
                    buttons[i].BackColor = Color.Transparent;
                    buttons[i].Text = "";
                    MessageBox.Show("Boshqa ma'lumotlar diskka sig'maydi!!!");
                    break;
                }*/
                Jadval_tuliq.Rows[i].Cells[0].Value = FileName[i];
                Rezultat.Rows[i].Cells[0].Value = FileName[i];

                Jadval_tuliq.Rows[i].Cells[1].Value = TypeofFiles[i];
                Rezultat.Rows[i].Cells[1].Value= TypeofFiles[i];

                Jadval_tuliq.Rows[i].Cells[2].Value = FileSize[i];
                Rezultat.Rows[i].Cells[2].Value=FileSize[i];

                Jadval_tuliq.Rows[i].Cells[3].Value = buttons[i].BackColor.Name;
                Rezultat.Rows[i].Cells[3].Value= buttons[i].BackColor.Name;

                if (i == 0)
                {
                    Jadval_tuliq.Rows[i].Cells[4].Value = "0";
                    Rezultat.Rows[i].Cells[4].Value = "0";

                    Jadval_tuliq.Rows[i].Cells[5].Value = format.Unlikdan_un_oltilikka(Convert.ToInt32(FileSize[i])*1000);
                    Rezultat.Rows[i].Cells[5].Value= format.Unlikdan_un_oltilikka(Convert.ToInt32(FileSize[i]) * 1000);
                }
                else
                {
                    Jadval_tuliq.Rows[i].Cells[4].Value = Jadval_tuliq.Rows[i-1].Cells[5].Value.ToString();
                    Rezultat.Rows[i].Cells[4].Value = Jadval_tuliq.Rows[i - 1].Cells[5].Value.ToString();

                    Jadval_tuliq.Rows[i].Cells[5].Value = format.Unlikdan_un_oltilikka(format.Un_oltilikdan_unlikka(Jadval_tuliq.Rows[i].Cells[4].Value.ToString())+Convert.ToInt32(FileSize[i]) * 1000);
                    Rezultat.Rows[i].Cells[5].Value = format.Unlikdan_un_oltilikka(format.Un_oltilikdan_unlikka(Jadval_tuliq.Rows[i].Cells[4].Value.ToString()) + Convert.ToInt32(FileSize[i]) * 1000);
                }
                color_index++;
            }
            
            panel1.Visible = true;
            panel3.Visible = false;
            
        }

        private void clicker(object sender, EventArgs e)
        {
            for (int i = 60; i < button_soni; i++)
                Controls.Remove(buttons[i]);
            int pos_x = 250;
            Button btn = sender as Button;
            string btn_name = btn.Name;
            string btn_color_name = btn.BackColor.Name;

            string x="",y="",z="";
            for(int i=0;i<Rezultat.Rows.Count;i++)
            {
                if(Rezultat.Rows[i].Cells[3].Value==btn_color_name && Rezultat.Rows[i].Cells[3].Value.ToString()!=Color.Transparent.ToString())
                {
                    x = Rezultat.Rows[i].Cells[0].Value.ToString();
                    y = Rezultat.Rows[i].Cells[1].Value.ToString();
                    z = Rezultat.Rows[i].Cells[2].Value.ToString();
                }
            }
            malumot_nomi.Text = x;
            malumot_kengaytma.Text = y;
            malumot_hajmi.Text = z;
            selected_index = Convert.ToInt32(btn_name.Substring(3, btn_name.Length - 3));
            button_soni = 60;
            for (int i = 0; i < data_soni; i++)
                if (buttons[i].BackColor == buttons[selected_index].BackColor)
                {
                    buttons[button_soni] = new Button();
                    buttons[button_soni].Name = "no"+i;
                    buttons[button_soni].Text = buttons[i].Text;
                    buttons[button_soni].Width = 45;
                    buttons[button_soni].Height = 45;
                    buttons[button_soni].Location = new Point(pos_x,230);
                    buttons[button_soni].Enabled = false;
                    buttons[button_soni].BackColor = buttons[i].BackColor;
                    Controls.Add(buttons[i]);
                    pos_x += 45;
                    Controls.Add(buttons[button_soni]);
                    button_soni++;
                }
                    
                if (selected_index < data_soni && buttons[selected_index].BackColor != Color.Transparent) button3.Enabled = true;
                    else button3.Enabled = false;

            label10.Text = umumiy_xotira().ToString() + " MB";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < data_soni; i++)
                if (buttons[i].BackColor == buttons[selected_index].BackColor && selected_index!=i)
                    buttons[i].BackColor = Color.Transparent;
            
            string get_color = buttons[selected_index].BackColor.ToString();
            buttons[selected_index].BackColor = Color.Transparent;

            Delete_element del = new Delete_element(buttons, selected_index,data_soni);
            buttons = del.btn_del();
            data_soni = del.btn_data_del();

            full_data = new string[Jadval_tuliq.RowCount, 6];

            for (int i = 0; i < Jadval_tuliq.RowCount; i++)
            {
                    full_data[i, 0] = Jadval_tuliq.Rows[i].Cells[0].Value.ToString();
                    full_data[i, 1] = Jadval_tuliq.Rows[i].Cells[1].Value.ToString();
                    full_data[i, 2] = Jadval_tuliq.Rows[i].Cells[2].Value.ToString();
                    full_data[i, 3] = Jadval_tuliq.Rows[i].Cells[3].Value.ToString();
                    full_data[i, 4] = Jadval_tuliq.Rows[i].Cells[4].Value.ToString();
                    full_data[i, 5] = Jadval_tuliq.Rows[i].Cells[5].Value.ToString();
            }
            
            Rulit_datagrid rd = new Rulit_datagrid(full_data,buttons,data_soni);
            full_data = rd.Rulit();
            Jadval_tuliq.Rows.Clear();
            Jadval_tuliq.RowCount = full_data.GetLength(0);
            for (int i = 0; i < full_data.GetLength(0); i++)
            {
                Jadval_tuliq.Rows[i].Cells[0].Value = full_data[i, 0];
                Jadval_tuliq.Rows[i].Cells[1].Value = full_data[i, 1];
                Jadval_tuliq.Rows[i].Cells[2].Value = full_data[i, 2];
                Jadval_tuliq.Rows[i].Cells[3].Value = full_data[i, 3];
                Jadval_tuliq.Rows[i].Cells[4].Value = full_data[i, 4];
                Jadval_tuliq.Rows[i].Cells[5].Value = full_data[i, 5];
            }
            rd = new Rulit_datagrid(Jadval_tuliq);
            DataGridView rez =rd.ResultEnd();
            Rezultat.Rows.Clear();
            Rezultat.Columns.Clear();

            Rezultat.RowCount= rez.Rows.Count;
            Rezultat.ColumnCount = rez.Columns.Count;

            Rezultat.Columns[0].Name = "Fayl nomi";
            Rezultat.Columns[1].Name = "Fayl kengaytmasi";
            Rezultat.Columns[2].Name = "Hajmi";
            Rezultat.Columns[3].Name = "Rangi";

            for(int i=4;i<rez.Columns.Count;i++)
            {
                if (i % 2 == 0)
                    Rezultat.Columns[i].Name = "Adress begin";
                else
                    Rezultat.Columns[i].Name = "Adress end";
            }
                
            for (int i=0;i<rez.Rows.Count;i++)
                for(int j=0;j<rez.Columns.Count;j++)
                    Rezultat.Rows[i].Cells[j].Value = rez.Rows[i].Cells[j].Value.ToString();

            label10.Text = umumiy_xotira().ToString() + " MB";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Format format = new Format();
            if(malumot_hajmi.Text!="" && malumot_nomi.Text!="")
            {
                button1.Enabled = true;
                Button new_button = new Button();
                new_button.Text = malumot_hajmi.Text;
                new_button.BackColor = colours[color_index++];

                Insert_element insert = new Insert_element(buttons, new_button, data_soni);
                buttons=insert.btn_insert();
                data_soni = insert.btn_data_insert();
                new_button.Text = malumot_hajmi.Text + " " + malumot_kengaytma.Text + " " + malumot_nomi.Text;
                full_data = new string[Jadval_tuliq.RowCount, 6];

                for (int i = 0; i < Jadval_tuliq.RowCount; i++)
                {
                    full_data[i, 0] = Jadval_tuliq.Rows[i].Cells[0].Value.ToString();
                    full_data[i, 1] = Jadval_tuliq.Rows[i].Cells[1].Value.ToString();
                    full_data[i, 2] = Jadval_tuliq.Rows[i].Cells[2].Value.ToString();
                    full_data[i, 3] = Jadval_tuliq.Rows[i].Cells[3].Value.ToString();
                    full_data[i, 4] = Jadval_tuliq.Rows[i].Cells[4].Value.ToString();
                    full_data[i, 5] = Jadval_tuliq.Rows[i].Cells[5].Value.ToString();
                }
                Rulit_datagrid rd = new Rulit_datagrid(full_data,new_button, buttons, data_soni);
                full_data = rd.Rulit_insert_datagrid();
                Jadval_tuliq.Rows.Clear();
                Jadval_tuliq.RowCount = full_data.GetLength(0);
                for (int i = 0; i < full_data.GetLength(0); i++)
                {
                    Jadval_tuliq.Rows[i].Cells[0].Value = full_data[i, 0];
                    Jadval_tuliq.Rows[i].Cells[1].Value = full_data[i, 1];
                    Jadval_tuliq.Rows[i].Cells[2].Value = full_data[i, 2];
                    Jadval_tuliq.Rows[i].Cells[3].Value = full_data[i, 3];
                    Jadval_tuliq.Rows[i].Cells[4].Value = full_data[i, 4];
                    Jadval_tuliq.Rows[i].Cells[5].Value = full_data[i, 5];
                }

                rd = new Rulit_datagrid(Jadval_tuliq);
                DataGridView rez = rd.ResultEnd();
                Rezultat.Rows.Clear();
                Rezultat.Columns.Clear();

                Rezultat.RowCount = rez.Rows.Count;
                Rezultat.ColumnCount = rez.Columns.Count;

                Rezultat.Columns[0].Name = "Fayl nomi";
                Rezultat.Columns[1].Name = "Fayl kengaytmasi";
                Rezultat.Columns[2].Name = "Hajmi";
                Rezultat.Columns[3].Name = "Rang";

                for (int i = 4; i < rez.Columns.Count; i++)
                {
                    if (i % 2 == 0)
                        Rezultat.Columns[i].Name = "Adress begin";
                    else
                        Rezultat.Columns[i].Name = "Adress end";
                }

                for (int i = 0; i < rez.Rows.Count; i++)
                    for (int j = 0; j < rez.Columns.Count; j++)
                        Rezultat.Rows[i].Cells[j].Value = rez.Rows[i].Cells[j].Value.ToString();
            }
            else
                button1.Enabled = false;

            label10.Text = umumiy_xotira().ToString()+" MB";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DefragmentatsiyaX def = new DefragmentatsiyaX(buttons);
            buttons=def.Defragmentation();
            data_soni = def.all_real_buttons(buttons);

            full_data = new string[Jadval_tuliq.RowCount, 6];

            for (int i = 0; i < Jadval_tuliq.RowCount; i++)
            {
                full_data[i, 0] = Jadval_tuliq.Rows[i].Cells[0].Value.ToString();
                full_data[i, 1] = Jadval_tuliq.Rows[i].Cells[1].Value.ToString();
                full_data[i, 2] = Jadval_tuliq.Rows[i].Cells[2].Value.ToString();
                full_data[i, 3] = Jadval_tuliq.Rows[i].Cells[3].Value.ToString();
                full_data[i, 4] = Jadval_tuliq.Rows[i].Cells[4].Value.ToString();
                full_data[i, 5] = Jadval_tuliq.Rows[i].Cells[5].Value.ToString();
            }

            Rulit_datagrid rd = new Rulit_datagrid(full_data, buttons, data_soni);
            full_data = rd.Rulit();
            Jadval_tuliq.Rows.Clear();
            Jadval_tuliq.RowCount = full_data.GetLength(0);
            for (int i = 0; i < full_data.GetLength(0); i++)
            {
                Jadval_tuliq.Rows[i].Cells[0].Value = full_data[i, 0];
                Jadval_tuliq.Rows[i].Cells[1].Value = full_data[i, 1];
                Jadval_tuliq.Rows[i].Cells[2].Value = full_data[i, 2];
                Jadval_tuliq.Rows[i].Cells[3].Value = full_data[i, 3];
                Jadval_tuliq.Rows[i].Cells[4].Value = full_data[i, 4];
                Jadval_tuliq.Rows[i].Cells[5].Value = full_data[i, 5];
            }
            rd = new Rulit_datagrid(Jadval_tuliq);
            DataGridView rez = rd.ResultEnd();
            Rezultat.Rows.Clear();
            Rezultat.Columns.Clear();

            Rezultat.RowCount = rez.Rows.Count;
            Rezultat.ColumnCount = rez.Columns.Count;

            Rezultat.Columns[0].Name = "Fayl nomi";
            Rezultat.Columns[1].Name = "Fayl kengaytmasi";
            Rezultat.Columns[2].Name = "Hajmi";
            Rezultat.Columns[3].Name = "Rangi";

            for (int i = 4; i < rez.Columns.Count; i++)
            {
                if (i % 2 == 0)
                    Rezultat.Columns[i].Name = "Adress begin";
                else
                    Rezultat.Columns[i].Name = "Adress end";
            }

            for (int i = 0; i < rez.Rows.Count; i++)
                for (int j = 0; j < rez.Columns.Count; j++)
                    Rezultat.Rows[i].Cells[j].Value = rez.Rows[i].Cells[j].Value.ToString();

            label10.Text = umumiy_xotira().ToString() + " MB";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
                int soni = Convert.ToInt32(textBox1.Text);
                float silindr = Convert.ToSingle(textBox2.Text);
                float farq = (float)(silindr / 20.0);
                float xotira = 0;
                for (int i = 0; i < soni; i++)
                {
                    xotira += (silindr + i * farq);
                }
                Xotira_hajmi.Text = Convert.ToString(xotira)+ " MB";
                label10.Text = umumiy_xotira().ToString()+" MB";
            }
            else
            {
                button1.Enabled = false;
                Xotira_hajmi.Text = "0 MB";
                label10.Text = "0 MB";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                button1.Enabled = true;
                int soni = Convert.ToInt32(textBox1.Text);
                float silindr = Convert.ToSingle(textBox2.Text);
                float farq = (float)(silindr / 20.0);
                float xotira = 0;
                for (int i = 0; i < soni; i++)
                {
                    xotira += (silindr + i * farq);
                }
                Xotira_hajmi.Text = Convert.ToString(xotira)+ " MB";
                label10.Text = umumiy_xotira().ToString() + " MB";
            }
            else
            {
                button1.Enabled = false;
                Xotira_hajmi.Text = "0 MB";
                label10.Text = "0 MB";
            }
        }

        public Form1()
        {
            InitializeComponent();
            Jadval_tuliq.Visible = true;
            Rezultat.Visible = true;
            panel3.Visible = true;
            panel1.Visible = false;
            List<Color> colors = new List<Color>();
            foreach (KnownColor color in Enum.GetValues(typeof(KnownColor)))
            {
                Color col = Color.FromKnownColor(color);
                colors.Add(col);
            }
            colours = colors.ToArray();

            for (int i = 0; i < 60; i++)
            {
                buttons[i] = new Button();
                buttons[i].Text = "";
                buttons[i].Name = "btn" + Convert.ToString(i);
                buttons[i].Width = 45;
                buttons[i].Height = 45;
                buttons[i].Location = new Point(posx, posy);
                buttons[i].Enabled = true;
                buttons[i].Click += new System.EventHandler(clicker);
                buttons[i].BackColor = Color.Transparent;
                posx += 45;
                Controls.Add(buttons[i]);
                if ((i + 1) % 20 == 0)
                {
                    posx = 250;
                    posy += 45;
                }
            }
            posx = 250;
            posy = 55;
        }
    }
}
