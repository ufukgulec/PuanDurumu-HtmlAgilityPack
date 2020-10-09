using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Collections;
namespace PuanDurumu_HtmlAgilityPack_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
       
            
                //*[@class='responsive-table']/table/tbody/tr/td[3]/a[1] Takım sırası...

            //https://www.transfermarkt.com.tr/fenerbahce-sk/startseite/verein/36
            //string XPathNo= "//*[@class='items']/tbody/tr/td[1]/div";
            //string XPathDogum = "//*[@class='items']/tbody/tr/td[4]";
            //string XPathMevki = "//*[@class='items']/tbody/tr/td[3]";
            //string XPathDeger = "//*[@class='items']/tbody/tr/td[6]";

        }
        ArrayList takımlar = new ArrayList();
        ArrayList puanlar = new ArrayList();
        ArrayList golcüler = new ArrayList();
        ArrayList kacGol = new ArrayList();
        ArrayList resimler = new ArrayList();
        private void scrape(string adres, string xPath, ArrayList liste)
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = web.Load(adres);
            
            foreach (var item in document.DocumentNode.SelectNodes(xPath))
            {
                liste.Add(item.InnerText);
            }
            //for (int i = 0; i < takımlar.Count; i++)
            //{
            //    dataGridView1.Rows.Add(i+1,takımlar[i], puanlar[i]);
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //tamEkran();
            bilgiler();

        }
        private void bilgiler() 
        {
            string adres = "https://www.transfermarkt.com.tr/super-lig/tabelle/wettbewerb/TR1/saison_id/2020";
            string XPathIsım = "//*[@class='responsive-table']/table/tbody/tr/td[3]/a[1]";
            string XPathPuan = "//*[@class='responsive-table']/table/tbody/tr/td[10]";
            scrape(adres, XPathIsım, takımlar);
            scrape(adres, XPathPuan, puanlar);
            yazdir(takımlar, puanlar, dataGridView1);
            scrape("https://www.mackolik.com/puan-durumu/t%C3%BCrkiye-s%C3%BCper-lig/istatistik/482ofyysbdbeoxauk19yg7tdt", "//*[@class='p0c-competition-player-ranking__player-name-container']", golcüler);
            scrape("https://www.mackolik.com/puan-durumu/t%C3%BCrkiye-s%C3%BCper-lig/istatistik/482ofyysbdbeoxauk19yg7tdt", "//*[@class='p0c-competition-player-ranking__cell p0c-competition-player-ranking__cell--stat']", kacGol);
            yazdir(golcüler, kacGol, dataGridView2);
        }
        private void yazdir(ArrayList item, ArrayList point,DataGridView dt)
        {
            for (int i = 0; i < item.Count; i++)
            {
                dt.Rows.Add(i + 1, item[i], point[i]);
            }
        }
        private void yazdir1()
        {
            for (int i = 0; i < golcüler.Count; i++)
            {
                dataGridView2.Rows.Add(i + 1, golcüler[i]);
            }
        }

        private void tamEkran()
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0,0);
            MessageBox.Show(w+","+h);
            this.Size=new Size(w,h);

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
