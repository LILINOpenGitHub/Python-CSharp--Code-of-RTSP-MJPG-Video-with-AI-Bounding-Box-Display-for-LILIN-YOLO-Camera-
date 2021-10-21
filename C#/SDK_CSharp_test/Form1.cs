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
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using System.Text.RegularExpressions;
using System.Net.Sockets;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using Newtonsoft.Json;
using System.Globalization;










namespace SDK_CSharp_test
{
    public partial class captureButton : Form
    {
        
        private VideoCapture _capture = null;
        private bool _captureInProgress;
        public void form_init()
        {
            Size = new System.Drawing.Size(715, 930);
            const int x_gap = 8;
            const int y_gap = 10;
            const int label_width = 90;
            const int label_height = 30;
            const int textbox_width = 200;
            const int textbox_height = 30;
            const int label_textbox_gap = 80;
            
            captureImageBox.Location = new Point(x_gap, y_gap);
            captureImageBox.Size = new Size(700 - 2 * x_gap, Convert.ToInt32((800 - 2 * x_gap) * 15/22));
            //22:15


            Label_Device.Location = new Point(captureImageBox.Location.X, captureImageBox.Location.Y + captureImageBox.Height + y_gap);
            Label_Device.Size = new Size(label_width, label_height);
            Label_Device.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);

            Textbox_Device.Location = new Point(Label_Device.Location.X + Label_Device.Width, Label_Device.Location.Y-2);
            Textbox_Device.Size = new Size(textbox_width, textbox_height);
            Textbox_Device.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);
            Textbox_Device.Visible = false;

