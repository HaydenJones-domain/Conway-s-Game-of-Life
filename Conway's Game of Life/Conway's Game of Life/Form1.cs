using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Conway_s_Game_of_Life
{
    public partial class Form1 : Form
    {
        private void CreateGrid(PaintEventArgs e)
        {
            RectangleF gridSpace = new RectangleF(10, 10, 551, 551);        //can be made variable size in time
            e.Graphics.FillRectangle(Brushes.Black, gridSpace);
            GridIterator.LivingCells.Clear();
            foreach (int i in MasterGridCreator.MasterGrid.Keys)
            {
                if (MasterGridCreator.MasterGrid[i].Mortality == true)
                {
                    GridIterator.AddTo(MasterGridCreator.MasterGrid[i].X, MasterGridCreator.MasterGrid[i].Y);
                    //e.Graphics.FillRegion(Brushes.White, newIterator[i]);         //could use an indexer in griditerator
                }
            }
            foreach (Region f in GridIterator.LivingCells)
            {
                e.Graphics.FillRegion(Brushes.White, f);
            }
        }
        public Form1()
        {
            InitializeComponent();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("heller, werld");
            MasterGridCreator.Iterate();
            //MessageBox.Show("finished iterating");
            panel1.Invalidate();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            CreateGrid(e);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point point = panel1.PointToClient(Cursor.Position);        // will need modification if variable grid size is implemented
            int calculatedKey = 50 * ((point.Y + 11)/ 11 - 1) + ((point.X + 11) / 11 - 1);   //calculates key from pixel coordinate
            //MessageBox.Show($"Point: {point}\nKey: {calculatedKey}");
            MasterGridCreator.MasterGrid[calculatedKey].Mortality = !MasterGridCreator.MasterGrid[calculatedKey].Mortality;
            panel1.Invalidate();
        }
    }
}
