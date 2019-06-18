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

namespace Хлебокомбинат
{
    public partial class Form3 : Form
    {
        private string myDirectory = string.Empty;
        public Form3()
        {
            InitializeComponent();
            Shown += new EventHandler(Dll);
            Shown += new EventHandler(Dlc);
        }
        private void Dll(object sender, EventArgs e)
        {
            if (File.Exists(myDirectory + @"\XLEB.xml"))
            {
                DataSet Tablica = new DataSet();
                Tablica.ReadXml(myDirectory + @"\XLEB.xml");

                foreach (DataRow item in Tablica.Tables["Все поставки"].Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item["Дата поставки"];
                    dataGridView1.Rows[n].Cells[1].Value = item["Кол-во хлеба"];
                    dataGridView1.Rows[n].Cells[2].Value = item["Цена поставки"];
                }
            }
            else
            {
                MessageBox.Show("XML файл не найден.", "Ошибка.");
            }
        }
        private void Dlc(object sender, EventArgs e)
        {
            this.chart1.Series["Количество"].Points.AddXY("07.04.2019", 35);
            this.chart1.Series["Количество"].Points.AddXY("14.04.2019", 18);
        }
    }
}