            Combobox_Device.Location = Textbox_Device.Location;
            Combobox_Device.Size = Textbox_Device.Size;
            Combobox_Device.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);
            Combobox_Device.Items.Add("IP Camera");
            Combobox_Device.Items.Add("NVR/DVR");
            Combobox_Device.Text = Combobox_Device.Items[0].ToString();
            Combobox_Device.DropDownStyle = ComboBoxStyle.DropDownList;




            Label_Username.Location = new Point(Textbox_Device.Location.X + Textbox_Device.Width + label_textbox_gap, Label_Device.Location.Y);
            Label_Username.Size = new Size(label_width, label_height);
            Label_Username.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);
            

            Textbox_Username.Location = new Point(Label_Username.Location.X + Label_Username.Width, Textbox_Device.Location.Y);
            Textbox_Username.Size = new Size(textbox_width, textbox_height);
            Textbox_Username.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);
            

            //2

            Label_IP.Location = new Point(Label_Device.Location.X, Label_Device.Location.Y + Label_Device.Height + y_gap);
            Label_IP.Size = new Size(label_width, label_height);
            Label_IP.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);

            Textbox_IP.Location = new Point(Label_IP.Location.X + Label_IP.Width, Label_IP.Location.Y - 2);
            Textbox_IP.Size = new Size(textbox_width, textbox_height);
            Textbox_IP.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);

            Label_Pass.Location = new Point(Label_Username.Location.X, Label_IP.Location.Y);
            Label_Pass.Size = new Size(label_width, label_height);
            Label_Pass.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);

            Textbox_Pass.Location = new Point(Textbox_Username.Location.X, Textbox_IP.Location.Y);
            Textbox_Pass.Size = new Size(textbox_width, textbox_height);
            Textbox_Pass.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);


            //3


            Label_HTTP_Port.Location = new Point(Label_Device.Location.X, Label_IP.Location.Y + Label_IP.Height + y_gap);
            Label_HTTP_Port.Size = new Size(label_width, label_height);
            Label_HTTP_Port.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);

            Textbox_HTTP_Port.Location = new Point(Textbox_Device.Location.X, Textbox_IP.Location.Y + Textbox_IP.Height + y_gap);
            Textbox_HTTP_Port.Size = new Size(textbox_width, textbox_height);
            Textbox_HTTP_Port.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);

            Label_Channel.Location = new Point(Label_Pass.Location.X , Label_HTTP_Port.Location.Y);
            Label_Channel.Size = new Size(label_width, label_height);
            Label_Channel.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);

            Textbox_Channel.Location = new Point(Textbox_Pass.Location.X, Textbox_HTTP_Port.Location.Y);
            Textbox_Channel.Size = new Size(textbox_width, textbox_height);
            Textbox_Channel.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);

            Combobox_Channel.Location = Textbox_Channel.Location;
            Combobox_Channel.Size = Textbox_Channel.Size;
            Combobox_Channel.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);
            for (int i = 0; i < 33; i++)
            {
                Combobox_Channel.Items.Add("Channel=" + i.ToString());
            }
            
            Combobox_Channel.Text = Combobox_Channel.Items[0].ToString();
            Combobox_Channel.DropDownStyle = ComboBoxStyle.DropDownList;
            Combobox_Channel.Visible = false;

            //4

            Label_RTSP_Port.Location = new Point(Label_Device.Location.X, Label_HTTP_Port.Location.Y + Label_HTTP_Port.Height + y_gap);
            Label_RTSP_Port.Size = new Size(label_width, label_height);
            Label_RTSP_Port.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);

            Textbox_RTSP_Port.Location = new Point(Textbox_Device.Location.X, Label_RTSP_Port.Location.Y - 2);
            Textbox_RTSP_Port.Size = new Size(textbox_width, textbox_height);
            Textbox_RTSP_Port.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);
            //5
            Label_RTSP_URL.Location = new Point(Label_Device.Location.X, Label_RTSP_Port.Location.Y + Label_RTSP_Port.Height + y_gap);
            Label_RTSP_URL.Size = new Size(label_width, label_height);
            Label_RTSP_URL.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);
            


            Textbox_RTSP_URL.Location = new Point(Textbox_Device.Location.X, Label_RTSP_URL.Location.Y - 2);
            Textbox_RTSP_URL.Size = new Size(textbox_width*2 + label_width + label_textbox_gap, textbox_height);
            Textbox_RTSP_URL.Font = new Font("Microsoft JhengHei UI", 10, FontStyle.Regular);
            Textbox_RTSP_URL.ReadOnly = false;

            //6

            Button_Connect.Location = new Point(Label_Channel.Location.X, Textbox_RTSP_URL.Location.Y + Textbox_RTSP_URL.Height + y_gap);
            Button_Connect.Size = new Size((label_width + textbox_width)/2, label_height*5/6);
            Button_Connect.Font = new Font("Microsoft JhengHei UI", 10, FontStyle.Regular);

            Button_Disconnect.Location = new Point(Button_Connect.Location.X + Button_Connect.Width, Button_Connect.Location.Y);
            Button_Disconnect.Size = Button_Connect.Size;
            Button_Disconnect.Font = new Font("Microsoft JhengHei UI", 10, FontStyle.Regular);

            //7
            
            Label_Playback.Location = new Point(Label_Device.Location.X, Button_Connect.Location.Y + Button_Connect.Height + y_gap);
            Label_Playback.Size = new Size(label_width, label_height);
            Label_Playback.Font = new Font("Microsoft JhengHei UI", 10, FontStyle.Regular);

            //8
            
            Button_Play.Location = new Point(Label_Device.Location.X, Label_Playback.Location.Y + Label_Playback.Height + y_gap);
            Button_Play.Size = Button_Connect.Size;
            Button_Play.Font = new Font("Microsoft JhengHei UI", 10, FontStyle.Regular);
            Button_Play.Enabled = false;


            Button_Stop.Location = new Point(Button_Play.Location.X + Button_Play.Width, Button_Play.Location.Y);
            Button_Stop.Size = Button_Play.Size;
            Button_Stop.Font = new Font("Microsoft JhengHei UI", 10, FontStyle.Regular);
            Button_Stop.Enabled = false;

            //9

            Button_Close.Location = new Point(Button_Disconnect.Location.X + Button_Disconnect.Width / 2, Button_Play.Location.Y + Button_Play.Height);
            Button_Close.Size = new Size(Button_Connect.Width / 2, Button_Connect.Height);
            Button_Close.Font = new Font("Microsoft JhengHei UI", 12, FontStyle.Regular);

        }

        private void Button_Close_Click(object sender, EventArgs arg)
        {
            System.Environment.Exit(0);
        }
        private void Combobox_Channel_Dropdownclosed(object sender, EventArgs arg)
        {
            if (Combobox_Device.Text == "NVR/DVR")
            {
                Button_Play.Enabled = true;
                Button_Stop.Enabled = true;
                Textbox_Username.Text = "admin";
                Textbox_IP.Text = "192.168.0.111";
                Textbox_Pass.Text = "Pass1234";
                Textbox_Channel.Text = "stream3";
                Textbox_HTTP_Port.Text = "80";
                Textbox_RTSP_Port.Text = "554";
                Textbox_Channel.Visible = false;
                Combobox_Channel.Visible = true;

                DateTime localDate = DateTime.Now;
                String[] cultureNames = { "ru-RU" };


                var culture = new CultureInfo(cultureNames[0]);
                //MessageBox.Show(localDate.ToString(culture));

                string date = localDate.ToString(culture).Split(' ')[0];
                string time = localDate.ToString(culture).Split(' ')[1];
                string[] now_date = date.Split('.');
                string[] now_time = time.Split(':');
                if (Convert.ToInt32(now_time[2].ToString()) == 0)
                {
                    now_time[2] = "59";
                    if (Convert.ToInt32(now_time[1].ToString()) == 0)
                    {
                        now_time[1] = "59";
                        if (Convert.ToInt32(now_time[0].ToString()) == 0)
                        {
                            now_time[0] = "23";
                            if (Convert.ToInt32(now_date[0].ToString()) == 1)
                            {
                                if (Convert.ToInt32(now_date[1].ToString()) == 3)
                                {
                                    now_date[0] = "28";                                    
                                }
                                if (Convert.ToInt32(now_date[1].ToString()) == 8)
                                {
                                    now_date[0] = "31";
                                }
                                if (Convert.ToInt32(now_date[1].ToString()) == 1)
                                {
                                    now_date[1] = "12";
                                    now_date[2] = (Convert.ToInt32(now_date[2]) - 1).ToString();
                                }

                            }
                        }
                    }
                }


                //MessageBox.Show(date.ToString());






                Textbox_RTSP_URL.Text = "rtsp://" + Textbox_Username.Text + ":" + Textbox_Pass.Text + "@" + Textbox_IP.Text + ":" + Textbox_RTSP_Port.Text + "/rtspstream?" + Combobox_Channel.Text + "&stream=0&playback=" + now_date[2] + "/" + now_date[1] + "/" + now_date[0] + "/" + now_time[0] + "/" + (Convert.ToInt32(now_time[1]) - 1).ToString() + "/00";
            }

        }
            private void Combobox_Device_Dropdownclosed(object sender, EventArgs arg)
        {
            if (Combobox_Device.Text == "NVR/DVR")
            {
                Button_Play.Enabled = true;
                Button_Stop.Enabled = true;
                Textbox_Username.Text = "admin";
                Textbox_IP.Text = "192.168.0.111";
                Textbox_Pass.Text = "Pass1234";
                Textbox_Channel.Text = "stream3";
                Textbox_HTTP_Port.Text = "80";
                Textbox_RTSP_Port.Text = "554";
                Textbox_Channel.Visible = false;
                Combobox_Channel.Visible = true;

                DateTime localDate = DateTime.Now;
                String[] cultureNames = {  "ru-RU" };

                
                    var culture = new CultureInfo(cultureNames[0]);
                    //MessageBox.Show(localDate.ToString(culture));
                
                string date = localDate.ToString(culture).Split(' ')[0];
                string time = localDate.ToString(culture).Split(' ')[1];
                string[] now_date = date.Split('.');
                string[] now_time = time.Split(':');


                //MessageBox.Show(date.ToString());
                



                

                Textbox_RTSP_URL.Text = "rtsp://" + Textbox_Username.Text + ":" + Textbox_Pass.Text  + "@"+ Textbox_IP.Text + ":" + Textbox_RTSP_Port.Text + "/rtspstream?"+ Combobox_Channel.Text + "&stream=0&playback=" + now_date[2] + "/" + now_date[1] + "/" + now_date[0] + "/" + now_time[0] + "/" + (Convert.ToInt32(now_time[1])-3).ToString() + "/00";
            }
            else
            {
                Button_Play.Enabled = false;
                Button_Stop.Enabled = false;
                Textbox_Username.Text = "admin";
                Textbox_IP.Text = "192.168.1.200";
                Textbox_Pass.Text = "Pass1234";
                Textbox_Channel.Text = "stream3";
                Textbox_RTSP_Port.Text = "554";
                Textbox_HTTP_Port.Text = "80";
                Textbox_Channel.Visible = true;
                Combobox_Channel.Visible = false;
                Textbox_RTSP_URL.Text = "rtsp://" + Textbox_Username.Text + ":" + Textbox_Pass.Text + "@" + Textbox_IP.Text + ":" + Textbox_RTSP_Port.Text + "/" + Textbox_Channel.Text;

            }
        }
        public captureButton()
        {
            InitializeComponent();
            form_init();

        }
        
        
        public Thread thread_boundingbox;
        JObject Public_Json_data = null;
        private void ProcessFrame(object sender, EventArgs arg)
        {
            
            Mat frame = new Mat();
            _capture.Retrieve(frame, 0);
            if (Public_Json_data != null)
            {
                if(Public_Json_data["AiEngine"].Count() > 0)
                {
                    for (int i = 0; i < Public_Json_data["AiEngine"].Count(); i++)
                    {
                        int pic_w = Convert.ToInt32(Public_Json_data["AiEngine"][i]["res_width"]);
                        int pic_h = Convert.ToInt32(Public_Json_data["AiEngine"][i]["res_height"]);
                        int pos_x = (Convert.ToInt32(Public_Json_data["AiEngine"][i]["x"]))*352/pic_w;
                        int pos_y = (Convert.ToInt32(Public_Json_data["AiEngine"][i]["y"]))*240/pic_h;
                        int b_w = (Convert.ToInt32(Public_Json_data["AiEngine"][i]["w"]))*352/pic_w;
                        int b_h = (Convert.ToInt32(Public_Json_data["AiEngine"][i]["h"]))*240/pic_h;
                        string label_name = Public_Json_data["AiEngine"][i]["label_name"].ToString();
                        string label_confidence = Public_Json_data["AiEngine"][i]["confidence"].ToString();
                        string puttext = label_name + "--confidence : " + label_confidence;
                        if (pos_y < 5)
                        {
                            pos_y = 5;
                        }

                        System.Diagnostics.Debug.Print("---------ori-----\njson_data test : \n" + Convert.ToInt32(Public_Json_data["AiEngine"][i]["x"]).ToString() + " , "+ Convert.ToInt32(Public_Json_data["AiEngine"][i]["y"]).ToString()  + "\n------ori--------\n");
                        System.Diagnostics.Debug.Print("---------des-----\njson_data test : \n" + pos_x.ToString() + " , " + pos_y.ToString() + "\n------des--------\n");
                        CvInvoke.Rectangle(frame, new Rectangle(new Point(pos_x, pos_y), new Size(b_w, b_h)), new MCvScalar(255, 0, 255, 255), 3);
                        CvInvoke.PutText(frame, puttext, new Point(pos_x, pos_y - 5), Emgu.CV.CvEnum.FontFace.HersheySimplex,0.5, new MCvScalar(255, 0, 255, 255), 1, Emgu.CV.CvEnum.LineType.AntiAlias);
                    }
                    
                }
                

            }

            
            Image<Bgr, Byte> imgeOrigenal = frame.ToImage<Bgr, Byte>();
            
            captureImageBox.Image = imgeOrigenal.ToBitmap<Bgr,Byte>();
            //{"AiEngine":[{"id":0,"channel_id":1,"camera_name":"","res_height":1080,"res_width":1920,"confidence":86,"engine_type":1,"label_name":"car","class_id":2,"obj_type":0,"obj_tracking_id":1,"obj_dwell_time":27,
            //"color_id":8,"color":"Black","linked_plate":"","x":918,"y":45,"w":912,"h":550,"parent_idx":-1,"detection_zone_id":0,"behavior_id":0}],"counter_count":[0,0,0,0,0,0,0,0],"something_vanish_in_zone1":"No",
            //"something_vanish_in_zone2":"No","something_vanish_in_zone3":"No","something_vanish_in_zone4":"No","Count":1}
            //
            
            



        }
        
        private void BoundingBox()
        {
            string _count = Convert.ToBase64String(Encoding.UTF8.GetBytes(Textbox_Username.Text + ":" + Textbox_Pass.Text));
            System.Diagnostics.Debug.Print("count : \n" + _count);

            string _header = "GET /getalarmmotion HTTP/1.1\r\nCookie: ipcam_lang=0\r\nHost: " + Textbox_IP.Text + ":" + Convert.ToString(8592) + "\r\nAuthorization: Basic " + Convert.ToString(_count) + "\r\n\r\n";
            System.Diagnostics.Debug.Print("header : \n" + _header);

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(new IPEndPoint(IPAddress.Parse(Textbox_IP.Text), 8592));
            clientSocket.Send(Encoding.UTF8.GetBytes(_header));

            while (true)
            {
                if (captureImageBox.Image != null)
                {
                    byte[] date = new byte[2048];
                    int count = clientSocket.Receive(date);
                    string msg = Encoding.UTF8.GetString(date, 0, count);
                    System.Diagnostics.Debug.Print("---------/////-----\nsocket : \n" + msg + "\n------/////-----\n");
                    string[] msg_split = msg.Split('\n');
                    string data_ = msg_split[5];



                    //Image<Bgr, byte> a = (Image<Bgr, byte>)captureImageBox.Image.Clone();
                    //CvInvoke.Rectangle(a, new Rectangle(new Point(100, 200), new Size(500, 500)), new MCvScalar(255, 0, 255, 255), 3);
                    //captureImageBox.Image = a.ToBitmap<Bgr,byte>();
                    JObject Json_data = JObject.Parse(data_);
                    Public_Json_data = Json_data;
                    //string test = JsonConvert.SerializeObject(Json_data);
                    
                    System.Diagnostics.Debug.Print("---------/////-----\njson_data test : \n" + data_ + "\n------/////-----\n");
                    
                    /*
                    if (Json_data["AiEngine"].Count() > 0)
                    {
                        for (int i = 0; i < Json_data["AiEngine"].Count(); i++)
                        {
                            System.Diagnostics.Debug.Print("---------label-----\njson_data test : \n" + Json_data["AiEngine"][i].ToString() + "\n------test-----\n");
                            int i_w = Convert.ToInt32(Json_data["AiEngine"][i][4]);
                            int i_h = Convert.ToInt32(Json_data["AiEngine"][i][3]);
                            Image<Bgr, byte> a = (Image<Bgr, byte>)captureImageBox.Image.Clone();
                            CvInvoke.Rectangle(a, new Rectangle(new Point(100, 200), new Size(500, 500)), new MCvScalar(255, 0, 255, 255), 3);
                            
                            
                        }
                    }
                    */



                }

            }
        }
        private void Button_Disconnect_Click(object sender, EventArgs e)
        {
            //Textbox_RTSP_URL.Text = "";
            Button_Connect.Enabled = true;
            if (_capture != null)
            {
                _capture.Pause();
                _capture.Stop();
                //thread_boundingbox.Suspend();
                


            }
        }
        private void Button_Connect_Click(object sender, EventArgs e)
        {
            bool blnTest = false;
            bool _Result = true;

            Regex regex = new Regex("^[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}$");
            blnTest = regex.IsMatch(Textbox_IP.Text);
            if (blnTest == true)
            {
                string[] strTemp = Textbox_IP.Text.Split(new char[] { '.' }); // textBox1.Text.Split(new char[] { ‘.’ });
                int nDotCount = strTemp.Length - 1; //字符串中.的數量，若.的數量小於3，則是非法的ip地址
                if (3 == nDotCount)//判斷字符串中.的數量
                {
                    for (int i = 0; i < strTemp.Length; i++)
                    {
                        if (Convert.ToInt32(strTemp[i]) > 255)
                        { //大於255則提示，不符合IP格式
                            MessageBox.Show("不符合IP格式");
                            _Result = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("不符合IP格式");
                    _Result = false;
                }
            }
            else
            {
                //輸入非數字則提示，不符合IP格式
                MessageBox.Show("不符合IP格式");
                _Result = false;
            }
            if (_Result)
            {
                if (Textbox_Username.Text.Length > 0 && Textbox_Pass.Text.Length > 0 && Textbox_RTSP_Port.Text.Length > 0 && Textbox_RTSP_Port.Text.Length > 0 && Textbox_Channel.Text.Length > 0)
                {
                    string rtsp_url = "rtsp://" + Textbox_Username.Text + ":" + Textbox_Pass.Text + "@" + Textbox_IP.Text + ":" + Textbox_RTSP_Port.Text + "/" + Textbox_Channel.Text;

                    Textbox_RTSP_URL.Text = rtsp_url;
                    CvInvoke.UseOpenCL = false;
                    try
                    {
                        //"http://帳號:密碼@你的IP/video.cgi?.mjpg"

                        
                        thread_boundingbox = new Thread(new ThreadStart(BoundingBox));
                        thread_boundingbox.Start();

                        _capture = new VideoCapture(rtsp_url);//
                        _capture.ImageGrabbed += ProcessFrame;
                        if (_capture != null)
                        {
                            //start the capture
                            _capture.Start();
                        }
                            
                    }
                    catch (NullReferenceException excpt)
                    {
                        MessageBox.Show(excpt.Message);
                        Button_Connect.Enabled = true;
                    }
                    Button_Connect.Enabled = false;
                    Button_Play.Enabled = true;

                }
                else
                {
                    MessageBox.Show("指定欄位不可為空");
                }
            }
            

        }
        private void Button_Play_Click(object sender, EventArgs e)
        {
            /*
            if (_capture != null)
            {
                //start the capture          
                _capture.Start();
                Button_Disconnect.Enabled = false;
                Button_Play.Enabled = false;
                Button_Stop.Enabled = true;
            }
            */
        }
        private void Button_Stop_Click(object sender, EventArgs e)
        {
            /*
            if (_capture != null)
            {

                _capture.Pause();
                Button_Play.Enabled = true;
                //Button_Connect.Enabled = true;
                Button_Disconnect.Enabled = true;

            }
            */
        }

        private void btn_start_stop_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {  //stop the capture
                    button1.Text = "Start Capture";
                    _capture.Pause();
                }
                else
                {
                    //start the capture
                    button1.Text = "Stop";
                    _capture.Start();
                }

                _captureInProgress = !_captureInProgress;
            }

        }

        private void btn_catch_Click(object sender, EventArgs e)
        {
            CvInvoke.UseOpenCL = false;
            try
            {
                //"http://帳號:密碼@你的IP/video.cgi?.mjpg"
                _capture = new VideoCapture("rtsp://admin:Pass1234@192.168.1.200:554/stream3");//
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }
    }
}
