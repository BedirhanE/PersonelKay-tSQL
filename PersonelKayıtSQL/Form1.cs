using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PersonelKayıtSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
       SqlConnection baglanti= new SqlConnection("Data Source=DESKTOP-QUP7DFP;Initial Catalog=PersonelVeriTabanı;Integrated Security=True");
        void temizle()
        {
            txtad.Text = "";
            txtsoyad.Text = "";
            txtid.Text = "";
            txtmeslek.Text = "";
            mskmaas.Text = "";
            cmbsehir.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtad.Focus();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeriTabanıDataSet.Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.personelTableAdapter.Fill(this.personelVeriTabanıDataSet.Personel);
            label1.Visible = false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
             this.personelTableAdapter.Fill(this.personelVeriTabanıDataSet.Personel);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open(); 
            
            SqlCommand komut = new SqlCommand("insert into Personel(PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek) values(@p1,@p2,@p3,@p4,@p5 )",baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3",cmbsehir.Text);
            komut.Parameters.AddWithValue("p4",mskmaas.Text);
            komut.Parameters.AddWithValue("p5", txtmeslek.Text);
            komut.ExecuteNonQuery();
                
            MessageBox.Show("Personel Ekleme İşlemi Başarılı ");

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete From  Personel Where Personelid=@p1",baglanti);
            sil.Parameters.AddWithValue("@p1", txtid.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silme İşlemi Başarılı  ");
        }

        private void txtad_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            mskmaas.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
            label1.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secim].Cells[6].Value.ToString();
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            if (label1.Text == "True")
            {

                radioButton1.Checked=true;
            }
            if (label1.Text == "False")
            {
            
                    radioButton2.Checked=true;  

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label1.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label1.Text="False"; 
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update  Personel Set PerAd=@p1,PerSoyad=@p2,PerSehir=@p3,PerMaas=@p4,PerDurum=@p5,PerMeslek=@p6  Where personelid=@p7",baglanti);
            guncelle.Parameters.AddWithValue("p1", txtad.Text);
            guncelle.Parameters.AddWithValue("p2", txtsoyad.Text);
            guncelle.Parameters.AddWithValue("p3", cmbsehir.Text);
            guncelle.Parameters.AddWithValue("p4", mskmaas.Text);
            guncelle.Parameters.AddWithValue("p5", label1.Text);
            guncelle.Parameters.AddWithValue("p6", txtmeslek.Text); 
            guncelle.Parameters.AddWithValue("p7", txtid.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Güncelleme İşlemi  Başarılı Şekilde Tamamlandı");
                
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {
     
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radibtnasc.Checked = true;
            {
              
                    
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           
        }
    }
}
