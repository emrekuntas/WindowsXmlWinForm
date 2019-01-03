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

namespace Windowsxml
{
    public partial class Form1 : Form
    {

        List<ogrenci> olist = new List<ogrenci>();
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("LGBT seçildi");
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("ERKEK seçildi");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            // MessageBox.Show("KADIN seçildi");
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            ogrenci o = new ogrenci();
            o.ID = Guid.NewGuid();
            o.Adi = txtname.Text;
            o.Soyadi = txtsoyad.Text;
            o.Dogumtarihi = dateTimePicker1.Value;

            if (radioButton1.Checked)
            {

                o.Cins = cinsiyet.kadın;

            }
            else if (radioButton2.Checked)
            {

                o.Cins = cinsiyet.erkek;

            }
            else 
            {
                o.Cins = cinsiyet.LGBT;
            }

            olist.Add(o);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = olist;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileOgrenci.Title = "öğrenci bilgileri kayıt";
            saveFileOgrenci.Filter = "*.xml|*.xml";
            saveFileOgrenci.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            XmlSerializer srl = new XmlSerializer(typeof(List<ogrenci>));
            if (saveFileOgrenci.ShowDialog()==DialogResult.OK) {
                TextWriter tw = new StreamWriter(saveFileOgrenci.FileName);
                srl.Serialize(tw,olist);
                tw.Close();
                MessageBox.Show("liste kaydedildi.");
            }

        }
       //
        private void button3_Click(object sender, EventArgs e)
        {
            List<ogrenci> okunanogrenciler = new List<ogrenci>();
            XmlSerializer srl = new XmlSerializer(typeof(List<ogrenci>));
            if (openfilegrenciler.ShowDialog()==DialogResult.OK) {

                TextReader tr = new StreamReader(openfilegrenciler.FileName);
                okunanogrenciler = (List<ogrenci>)srl.Deserialize(tr);
                tr.Close();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = okunanogrenciler;

            }



        }
    }
}
