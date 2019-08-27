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
using System.Collections;

namespace MilliPiyango
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PCOH8E6\\SQLEXPRESS;Initial Catalog=MilliPiyango;Integrated Security=True");


        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(200, 300);
            //this.Size = new Size(500, 500);
            
           
            //tambiletsecimi();
            //yarimbiletsecimi();
            //ceyrekbiletsecimi();
            Mlistele();
           

        }
        public int Khafta = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            yeniBoyut();
            mGoster();


        }





        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CekilisForm frm2 = new CekilisForm();
            this.Hide();
            frm2.Show();
        }

        private void biletTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            biletfiyatigoster();
            biletListele();
            alinmisbiletlericikart();
            
            
          
            
        }
        void alinmisbiletlericikart()
        { //comboBox1.Items.Remove("Photoshop");
            int[] alinanbilet = new int[50];//en fazla 50 bilet sattığım için
            if (baglanti.State == ConnectionState.Closed)
            {
                if (Hafta.Text !="")
                {
                    baglanti.Open();
                    //

                    SqlDataAdapter adtr = new SqlDataAdapter("select * from Tablo1 where hafta='" + int.Parse(Hafta.Text) + "' and bilettipi='" + biletTipi.Text + "'", baglanti);
                    DataTable Tablo1 = new DataTable();
                    adtr.Fill(Tablo1);
                    if (Tablo1.Rows.Count == 0)
                    {
                        baglanti.Close();

                    }
                    else
                    {
                        for (int i = 0; i < Tablo1.Rows.Count; i++)
                        {
                            //Tam Bilet
                            //Çeyrek Bilet
                            //Yarım Bilet
                            alinanbilet[i] = int.Parse("" + Tablo1.Rows[i][5]);
                            if (biletTipi.Text == "Tam Bilet")
                            {

                                for (int j = 0; j < Mtambilet.Length; j++)
                                {
                                    if (Mtambilet[j] == alinanbilet[i])
                                    {
                                        int k = Mtambilet[j];
                                        comboBox1.Items.Remove(k);

                                    }
                                }
                            }
                            else if (biletTipi.Text == "Yarım Bilet")
                            {
                                for (int j = 0; j < Myarimbilet.Length; j++)
                                {
                                    if (Myarimbilet[j] == alinanbilet[i])
                                    {
                                        int t = Myarimbilet[j];
                                        comboBox1.Items.Remove(t);

                                    }
                                }
                            }
                            else if (biletTipi.Text == "Çeyrek Bilet")
                            {
                                for (int j = 0; j < Mceyrekbilet.Length; j++)
                                {
                                    if (Mceyrekbilet[j] == alinanbilet[i])
                                    {
                                        int p = Mceyrekbilet[j];
                                        comboBox1.Items.Remove(p);

                                    }
                                }
                            }
                        }
                        baglanti.Close();
                    }



                }
            }
            for (int i = 0; i < alinanbilet.Length; i++)
            {
                alinanbilet[i] = 0;
            }
        }
        void biletListele()
        {
            if (biletTipi.Text == "Tam Bilet")
            {
                comboBox1.Items.Clear();

                for (int i = 0; i < Mtambilet.Length; i++)
                {
                    // int x = birincibasamakgetir(Mtambilet[i]), y = ikincibasamakgetir(Mtambilet[i]), z = ücüncübasamakgetir(Mtambilet[i]);

                    //comboBox1.Items.Add(x + "-" + y + "-" + z);
                    comboBox1.Items.Add(Mtambilet[i]);

                }

            }
            else if (biletTipi.Text == "Yarım Bilet")
            {

                comboBox1.Items.Clear();

                for (int i = 0; i < Myarimbilet.Length; i++)
                {
                    //int x = birincibasamakgetir(Myarimbilet[i]), y = ikincibasamakgetir(Myarimbilet[i]), z = ücüncübasamakgetir(Myarimbilet[i]);

                    //comboBox1.Items.Add(x + "-" + y + "-" + z);
                    comboBox1.Items.Add(Myarimbilet[i]);
                }
            }
            else if (biletTipi.Text == "Çeyrek Bilet")
            {
                comboBox1.Items.Clear();

                for (int i = 0; i < Mceyrekbilet.Length; i++)
                {
                    //int x = birincibasamakgetir(Mceyrekbilet[i]), y = ikincibasamakgetir(Mceyrekbilet[i]), z = ücüncübasamakgetir(Mceyrekbilet[i]);

                    // comboBox1.Items.Add(x + "-" + y + "-" + z);

                    comboBox1.Items.Add(Mceyrekbilet[i]);

                }
            }

        }
        void mGoster()
        {
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            mAd.Visible = true;
            mSoyad.Visible = true;
            biletTipi.Visible = true;
            odenenFiyat.Visible = true;
            mEkle.Visible = true;

        }
        void yeniBoyut()
        {
            this.Size = new Size(1118, 596);
        }
        void biletfiyatigoster()
        {
            if (biletTipi.Text == "Tam Bilet")
            {
                odenenFiyat.Text = "70";
            }
            else if (biletTipi.Text == "Yarım Bilet")
            {
                odenenFiyat.Text = "35";
            }
            else if (biletTipi.Text == "Çeyrek Bilet")
            {
                odenenFiyat.Text = "17";
            }


        }

        //int birincibasamakgetir(int A)
        //{
        //    return A / 100;

        //}
        //int ikincibasamakgetir(int A)
        //{
        //    return A % 100 / 10;

        //}
        //int ücüncübasamakgetir(int A)
        //{
        //    return (A % 100) % 10;
        //}
       


        int[] Mtambilet = new int[50];
        int[] Myarimbilet = new int[50];
        int[] Mceyrekbilet = new int[50];
        //1000+Khafta*250
        //2000+Khafta*250
        //3000+Khafta*250

        void tambiletsecimi()
        {
            Random rastgele = new Random(100+Khafta*25);
            int salla;

            int a = 0;
            for (int i = 0; i < Mtambilet.Length; i++)
            {
                salla = rastgele.Next(100, 999);
                
                for (int j = 0; j < Mtambilet.Length; j++)
                {
                    if (Mtambilet[j] == salla)
                    {
                        a++;
                        i--;
                        break;
                    }
                }
                if (a == 0)
                {
                    Mtambilet[i] = salla;
                }
                a = 0;
            }


        }

        void yarimbiletsecimi()
        {
            Random rastgele2 = new Random(200+Khafta*25);
            int salla2;
            int a2 = 0;
            for (int i = 0; i < Myarimbilet.Length; i++)
            {
                salla2 = rastgele2.Next(100, 999);
                for (int j = 0; j < Myarimbilet.Length; j++)
                {
                    if ((Myarimbilet[j] == salla2) || (biletlerikarsilastir(Myarimbilet, Mtambilet) ))
                    {
                        a2++;
                        i--;
                        break;
                    }


                }
                if ((a2 == 0) || (a2 < 2))
                {
                    Myarimbilet[i] = salla2;
                }
                a2 = 0;
            }


        }

        void ceyrekbiletsecimi()
        {

            Random rastgele3 = new Random(300+Khafta*25);
            int salla3;
            int a3 = 0;
            for (int i = 0; i < Mceyrekbilet.Length; i++)
            {
                salla3 = rastgele3.Next(100,999);
                for (int j = 0; j < Mceyrekbilet.Length; j++)
                {
                    if ((Mceyrekbilet[j] == salla3) || (biletlerikarsilastir(Mtambilet, Myarimbilet) || (biletlerikarsilastir(Mtambilet, Mceyrekbilet)) || (biletlerikarsilastir(Myarimbilet, Mceyrekbilet))))
                    {
                        a3++;
                        i--;
                        break;
                    }


                }


                if ((a3 == 0) || (a3 < 5))
                {
                  Mceyrekbilet[i] = salla3;
                }
                  a3 = 0;       
                
            }

        }
        bool biletlerikarsilastir(int[] A, int[] B)
        {

            //  string sonuc = null; 
            
          var sonuc= A.Intersect(B);

            foreach (var n in sonuc)
            {
                return true;
            }
            return false;
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 47 && (int)e.KeyChar <= 57)
            {

                e.Handled = false;//eğer 47 -58 arasındaysa tuşu yazdır.

            }

            else if ((int)e.KeyChar == 8)
            {

                e.Handled = false;//eğer basılan tuş backspace ise yazdır.

            }

            else
            {

                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma

            }
            if (textBox1.Text.Length > 10)
            {
                MessageBox.Show("Lütfen 11 haneli telefon numaranızı giriniz");
                textBox1.Text = "";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void mEkle_Click(object sender, EventArgs e)
        {
           // havuzaParaekle();

            Mkayitkontrol();
            
            
        }

        int paraHavuz = 0;
        void havuzaParaekle()
        {
            int x;
            x=int.Parse(odenenFiyat.Text);
            paraHavuz = paraHavuz + x;

        }
        void Mkayitkontrol()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlDataAdapter adtr = new SqlDataAdapter("select * from Tablo1 where isim='" + mAd.Text + "'and soyisim='" + mSoyad.Text + "' and telno='" + textBox1.Text + "'", baglanti);
                    DataTable Tablo1 = new DataTable();
                    adtr.Fill(Tablo1);
                    if (Tablo1.Rows.Count == 0)
                    {
                        baglanti.Close();
                        Mkayit();
                    }
                    else
                    {
                        if (Tablo1.Rows[0][0] != null)
                        {
                            //MessageBox.Show("Sayın " + Tablo1.Rows[0][1] + " " + Tablo1.Rows[0][2] + " yeni bilet almak istiyor musunuz?");
                            if (MessageBox.Show("Sayın " + Tablo1.Rows[0][1] + " " + Tablo1.Rows[0][2] + " yeni bilet almak istiyor musunuz? \nEski biletleriniz:\n" + Eskibilet(), "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                baglanti.Close();
                                Mkayit();

                            }

                        }
                    }


                    baglanti.Close();



                }
                Mlistele();



            }
            catch {
            }
           
               
        }
        string Eskibilet()
        {
            string A="";
            //baglanti.Open();
            try
            {
                SqlDataAdapter adtr = new SqlDataAdapter("select * from Tablo1 where isim='" + mAd.Text + "'and soyisim='" + mSoyad.Text + "' and telno='" + textBox1.Text + "'", baglanti);
                DataTable Tablo1 = new DataTable();
                adtr.Fill(Tablo1);
                for (int i = 0; i < Tablo1.Rows.Count; i++)
                {
                    A = A + ("" + Tablo1.Rows[i][7] + ".Hafta  " + Tablo1.Rows[i][4] + "    " + Tablo1.Rows[i][5] + "\n");
                }
                return A;
            }
            catch { }
            return "";
        }
        void Mkayit()
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "INSERT INTO Tablo1(isim,soyisim,telno,bilettipi,biletnumarasi,odedigiucret,hafta) VALUES ('" + mAd.Text + "','" + mSoyad.Text + "','" + textBox1.Text + "','" + biletTipi.Text + "','" + int.Parse(comboBox1.Text) + "','" + int.Parse(odenenFiyat.Text) + "','" + int.Parse(Hafta.Text) + "')";
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    baglanti.Close();
                    MessageBox.Show("Kayıt tamamlandı");
                    Mlistele();
                }
            }
            catch { }
          

        }

        void Mlistele()
        {
            try {
                if (baglanti.State == ConnectionState.Closed)
                {
                    SqlCommand cmd2 = new SqlCommand
                    {
                        Connection = baglanti,
                        CommandText = "SELECT * FROM Tablo1"
                    };
                    SqlDataAdapter adptr = new SqlDataAdapter(cmd2);
                    DataSet ds = new DataSet();
                    adptr.Fill(ds, "Tablo1");
                    dataGridView1.DataSource = ds.Tables["Tablo1"];
                    baglanti.Close();

                }
            }
            catch { }

        }


        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "update Tablo1 set isim='" + mAd.Text + "',soyisim='" + mSoyad.Text + "',telno='" + textBox1.Text + "',bilettipi='" + biletTipi.Text + "',biletnumarasi='" + int.Parse(comboBox1.Text) + "',odedigiucret='" + int.Parse(odenenFiyat.Text) + "',hafta='" + int.Parse(Hafta.Text) + "'where id=@numara";
                    cmd.Parameters.AddWithValue("@numara", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    baglanti.Close();
                    MessageBox.Show("Kayıt guncellendi");
                    Mlistele();
                }
            }
            catch { }

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            try {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandText = "update Tablo1 set isim='" + mAd.Text + "',soyisim='" + mSoyad.Text + "',telno='" + textBox1.Text + "',bilettipi='" + biletTipi.Text + "',biletnumarasi='" + int.Parse(comboBox1.Text) + "',odedigiucret='" + int.Parse(odenenFiyat.Text) + "',hafta='" + int.Parse(Hafta.Text) + "'where id=@numara";
                    cmd.Parameters.AddWithValue("@numara", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    baglanti.Close();
                    MessageBox.Show("Kayıt guncellendi");
                    Mlistele();
                }
            } catch { }
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Silmek istediğinizden emin misiniz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (baglanti.State == ConnectionState.Closed)
                    {
                        baglanti.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = baglanti;
                        cmd.CommandText = "delete from Tablo1 where id=@numara";
                        cmd.Parameters.AddWithValue("@numara", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        baglanti.Close();
                        MessageBox.Show("Kayıt silindi");
                        Mlistele();
                    }
                }
            }
            catch{ }
           
        }
      
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            mAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            mSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            biletTipi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            odenenFiyat.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            Hafta.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Tablo1 where isim like '%" + mAd.Text + "%'", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    baglanti.Close();


                }
            } catch { }
           

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand("Select * from Tablo1 where hafta='" + int.Parse(Hafta.Text) + "'", baglanti);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    baglanti.Close();


                }
            } catch { }
            
        }

        private void Hafta_SelectedIndexChanged(object sender, EventArgs e)
        {
            Khafta = int.Parse(Hafta.Text);
            diziSifirla();
            tambiletsecimi();
            yarimbiletsecimi();
            ceyrekbiletsecimi();
            //alinanlariEksilt();
            biletListele();

        }
        void diziSifirla()
        {
            for (int i = 0; i < Mtambilet.Length; i++)
            {
                Mtambilet[i] = 0;
                Myarimbilet[i] = 0;
                Mceyrekbilet[i] = 0;
            }
        }
        //void alinanlariEksilt()
        //{
        //    if (int.Parse(Hafta.Text) == 1)
        //    {
        //        if(biletTipi.Text=="Tam Bilet")
        //        {
        //            if (baglanti.State == ConnectionState.Closed)
        //            {
        //                baglanti.Open();
        //                SqlDataAdapter adtr = new SqlDataAdapter("select * from tablo1 where bilettipi='Tam Bilet' and hafta=1", baglanti);
        //                DataTable Tablo1 = new DataTable();
        //                adtr.Fill(Tablo1);
        //                if (Tablo1.Rows.Count == 0)
        //                {
        //                    baglanti.Close();
        //                    Mkayit();
        //                }
        //                baglanti.Close();
        //            }
        //        }
        //        else if(biletTipi.Text == "Yarım Bilet")
        //        {

        //        }
        //        else if (biletTipi.Text == "Çeyrek Bilet")
        //        {

        //        }

        //    }
        //    else if(int.Parse(Hafta.Text) == 2)
        //    {

        //    }
        //    else if (int.Parse(Hafta.Text) == 3)
        //    {

        //    }
        //    else if (int.Parse(Hafta.Text) == 4)
        //    {

        //    }
        //    else if (int.Parse(Hafta.Text) == 5)
        //    {

        //    }
        //    else if (int.Parse(Hafta.Text) == 6)
        //    {

        //    }
        //    else if (int.Parse(Hafta.Text) == 7)
        //    {

        //    }
        //}
        private void button11_Click(object sender, EventArgs e)
        {
            Mlistele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            //datakontrol = false;
            //string x, y;
            //x=biletTipi.Text;
            //y=Hafta.Text;
            //biletTipi.Text = "" + -1;
            //Hafta.Text = "" + -1;
            //biletTipi.Text =  x;
            //Hafta.Text = y;
            //mEkle.Enabled = true;
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu otomasyon Mehmet Berkay tarafından hazırlanmıştır.");
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

            
        


    

       





    


