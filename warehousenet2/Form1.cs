using System.Reflection;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;
using System.Reflection.Emit;
using System.Collections.Generic;
using System;

namespace warehousenet2
{
    public partial class Form1 : Form
    {

        private readonly List<Tovar> tovari;
        private readonly BindingSource bindingSource;
        private decimal sum2 = 0;
        public Form1()
        {
            InitializeComponent();
            tovari = new List<Tovar>();
            bindingSource = new BindingSource();
            bindingSource.DataSource = tovari;
            dataGridView1.DataSource = bindingSource;
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
                MessageBox.Show("Программа Алейникова Кирилла",
                    "Склад гвоздей",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            addToolStripMenuItem_Click(sender, e);
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            toolStripButton2.Enabled =
            toolStripButton3.Enabled =
            changeToolStripMenuItem.Enabled =
            deleteToolStripMenuItem.Enabled =
            dataGridView1.SelectedRows.Count > 0;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            var data = (Tovar)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
            if (MessageBox.Show("Вы действительно хотите удалить товар?",
                "Удаление товара",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                tovari.Remove(data);
                bindingSource.ResetBindings(false);
                CalculateStats();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           var data = (Tovar)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
            var tovarinfoForm = new tovarinfoform(data);
            tovarinfoForm.Text = "Редактирование товара";
            if (tovarinfoForm.ShowDialog(this) == DialogResult.OK)
            {
                data.FullName = tovarinfoForm.Tovar.FullName;
                data.Razmer = tovarinfoForm.Tovar.Razmer;
                data.Material = tovarinfoForm.Tovar.Material;
                data.kolvo = tovarinfoForm.Tovar.kolvo;
                data.minpr = tovarinfoForm.Tovar.minpr;
                data.price = tovarinfoForm.Tovar.price;
                bindingSource.ResetBindings(false);
                CalculateStats();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var infoform = new tovarinfoform();
            infoform.Text = "Добавление товара";
            if (infoform.ShowDialog(this) == DialogResult.OK)
            {
                tovari.Add(infoform.Tovar);
                bindingSource.ResetBindings(false);
                CalculateStats();
            }
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(sender, e); 
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton3_Click(sender, e);
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Column7")
            {
                var data = (Tovar)dataGridView1.Rows[e.RowIndex].DataBoundItem;
                sum2 += (data.kolvo * data.price);
                e.Value = sum2;
                sum2 = 0;
            }
        }

        public void CalculateStats()
        {
            toolStripStatusLabel1.Text =$"Общее количество: {tovari.Count.ToString()}" ;
            decimal sum = 0;
            decimal sum3=0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDecimal(dataGridView1.Rows[i].Cells["Column4"].Value) * Convert.ToDecimal(dataGridView1.Rows[i].Cells["Column6"].Value);
            }
            toolStripStatusLabel3.Text = $"Без НДС: {sum.ToString()} ₽";
            sum3 = Math.Round(sum+sum*0.2m,2);
            toolStripStatusLabel2.Text = $"С НДС: {sum3.ToString()} ₽";
        }

    }
}