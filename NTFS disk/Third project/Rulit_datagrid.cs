using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Third_project
{

    internal class Rulit_datagrid
    {
        string[,] data;
        DataGridView datagrid;
        int index;
        Button[] button;
        Button btn;

        public Rulit_datagrid(string[,] data, Button[] button, int index)
        {
            this.data = data;
            this.index = index;
            this.button = button;
        }
        public Rulit_datagrid(string[,] data, Button btn, Button[] button, int index)
        {
            this.btn = btn;
            this.data = data;
            this.index = index;
            this.button = button;
        }

        public Rulit_datagrid(DataGridView datagrid)
        {
            this.datagrid = datagrid;
        }
        public DataGridView ResultEnd()
        {
            DataGridView new_data = new DataGridView();

            for (int i = 0; i < datagrid.RowCount; i++)
            {
                if (datagrid.Rows[i].Cells[4].Value.ToString() != "-")
                {
                    for (int j = i + 1; j < datagrid.RowCount; j++)
                    {
                        if (datagrid.Rows[i].Cells[0].Value.ToString().Equals(datagrid.Rows[j].Cells[0].Value.ToString()) && datagrid.Rows[i].Cells[1].Value.ToString().Equals(datagrid.Rows[j].Cells[1].Value.ToString()) && datagrid.Rows[i].Cells[3].Value.ToString().Equals(datagrid.Rows[j].Cells[3].Value.ToString()))
                        {
                            datagrid.Rows[i].Cells[4].Value += "," + datagrid.Rows[j].Cells[4].Value.ToString();
                            datagrid.Rows[i].Cells[5].Value += "," + datagrid.Rows[j].Cells[5].Value.ToString();
                            datagrid.Rows[i].Cells[2].Value = Convert.ToString(Convert.ToInt32(datagrid.Rows[i].Cells[2].Value) + Convert.ToInt32(datagrid.Rows[j].Cells[2].Value));
                            datagrid.Rows[j].Cells[0].Value = "-";
                            datagrid.Rows[j].Cells[1].Value = "-";
                            datagrid.Rows[j].Cells[2].Value = "-";
                            datagrid.Rows[j].Cells[3].Value = "-";
                            datagrid.Rows[j].Cells[4].Value = "-";
                            datagrid.Rows[j].Cells[5].Value = "-";
                        }
                    }
                }
            }

            int minusla = 0;
            for (int i = 0; i < datagrid.RowCount; i++)
                if (datagrid.Rows[i].Cells[4].Value.ToString() == "-")
                    minusla++;

            new_data.ColumnCount = 6;
            new_data.RowCount = datagrid.Rows.Count - minusla;
            minusla = 0;

            for (int i = 0; i < datagrid.RowCount; i++)
            {
                if (datagrid.Rows[i].Cells[4].Value.ToString() != "-")
                {
                    new_data.Rows[minusla].Cells[0].Value = datagrid.Rows[i].Cells[0].Value.ToString();
                    new_data.Rows[minusla].Cells[1].Value = datagrid.Rows[i].Cells[1].Value.ToString();
                    new_data.Rows[minusla].Cells[2].Value = datagrid.Rows[i].Cells[2].Value.ToString();
                    new_data.Rows[minusla].Cells[3].Value = datagrid.Rows[i].Cells[3].Value.ToString();
                    new_data.Rows[minusla].Cells[4].Value = datagrid.Rows[i].Cells[4].Value.ToString();
                    new_data.Rows[minusla].Cells[5].Value = datagrid.Rows[i].Cells[5].Value.ToString();
                    minusla++;
                }
            }
            int[] soni = new int[new_data.RowCount];
            for (int i = 0; i < new_data.RowCount; i++)
            {
                soni[i] = CountNonSpaceChars(new_data.Rows[i].Cells[4].Value.ToString());
                if (i == 0)
                    minusla = soni[i];
                else if (minusla < soni[i])
                    minusla = soni[i];
            }

            datagrid.Rows.Clear();
            datagrid.Columns.Clear();

            datagrid.ColumnCount = 4 + minusla * 2;
            datagrid.RowCount = new_data.RowCount;

            string[] begin = null;
            string[] end = null;
            for (int i = 0; i < datagrid.RowCount; i++)
            {
                begin = new_data.Rows[i].Cells[4].Value.ToString().Split(',');
                end = new_data.Rows[i].Cells[5].Value.ToString().Split(',');

                for (int j = 0; j < datagrid.ColumnCount; j++)
                {
                    if (j < 6)
                    {
                        if (j == 4)
                            datagrid.Rows[i].Cells[j].Value = begin[0];
                        else if (j == 5)
                            datagrid.Rows[i].Cells[j].Value = end[0];
                        else
                            datagrid.Rows[i].Cells[j].Value = new_data.Rows[i].Cells[j].Value.ToString();
                    }


                    else if (soni[i] == 1)
                        datagrid.Rows[i].Cells[j].Value = "-";

                    else if (soni[i] > 1)
                    {
                        for (int k = 0; k < soni[i] - 1; k++)
                        {
                            datagrid.Rows[i].Cells[j + 2 * k].Value = begin[1 + k];
                            datagrid.Rows[i].Cells[j + 1 + 2 * k].Value = end[1 + k];
                        }
                        for (int k = 6 + (soni[i] - 1) * 2; k < datagrid.ColumnCount; k++)
                            datagrid.Rows[i].Cells[k].Value = "-";
                        break;
                    }
                }
            }

            return datagrid;
        }
        static int CountNonSpaceChars(string value)
        {
            int result = 1;
            foreach (char c in value)
            {
                if (c == ',')
                    result++;
            }
            return result;
        }

        public string[,] Rulit()
        {
            string[,] new_data = new string[index, 6];
            Format format = new Format();

            for (int i = 0; i < new_data.GetLength(0); i++)
            {
                new_data[i, 0] = "-";
                new_data[i, 1] = "-";
                new_data[i, 2] = button[i].Text;
                new_data[i, 3] = button[i].BackColor.Name;
                if (i == 0)
                {
                    new_data[i, 4] = "0";
                    new_data[i, 5] = format.Unlikdan_un_oltilikka(Convert.ToInt64(button[i].Text) * 1000);
                }
                else
                {
                    new_data[i, 4] = new_data[i - 1, 5];
                    new_data[i, 5] = format.Unlikdan_un_oltilikka(format.Un_oltilikdan_unlikka(new_data[i, 4]) + Convert.ToInt64(button[i].Text) * 1000);
                }
            }


            for (int i = 0; i < new_data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(0); j++)
                {
                    if (new_data[i, 3] == data[j, 3] && new_data[i, 3] != Color.Transparent.Name)
                    {
                        new_data[i, 0] = data[j, 0];
                        new_data[i, 1] = data[j, 1];
                        break;
                    }
                }
            }
            return new_data;
        }

        public string[,] Rulit_insert_datagrid()
        {
            string data_nomi = btn.Text.Split()[2];
            string data_kengaytma = btn.Text.Split()[1];
            string data_hajm = btn.Text.Split()[0];

            string[,] new_data = new string[index, 6];
            Format format = new Format();

            for (int i = 0; i < new_data.GetLength(0); i++)
            {
                new_data[i, 0] = "-";
                new_data[i, 1] = "-";
                new_data[i, 2] = button[i].Text;
                new_data[i, 3] = button[i].BackColor.Name;
                if (i == 0)
                {
                    new_data[i, 4] = "0";
                    new_data[i, 5] = format.Unlikdan_un_oltilikka(Convert.ToInt64(button[i].Text) * 1000);
                }
                else
                {
                    new_data[i, 4] = new_data[i - 1, 5];
                    new_data[i, 5] = format.Unlikdan_un_oltilikka(format.Un_oltilikdan_unlikka(new_data[i, 4]) + Convert.ToInt64(button[i].Text) * 1000);
                }
            }

            for (int i = 0; i < new_data.GetLength(0); i++)
            {
                for (int j = 0; j < data.GetLength(0); j++)
                {
                    if (new_data[i, 2] == data[j, 2] && new_data[i, 3] == data[j, 3] && new_data[i, 3] != Color.Transparent.Name)
                    {
                        new_data[i, 0] = data[j, 0];
                        new_data[i, 1] = data[j, 1];
                        break;
                    }
                    else if (new_data[i, 3] == btn.BackColor.Name)
                    {
                        new_data[i, 0] = data_nomi;
                        new_data[i, 1] = data_kengaytma;
                    }
                }
            }
            return new_data;
        }

    }
} 
