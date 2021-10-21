
namespace SDK_CSharp_test
{
    partial class captureButton
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.captureImageBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Label_Device = new System.Windows.Forms.Label();
            this.Textbox_Device = new System.Windows.Forms.TextBox();
            this.Combobox_Device = new System.Windows.Forms.ComboBox();
            this.Label_Username = new System.Windows.Forms.Label();
            this.Textbox_Username = new System.Windows.Forms.TextBox();
            this.Label_IP = new System.Windows.Forms.Label();
            this.Textbox_IP = new System.Windows.Forms.TextBox();
            this.Label_Pass = new System.Windows.Forms.Label();
            this.Textbox_Pass = new System.Windows.Forms.TextBox();
            this.Label_HTTP_Port = new System.Windows.Forms.Label();
            this.Textbox_HTTP_Port = new System.Windows.Forms.TextBox();
            this.Label_Channel = new System.Windows.Forms.Label();
            this.Textbox_Channel = new System.Windows.Forms.TextBox();
            this.Label_RTSP_Port = new System.Windows.Forms.Label();
            this.Textbox_RTSP_Port = new System.Windows.Forms.TextBox();
            this.Label_RTSP_URL = new System.Windows.Forms.Label();
            this.Textbox_RTSP_URL = new System.Windows.Forms.TextBox();
            this.Button_Connect = new System.Windows.Forms.Button();
            this.Button_Disconnect = new System.Windows.Forms.Button();
            this.Label_Playback = new System.Windows.Forms.Label();
            this.Button_Play = new System.Windows.Forms.Button();
            this.Button_Stop = new System.Windows.Forms.Button();
            this.Button_Close = new System.Windows.Forms.Button();
            this.Combobox_Channel = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // captureImageBox
            // 
            this.captureImageBox.Location = new System.Drawing.Point(0, 12);
            this.captureImageBox.Name = "captureImageBox";
            this.captureImageBox.Size = new System.Drawing.Size(637, 354);
            this.captureImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.captureImageBox.TabIndex = 0;
            this.captureImageBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(562, 381);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.btn_start_stop_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(463, 381);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "catch";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.btn_catch_Click);
            // 
            // Label_Device
            // 
            this.Label_Device.Location = new System.Drawing.Point(0, 0);
            this.Label_Device.Name = "Label_Device";
            this.Label_Device.Size = new System.Drawing.Size(100, 23);
            this.Label_Device.TabIndex = 4;
            this.Label_Device.Text = "Device";
            // 
            // Textbox_Device
            // 
            this.Textbox_Device.Location = new System.Drawing.Point(0, 0);
            this.Textbox_Device.Name = "Textbox_Device";
            this.Textbox_Device.Size = new System.Drawing.Size(100, 23);
            this.Textbox_Device.TabIndex = 5;

            //
            //combobox_Device
            //
            this.Combobox_Device.Location = Textbox_Device.Location;
            this.Combobox_Device.Name = "Combobox_Device";
            this.Combobox_Device.Size = Textbox_Device.Size;
            this.Combobox_Device.DropDownClosed += new System.EventHandler(this.Combobox_Device_Dropdownclosed);

            //
            //Combobox_Channel_Dropdownclosed
            //
            this.Combobox_Channel.Location = Textbox_Channel.Location;
            this.Combobox_Channel.Name = "Combobox_Channel";
            this.Combobox_Channel.Size = Textbox_Channel.Size;
            this.Combobox_Channel.DropDownClosed += new System.EventHandler(this.Combobox_Channel_Dropdownclosed);

            // 
            // Label_Username
            // 
            this.Label_Username.Location = new System.Drawing.Point(0, 0);
            this.Label_Username.Name = "Label_Username";
            this.Label_Username.Size = new System.Drawing.Size(100, 23);
            this.Label_Username.TabIndex = 6;
            this.Label_Username.Text = "Username";
            // 
            // Textbox_Username
            // 
            this.Textbox_Username.Location = new System.Drawing.Point(0, 0);
            this.Textbox_Username.Name = "Textbox_Username";
            this.Textbox_Username.Size = new System.Drawing.Size(100, 23);
            this.Textbox_Username.TabIndex = 7;
            // 
            // Label_IP
            // 
            this.Label_IP.Location = new System.Drawing.Point(0, 0);
            this.Label_IP.Name = "Label_IP";
            this.Label_IP.Size = new System.Drawing.Size(100, 23);
            this.Label_IP.TabIndex = 3;
            this.Label_IP.Text = "IP address";
            // 
            // Textbox_IP
            // 
            this.Textbox_IP.Location = new System.Drawing.Point(0, 0);
            this.Textbox_IP.Name = "Textbox_IP";
            this.Textbox_IP.Size = new System.Drawing.Size(100, 23);
            this.Textbox_IP.TabIndex = 8;
            // 
            // Label_Pass
            // 
            this.Label_Pass.Location = new System.Drawing.Point(0, 0);
            this.Label_Pass.Name = "Label_Pass";
            this.Label_Pass.Size = new System.Drawing.Size(100, 23);
            this.Label_Pass.TabIndex = 9;
            this.Label_Pass.Text = "Password";
            // 
            // Textbox_Pass
            // 
            this.Textbox_Pass.Location = new System.Drawing.Point(0, 0);
            this.Textbox_Pass.Name = "Textbox_Pass";
            this.Textbox_Pass.Size = new System.Drawing.Size(100, 23);
            this.Textbox_Pass.TabIndex = 10;
            // 
            // Label_HTTP_Port
            // 
            this.Label_HTTP_Port.Location = new System.Drawing.Point(0, 0);
            this.Label_HTTP_Port.Name = "Label_HTTP_Port";
            this.Label_HTTP_Port.Size = new System.Drawing.Size(100, 23);
            this.Label_HTTP_Port.TabIndex = 11;
            this.Label_HTTP_Port.Text = "HTTP port";
            // 
            // Textbox_HTTP_Port
            // 
            this.Textbox_HTTP_Port.Location = new System.Drawing.Point(0, 0);
            this.Textbox_HTTP_Port.Name = "Textbox_HTTP_Port";
            this.Textbox_HTTP_Port.Size = new System.Drawing.Size(100, 23);
            this.Textbox_HTTP_Port.TabIndex = 12;
            // 
            // Label_Channel
            // 
            this.Label_Channel.Location = new System.Drawing.Point(0, 0);
            this.Label_Channel.Name = "Label_Channel";
            this.Label_Channel.Size = new System.Drawing.Size(100, 23);
            this.Label_Channel.TabIndex = 13;
            this.Label_Channel.Text = "Channel";
            // 
            // Textbox_Channel
            // 
            this.Textbox_Channel.Location = new System.Drawing.Point(0, 0);
            this.Textbox_Channel.Name = "Textbox_Channel";
            this.Textbox_Channel.Size = new System.Drawing.Size(100, 23);
            this.Textbox_Channel.TabIndex = 14;

            this.Combobox_Channel.Location = new System.Drawing.Point(0, 0);
            this.Combobox_Channel.Name = "Combobox_Channel";
            this.Combobox_Channel.Size = new System.Drawing.Size(100, 23);
            this.Combobox_Channel.TabIndex = 14;

            // 
            // Label_RTSP_Port
            // 
            this.Label_RTSP_Port.Location = new System.Drawing.Point(0, 0);
            this.Label_RTSP_Port.Name = "Label_RTSP_Port";
            this.Label_RTSP_Port.Size = new System.Drawing.Size(100, 23);
            this.Label_RTSP_Port.TabIndex = 15;
            this.Label_RTSP_Port.Text = "RTSP port";
            // 
            // Textbox_RTSP_Port
            // 
            this.Textbox_RTSP_Port.Location = new System.Drawing.Point(0, 0);
            this.Textbox_RTSP_Port.Name = "Textbox_RTSP_Port";
            this.Textbox_RTSP_Port.Size = new System.Drawing.Size(100, 23);
            this.Textbox_RTSP_Port.TabIndex = 16;
            // 
            // Label_RTSP_URL
            // 
            this.Label_RTSP_URL.Location = new System.Drawing.Point(0, 0);
            this.Label_RTSP_URL.Name = "Label_RTSP_URL";
            this.Label_RTSP_URL.Size = new System.Drawing.Size(100, 23);
            this.Label_RTSP_URL.TabIndex = 17;
            this.Label_RTSP_URL.Text = "RTSP URL";
            // 
            // Textbox_RTSP_URL
            // 
            this.Textbox_RTSP_URL.Location = new System.Drawing.Point(0, 0);
            this.Textbox_RTSP_URL.Name = "Textbox_RTSP_URL";
            this.Textbox_RTSP_URL.Size = new System.Drawing.Size(100, 23);
            this.Textbox_RTSP_URL.TabIndex = 18;
            // 
            // Button_Connect
            // 
            this.Button_Connect.Location = new System.Drawing.Point(0, 0);
            this.Button_Connect.Name = "Button_Connect";
            this.Button_Connect.Size = new System.Drawing.Size(75, 23);
            this.Button_Connect.TabIndex = 19;
            this.Button_Connect.Text = "Connect";
            this.Button_Connect.Click += new System.EventHandler(this.Button_Connect_Click);
            // 
            // Button_Disconnect
            // 
            this.Button_Disconnect.Location = new System.Drawing.Point(0, 0);
            this.Button_Disconnect.Name = "Button_Disconnect";
            this.Button_Disconnect.Size = new System.Drawing.Size(75, 23);
            this.Button_Disconnect.TabIndex = 20;
            this.Button_Disconnect.Text = "Disconnect";
            this.Button_Disconnect.Click += new System.EventHandler(this.Button_Disconnect_Click);
            // 
            // Label_Playback
            // 
            this.Label_Playback.Location = new System.Drawing.Point(0, 0);
            this.Label_Playback.Name = "Label_Playback";
            this.Label_Playback.Size = new System.Drawing.Size(100, 23);
            this.Label_Playback.TabIndex = 21;
            this.Label_Playback.Text = "Playback";
            // 
            // Button_Play
            // 
            this.Button_Play.Location = new System.Drawing.Point(0, 0);
            this.Button_Play.Name = "Button_Play";
            this.Button_Play.Size = new System.Drawing.Size(75, 23);
            this.Button_Play.TabIndex = 22;
            this.Button_Play.Text = "Play";
            this.Button_Play.Click += new System.EventHandler(this.Button_Play_Click);
            // 
            // Button_Stop
            // 
            this.Button_Stop.Location = new System.Drawing.Point(0, 0);
            this.Button_Stop.Name = "Button_Stop";
            this.Button_Stop.Size = new System.Drawing.Size(75, 23);
            this.Button_Stop.TabIndex = 23;
            this.Button_Stop.Text = "Stop";
            this.Button_Stop.Click += new System.EventHandler(this.Button_Stop_Click);
            // 
            // Button_Close
            // 
            this.Button_Close.Location = new System.Drawing.Point(0, 0);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Size = new System.Drawing.Size(75, 23);
            this.Button_Close.TabIndex = 24;
            this.Button_Close.Text = "Close";
            this.Button_Close.Click += new System.EventHandler(this.Button_Close_Click);
            // 
            // captureButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 490);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.captureImageBox);
            this.Controls.Add(this.Label_IP);
            this.Controls.Add(this.Label_Device);
            this.Controls.Add(this.Textbox_Device);
            this.Controls.Add(this.Label_Username);
            this.Controls.Add(this.Textbox_Username);
            this.Controls.Add(this.Textbox_IP);
            this.Controls.Add(this.Label_Pass);
            this.Controls.Add(this.Textbox_Pass);
            this.Controls.Add(this.Label_HTTP_Port);
            this.Controls.Add(this.Textbox_HTTP_Port);
            this.Controls.Add(this.Label_Channel);
            this.Controls.Add(this.Textbox_Channel);
            this.Controls.Add(this.Label_RTSP_Port);
            this.Controls.Add(this.Textbox_RTSP_Port);
            this.Controls.Add(this.Label_RTSP_URL);
            this.Controls.Add(this.Textbox_RTSP_URL);
            this.Controls.Add(this.Button_Connect);
            this.Controls.Add(this.Button_Disconnect);
            this.Controls.Add(this.Label_Playback);
            this.Controls.Add(this.Button_Play);
            this.Controls.Add(this.Button_Stop);
            this.Controls.Add(this.Button_Close);
            this.Controls.Add(this.Combobox_Device);
            this.Controls.Add(this.Combobox_Channel);
            this.Name = "captureButton";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.captureImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        //圖片
        private System.Windows.Forms.PictureBox captureImageBox;


        //第一
        private System.Windows.Forms.Label Label_Device;
        private System.Windows.Forms.TextBox Textbox_Device;
        private System.Windows.Forms.ComboBox Combobox_Device;


        private System.Windows.Forms.Label Label_Username;
        private System.Windows.Forms.TextBox Textbox_Username;


        //第二
        private System.Windows.Forms.Label Label_IP;
        private System.Windows.Forms.TextBox Textbox_IP;

        private System.Windows.Forms.Label Label_Pass;
        private System.Windows.Forms.TextBox Textbox_Pass;


        //第三
        private System.Windows.Forms.Label Label_HTTP_Port;
        private System.Windows.Forms.TextBox Textbox_HTTP_Port;

        private System.Windows.Forms.Label Label_Channel;
        private System.Windows.Forms.TextBox Textbox_Channel;
        private System.Windows.Forms.ComboBox Combobox_Channel;


        //第四
        private System.Windows.Forms.Label Label_RTSP_Port;
        private System.Windows.Forms.TextBox Textbox_RTSP_Port;


        //第五
        private System.Windows.Forms.Label Label_RTSP_URL;
        private System.Windows.Forms.TextBox Textbox_RTSP_URL;


        //第六
        private System.Windows.Forms.Button Button_Connect;
        private System.Windows.Forms.Button Button_Disconnect;


        //第七
        private System.Windows.Forms.Label Label_Playback;


        //第八
        private System.Windows.Forms.Button Button_Play;
        private System.Windows.Forms.Button Button_Stop;
        

        //第九        
        private System.Windows.Forms.Button Button_Close;


        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;

        

        



    }
}

