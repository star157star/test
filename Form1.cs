using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Windows.Forms;

namespace PTT_Crawler
{
    public partial class Form1 : Form
    {
        DB db;
        public Form1()
        {
            InitializeComponent();
            db = new DB("localhost", "root", "", "ptt-crawler-db");
            db.open();
        }

        private void insertData_Click(object sender, EventArgs e)
        {
            db.insertData("test", "test", "你好");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("你是否確定要離開?", "警告", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                db.close();
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void crawPTT_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new ChromeDriver(".");
            driver.Navigate().GoToUrl("https://www.ptt.cc/bbs/NBA/index4539.html");
            for (int i = 1; i <= 20; i++)
            {
                var title = driver.FindElement(By.XPath("/html/body/div[@id='main-container']/div[@class='r-list-container bbs-screen']/div[@class='r-ent'][" + i + "]/div[@class='title']/a"));
                db.insertData("test", "test", title.GetAttribute("innerHTML").ToString());
            }

            driver.Quit();
        }
    }
}