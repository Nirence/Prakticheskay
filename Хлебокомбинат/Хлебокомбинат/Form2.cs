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
    public partial class Form2 : Form
    {
        private string myDirectory = string.Empty;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {


            if (textBox2.Text == "" && textBox3.Text == "")
            {
                MessageBox.Show("Заполните все поля.", "Ошибка.");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dateTimePicker1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text; 
                dataGridView1.Rows[n].Cells[2].Value = textBox3.Text;
            }
            
        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.MaxLength = 4;
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                return;
            }
            String text = textBox2.Text;

            if (text == "0" && e.KeyChar != 8)
                e.Handled = true;

            if (e.KeyChar == 48 && textBox2.SelectionStart == 0 && text != "")
                e.Handled = true;

            {
                if (textBox2.Text.Length == 0)
                    if (e.KeyChar == '0') e.Handled = true;
            }
        }

        private void TextBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                return;
            }
            String text = textBox3.Text;

            if (text == "0" && e.KeyChar != 8)
                e.Handled = true;

            if (e.KeyChar == 48 && textBox3.SelectionStart == 0 && text != "")
                e.Handled = true;

            {
                if (textBox3.Text.Length == 0)
                    if (e.KeyChar == '0') e.Handled = true;
            }
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            textBox3.MaxLength = 4;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.", "Ошибка.");
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet XLEB = new DataSet();
                DataTable Tablica = new DataTable
                {
                    TableName = "Все поставки"
                };
                Tablica.Columns.Add("Дата поставки");
                Tablica.Columns.Add("Кол-во хлеба");
                Tablica.Columns.Add("Цена поставки");
                XLEB.Tables.Add(Tablica);

                foreach (DataGridViewRow r in dataGridView1.Rows)
                {
                    DataRow row = XLEB.Tables["Все поставки"].NewRow();
                    row["Дата поставки"] = r.Cells[0].Value;
                    row["Кол-во хлеба"] = r.Cells[1].Value;
                    row["Цена поставки"] = r.Cells[2].Value;
                    XLEB.Tables["Все поставки"].Rows.Add(row);
                }
                XLEB.WriteXml(myDirectory + @"\XLEB.xml");
                XLEB = new DataSet();
                MessageBox.Show("XML файл успешно сохранен.", "Выполнено.");
            }
            catch
            {
                MessageBox.Show("Невозможно сохранить XML файл.", "Ошибка.");
            }
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                removeSpaces();
            }
            
            if (e.KeyCode == Keys.Control && e.KeyCode == Keys.Insert)
            {
                removeSpaces();
            }
        }
        private void removeSpaces()
        {
            textBox2.Text = textBox2.Text.Replace(" ", string.Empty);
        }

        private void TextBox2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                textBox2.ContextMenu = new ContextMenu();
            }
        }

        private void TextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                removeSpaces1();
            }

            if (e.KeyCode == Keys.Control && e.KeyCode == Keys.Insert)
            {
                removeSpaces1();
            }
        }
        private void removeSpaces1()
        {
            textBox3.Text = textBox3.Text.Replace(" ", string.Empty);
        }

        private void TextBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                textBox3.ContextMenu = new ContextMenu();
            }
        }
    }
}
