using System;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace TBlab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void LoadText_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog() { Title = "Загрузка данных", Filter = "ТВ|*.txt" };
            var result = ofd.ShowDialog(this);
            if (result != DialogResult.OK)
                return;
            //var file = File.OpenRead(ofd.FileName);
            try
            {
                using (StreamReader sr = new StreamReader(ofd.FileName, Encoding.Default))
                {
                    String line = await sr.ReadToEndAsync();
                    string line2 = "";
                    string line3 = "";
                    int count = 0,a=0,r=0,moda=0,maxcount=0,mediana=0,nslov=0;
                    char[] delimiterChars = { ' ', ',', '.', ':', '\t','?','—','!'};
                    string[] words = line.Split(delimiterChars);
                    for (int j = 1; j < 20; j++)
                    {
                        for (int i = 0; i < 400; i++)
                        {
                             a = words[i].Length;
                            if (a > r) r = a;
                            if (a == j)
                            {
                                line2 = line2 + "\n" + words[i] + "    -" + a;
                                count++;
                                mediana += a;
                            }
                        }
                        line3 = line3 + "\n" + "Количество букв: " + j + "Количество слов: " + count;
                        if (count > maxcount){ maxcount = count;
                            moda = j;
                        }
                        nslov += count;
                        count = 0;
                    }
                    int b = r-1;
                    mediana = mediana/nslov;
                    textBox1.Text = line;
                    richTextBox1.Text = line2;
                    richTextBox2.Text = line3;
                    textBoxRazmah.Text = b.ToString();
                    textBoxModa.Text = moda.ToString();
                    textBoxMediana.Text = mediana.ToString();
                    //StreamWriter sw = new StreamWriter(ofd.FileName);
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = "Could not read the file";
            }
        }
    }
}
