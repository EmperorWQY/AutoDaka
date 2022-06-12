using Sign.Models;

namespace Sign
{
    public partial class Form1 : Form
    {
        db_signContext ctx;
        SignData signData;

        public Form1()
        {
            InitializeComponent();

            ctx = new db_signContext();
            signData = new SignData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            label1.Text = "运行状态：正在运行";
            label1.ForeColor = Color.LightGreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            setValue();
            timer1.Enabled = true;
            timer1.Interval = 10;

            refreshUserData();
        }

        private void refreshUserData()
        {
            try
            {
                var infoList = ctx.Js.ToList();
                foreach (var info in infoList)
                {
                    var row = new string[] { info.Uid.ToString(), info.Usr, info.Pwd };
                    dataGridView1.Rows.Add(row);
                }
            } catch (Exception)
            {
                richTextBox1.Text += DateTime.Now.ToString() + "数据库连接失败";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            getValue();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                var uList = ctx.Js.ToList();
                foreach (var u in uList)
                {
                    var rsp = HttpUtil.Post("https://student.wozaixiaoyuan.com/health/save.json", signData.getData(), u.Usr, u.Pwd);
                    if (rsp.Contains("200"))
                        richTextBox1.Text += DateTime.Now.ToString() + ":" + u.Uid + "已打卡" + u.Usr + "\r\n";
                    else
                        richTextBox1.Text += DateTime.Now.ToString() + ":" + u.Uid + "打卡失败" + u.Usr + "\r\n";
                }
            }
            catch (Exception)
            {
                richTextBox1.Text += DateTime.Now.ToString() + "数据库连接失败";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            label1.Text = "运行状态：已停止";
            label1.ForeColor = Color.PaleVioletRed;
        }

        private void setValue()
        {
            textBox1.Text = "108.60494";
            textBox2.Text = "34.10847";
            textBox3.Text = "610118";
            textBox4.Text = "东街";
            textBox5.Text = "甘宁街道";
            textBox6.Text = "鄠邑区";
            textBox7.Text = "陕西省";
            textBox8.Text = "西安市";
            textBox9.Text = "中国";
            textBox10.Text = "610118001";
            textBox11.Text = "156610100";
        }

        private void getValue()
        {
            var longitude = textBox1.Text;
            var latitude = textBox2.Text;
            var areacode = textBox3.Text;
            var street = textBox4.Text;
            var township = textBox5.Text;
            var district = textBox6.Text;
            var province = textBox7.Text;
            var city = textBox8.Text;
            var country = textBox9.Text;
            var towncode = textBox10.Text;
            var citycode = textBox11.Text;
            var timestampHeader = GetTimeStamp();
            signData = new SignData(longitude,latitude,areacode,street,township,district,province,city,
                country,towncode,citycode,timestampHeader);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.SaveFile("Log.txt");
        }

        private string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
    }
}