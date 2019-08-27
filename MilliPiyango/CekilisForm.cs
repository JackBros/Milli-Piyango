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

namespace MilliPiyango
{
    public partial class CekilisForm : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PCOH8E6\\SQLEXPRESS;Initial Catalog=MilliPiyango;Integrated Security=True");
        int ilkdegeri = 0;
        public CekilisForm()
        {

            InitializeComponent();
            
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bu otomasyon Mehmet Berkay tarafından hazırlanmıştır.");

        }

        private void anaMenüyeDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            this.Hide();
            frm1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void CekilisForm_Load(object sender, EventArgs e)
        {

        }

        private void haftaSecimi_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            listBox1.Items.Clear();
            // int havuzhesabi = 0;
            //havuzhesabi+= havuzdakiparayihesapla();
            //textBox2.Text =""+ havuzhesabi;
            textBox2.Text = "" +havuzdakiparayihesapla();//-kazananlar
            fonksiyonX();
            ilkdegeri = int.Parse(textBox2.Text);
        }
        int odenecekler()
        {
            return 0;
        }
        void fonksiyonX()
        {
            //BTNcekilis.Enabled = false;
            //BTNonay.Enabled = false;
            //int haftasec = int.Parse(haftaSecimi.Text);
            //çekiliş yapılmış ama kazanılan olmamış olabilir
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select * from Tablo2 where hafta='" + int.Parse(haftaSecimi.Text) + "'", baglanti);
                DataTable Tablo2 = new DataTable();
                adtr.Fill(Tablo2);
                if (Tablo2.Rows.Count == 0)
                {
                    BTNcekilis.Enabled = true;
                    BTNonay.Enabled = true;
                    /////////////////////////////////// işlem yapılacak
                    baglanti.Close();

                }
                else
                {
                    //kazananları gösterir
                    for (int i = 0; i < Tablo2.Rows.Count; i++)
                    {
                        listBox1.Items.Add("" + Tablo2.Rows[i][1] + "---" + Tablo2.Rows[i][2] + "---" + Tablo2.Rows[i][3] + "---" + Tablo2.Rows[i][4] + "---" + Tablo2.Rows[i][8]);
                    }

                }


                baglanti.Close();



            }


        }
        private void BTNcekilis_Click(object sender, EventArgs e)
        {

            /*Random rnd = new Random();
            int kazananno = rnd.Next(100, 999);
            textBox1.Text = "" + kazananno;
            */

            textBox1.Text = "626" ;
        }
        int odenecekucret(string A)
        {
            
            int kazanansayi = int.Parse(textBox1.Text);




                return 0;
           
        }
        void kazanankontrol()
        {
            baglanti.Close();
            try {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    int amorti = (int.Parse(textBox1.Text))%100;
                    string amortilike = "";
                    //MessageBox.Show("" + amorti);
                    if (amorti == 0)
                    {
                         amortilike = "%" + amorti+""+amorti ;//'%'+'"+amorti+"'
                    }
                    else
                    {
                        amortilike = "%" + amorti;//'%'+'"+amorti+"'
                    }
                   
                    SqlDataAdapter adtr = new SqlDataAdapter("select * from Tablo1 where hafta='" + int.Parse(haftaSecimi.Text) + "' and (biletnumarasi LIKE '"+amortilike+"')", baglanti);
                    DataTable Tablo1 = new DataTable();
                    adtr.Fill(Tablo1);
                    if (Tablo1.Rows.Count == 0)
                    {
                        //kazanan olmadı demek
                        listBox1.Items.Add("Kazanan Yok!!");
                        MessageBox.Show("Kazanan Yok!");
                         baglanti.Close();

                    }
                    else
                    { //amorti varsa
                        

                        
                        for (int i = 0; i < Tablo1.Rows.Count; i++)
                        {
                            int kazandigimiktar;
                            if (int.Parse("" + Tablo1.Rows[i][5]) == (int.Parse(textBox1.Text)))
                            {
                                kazandigimiktar = hepsinikazandi("" + Tablo1.Rows[i][4]);
                                listBox1.Items.Add("" + strgonder("" + Tablo1.Rows[i][1]) + "---" + strgonder("" + Tablo1.Rows[i][2]) + "---" + strgonder("" + Tablo1.Rows[i][3]) + "---" + strgonder("" + Tablo1.Rows[i][4]) + "---" + "Kazandığı="+kazandigimiktar);


                            }
                            else
                            {
                                 kazandigimiktar = amorticikti("" + Tablo1.Rows[i][4]);
                                listBox1.Items.Add("" + strgonder("" + Tablo1.Rows[i][1]) + "---" + strgonder("" + Tablo1.Rows[i][2]) + "---" + strgonder("" + Tablo1.Rows[i][3]) + "---" + strgonder("" + Tablo1.Rows[i][4]) + "---" + "Kazandığı=" + kazandigimiktar);

                            }


                            //düzeltcek 8. satıra kaznılan para eklenicek öyle listbox a yazılacak
                            // bu sorgu 2. tabloya elemanları ekliyor bu yüzden Onayla butonu.... eklemeyi onaylada yap. sonra havuzu göstereni veritabanına bağlayabilirsin.

                            //////SqlCommand cmd = new SqlCommand();
                            //////cmd.Connection = baglanti;
                            //////cmd.CommandText = "INSERT INTO Tablo2(isim,soyisim,telno,bilettipi,biletnumarasi,odedigiucret,hafta,alacagiucret) VALUES ('" + "" + Tablo1.Rows[i][1] + "','" + "" + Tablo1.Rows[i][2] + "','" + "" + Tablo1.Rows[i][3] + "','" + "" + Tablo1.Rows[i][4] + "','" + int.Parse("" + Tablo1.Rows[i][5]) + "','" + int.Parse("" + Tablo1.Rows[i][6]) + "','" + int.Parse("" + Tablo1.Rows[i][7]) + "','" + odenecekucret("" + Tablo1.Rows[i][3]) + "')";
                            //////cmd.ExecuteNonQuery();
                            //////cmd.Dispose();


                            //SqlDataAdapter adtr2 = new SqlDataAdapter("select * from Tablo1 where hafta='" + int.Parse(haftaSecimi.Text) + "' and biletnumarasi='"+int.Parse(textBox1.Text)+"'", baglanti);


                        }

                    }


                    baglanti.Close();



                }
            } catch { }
            
        }
        string strgonder(string A)
        {
            A = A + "";
            return A;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            kazanankontrol();
        }

        private void BTNonay_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            //havuzdaki paraları hesaplattır.
        }
        int amorticikti(string A)
        {
            int azalt=0;
            
            if (A == "Tam Bilet")
            {
                azalt = 70;
                textBox2.Text = "" + (ilkdegeri - azalt);
                return 70;
            }
            else if (A == "Yarım Bilet")
            {
                azalt = 35;
                textBox2.Text = "" + (ilkdegeri - azalt);
                return 35;
            }
            else if (A == "Çeyrek Bilet")
            {
                azalt = 17;
                textBox2.Text = "" + (ilkdegeri - azalt);
                return 17;
            }

            return 0;
        }
        int hepsinikazandi(string B)
        {
            
            int kazandigi= 0;
            
            if (B == "Tam Bilet")
            {
                kazandigi = ilkdegeri;
                //azalt =ilkdegeri-kazandigi;
                textBox2.Text = "" + (ilkdegeri-kazandigi);
                return kazandigi;
            }
            else if (B == "Yarım Bilet")
            {
                kazandigi = ilkdegeri/2;
                //azalt = ilkdegeri - kazandigi;
                textBox2.Text = "" + (ilkdegeri-kazandigi);
                return kazandigi;
                
            }
            else if (B == "Çeyrek Bilet")
            {
                kazandigi = ilkdegeri / 4;
                //azalt = ilkdegeri - kazandigi;
                textBox2.Text = "" + (ilkdegeri-kazandigi);
                return kazandigi;

            }

            return 0;
        }

        int k = 0;
        int havuzdakiparayihesapla()
        {
            try {
                if (baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                    SqlDataAdapter adtr = new SqlDataAdapter("select * from Tablo1 where hafta='" + int.Parse(haftaSecimi.Text) + "'", baglanti);
                    DataTable Tablo1 = new DataTable();
                    adtr.Fill(Tablo1);
                    for (int i = 0; i < Tablo1.Rows.Count; i++)
                    {
                        
                        k += int.Parse("" + Tablo1.Rows[i][6]);// - ödenecek ücret
                    }
                    baglanti.Close();
                }
                return k;
            } catch { }
            return 0;
        }
    }
}
