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
using System.Xml.Serialization;

namespace Laba1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitDefaultes();
            InitializeComponent();
        }

        public Cs Sp()
        {
            var Inf = new Cs();

            Inf.Name = textBox1.Text;
            Inf.Surname = textBox2.Text;

            if (radioButton1.Checked)
                Inf.Type = Aura.green;
            else if (radioButton2.Checked)
                Inf.Type = Aura.dark;
            else if (radioButton3.Checked)
                Inf.Type = Aura.blue;
            else if (radioButton4.Checked)
                Inf.Type = Aura.orange;
            else if (radioButton5.Checked)
                Inf.Type = Aura.white;
            else if (radioButton6.Checked)
                Inf.Type = Aura.gold;

            Inf.Power = listBox1.SelectedIndex;

            return Inf;
        }

        void InitDefaultes()
        {
            radioButton1Items = new List<string> { "Hyperkinesthesia", "Levetation", "Fitokinesis" };
            radioButton2Items = new List<string> { "Abilitiabsorbtion", "Vitakinesis", "Hypersupression" };
            radioButton3Items = new List<string> { "Aprior", "Hyperdynamia", "Regeneration" };
            radioButton4Items = new List<string> { "Pyrocinesis", "Byocurrentia", "Absorbtion" };
            radioButton5Items = new List<string> { "Cryokinesis", "Umrakinesis", "Invisibility" };
            radioButton6Items = new List<string> { "Chronokinesis", "Second sight", "Desintegrity" };
        }

        List<string> radioButton1Items;
        List<string> radioButton2Items;
        List<string> radioButton3Items;
        List<string> radioButton4Items;
        List<string> radioButton5Items;
        List<string> radioButton6Items;

       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var Item in radioButton1Items)
            {
                listBox1.Items.Add(Item);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var Item in radioButton2Items)
            {
                listBox1.Items.Add(Item);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var Item in radioButton3Items)
            {
                listBox1.Items.Add(Item);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                listBox1.Items.Clear();
                foreach (var Item in radioButton5Items)
                {
                    listBox1.Items.Add(Item);
                }
            }
            if (radioButton4.Checked)
            {
                listBox1.Items.Clear();
                foreach (var Item in radioButton4Items)
                {
                    listBox1.Items.Add(Item);
                }
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var Item in radioButton6Items)
            {
                listBox1.Items.Add(Item);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                radioButton1Items.Add(textBox3.Text);

                listBox1.Items.Clear();
                foreach (var item in radioButton1Items)
                {
                    listBox1.Items.Add(item);
                }
                textBox3.Clear();
            }

            if (radioButton2.Checked)
            {
                radioButton2Items.Add(textBox3.Text);

                listBox1.Items.Clear();
                foreach (var item in radioButton2Items)
                {
                    listBox1.Items.Add(item);
                }
                textBox3.Clear();
            }

            if (radioButton3.Checked)
            {
                radioButton3Items.Add(textBox3.Text);

                listBox1.Items.Clear();
                foreach (var item in radioButton3Items)
                {
                    listBox1.Items.Add(item);
                }
                textBox3.Clear();
            }

            if (radioButton4.Checked)
            {
                radioButton4Items.Add(textBox3.Text);

                listBox1.Items.Clear();
                foreach (var item in radioButton4Items)
                {
                    listBox1.Items.Add(item);
                }
                textBox3.Clear();
            }

            if (radioButton5.Checked)
            {
                radioButton5Items.Add(textBox3.Text);

                listBox1.Items.Clear();
                foreach (var item in radioButton5Items)
                {
                    listBox1.Items.Add(item);
                }
                textBox3.Clear();
            }

            if (radioButton6.Checked)
            {
                radioButton6Items.Add(textBox3.Text);

                listBox1.Items.Clear();
                foreach (var item in radioButton6Items)
                {
                    listBox1.Items.Add(item);
                }
                textBox3.Clear();
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() { Title = "Сохранение данных", Filter = "PandoraBox|*.PBF" };
            var result = sfd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;


            var xs = new XmlSerializer(typeof(Cs));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file, Sp());
            file.Close();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Сохранение данных", Filter = "PandoraBox|*.PBF" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(Cs));
            var file = File.OpenRead(ofd.FileName);
            Cs Inf = (Cs)xs.Deserialize(file);
            file.Close();

            textBox1.Text = Inf.Name;
            textBox2.Text = Inf.Surname;

            if (Inf.Type == Aura.green)
                radioButton1.Checked = true;
            else if (Inf.Type == Aura.dark)
                radioButton2.Checked = true;
            else if (Inf.Type == Aura.blue)
                radioButton3.Checked = true;
            else if (Inf.Type == Aura.orange)
                radioButton4.Checked = true;
            else if (Inf.Type == Aura.white)
                radioButton5.Checked = true;
            else if (Inf.Type == Aura.gold)
                radioButton6.Checked = true;

            listBox1.SelectedIndex = Inf.Power;
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Add("Выбран элемент " + listBox1.SelectedItem);
            
        }
    }
}
