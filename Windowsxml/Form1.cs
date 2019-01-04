using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

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
            if (saveFileOgrenci.ShowDialog() == DialogResult.OK)
            {
                TextWriter tw = new StreamWriter(saveFileOgrenci.FileName);
                srl.Serialize(tw, olist);
                tw.Close();
                MessageBox.Show("liste kaydedildi.");
            }

        }
        //
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                List<ogrenci> okunanogrenciler = new List<ogrenci>();
            openfilegrenciler.Title = "xml dosyaları";
            openfilegrenciler.Filter = "*.xml|*.xml";
            openfilegrenciler.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


            XmlSerializer srl = new XmlSerializer(typeof(List<ogrenci>));
            if (openfilegrenciler.ShowDialog() == DialogResult.OK)
            {

                TextReader tr = new StreamReader(openfilegrenciler.FileName);
                okunanogrenciler = (List<ogrenci>)srl.Deserialize(tr);
              tr.Close();
               

            }
                MessageBox.Show("liste alındı.");
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = okunanogrenciler;
            }  
            catch (Exception ex)
            {

                throw new Exception("hata" + ex.Message);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                saveFileOgrenci.Title = "öğrenci bilgileri kayıt";
                saveFileOgrenci.Filter = "*.ktc|*.ktc";
                saveFileOgrenci.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                if (saveFileOgrenci.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fsWrite = new FileStream(saveFileOgrenci.FileName, FileMode.Create))
                    {
                        BinaryFormatter bfWrite = new BinaryFormatter();
                        bfWrite.Serialize(fsWrite, olist);


                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("hata" + ex.Message);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {


            try
            {
                List<ogrenci> result = new List<ogrenci>();
                openfilegrenciler.Title = "ktc dosyaları";
                openfilegrenciler.Filter = "*.ktc|*.ktc";
                openfilegrenciler.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                if (openfilegrenciler.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fsRead = new FileStream(openfilegrenciler.FileName, FileMode.Open))
                    {
                        BinaryFormatter bfRead = new BinaryFormatter();
                        result = (List<ogrenci>)bfRead.Deserialize(fsRead);

                    }
                    MessageBox.Show("liste alındı.");

                }
                dataGridView1.DataSource = result;

            }
            catch (Exception ex)
            {
                throw new Exception("hata"+ex.Message);

            }

        }
    }
}
