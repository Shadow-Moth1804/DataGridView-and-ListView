using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccionesComunes.LlenarCombo(textBox1.Text, comboBox1, "UserID","Email");
            AccionesComunes.LlenarCombo(textBox1.Text, comboBox2, "UserID", "Email");
            AccionesComunes.llenaDatagrid(textBox1.Text, dataGridView1);
            AccionesComunes.llenalist(textBox1.Text, listView1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text=comboBox1.SelectedValue.ToString();
        }
    }
}
