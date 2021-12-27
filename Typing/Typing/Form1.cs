using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Typing
{
    public partial class Form1 : Form
    {
        //key value reference 
        // http://web.tnu.edu.tw/me/study/moodle/tutor/vb6/tutor/r03/index.htm

        //play wav https://blog.kkbruce.net/2019/03/csharpformusicplay.html#.YcWFE2hBxGM
        //wav download https://www.youtube.com/watch?v=l59FoIJXeOg 
        //wav download https://drive.google.com/drive/folders/1MC1vxAaPhOdjULhccmDZaM6nlemkTzzm?fbclid=IwAR0LKtuH0hHcBQ2hFM5RnkyD-yhf_E-6bRuY4tIIT3OuBK5HlZlMDVa_rdk
        //wav download 


        public Form1()
        {
            InitializeComponent();
            label2.Visible = false;

        }

        int User_input_key = 0;
        bool inputFlag = false;
        bool loopFlag1 = false;
        bool loopFlag2 = false;

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            User_input_key = e.KeyValue;
            inputFlag = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            loopFlag1 = true;
            var player = new SoundPlayer();

            while (loopFlag1)
            {
                Thread.Sleep(50);
                Application.DoEvents();

                string StrTemp = "";
                int Question_key = rnd.Next(65,90); //A~Z = 65 ~90
                label1.Text = ((char)Question_key).ToString();
                Application.DoEvents();

                //compare Question_key and User_input_key
                loopFlag2 = true;
                while (loopFlag2)
                {
                    Thread.Sleep(50);
                    Application.DoEvents();

                    if (inputFlag == true)
                    {
                        inputFlag = false;
                        //StrTemp = User_input_key.ToString() + string.Format(" ,{0:D}", GetKey);
                        StrTemp = ((char)User_input_key).ToString() + string.Format(" ,{0:D}", User_input_key);
                        richTextBox1.AppendText("\n" + StrTemp);

                        
                        if (Question_key == User_input_key)
                        {
                            loopFlag2 = false;
                            label2.Visible = false;
                            Application.DoEvents();

                            if (ckb_sound.Checked == true)
                            {
                                player.SoundLocation = "sound_ok.wav";
                                player.LoadAsync();
                                player.PlaySync();
                            }

                            Application.DoEvents();
                        }
                        else
                        {
                            label2.ForeColor = Color.Red;
                            label2.Visible = true;
                            Application.DoEvents();

                            if (ckb_sound.Checked == true)
                            {
                                player.SoundLocation = "sound_ng.wav";
                                player.LoadAsync();
                                player.PlaySync();
                            }
                            Application.DoEvents();
                        }

                    }

                }//while (loopFlag2)




                
            }//while (loopFlag1)
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loopFlag1 = false;
            loopFlag2 = false;
            richTextBox1.AppendText("\nEnd Game\n");
            Application.DoEvents();
        }
    }
}
