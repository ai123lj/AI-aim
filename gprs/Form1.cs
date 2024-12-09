using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Media;
using Microsoft.VisualBasic.Devices;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

using Compunet.YoloV8;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Compunet.YoloV8.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace gprs
{
    public partial class Form1 : Form
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////鼠标驱动
        [System.Runtime.InteropServices.DllImport("user32.dll")] //导入user32.dll函数库
        public static extern bool GetCursorPos(out System.Drawing.Point lpPoint);//获取鼠标坐标

        [DllImport("user32.dll")]
        private static extern void mouse_event(uint dwFlags, int dx, int dy, int dwData, UIntPtr extraInfo);

        const uint MOUSEEVENTF_MOVE = 0x0001;            //移动鼠标 
        const uint MOUSEEVENTF_LEFTDOWN = 0x02;          //模拟鼠标左键按下
        const uint MOUSEEVENTF_LEFTUP = 0x04;            //模拟鼠标左键抬起
        const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;       //模拟鼠标右键按下
        const uint MOUSEEVENTF_RIGHTUP = 0x0010;         //模拟鼠标右键抬起
        const uint MOUSEEVENTF_WHEEL = 0x0800;           //模拟鼠标滚轮事件
        const uint MOUSEEVENTF_ABSOLUTE = 0x8000;        //标示是否采用绝对坐标 

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////键盘驱动
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetKeyState(Keys key);

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////游戏操作相关变量
        System.Drawing.Color pixelColorJiaDian;
        System.Drawing.Color pixelColorJiaDian2;
        System.Drawing.Point mousePositionJiaDian;
        bool jiaDianMode = false;

        System.Drawing.Point HongMingMousePosition;
        bool HongMingMode = false;

        bool autofire = false;

        int fireMode = 1;
        int fireZhu = 1;
        int fireFu = 1;

        bool fireEn= false;
        bool fireEnLast = false;

        ////////////////////////////////////////////////////////
        int count;
        Stopwatch stopwatch = new Stopwatch();
        Stopwatch stopwatchJianGe = new Stopwatch();

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////yolo
        YoloV8Predictor predictor = YoloV8Predictor.Create("./yolov8n-pose.onnx");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 165;
            numericUpDown3.Value = 222;
            radioButton1.Checked = true;
            radioButton5.Checked = true;
            Task.Run(() =>
            {
                //var result = predictor.DetectAndSave("./bus.jpg");
                //var result = predictor.Detect("./bus.jpg");
                //predictor.PoseAndSave("./bus.jpg");
                while (true)
                {                 
                    
                    if (radioButton5.Checked)//98k
                    {
                        fireZhu = 1;
                        Yolo(radioButton1.Checked, new System.Drawing.Point(7, 30), new System.Drawing.Point(18, 30), new System.Drawing.Point(10, 185), 25, 300,0, 0,1);
                        AutojiaDian(radioButton2.Checked, new System.Drawing.Point(10, 29), new System.Drawing.Point(13, 29), new System.Drawing.Point(10, 185), 25, 880);
                        jiaDian(radioButton3.Checked, new System.Drawing.Point(10, 29), new System.Drawing.Point(13, 29), new System.Drawing.Point(10, 185), 25);                       
                    }
                    else if (radioButton6.Checked)//大炮
                    {
                        fireZhu = 2;
                        Yolo(radioButton1.Checked, new System.Drawing.Point(7, 30), new System.Drawing.Point(18, 30), new System.Drawing.Point(10, 185), 40, 1300, 0,0,1);
                        AutojiaDian(radioButton2.Checked, new System.Drawing.Point(9, 31), new System.Drawing.Point(13, 31), new System.Drawing.Point(10, 185), 40,1300);
                        jiaDian(radioButton3.Checked, new System.Drawing.Point(9, 31), new System.Drawing.Point(13, 31), new System.Drawing.Point(10, 185), 40);
                    }
                    else if (radioButton7.Checked)//m200
                    {
                        fireZhu = 3;
                    }
                    else if (radioButton8.Checked)//步枪
                    {
                        fireZhu = 4;
                        Yolo(radioButton1.Checked, new System.Drawing.Point(7, 30), new System.Drawing.Point(18, 30), new System.Drawing.Point(10, 185), 0, 100, 1,30,2);
                        //AutojiaDian(radioButton2.Checked, new System.Drawing.Point(10, 29), new System.Drawing.Point(13, 29), new System.Drawing.Point(10, 185), 25, 880);
                        //jiaDian(radioButton3.Checked, new System.Drawing.Point(10, 29), new System.Drawing.Point(13, 29), new System.Drawing.Point(10, 185), 25);
                    }
                    else if (radioButton12.Checked)//步枪
                    {
                        fireZhu = 6;
                        Yolo(radioButton1.Checked, new System.Drawing.Point(7, 30), new System.Drawing.Point(18, 30), new System.Drawing.Point(10, 185), 0, 100, 1, 30, 1);
                        //AutojiaDian(radioButton2.Checked, new System.Drawing.Point(10, 29), new System.Drawing.Point(13, 29), new System.Drawing.Point(10, 185), 25, 880);
                        //jiaDian(radioButton3.Checked, new System.Drawing.Point(10, 29), new System.Drawing.Point(13, 29), new System.Drawing.Point(10, 185), 25);
                    }
                    else if (radioButton11.Checked)//m700
                    {
                        fireZhu = 5;
                        Yolo(radioButton1.Checked, new System.Drawing.Point(7, 30), new System.Drawing.Point(18, 30), new System.Drawing.Point(10, 185), 25, 300, 0, 0,0);
                    }

                    if (radioButton9.Checked)//柯尔特
                    {
                        fireFu = 1;
                        Yolo(radioButton1.Checked, new System.Drawing.Point(7, 30), new System.Drawing.Point(18, 30), new System.Drawing.Point(10, 185), 0, 100,0,1000,0);
                    }

                    moveMouse(radioButton10.Checked);

                    //Autofire(radioButton1.Checked);

                    //hongMing(radioButton4.Checked);
                    Thread.Sleep(0);
                    //Delay(1);

                    count++;
                    //移动鼠标到屏幕坐标(100, 100)
                    //SetCursorPos(100, 100);
                }
            });

            Task.Run(() =>
            {               
                while (true)
                {
                    Thread.Sleep(1000);

                    Action action = () =>
                    {
                        textBox2.Text = "每秒检测次数:" + count;
                    };
                    Invoke(action);
                    count = 0;
                }
            });
            Task.Run(() =>
            {
                bool key = false, keyLast = false;
                bool key2 = false, keyLast2 = false;
                while (true)
                {
                    Thread.Sleep(5);

                    //获取键盘输入
                    if (GetKeyState(Keys.F5) < 0)
                    {
                        mousePositionJiaDian = Control.MousePosition;
                    }

                    if (GetKeyState(Keys.D1) < 0)
                    {
                        fireMode = 1;
                    }
                    else if (GetKeyState(Keys.D2) < 0)
                    {
                        fireMode = 2;
                    }
                    else if (GetKeyState(Keys.D3) < 0)
                    {
                        fireMode = 3;
                    }
                    else if (GetKeyState(Keys.D4) < 0)
                    {
                        fireMode = 4;
                    }                    

                    Action action = () =>
                    {
                        switch (fireMode)
                        {
                            case 1:
                                switch (fireZhu)
                                {
                                    case 1: radioButton5.Checked = true; break;
                                    case 2: radioButton6.Checked = true; break;
                                    case 3: radioButton7.Checked = true; break;
                                    case 4: radioButton8.Checked = true; break;
                                    case 5: radioButton11.Checked = true; break;
                                    case 6: radioButton12.Checked = true; break;
                                }
                                break;
                            case 2:
                                switch (fireFu)
                                {
                                    case 1: radioButton9.Checked = true; break;
                                }
                                break;
                            default:
                                radioButton5.Checked = false;
                                radioButton6.Checked = false;
                                radioButton7.Checked = false;
                                radioButton8.Checked = false;
                                radioButton9.Checked = false;
                                radioButton11.Checked = false;
                                break;
                        }
                    };
                    Invoke(action);



                    if ((Control.ModifierKeys & Keys.Control) > Keys.None)
                    {
                        key2 = true;
                    }
                    else
                    {
                        key2 = false;
                    }
                    if (key2 != keyLast2)
                    {
                        keyLast2 = key;
                        if (Control.IsKeyLocked(Keys.CapsLock))
                        {
                            //keybd_event((int)Keys.CapsLock, (byte)59, 0, 0);
                            // 模拟释放向上键
                            //keybd_event((int)Keys.CapsLock, (byte)59, 2, 0);
                        }
                    }

                    key = false;
                    //获取键盘输入
                    if (Control.IsKeyLocked(Keys.CapsLock))
                    {
                        key = true;
                    }

                    if (key != keyLast)
                    {
                        keyLast = key;
                        if (key)
                        {
                            OnAudio();
                        }
                        else 
                        {
                            OffAudio();
                        }
                    }
                }
            });
        }


        public void Autofire(bool en)
        {
            if (!en)
                return;
            //获取键盘输入
            if (GetKeyState(Keys.F5) < 0)
            {
                autofire = true;
            }
            if (GetKeyState(Keys.F6) < 0)
            {
                autofire = false;
            }
            System.Drawing.Point point1 = new System.Drawing.Point(18, 30);
            System.Drawing.Point point2 = new System.Drawing.Point(18, 30);
            System.Drawing.Point pointMirror = new System.Drawing.Point(18, 30);

            // 获取当前鼠标的屏幕坐标
            System.Drawing.Point mousePosition = Control.MousePosition;
            System.Drawing.Color Color1, Color2, ColorMirror;
            System.Drawing.Rectangle region2 = new System.Drawing.Rectangle(mousePosition.X - 10, mousePosition.Y - 20, 200, 200);
            using (Bitmap bitmap = new Bitmap(region2.Width, region2.Height, PixelFormat.Format32bppArgb))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(region2.X, region2.Y, 0, 0, region2.Size);
                    Color1 = bitmap.GetPixel(point1.X, point1.Y);
                    Color2 = bitmap.GetPixel(point2.X, point2.Y);
                    ColorMirror = bitmap.GetPixel(pointMirror.X, pointMirror.Y);
                    Pen pen = new Pen(System.Drawing.Color.Red, 1); // 点的大小设置为1像素
                    graphics.DrawLine(pen, point1.X, point1.Y, point1.X, point1.Y - 1); // 绘制一条宽度为1的线，因为点是1x1的
                    graphics.DrawLine(pen, point2.X, point2.Y, point2.X, point2.Y - 1); // 绘制一条宽度为1的线，因为点是1x1的
                    graphics.DrawLine(pen, pointMirror.X, pointMirror.Y, pointMirror.X, pointMirror.Y - 1); // 绘制一条宽度为1的线，因为点是1x1的
                    Action action = () =>
                    {
                        textBox1.Text = ColorMirror.ToString();
                        pictureBox1.Image = new Bitmap(bitmap);
                    };
                    Invoke(action);                    
                }
            }

            if (!autofire)
                return;

            // 模拟自动切枪
            keybd_event((int)Keys.E, 18, 0, 0); Delay(100);
            keybd_event((int)Keys.E, 18, 2, 0); Delay(1000);

            mouse_event(MOUSEEVENTF_MOVE, -200, 0, 0, UIntPtr.Zero); Delay(1000);

            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero); Delay(1000);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero); Delay(1000);

            mouse_event(MOUSEEVENTF_MOVE, 400, 200, 0, UIntPtr.Zero); Delay(1000);

            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero); Delay(1000);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero); Delay(1000);

            autofire = false;
            return;
        }

        public void moveMouse(bool en)
        {
            if (!en)
                return;

            //if (Control.MouseButtons == MouseButtons.Right)
            if (GetKeyState(Keys.F) < 0)
            {
                jiaDianMode = true;
            }
            if (!jiaDianMode)
                return;

            int x = 155; //(int)numericUpDown2.Value;
            int y = 155;// (int)numericUpDown3.Value;

            int x1 = (int)(x * (((int)numericUpDown2.Value) / 100.0f));
            int y1 = (int)(y * (((int)numericUpDown3.Value) / 100.0f));
            mouse_event(MOUSEEVENTF_MOVE, x1, -y1, 0, UIntPtr.Zero);

            Thread.Sleep(250);

            // 模拟鼠标点击
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
            Thread.Sleep(1800);

            mouse_event(MOUSEEVENTF_MOVE, -x1, y1, 0, UIntPtr.Zero);

            Thread.Sleep(250);

            //进入架点
            System.Drawing.Rectangle region2 = new System.Drawing.Rectangle(mousePositionJiaDian.X - 160, mousePositionJiaDian.Y - 160 + 11, 320, 320);
            using (Bitmap bitmap = new Bitmap(region2.Width, region2.Height, PixelFormat.Format32bppArgb))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(region2.X, region2.Y, 0, 0, region2.Size);

                    Pen pen = new Pen(System.Drawing.Color.Red, 1); // 点的大小设置为1像素
                    //
                    using (Brush brush = new SolidBrush(System.Drawing.Color.Black))
                    {
                        graphics.FillRectangle(brush, new System.Drawing.Rectangle(160 + x - 2, 160 - y - 2, 4, 4));
                    }

                    Action action = () =>
                    {
                        pictureBox1.Image = new Bitmap(bitmap);
                    };
                    Invoke(action);
                 
                    jiaDianMode = false;
                    return;
                }
            }
        }
     
        public void Yolo(bool en, System.Drawing.Point point1, System.Drawing.Point point2, System.Drawing.Point pointMirror, int delayOpenMirror, int delaySwitch, int fireMode,int delayRun,int location)
        {
            if (!en)
                return;

            // 获取准心坐标
            System.Drawing.Point mousePosition = new System.Drawing.Point(mousePositionJiaDian.X, mousePositionJiaDian.Y);
            System.Drawing.Rectangle region2 = new System.Drawing.Rectangle(mousePosition.X - 160, mousePosition.Y - 160 + 11, 320, 320);
            using (Bitmap bitmap = new Bitmap(region2.Width, region2.Height, PixelFormat.Format32bppArgb))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(region2.X, region2.Y, 0, 0, region2.Size);
                    Pen pen = new Pen(System.Drawing.Color.Red); // 点的大小设置为1像素

                    System.Drawing.Color ColorMirror = bitmap.GetPixel(pointMirror.X+150, pointMirror.Y + 130);
                    graphics.DrawLine(pen, pointMirror.X + 150, pointMirror.Y + 130, pointMirror.X + 150, pointMirror.Y + 130 -1);

                    // 屏蔽枪械区域，防止干扰
                    using (Brush brush = new SolidBrush(System.Drawing.Color.Black))
                    {
                        graphics.FillRectangle(brush, new System.Drawing.Rectangle(160 + 100, 160 + 100, 100, 100));
                    }

                    if (fireMode != 0) 
                    {
                        fireEn = jiaDianMode;
                        if (fireEn != fireEnLast)
                        {
                            fireEnLast = fireEn;
                            if (fireEn)
                            {                                
                                //stopwatchJianGe.Restart();
                                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
                            }
                            else
                            {
                                stopwatchJianGe.Reset();
                                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
                            }
                                
                        }
                    }
                    

                    //触发识别的条件，狙的话为开镜后一直识别，非狙则点一下右键识别0.5秒
                    if (delayOpenMirror > 0)
                    {
                        if (!(ColorMirror.R < 4 && ColorMirror.G < 4 && ColorMirror.B < 4))
                            return;
                    }
                    else
                    {
                        if ((Control.MouseButtons == MouseButtons.Right) || (Control.MouseButtons == (MouseButtons.Right | MouseButtons.Left)))
                        {
                            stopwatch.Restart();
                            jiaDianMode = true;
                        }

                        if (stopwatch.ElapsedMilliseconds > delayRun)
                        {
                            stopwatch.Reset();
                            jiaDianMode = false;
                        }
                        //架点自动开枪
                        if (!jiaDianMode)
                            return; 
                    }

                    //开始识别
                    MemoryStream memoryStream = new MemoryStream();
                    bitmap.Save(memoryStream, ImageFormat.Bmp); // 可以改变ImageFormat来保存为其他格式，如Jpeg, Bmp等
                    memoryStream.Position = 0; // 重设流的位置，以确保从头开始读取
                    SixLabors.ImageSharp.Image img = SixLabors.ImageSharp.Image.Load(memoryStream);
                    var result = predictor.Pose(img);

                    //把识别结果画到图像上，并寻找离准心最近的敌人
                    int id = -1, min = 1000,id2=0;                   
                    for (int i = 0; i < result.Boxes.Length; i++)
                    {
                        var box = result.Boxes[i];
                        graphics.DrawRectangle(pen, box.Bounds.X, box.Bounds.Y, box.Bounds.Width, box.Bounds.Height);

                        Keypoint[] keypoint = box.Keypoints;
                        foreach (var item in keypoint)
                        {
                            graphics.DrawLine(pen, item.Point.X, item.Point.Y, item.Point.X, item.Point.Y - 1); // 绘制一条宽度为1的线，因为点是1x1的
                            //graphics.DrawString("" + id2++, new System.Drawing.Font("Arial", 16), new SolidBrush(System.Drawing.Color.Black), item.Point.X, item.Point.Y);
                        }

                        if (Math.Abs(keypoint[0].Point.X - 160) < min)
                        {
                            min = Math.Abs(keypoint[0].Point.X - 160);
                            id = i;
                        }
                    }

                    //显示图像
                    Action action = () =>
                    {
                        //textBox1.Text = result.Boxes[id].Bounds.X + "";//  result.ToString();
                        //textBox1.Text = ColorMirror.ToString();
                        pictureBox1.Image = new Bitmap(bitmap);
                    };
                    Invoke(action);

                    if (id < 0)
                        return;                   

                    //根据识别坐标，进行瞄准杀敌操作                   
                    var box1 = result.Boxes[id];
                    Keypoint[] keypoint1 = box1.Keypoints;
                    
                    int x = keypoint1[0].Point.X-160;
                    int y = (box1.Bounds.Y+keypoint1[1].Point.Y)/2-160;

                    switch (location)
                    {
                        case 0: break;
                        case 1: y = keypoint1[6].Point.Y - 160; break;
                        case 2: y = keypoint1[1].Point.Y - 160; break;
                    }                       

                    int x1 = (int)(x * (((int)numericUpDown2.Value) / 100.0f));
                    int y1 = (int)(y * (((int)numericUpDown3.Value) / 100.0f));

                    if (fireMode != 0)
                    {
                        if (stopwatchJianGe.IsRunning)
                        {
                            if (stopwatchJianGe.ElapsedMilliseconds > 80)
                            {
                                stopwatchJianGe.Restart();
                                mouse_event(MOUSEEVENTF_MOVE, x1, y1, 0, UIntPtr.Zero);
                            }
                        }
                        else
                        {
                            mouse_event(MOUSEEVENTF_MOVE, x1, y1, 0, UIntPtr.Zero);
                        }                                                     
                    }
                    else
                    {
                        mouse_event(MOUSEEVENTF_MOVE, x1, y1, 0, UIntPtr.Zero);
                    }

                   

                    
                    if (fireMode == 0)//非连发模式
                    {
                        //开枪
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);

                        string time1 = "./img/" + DateTime.Now.Ticks / 10000 + " " + x1 + "," + y1 + ".bmp";
                        //记录操作后的图像
                        using (Bitmap bitmap2 = new Bitmap(region2.Width, region2.Height, PixelFormat.Format32bppArgb))
                        {
                            using (Graphics graphics2 = Graphics.FromImage(bitmap2))
                            {
                                graphics2.CopyFromScreen(region2.X, region2.Y, 0, 0, region2.Size);
                                string time2 = "./img/" + DateTime.Now.Ticks / 10000 + " ok.bmp";
                                bitmap2.Save(time2, ImageFormat.Bmp);
                            }
                        }
                        //记录未操作前的图像                               
                        bitmap.Save(time1, ImageFormat.Bmp);

                        //狙 自动切枪
                        if (delaySwitch > 200)
                        {
                            Delay(1);
                            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -1, UIntPtr.Zero);
                            Delay(80);
                            mouse_event(MOUSEEVENTF_WHEEL, 0, 0, 1, UIntPtr.Zero);
                            // 模拟延迟
                            Thread.Sleep(delaySwitch);
                        }
                        else//手枪
                        {
                            int time = new Random().Next(0, 30);
                            Thread.Sleep(delaySwitch + time);
                        }
                        jiaDianMode = false;
                        stopwatch.Reset();
                    }
                    else
                    {
                        if (!stopwatchJianGe.IsRunning)
                        {
                            stopwatchJianGe.Restart();
                        }
                    }                                                        
                    return;                  
                }
            }
        }

        public void AutojiaDian(bool en, System.Drawing.Point point1, System.Drawing.Point point2, System.Drawing.Point pointMirror, int delayMirror, int delaySwitch)
        {
            if (!en)
                return;

            //获取键盘输入
            if (GetKeyState(Keys.F) < 0)
            {
                //keybd_event((int)Keys.CapsLock, (byte)59, 0, 0);
                // 模拟释放向上键
                //keybd_event((int)Keys.CapsLock, (byte)59, 2, 0);
            }

            //获取键盘输入
            if (!Control.IsKeyLocked(Keys.CapsLock))
            {
                mousePositionJiaDian = Control.MousePosition;

                System.Drawing.Rectangle region = new System.Drawing.Rectangle(mousePositionJiaDian.X - 10, mousePositionJiaDian.Y - 20, 20, 40);
                using (Bitmap bitmap = new Bitmap(region.Width, region.Height, PixelFormat.Format32bppArgb))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(region.X, region.Y, 0, 0, region.Size);
                        pixelColorJiaDian = bitmap.GetPixel(point1.X, point1.Y);
                        pixelColorJiaDian2 = bitmap.GetPixel(point2.X, point2.Y);
                    }
                }
                return;
            }

            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);


            int time = new Random().Next(10, 30);
            Thread.Sleep((int)numericUpDown1.Value + time);
            return;

            //进入架点
            System.Drawing.Color Color1, Color2, ColorMirror;
            System.Drawing.Rectangle region2 = new System.Drawing.Rectangle(mousePositionJiaDian.X - 10, mousePositionJiaDian.Y - 20, 250, 200);
            using (Bitmap bitmap = new Bitmap(region2.Width, region2.Height, PixelFormat.Format32bppArgb))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(region2.X, region2.Y, 0, 0, region2.Size);
                    Color1 = bitmap.GetPixel(point1.X, point1.Y);
                    Color2 = bitmap.GetPixel(point2.X, point2.Y);
                    ColorMirror = bitmap.GetPixel(pointMirror.X, pointMirror.Y);
                    Pen pen = new Pen(System.Drawing.Color.Red, 1); // 点的大小设置为1像素
                    graphics.DrawLine(pen, point1.X, point1.Y, point1.X, point1.Y-1); // 绘制一条宽度为1的线，因为点是1x1的
                    graphics.DrawLine(pen, point2.X, point2.Y, point2.X, point2.Y-1); // 绘制一条宽度为1的线，因为点是1x1的
                    graphics.DrawLine(pen, pointMirror.X, pointMirror.Y, pointMirror.X, pointMirror.Y - 1); // 绘制一条宽度为1的线，因为点是1x1的
                    Action action = () =>
                    {
                        textBox1.Text = ColorMirror.ToString();
                        pictureBox1.Image = new Bitmap(bitmap);
                    };
                    Invoke(action);                 
                }
            }
            if ((Math.Abs(pixelColorJiaDian.R - Color1.R) > 30) || (Math.Abs(pixelColorJiaDian.G - Color1.G) > 30) || (Math.Abs(pixelColorJiaDian.B - Color1.B) > 30) || (Math.Abs(pixelColorJiaDian2.R - Color2.R) > 30) || (Math.Abs(pixelColorJiaDian2.G - Color2.G) > 30) || (Math.Abs(pixelColorJiaDian2.B - Color2.B) > 30))
            {
                // 模拟人的反应延迟,
                Delay((int)numericUpDown1.Value);
                if (ColorMirror.R < 3 && ColorMirror.G < 3 && ColorMirror.B < 3)//是否开镜
                {
                    // 模拟鼠标点击
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
                }
                else
                {
                    // 模拟鼠标点击
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, UIntPtr.Zero);
                    mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, UIntPtr.Zero);
                    Delay(delayMirror);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
                }
                Delay(1);
                mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -1, UIntPtr.Zero);
                Delay(80);
                mouse_event(MOUSEEVENTF_WHEEL, 0, 0, 1, UIntPtr.Zero);

                // 模拟延迟
                Delay(delaySwitch);

                // 再次进入架点模式，记录像素点
                System.Drawing.Rectangle region = new System.Drawing.Rectangle(mousePositionJiaDian.X - 10, mousePositionJiaDian.Y - 20, 20, 40);
                using (Bitmap bitmap = new Bitmap(region.Width, region.Height, PixelFormat.Format32bppArgb))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(region.X, region.Y, 0, 0, region.Size);
                        pixelColorJiaDian = bitmap.GetPixel(point1.X, point1.Y);
                        pixelColorJiaDian2 = bitmap.GetPixel(point2.X, point2.Y);
                    }
                }
            }
        }
        public void jiaDian(bool en, System.Drawing.Point point1, System.Drawing.Point point2, System.Drawing.Point pointMirror,int delayMirror)
        {
            if (!en)
                return;

            //获取键盘输入
            if (GetKeyState(Keys.F) < 0)
            {               
                mousePositionJiaDian = Control.MousePosition;

                System.Drawing.Rectangle region = new System.Drawing.Rectangle(mousePositionJiaDian.X - 10, mousePositionJiaDian.Y - 20, 20, 40);
                using (Bitmap bitmap = new Bitmap(region.Width, region.Height, PixelFormat.Format32bppArgb))
                {
                    using (Graphics graphics = Graphics.FromImage(bitmap))
                    {
                        graphics.CopyFromScreen(region.X, region.Y, 0, 0, region.Size);
                        pixelColorJiaDian = bitmap.GetPixel(point1.X, point1.Y);
                        pixelColorJiaDian2 = bitmap.GetPixel(point2.X, point2.Y);
                    }
                }
                jiaDianMode = true;
                OnAudio();                
            }

            //架点自动开枪
            if (!jiaDianMode)
                return;


            // 获取当前鼠标的屏幕坐标
            System.Drawing.Point mousePosition = Control.MousePosition;
            //如果鼠标大幅度移动，取消架点
            if ((Math.Abs(mousePosition.X - mousePositionJiaDian.X) > 1) || (Math.Abs(mousePosition.Y - mousePositionJiaDian.Y) > 1))
            {
                jiaDianMode = false;
                OffAudio();
                return;
            }

            //进入架点
            System.Drawing.Color Color1, Color2, ColorMirror;
            System.Drawing.Rectangle region2 = new System.Drawing.Rectangle(mousePositionJiaDian.X - 10, mousePositionJiaDian.Y - 20, 25, 200);
            using (Bitmap bitmap = new Bitmap(region2.Width, region2.Height, PixelFormat.Format32bppArgb))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.CopyFromScreen(region2.X, region2.Y, 0, 0, region2.Size);
                    Color1 = bitmap.GetPixel(point1.X, point1.Y);
                    Color2 = bitmap.GetPixel(point2.X, point2.Y);
                    ColorMirror = bitmap.GetPixel(pointMirror.X, pointMirror.Y);
                    Pen pen = new Pen(System.Drawing.Color.Red, 1); // 点的大小设置为1像素
                    graphics.DrawLine(pen, point1.X, point1.Y, point1.X, point1.Y - 1); // 绘制一条宽度为1的线，因为点是1x1的
                    graphics.DrawLine(pen, point2.X, point2.Y, point2.X, point2.Y - 1); // 绘制一条宽度为1的线，因为点是1x1的
                    graphics.DrawLine(pen, pointMirror.X, pointMirror.Y, pointMirror.X, pointMirror.Y - 1); // 绘制一条宽度为1的线，因为点是1x1的
                    Action action = () =>
                    {
                        textBox1.Text = ColorMirror.ToString();
                        pictureBox1.Image = new Bitmap(bitmap);
                    };
                    Invoke(action);
                }
            }
            if ((Math.Abs(pixelColorJiaDian.R - Color1.R) > 30) || (Math.Abs(pixelColorJiaDian.G - Color1.G) > 30) || (Math.Abs(pixelColorJiaDian.B - Color1.B) > 30) || (Math.Abs(pixelColorJiaDian2.R - Color2.R) > 30) || (Math.Abs(pixelColorJiaDian2.G - Color2.G) > 30) || (Math.Abs(pixelColorJiaDian2.B - Color2.B) > 30))
            {
                // 模拟人的反应延迟,
                Delay((int)numericUpDown1.Value);
                if (ColorMirror.R < 3 && ColorMirror.G < 3 && ColorMirror.B < 3)//是否开镜
                {
                    // 模拟鼠标点击
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
                }
                else
                {
                    // 模拟鼠标点击
                    mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, UIntPtr.Zero);
                    mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, UIntPtr.Zero);
                    Delay(delayMirror);
                    mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
                    mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);
                }

                // 模拟自动切枪
                Delay(1);
                mouse_event(MOUSEEVENTF_WHEEL, 0, 0, -1, UIntPtr.Zero);
                jiaDianMode = false;
            }
        }

        public void hongMing(bool en)
        {
            if (!en)
                return;

            //获取键盘输入
            if (!Control.IsKeyLocked(Keys.CapsLock))
            {
                // 获取当前鼠标的屏幕坐标
                HongMingMousePosition = Control.MousePosition;
                return;
            }

            System.Drawing.Rectangle region = new System.Drawing.Rectangle(HongMingMousePosition.X - 30, HongMingMousePosition.Y + 50, 20, 20);
            Bitmap bmp = new Bitmap(region.Width, region.Height);

            Graphics g = Graphics.FromImage(bmp);
            g.CopyFromScreen(region.X, region.Y, 0, 0, region.Size);


            Action action = () =>
            {
                pictureBox2.Image = new Bitmap(bmp);
                //textBox1.Text = pixelColor.ToString();
            };
            Invoke(action);

            for (int y = 0; y < 20; y++)
            {

                for (int x = 0; x < 20; x++)
                {
                    if (bmp.GetPixel(x, y).R < 2)
                    {
                        //mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, UIntPtr.Zero);
                        //mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, UIntPtr.Zero);
                        //Delay(40);
                        //模拟人的反应延迟
                        Delay((int)numericUpDown1.Value);
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, UIntPtr.Zero);
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, UIntPtr.Zero);

                        // 模拟延迟
                        System.Threading.Thread.Sleep(100);
                        return;
                    }
                }
            }

        }

        private void OnAudio()
        {
            Stopwatch sw = new Stopwatch();
            SoundPlayer my_wave_file = new SoundPlayer(Properties.Resources.开);
            my_wave_file.Play();
        }
        private void OffAudio()
        {
            Stopwatch sw = new Stopwatch();
            SoundPlayer my_wave_file = new SoundPlayer(Properties.Resources.关);
            my_wave_file.Play();
        }

        public void Delay(int delayMilliseconds)
        {
            // 创建一个Stopwatch实例来测量时间
            Stopwatch stopwatch = new Stopwatch();

            // 开始Stopwatch
            stopwatch.Start();

            // 当Stopwatch记录的时间小于设定的延迟时间时，持续循环
            while (stopwatch.ElapsedMilliseconds < delayMilliseconds)
            {
                // 通过Thread.Sleep(0)释放当前线程的时间片，防止占用CPU
                Thread.Sleep(0);
            }
            // 停止Stopwatch
            stopwatch.Stop();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }


}