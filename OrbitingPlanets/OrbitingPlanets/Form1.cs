using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrbitingPlanets
{
    public partial class Form1 : Form
    {
        public List<Center> CentersList;
        private Timer theTimer;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CentersList = new List<Center>();
            theTimer = new Timer();
            theTimer.Interval = 30; // 30 ms
            theTimer.Tick += timer_Tick; 
            theTimer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (CentersList.Count == 0) { return; }
            pictureBox.Refresh();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            int clickX = ((MouseEventArgs)e).X; // x coordinate of click
            int clickY = ((MouseEventArgs)e).Y; // y coordinate of click

            if (createPlanetButton.Checked)
            {
                CentersList.Reverse(); // if centers overlap, planet will be on the center created latest

                foreach (Center center in CentersList)
                {
                    if (center.IsInsideCenter(clickX, clickY))
                    {
                        center.AddPlanets(clickX, clickY); 
                        CentersList.Reverse();
                        break;
                    }
                }
            }
            else
            {
                CentersList.Reverse();
                CentersList.Add(new Center(clickX, clickY, int.Parse(pixelBox.Value.ToString())));
            }
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            foreach (Center center in CentersList) 
            {
                center.UpdatePlanetsPosition(); // based on what center(s) of gravity within range 

                // draw the grey circle (gravity)
                SolidBrush brush = new SolidBrush(Color.LightGray); 
                e.Graphics.FillEllipse(brush, center.RadiusUpperLeftX, center.RadiusUpperLeftY, (int)(center.Radius * 2), (int)(center.Radius * 2));

                // draw black circle (center)
                brush = new SolidBrush(Color.Black); 
                e.Graphics.FillEllipse(brush, center.X - 5, center.Y - 5, 10, 10);

                // draw each planet (red)
                foreach (Planet planet in center.Planets) 
                {
                    brush = new SolidBrush(Color.Red); 
                    e.Graphics.FillEllipse(brush, (float)(planet.X - 5.0), (float)(planet.Y - 5.0), 10, 10); // floats used for precision
                }

                brush.Dispose(); // have to dispose of the brush
            }
        }
    }
}
