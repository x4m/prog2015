using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Contacts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           // pictureBox1.Image=Apple.jpg;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog() {Title = "Сохранение данных", Filter = "Контакты|*.contacts"}; 
            var result = sfd.ShowDialog(this);
            if(result!=DialogResult.OK)
                return;

            var ct = new ClassContacts();
            ct.Name = textBoxName.Text;
            ct.Company = textBoxCompany.Text;
            ct.Dcompany = IDtextbox.Text;
            ct.LastCall = dateTimePickerLastCall.Value;
            ct.Telephone = textBoxTel.Text;
            ct.Email = textBoxEmail.Text;
          
            if (checkBoxClient.Checked)
            {
                ct.Checked = true;
            }
            else ct.Checked = false;

            

            var xs = new XmlSerializer(typeof(ClassContacts));
            var file = File.Create(sfd.FileName);
            xs.Serialize(file,ct);
            file.Close();
        }

        private void buttonload_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Загрузка данных", Filter = "Контакты|*.contacts" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;

            var xs = new XmlSerializer(typeof(ClassContacts));
            var file = File.OpenRead(ofd.FileName);
            ClassContacts ct = (ClassContacts)xs.Deserialize(file);
            file.Close();


            textBoxName.Text = ct.Name;
            textBoxCompany.Text = ct.Company;
            textBoxTel.Text = ct.Telephone;
            dateTimePickerLastCall.Value = ct.LastCall;
            textBoxEmail.Text = ct.Email;
            IDtextbox.Text = ct.Dcompany;

            if (ct.Checked)  checkBoxClient.Checked = true;

            else checkBoxClient.Checked = false;

        }


        }

        
    }

    
