using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace ProgAnalys
{
    public partial class RightFile : Form //форма результата
    {
        public RightFile()
        {

            InitializeComponent();
            dataGridView1.Rows.Clear(); //очистка таблиц
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView4.Rows.Clear();
            dataGridView5.Rows.Clear();
            dataGridView6.Rows.Clear();
            chart1.Series.Clear();

            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            int i = 0;
            int j = 0;
            var result = Activity.resultdata.GroupBy(p => p.year); //группировка

            foreach (var g in result)
            {
                if (g.Key == 1)
                {
                    foreach (var t in g) //запись в таблицы
                    {
                        dataGridView1.Rows.Add();
                        dataGridView6.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = t.product;
                        dataGridView1.Rows[i].Cells[1].Value = t.demand;
                        dataGridView6.Rows[j].Cells[0].Value = t.product;
                        dataGridView6.Rows[j].Cells[1].Value = t.demand;
                        dataGridView6.Rows[j].Cells[2].Value = t.year;
                        i++;
                        j++;
                    };

                    i = 0;
                }
                else if (g.Key == 2)
                {
                    foreach (var t in g)
                    {
                        dataGridView2.Rows.Add();
                        dataGridView6.Rows.Add();
                        dataGridView2.Rows[i].Cells[0].Value = t.product;
                        dataGridView2.Rows[i].Cells[1].Value = t.demand;
                        dataGridView6.Rows[j].Cells[0].Value = t.product;
                        dataGridView6.Rows[j].Cells[1].Value = t.demand;
                        dataGridView6.Rows[j].Cells[2].Value = t.year;
                        i++;
                        j++;
                    };
                    i = 0;
                }
                else if (g.Key == 3)
                {
                    foreach (var t in g)
                    {
                        dataGridView3.Rows.Add();
                        dataGridView6.Rows.Add();
                        dataGridView3.Rows[i].Cells[0].Value = t.product;
                        dataGridView3.Rows[i].Cells[1].Value = t.demand;
                        dataGridView6.Rows[j].Cells[0].Value = t.product;
                        dataGridView6.Rows[j].Cells[1].Value = t.demand;
                        dataGridView6.Rows[j].Cells[2].Value = t.year;
                        i++;
                        j++;
                    };
                    i = 0;
                }
                else if (g.Key == 4)
                {
                    foreach (var t in g)
                    {
                        dataGridView4.Rows.Add();
                        dataGridView6.Rows.Add();
                        dataGridView4.Rows[i].Cells[0].Value = t.product;
                        dataGridView4.Rows[i].Cells[1].Value = t.demand;
                        dataGridView6.Rows[j].Cells[0].Value = t.product;
                        dataGridView6.Rows[j].Cells[1].Value = t.demand;
                        dataGridView6.Rows[j].Cells[2].Value = t.year;
                        i++;
                        j++;
                    };
                    i = 0;
                }
                else if (g.Key == 5)
                {
                    foreach (var t in g)
                    {

                        dataGridView5.Rows.Add();
                        dataGridView6.Rows.Add();
                        dataGridView5.Rows[i].Cells[0].Value = t.product;
                        dataGridView5.Rows[i].Cells[1].Value = t.demand;
                        dataGridView6.Rows[j].Cells[0].Value = t.product;
                        dataGridView6.Rows[j].Cells[1].Value = t.demand;
                        dataGridView6.Rows[j].Cells[2].Value = t.year;
                        i++;
                        j++;
                    };
                    i = 0;
                }
            }

            var result1 = Activity.resultdata.GroupBy(p => p.product);

            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chart1.Titles.Add("Спрос");

            foreach (var g in result1)
            {
                Series series = this.chart1.Series.Add(g.Key);
                foreach (var t in g)
                {
                    series.Points.Add(t.demand);
                    
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;

            StreamWriter streamWriter = new StreamWriter(filename, false, Encoding.Default);

            streamWriter.WriteLine($"1 год" + " | " + dataGridView1.Columns[0].HeaderText + " | " + dataGridView1.Columns[1].HeaderText); //записываем как нам нужно
            streamWriter.WriteLine("---");
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    streamWriter.Write(dataGridView1[j, i].Value.ToString());
                    streamWriter.Write(" | ");
                }
                streamWriter.WriteLine(" ");
            }
            streamWriter.WriteLine("---");

            streamWriter.WriteLine($"2 год" + " | " + dataGridView2.Columns[0].HeaderText + " | " + dataGridView2.Columns[1].HeaderText);
            streamWriter.WriteLine("---");
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView2.Columns.Count; j++)
                {
                    streamWriter.Write(dataGridView2[j, i].Value.ToString());
                    streamWriter.Write(" | ");
                }
                streamWriter.WriteLine(" ");
            }
            streamWriter.WriteLine("---");

            streamWriter.WriteLine($"3 год" + " | " + dataGridView3.Columns[0].HeaderText + " | " + dataGridView3.Columns[1].HeaderText);
            streamWriter.WriteLine("---");
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView3.Columns.Count; j++)
                {
                    streamWriter.Write(dataGridView3[j, i].Value.ToString());
                    streamWriter.Write(" | ");
                }
                streamWriter.WriteLine(" ");
            }
            streamWriter.WriteLine("---");

            streamWriter.WriteLine($"4 год" + " | " + dataGridView4.Columns[0].HeaderText + " | " + dataGridView4.Columns[1].HeaderText);
            streamWriter.WriteLine("---");
            for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView4.Columns.Count; j++)
                {
                    streamWriter.Write(dataGridView4[j, i].Value.ToString());
                    streamWriter.Write(" | ");
                }
                streamWriter.WriteLine(" ");
            }
            streamWriter.WriteLine("---");

            streamWriter.WriteLine($"5 год" + " | " + dataGridView5.Columns[0].HeaderText + " | " + dataGridView5.Columns[1].HeaderText);
            streamWriter.WriteLine("---");
            for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView5.Columns.Count; j++)
                {
                    streamWriter.Write(dataGridView5[j, i].Value.ToString());
                    streamWriter.Write(" | ");
                }
                streamWriter.WriteLine(" ");
            }
            streamWriter.WriteLine("---");


            streamWriter.Close();

            MessageBox.Show("Файл сохранен");
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void RightFile_Load(object sender, EventArgs e)
        {

        }
    }
}
