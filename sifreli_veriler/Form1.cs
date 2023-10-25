﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sifreli_veriler
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-KPC6PV7\SQLEXPRESS;Initial Catalog=etrade;Integrated Security=True");
        
     
            void listele()
        {
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("select *from tblveriler", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
            

        
       

        private void button1_Click(object sender, EventArgs e)
        {

            string ad = txtad.Text;
            byte []addizi=ASCIIEncoding.ASCII.GetBytes(ad); 
            string adsifre=Convert.ToBase64String(addizi);
            
            string soyad=txtsoyad.Text;
            byte []soyaddizi=ASCIIEncoding .ASCII.GetBytes(soyad);
            string soyadsifre = Convert.ToBase64String(soyaddizi);

            string mail=txtmail.Text;
            byte [] maildizi=ASCIIEncoding.ASCII .GetBytes(mail);
            string mailsifre = Convert.ToBase64String(maildizi);

            string sifre =txtsifre.Text;
            byte[] sifredizi = ASCIIEncoding.ASCII.GetBytes(sifre);
            string sifresifre = Convert.ToBase64String(sifredizi);

            string hesapno=txthesapno.Text;
            byte[] hesapnodizi = ASCIIEncoding.ASCII.GetBytes(hesapno);
            string hesapnosifre = Convert.ToBase64String(hesapnodizi);

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tblveriler (ad,soyad,maıl,sıfre,hesapno)values(@p1,@p2,@p3,@p4,@p5)",baglanti);
            komut.Parameters.AddWithValue("@p1",adsifre);
            komut.Parameters.AddWithValue("@p2",soyadsifre);
            komut.Parameters.AddWithValue("@p3",mailsifre);
            komut.Parameters.AddWithValue("@p4", sifresifre);
            komut.Parameters.AddWithValue("@p5", hesapnosifre);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Veriler Eklendi");

            listele();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

       public void islem()
        {
            string adcozum = txtcoz.Text;
            byte[] adcozumdizi = Convert.FromBase64String(adcozum);
            string adverisi = ASCIIEncoding.ASCII.GetString(adcozumdizi);
           
            label6.Text = adverisi;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            
          islem();
        }

        
    }
}
