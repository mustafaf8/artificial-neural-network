using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace YSAP
{
    public partial class Form1 : Form
    {
        YapaySinirAgi YSA;

        public Form1()
        {
            InitializeComponent();
            YSA = new YapaySinirAgi();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BaslangicDurumunaGetir();
        }

        private void BaslangicDurumunaGetir()
        {
            tableLayoutPanel1.Controls.Clear();
            for (int i = 0; i < 7; i++) // Her satır için
            {
                for (int j = 0; j < 5; j++) // Her sütun için
                {
                    Panel panel = new Panel();
                    panel.BackColor = System.Drawing.Color.White;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    panel.Click += Kare_Click;
                    panel.Tag = 0;
                    tableLayoutPanel1.Controls.Add(panel, j, i); // Paneli satır ve sütun konumuna göre ekleyin
                }
            }

            listBoxSonuclar.Items.Clear(); // Liste temizleniyor
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            BaslangicDurumunaGetir();
        }

        private void btnEgit_Click(object sender, EventArgs e)
        {
            listBoxSonuclar.Items.Clear(); // Liste temizleniyor

            double minHata = double.MaxValue;
            char enIyiHarf = ' ';

            foreach (char harf in new char[] { 'A', 'B', 'C', 'D', 'E' }) // Her harf için eğitim yapılıyor ve test ediliyor
            {
                double hata = YSA.Egit(harf);
                listBoxSonuclar.Items.Add($"    {harf} => Eğitim Hatası: {hata}");

                if (hata < minHata)
                {
                    minHata = hata;
                    enIyiHarf = harf;
                }
            }

            
        }

        private void btnTestEt_Click(object sender, EventArgs e)
        {
            listBoxSonuclar.Items.Clear(); // Liste temizleniyor

            double[] giris = new double[35];

            int index = 0;
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                if (control is Panel)
                {
                    Panel panel = (Panel)control;
                    giris[index++] = (int)panel.Tag;
                }
            }

            char enIyiHarf = ' '; // En iyi harf başlangıçta belirtilmediği için
                                  // Test işlemi için en iyi harfi tahmin etmek için en iyi harfi bulmamız gerekiyor
            double minHata = double.MaxValue;
            foreach (char harf in new char[] { 'A', 'B', 'C', 'D', 'E' })
            {
                double[] cikis = YSA.TahminEt(giris);

                double hata = 0;
                double[] egitim = null;
                switch (harf)
                {
                    case 'A':
                        egitim = new double[]{ 0,0,1,0,0, // A
                                              0,1,0,1,0,
                                              1,0,0,0,1,
                                              1,0,0,0,1,
                                              1,1,1,1,1,
                                              1,0,0,0,1,
                                              1,0,0,0,1};
                        break;
                    case 'B':
                        egitim = new double[]{ 1,1,1,1,0, // B
                                              1,0,0,0,1,
                                              1,0,0,0,1,
                                              1,1,1,1,0,
                                              1,0,0,0,1,
                                              1,0,0,0,1,
                                              1,1,1,1,0};
                        break;
                    case 'C':
                        egitim = new double[]{0,0,1,1,1, // C
                                              0,1,0,0,0,
                                              1,0,0,0,0,
                                              1,0,0,0,0,
                                              1,0,0,0,0,
                                              0,1,0,0,0,
                                              0,0,1,1,1};
                        break;
                    case 'D':
                        egitim = new double[]{ 1,1,1,0,0, // D
                                              1,0,0,1,0,
                                              1,0,0,0,1,
                                              1,0,0,0,1,
                                              1,0,0,0,1,
                                              1,0,0,1,0,
                                              1,1,1,0,0};
                        break;
                    case 'E':
                        egitim = new double[]{ 1,1,1,1,1, // E
                                              1,0,0,0,0,
                                              1,0,0,0,0,
                                              1,1,1,1,1,
                                              1,0,0,0,0,
                                              1,0,0,0,0,
                                              1,1,1,1,1};
                        break;
                    default:
                        break;
                }

                for (int j = 0; j < 5; j++)
                {
                    hata += Math.Pow(egitim[j] - cikis[j], 2);
                }

                listBoxSonuclar.Items.Add($"    {harf} => Hata: {hata}");

                if (hata < minHata)
                {
                    minHata = hata;
                    enIyiHarf = harf;
                }
            }

            listBoxSonuclar.Items.Add($"En İyi Harf: ({enIyiHarf}) , Hata: {minHata}");
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            YSA.AgirliklariKaydet();
        }

        private void btnYukle_Click(object sender, EventArgs e)
        {
            YSA.AgirliklariYukle();
        }

        private void Kare_Click(object sender, EventArgs e)
        {
            Panel kare = (Panel)sender;
            if (kare.BackColor == System.Drawing.Color.Black)
                kare.BackColor = System.Drawing.Color.White;
            else
                kare.BackColor = System.Drawing.Color.Black;

            kare.Tag = kare.BackColor == System.Drawing.Color.Black ? 1 : 0;
        }
    }

    public class YapaySinirAgi
    {
        double[,] agirlikGizli;
        double[,] agirlikCikis;
        double ogrenmeKatsayisi = 0.1;
        int gizliNoronSayisi = 20;

        public YapaySinirAgi()
        {
            agirlikGizli = new double[35, gizliNoronSayisi];
            agirlikCikis = new double[gizliNoronSayisi, 5];

            Random rastgele = new Random();
            double minAgrlik = -0.1;
            double maxAgrlik = 0.1;

            for (int i = 0; i < 35; i++)
            {
                for (int j = 0; j < gizliNoronSayisi; j++)
                {
                    agirlikGizli[i, j] = minAgrlik + (maxAgrlik - minAgrlik) * rastgele.NextDouble();
                }
            }
            for (int i = 0; i < gizliNoronSayisi; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    agirlikCikis[i, j] = minAgrlik + (maxAgrlik - minAgrlik) * rastgele.NextDouble();
                }
            }
        }

        public double Egit(char harf)
        {
            double[][] egitimVerisi = new double[][]
            {
                new double[]{ 0,0,1,0,0, // A
                              0,1,0,1,0,
                              1,0,0,0,1,
                              1,0,0,0,1,
                              1,1,1,1,1,
                              1,0,0,0,1,
                              1,0,0,0,1,},
                new double[]{ 1,1,1,1,0, // B
                              1,0,0,0,1,
                              1,0,0,0,1,
                              1,1,1,1,0,
                              1,0,0,0,1,
                              1,0,0,0,1,
                              1,1,1,1,0,},
                new double[]{ 0,0,1,1,1, // C
                              0,1,0,0,0,
                              1,0,0,0,0,
                              1,0,0,0,0,
                              1,0,0,0,0,
                              0,1,0,0,0,
                              0,0,1,1,1},
                new double[]{ 1,1,1,0,0, // D
                              1,0,0,1,0,
                              1,0,0,0,1,
                              1,0,0,0,1,
                              1,0,0,0,1,
                              1,0,0,1,0,
                              1,1,1,0,0},
                new double[]{ 1,1,1,1,1, // E
                              1,0,0,0,0,
                              1,0,0,0,0,
                              1,1,1,1,1,
                              1,0,0,0,0,
                              1,0,0,0,0,
                              1,1,1,1,1},
            };

            int harfIndex = harf - 'A'; // Harfin indeksi

            double[] egitim = egitimVerisi[harfIndex];
            double toplamHata = 0;

            for (int iterasyon = 0; iterasyon < 5000; iterasyon++)
            {
                double[] giris = egitim;

                double[] gizliCikis = new double[gizliNoronSayisi];
                for (int j = 0; j < gizliNoronSayisi; j++)
                {
                    double net = 0;
                    for (int k = 0; k < 35; k++)
                    {
                        net += giris[k] * agirlikGizli[k, j];
                    }
                    gizliCikis[j] = Sigmoid(net);
                }

                double[] cikis = new double[5];
                for (int j = 0; j < 5; j++)
                {
                    double net = 0;
                    for (int k = 0; k < gizliNoronSayisi; k++)
                    {
                        net += gizliCikis[k] * agirlikCikis[k, j];
                    }
                    cikis[j] = Sigmoid(net);
                }
                //geri  yayılım (Backpropagation)

                double[] geriHataCikis = new double[5];
                for (int j = 0; j < 5; j++)
                {
                    geriHataCikis[j] = (egitim[j] - cikis[j]) * SigmoidTurevi(cikis[j]);
                    toplamHata += Math.Pow(egitim[j] - cikis[j], 2);
                }

                double[] geriHataGizli = new double[gizliNoronSayisi];
                for (int j = 0; j < gizliNoronSayisi; j++)
                {
                    double hata = 0;
                    for (int k = 0; k < 5; k++)
                    {
                        hata += geriHataCikis[k] * agirlikCikis[j, k];
                    }
                    geriHataGizli[j] = hata * SigmoidTurevi(gizliCikis[j]);
                }

                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < gizliNoronSayisi; k++)
                    {
                        agirlikCikis[k, j] += ogrenmeKatsayisi * geriHataCikis[j] * gizliCikis[k];
                    }
                }

                for (int j = 0; j < gizliNoronSayisi; j++)
                {
                    for (int k = 0; k < 35; k++)
                    {
                        agirlikGizli[k, j] += ogrenmeKatsayisi * geriHataGizli[j] * giris[k];
                    }
                }
            }

            return toplamHata;
        }

        public double[] TahminEt(double[] giris)
        {
            double[] gizliCikis = new double[gizliNoronSayisi];
            for (int j = 0; j < gizliNoronSayisi; j++)
            {
                double net = 0;
                for (int k = 0; k < 35; k++)
                {
                    net += giris[k] * agirlikGizli[k, j];
                }
                gizliCikis[j] = Sigmoid(net);
            }

            double[] cikis = new double[5];
            for (int j = 0; j < 5; j++)
            {
                double net = 0;
                for (int k = 0; k < gizliNoronSayisi; k++)
                {
                    net += gizliCikis[k] * agirlikCikis[k, j];
                }
                cikis[j] = Sigmoid(net);
            }

            return cikis;
        }

        private double Sigmoid(double net)
        {
            return 1 / (1 + Math.Exp(-net));
        }

        private double SigmoidTurevi(double cikis)
        {
            return cikis * (1 - cikis);
        }

        public void AgirliklariKaydet()
        {
            int gizliBoyut1 = agirlikGizli.GetLength(0);
            int gizliBoyut2 = agirlikGizli.GetLength(1);
            int cikisBoyut1 = agirlikCikis.GetLength(0);
            int cikisBoyut2 = agirlikCikis.GetLength(1);

            string agirlikGizliStr = $"{gizliBoyut1},{gizliBoyut2},{string.Join(",", agirlikGizli.Cast<double>())}";
            string agirlikCikisStr = $"{cikisBoyut1},{cikisBoyut2},{string.Join(",", agirlikCikis.Cast<double>())}";

            File.WriteAllText("agirlik_gizli.txt", agirlikGizliStr);
            File.WriteAllText("agirlik_cikis.txt", agirlikCikisStr);
            MessageBox.Show("Agırlıklar başarıyla kaydedildi.", "Kaydetme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void AgirliklariYukle()
        {
            if (File.Exists("agirlik_gizli.txt") && File.Exists("agirlik_cikis.txt"))
            {
                string[] agirlikGizliStr = File.ReadAllText("agirlik_gizli.txt").Split(',');
                string[] agirlikCikisStr = File.ReadAllText("agirlik_cikis.txt").Split(',');

                int gizliBoyut1 = int.Parse(agirlikGizliStr[0]);
                int gizliBoyut2 = int.Parse(agirlikGizliStr[1]);
                int cikisBoyut1 = int.Parse(agirlikCikisStr[0]);
                int cikisBoyut2 = int.Parse(agirlikCikisStr[1]);

                agirlikGizli = new double[gizliBoyut1, gizliBoyut2];
                agirlikCikis = new double[cikisBoyut1, cikisBoyut2];

                int index = 2;
                for (int i = 0; i < gizliBoyut1; i++)
                {
                    for (int j = 0; j < gizliBoyut2; j++)
                    {
                        agirlikGizli[i, j] = Convert.ToDouble(agirlikGizliStr[index++]);
                    }
                }

                index = 2;
                for (int i = 0; i < cikisBoyut1; i++)
                {
                    for (int j = 0; j < cikisBoyut2; j++)
                    {
                        agirlikCikis[i, j] = Convert.ToDouble(agirlikCikisStr[index++]);
                    }
                }
            }
        }
    }
}
