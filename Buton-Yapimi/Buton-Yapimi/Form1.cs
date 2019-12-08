using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InSimDotNet;
using InSimDotNet.Packets;
using InSimDotNet.Helpers;

namespace Buton_Yapimi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InSim insim = new InSim();

            // Initialize InSim
            insim.Initialize(new InSimSettings
            {
                Host = "127.0.0.1",
                Port = 29999,
                Admin = "123123",
                Flags = InSimFlags.ISF_MCI | InSimFlags.ISF_CON,
                Interval = 1000,
                IName = "EmirhanPala",
            });

            // Send message to LFS
            insim.Send("/msg Canlı button, InSim-EmirhanPala!");
            insim.Bind<IS_MCI>(ButtonGorunumu);
        }

        private void ButtonGorunumu(InSim insim, IS_MCI mci)
        {
            try
            {
                IS_NCN conn = new IS_NCN();
                string[] buttons1 = {
                                        string.Format(textBox1.Text), 
                                        string.Format(textBox2.Text), 
                                        string.Format(textBox3.Text), 
                                        string.Format(textBox4.Text), 
                                    };

                for (byte i = 0, id = 1, top = (byte)numericUpDown1.Value; i < buttons1.Length; i++, id++, top += (byte)numericUpDown5.Value)
                {
                    insim.Send(new IS_BTN
                    {
                        ReqI = 255,
                        UCID = conn.UCID,
                        ClickID = id,
                        BStyle = ButtonStyles.ISB_DARK | ButtonStyles.ISB_LEFT,
                        T = top,
                        L = (byte)numericUpDown2.Value,
                        W = (byte)numericUpDown3.Value,
                        H = (byte)numericUpDown4.Value,
                        Text = buttons1[i],
                    });
                }


                string[] buttons2 = {
                                        string.Format(textBox5.Text), 
                                        string.Format(textBox6.Text), 
                                        string.Format(textBox7.Text), 
                                        string.Format(textBox8.Text), 
                                    };

                for (byte i = 0, id = 5, top = (byte)numericUpDown6.Value; i < buttons2.Length; i++, id++, top += (byte)numericUpDown10.Value)
                {
                    insim.Send(new IS_BTN
                    {
                        ReqI = 255,
                        UCID = conn.UCID,
                        ClickID = id,
                        BStyle = ButtonStyles.ISB_DARK | ButtonStyles.ISB_LEFT,
                        T = top,
                        L = (byte)numericUpDown7.Value,
                        W = (byte)numericUpDown8.Value,
                        H = (byte)numericUpDown9.Value,
                        Text = buttons2[i],
                    });
                }
            }
            catch { }
        }
    }
}
