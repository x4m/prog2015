using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ws
{
    public partial class FORMA : Form
    {
        public FORMA()
        {
            InitializeComponent();
        }

        public Add Data { get; set; }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Data = new Add();
            Data.Combo3 = comboBox3.Text;
            Data.Team = textBox_team.Text;
            Data.Start = dateTimePicker1.Value;
            Data.End = dateTimePicker2.Value;

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


    }
}
