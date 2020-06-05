using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgAnalys
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        public string filename = "111.txt";
        public string filetext;
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            MessageBox.Show("Файл открыт");
            string filename = openFileDialog1.FileName; //считывание имени файла
            textBox1.Text = filename;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filename = textBox1.Text;
            filetext = System.IO.File.ReadAllText(filename, Encoding.Default); //считывание текста файла
            bool Result = Activity.Check(filetext); //вызов записи листа объектов и корректности исходного файла
            if (Result)
            {
                Activity.System(); //запуск основного решения
                RightFile f2 = new RightFile(); //открытие формы представления при условии того, что файл верен
                f2.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Requirement f2 = new Requirement(); //открытие окна требований к файлу
            f2.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Requirement f2 = new Requirement(); //открытие окна требований к файлу
            f2.Show();
        }
    }
}
