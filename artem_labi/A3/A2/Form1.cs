using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevExpress.XtraReports.UI;

namespace ws
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


  
        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Title = "Сохранение данных", Filter = "анкета фуболиста|*.anketa" };
            var result = sfd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var cd = new klub();

            cd.Name = Text_Box_name.Text;
            cd.Surname = Text_Box_Surname.Text;
            cd.Patronymic = Text_Box_Patronymic.Text;
            cd.Date = Date_Birthday.Value;
            cd.Combo = comboBox1.Text;
            cd.Combo2 = comboBox2.Text;

            foreach (Add cn in listBox1.Items)
            {
                cd.clubs.Add(cn);
            }

            var xs = new XmlSerializer(typeof(klub));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, cd);
            file.Close();

        }

        private void Load_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Загрузка данных", Filter = "Показания счётчиков|*.CNDT" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(klub));
            var file = File.OpenRead(ofd.FileName);
            klub cd = (klub)xs.Deserialize(file);
            file.Close();

            Text_Box_name.Text = cd.Name;
            Text_Box_Surname.Text = cd.Surname;
            Text_Box_Patronymic.Text = cd.Patronymic;
            Date_Birthday.Value = cd.Date;
            comboBox1.Text = cd.Combo;
            comboBox2.Text = cd.Combo2;


            for (int index = 0; index < cd.clubs.Count; index++)
            {
                Add cnt = cd.clubs[index];
                listBox1.Items.Add(cnt);
            }

        }

        public klub qwe()
        {
            var cd = new klub();

            cd.Name = Text_Box_name.Text;
            cd.Surname = Text_Box_Surname.Text;
            cd.Patronymic = Text_Box_Patronymic.Text;
            cd.Date = Date_Birthday.Value;
            cd.Combo = comboBox1.Text;
            cd.Combo2 = comboBox2.Text;

            foreach (Add cn in listBox1.Items)
            {
                cd.clubs.Add(cn);
            }
            return cd;
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            var form = new FORMA();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                listBox1.Items.Add(form.Data);
            }

        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count != 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndices[0]);
            }
        }


        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Print_Click(object sender, EventArgs e)
        {
            var rpt = new ReportPrintTool(new XtraReport1()
            {
                DataSource = new BindingSource()
                {
                    DataSource = qwe()
                }
            });

            rpt.Report.CreateDocument(false);
            rpt.ShowPreview();

        }

    }
}
