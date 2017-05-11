using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DirectX.Capture;
using DShowNET.Device;

namespace SqPxDesktop
{
    public partial class Form3 : Form
    {
        public DirectX.Capture.Filter Camera;
        public DirectX.Capture.Capture CaptureInfo;
        public DirectX.Capture.Filters CamContainer;
        Image captureImage;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            CamContainer = new DirectX.Capture.Filters();
            try
            {
                int no_of_cam = CamContainer.VideoInputDevices.Count;

                for (int i = 0; i < no_of_cam; i++)
                {
                    try
                    {
                        // get the video input device 
                        Camera = CamContainer.VideoInputDevices[i];
                       
                        // initialize the Capture using the video input device
                        CaptureInfo = new DirectX.Capture.Capture(Camera, null);

                        // set the input video preview window 
                        CaptureInfo.PreviewWindow = this.pictureBox1;

                        // Capturing complete event handler
                        CaptureInfo.FrameCaptureComplete += RefreshImage;
                       
                        // Capture the frame from input device 
                        CaptureInfo.CaptureFrame();

                        // if device found and initialize properly then exit without   
                        // checking rest of input device 
                        break;
                    }
                    catch (Exception ex) { }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }


        }
        public void RefreshImage(PictureBox frame)
        {
            captureImage = frame.Image;
          
            this.pictureBox2.Image = captureImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CaptureInfo.CaptureFrame();
            tabControl1.SelectTab(tabPage2);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            tabControl1.SelectTab(tabPage1);
        }

        private void label1_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }
    }
    }

