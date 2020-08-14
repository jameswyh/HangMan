using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using System.Media;
using System.Drawing.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;

namespace Hangman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timelabel.Text = (countdown/10).ToString()+"s";
            highscorelabel.Text = File.ReadAllText(@"score.txt");
            newfont();
        }

        private void newfont()
        {
            PrivateFontCollection pfc = new PrivateFontCollection();  //读取字体文件           
            pfc.AddFontFile(@"youyun.ttf");
            //Font f =new Font(pfc .Families[0],16);    //实例化字体    
            foreach (Control control in this.Controls)
            {
                control.Font = new Font(pfc.Families[0], 26, control.Font.Style); ;
            }
            foreach (Control control in this.panel1.Controls)
            {
                control.Font = new Font(pfc.Families[0], 30, control.Font.Style);
            }
            foreach (Control control in this.panel2.Controls)
            {
                control.Font = new Font(pfc.Families[0], 16, control.Font.Style);
            }
            foreach (Control control in this.panel3.Controls)
            {
                control.Font = new Font(pfc.Families[0], 14, control.Font.Style);
            }
        }
        private void clicksound()//按键音
        {
            SecondaryBuffer secBuffer;//缓冲区对象    
            Device secDev;//设备对象    
            secDev = new Device();
            secDev.SetCooperativeLevel(this, CooperativeLevel.Normal);//设置设备协作级别    
            secBuffer = new SecondaryBuffer(@"click.wav", secDev);//创建辅助缓冲区    
            secBuffer.Play(0, BufferPlayFlags.Default);//设置缓冲区为默认播放   
        }
        private static void wrongsound()
        {
            System.Media.SoundPlayer sp1 = new SoundPlayer();//播放音效
            sp1.SoundLocation = @"wrong.wav";
            sp1.Play();
        }

        string eng = "";//英语单词题目
        string chn = "";
        string blk = "";//空下划线
        char[] carr;//字符替换中间量
        int count = 1;//错误次数统计
        int flaglose = 0;//输flag
        int flagwin = 0;//赢flag 正确字母个数
        int countdown = 300;//倒计时30s
        int score = 0;//计分

        private void Form1_Load(object sender, EventArgs e)
        {
            blk = "";
            flagwin = 0;
            int other = 1;
            while (other != 0)
            {
                int i;
                Random ran = new Random();
                int n = ran.Next(1, 15329);
                OleDbConnection word = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|\\cet6.mdb;");
                OleDbCommand cmd1 = new OleDbCommand("SELECT English FROM cetsix WHERE ID =  " + n.ToString(), word);//根据随机ID取单词
                OleDbCommand cmd2 = new OleDbCommand("SELECT Chinese FROM cetsix WHERE ID =  " + n.ToString(), word);//根据随机ID取中文
                word.Open();
                eng = cmd1.ExecuteScalar().ToString();
                chn = cmd2.ExecuteScalar().ToString();

                word.Close();
                for (i = 0; i < eng.Length; i++) //排除含有非字母的单词
                {
                    if (eng[i] < 'a' || eng[i] > 'z')
                    {
                        other = 1;
                        break;
                    }
                }
                if (i == eng.Length)
                {
                    other = 0;
                }
            }

            for (int i = 0; i < eng.Length; i++)//根据字母长度生产空下划线
            {
                blk += "_ ";
            }
            carr = blk.ToCharArray();//空格字符串转字符数组
            englishlabel.Text = blk;
            answerlabel.Text = eng;
            chineselabel.Text = chn;
            scorelabel.Text = score.ToString();
            if (score > Convert.ToInt32(File.ReadAllText(@"score.txt")))
            {
                File.WriteAllText(@"score.txt", scorelabel.Text);
                highscorelabel.Text = File.ReadAllText(@"score.txt");
            }
        }

        private void pic()//根据错误次数更换小人图片
        {
            count++;
            
            if (count == 2)
            {
                pictureBox1.Image = Image.FromFile(@"Hangman-2.png");
            }
            else if (count == 3)
            {
                pictureBox1.Image = Image.FromFile(@"Hangman-3.png");
            }
            else if (count == 4)
            {
                pictureBox1.Image = Image.FromFile(@"Hangman-4.png");
            }
            else if (count == 5)
            {
                pictureBox1.Image = Image.FromFile(@"Hangman-5.png");
            }
            else if (count == 6)
            {
                pictureBox1.Image = Image.FromFile(@"Hangman-6.png");
            }
            else if (count == 7)
            {
                pictureBox1.Image = Image.FromFile(@"Hangman-7.png");
            }
            else if (count == 8)
            {
                pictureBox1.Image = Image.FromFile(@"Hangman-8.png");
                resultlabel.Visible = true;
                resultlabel.Text = "YOU LOSE!";
                panel1.Enabled = false;
                englishlabel.Text = eng;
                chineselabel.Visible = true;
                timer1.Stop();
                startbutton.Visible = true;
                startbutton.Text = "Restart";
                unenbledtool();
                wrongsound();
                if (score > Convert.ToInt32(File.ReadAllText(@"score.txt")))
                {
                    timer2.Start();
                }
            }
        }

        private void win()//判断赢
        {
            if (flagwin == eng.Length)
            {
                resultlabel.Visible = true;
                resultlabel.Text = "YOU WIN!";
                panel1.Enabled = false;
                chineselabel.Visible = true;
                score += 10;
                scorelabel.Text = score.ToString();
                timer1.Stop();
                startbutton.Visible = true;
                startbutton.Text = "Continue";
                unenbledtool();
                SecondaryBuffer secBuffer1;//缓冲区对象    
                Device secDev1;//设备对象    
                secDev1 = new Device();
                secDev1.SetCooperativeLevel(this, CooperativeLevel.Normal);//设置设备协作级别    
                secBuffer1 = new SecondaryBuffer(@"yes.wav", secDev1);//创建辅助缓冲区    
                secBuffer1.Play(0, BufferPlayFlags.Default);//设置缓冲区为默认播放  
                
                if (score > Convert.ToInt32(File.ReadAllText(@"score.txt")))
                {
                    timer2.Start();
                }
            }
        }

        private void guess(char x)//猜词过程
        {
            flaglose = 0;
            for (int i = 0; i < eng.Length; i++)
            {
                if (eng[i] == x)//如果正确则将下划线替换成相应字母
                {
                    carr[2*i] = x;
                    englishlabel.Text = new string(carr);
                    flaglose = 1;
                    flagwin++;
                    countdown += 30;
                }

            }
            if (flaglose == 0)//错误则更换图片
            {
                countdown -= 10;
                pic();
            }
            else
            {
                win();
            }
            foreach (Control ctl in panel1.Controls)//将被提示的按钮消失
            {
                if (ctl is Button)
                {
                    Button btn = ctl as Button;
                    if (btn.Text == x.ToString().ToUpper())
                    {
                        btn.Visible = false;
                    }
                }
            }
            clicksound();
        }

        

        private void buttonA_Click(object sender, EventArgs e)
        {
            guess('a');
        }

        private void buttonB_Click(object sender, EventArgs e)
        {
            guess('b');
        }

        private void buttonC_Click(object sender, EventArgs e)
        {
            guess('c');
        }

        private void buttonD_Click(object sender, EventArgs e)
        {
            guess('d');
        }

        private void buttonE_Click(object sender, EventArgs e)
        {
            guess('e');
        }

        private void buttonF_Click(object sender, EventArgs e)
        {
            guess('f');
        }

        private void buttonG_Click(object sender, EventArgs e)
        {
            guess('g');
        }

        private void buttonH_Click(object sender, EventArgs e)
        {
            guess('h');
        }

        private void buttonI_Click(object sender, EventArgs e)
        {
            guess('i');
        }

        private void buttonJ_Click(object sender, EventArgs e)
        {
            guess('j');
        }

        private void buttonK_Click(object sender, EventArgs e)
        {
            guess('k');
        }

        private void buttonL_Click(object sender, EventArgs e)
        {
            guess('l');
        }

        private void buttonM_Click(object sender, EventArgs e)
        {
            guess('m');
        }

        private void buttonN_Click(object sender, EventArgs e)
        {
            guess('n');
        }

        private void buttonO_Click(object sender, EventArgs e)
        {
            guess('o');
        }

        private void buttonP_Click(object sender, EventArgs e)
        {
            guess('p');
        }

        private void buttonQ_Click(object sender, EventArgs e)
        {
            guess('q');
        }

        private void buttonR_Click(object sender, EventArgs e)
        {
            guess('r');
        }

        private void buttonS_Click(object sender, EventArgs e)
        {
            guess('s');
        }

        private void buttonT_Click(object sender, EventArgs e)
        {
            guess('t');
        }

        private void buttonU_Click(object sender, EventArgs e)
        {
            guess('u');
        }

        private void buttonV_Click(object sender, EventArgs e)
        {
            guess('v');
        }

        private void buttonW_Click(object sender, EventArgs e)
        {
            guess('w');
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            guess('x');
        }

        private void buttonY_Click(object sender, EventArgs e)
        {
            guess('y');
        }

        private void buttonZ_Click(object sender, EventArgs e)
        {
            guess('z');
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (--countdown <= 0)
                if (timelabel.Text.Trim() == "0s" || timelabel.Text.Trim()[0] == '-')
                {
                    timer1.Stop();
                    timelabel.Text = "0s";
                    resultlabel.Visible = true;
                    resultlabel.Text="TIME OUT!";
                    panel1.Enabled = false;
                    startbutton.Visible = true;
                    startbutton.Text = "Restart";
                    pictureBox1.Image = Image.FromFile(@"Hangman-8.png");
                    englishlabel.Text = eng;
                    chineselabel.Visible = true;
                    unenbledtool();
                    wrongsound();
                    if (score > Convert.ToInt32(File.ReadAllText(@"score.txt")))
                    {
                        timer2.Start();
                    }
                }
            timelabel.Text = (countdown / 10).ToString() + "s";
        }

        
        private void renewbtm()//所有字母激活
        {
            foreach (Control ctl in panel1.Controls)
            {
                if (ctl is Button)
                {
                    Button btn = ctl as Button;
                    btn.Visible = true;
                }
            }
        }

        private void startbutton_Click(object sender, EventArgs e)
        {
            clicksound();
            panel1.Enabled = true;
            timer1.Start();
            renewbtm();
            panel1.Visible = true;
            startbutton.Hide();
            resultlabel.Visible = false;
            englishlabel.Visible = true;
            enbledtool();
            count = 1;
            if (flaglose != 0)
            {
                countdown += 150;
            }
            else
            {
                countdown = 310;
                score = 0;
            }
            flaglose = 0;//输flag
            flagwin = 0;//赢flag
            count = 1;
            pictureBox1.Image = Image.FromFile(@"Hangman-1.png");
            chineselabel.Visible = false;
            
            if (startbutton.Text == "Restart" || startbutton.Text == "Start")
            {
                System.Media.SoundPlayer sp = new SoundPlayer();//播放背景音乐
                sp.SoundLocation = @"bgm1.wav";
                sp.PlayLooping();
            }
            timer2.Stop();
            highestlabel.Visible = false;
            Form1_Load(sender, e);
        }

        private void enbledtool()//工具激活
        {
            hintbuttom.Enabled = true;
            chinesebuttom.Enabled = true;
            skipbutton.Enabled = true;
            //answerbuttom.Enabled = true;
        }
        private void unenbledtool()//工具灰显
        {
            hintbuttom.Enabled = false;
            chinesebuttom.Enabled = false;
            skipbutton.Enabled = false;
            //answerbuttom.Enabled = false;
        }



        private void hintbuttom_Click(object sender, EventArgs e)
        {
            clicksound();
            int p = 0;
            int i = 0;
            Random ran = new Random();//随机提示一个字母
            int n = ran.Next(0, eng.Length);
            char y = eng[n];
            while (p == 0)
            {
                for (i = 0; i < blk.Length; i++)
                {
                    if (y == carr[i])
                    {
                        break;
                    }
                }
                if (i == blk.Length)
                {
                    p = 1;
                }
                else
                {
                    n = ran.Next(0, eng.Length);
                    y = eng[n];
                }
            }
            guess(y);
            hintbuttom.Enabled = false;//提示只能用一次
        }

        private void chinesebuttom_Click(object sender, EventArgs e)
        {
            if (chineselabel.Visible == false)
            {
                chineselabel.Visible = true;
            }
            else
            {
                chineselabel.Visible = false;
            }
            clicksound();
        }

        private void skipbutton_Click(object sender, EventArgs e)
        {
            renewbtm();
            enbledtool();
            startbutton.Hide();
            count = 1;
            pictureBox1.Image = Image.FromFile(@"Hangman-1.png");
            clicksound();
            Form1_Load(sender, e);
        }

        private void answerbuttom_Click(object sender, EventArgs e)//显示答案，仅供测试使用
        {
            if (answerlabel.Visible == false)
            {
                answerlabel.Visible = true;
            }
            else
            {
                answerlabel.Visible = false;
            }
            clicksound();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (highestlabel.Visible == false)
            {
                highestlabel.Visible = true;
            }
            else
            {
                highestlabel.Visible = false;
            }
        }

        private void highscorelabel_DoubleClick(object sender, EventArgs e)
        {
            File.WriteAllText(@"score.txt", "0");
            highscorelabel.Text = File.ReadAllText(@"score.txt");
        }

    }
}
