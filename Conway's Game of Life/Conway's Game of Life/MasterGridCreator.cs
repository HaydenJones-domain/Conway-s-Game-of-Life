using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Conway_s_Game_of_Life
{
    class LivingCoordinate
    {
        public int X;
        public int Y;
        public bool Mortality;
        public LivingCoordinate(int x, int y, bool m)
        {
            this.Mortality = m;
            this.Y = y;
            this.X = x;
        }
    }
    class MasterGridCreator
    {
        public static Dictionary<int, LivingCoordinate> MasterGrid = new Dictionary<int, LivingCoordinate>();
        //methods
        public static void Iterate()    //flaw in logic: it's rewriting grid as I search it, needs copycat grid, or use griditerator somehow
        {
            int[] arr1 = new int[] { -51, -50, -49, -1, 1, 49, 50, 51 };//works for a 50x50 grid, would need additional logic for different dimensions
            List<int> keyarr = new List<int>(); 
            GridIterator.LivingCells.Clear();

            foreach (int i in MasterGridCreator.MasterGrid.Keys)
            {
                int count = 0;
                foreach (int x in arr1)                 //for each foreign cell in proximity to current selected
                {
                    try
                    {
                        if (MasterGridCreator.MasterGrid[(i + x)].Mortality == true)
                            count++;
                    }
                    catch (KeyNotFoundException) { }
                }
                /*if (count == 3 && MasterGridCreator.MasterGrid[i].Mortality == false)
                        MasterGridCreator.MasterGrid[i].Mortality = !MasterGridCreator.MasterGrid[i].Mortality;
                else if ((count <= 1 || count >= 4) && MasterGridCreator.MasterGrid[i].Mortality == true) 
                {
                    MasterGridCreator.MasterGrid[i].Mortality = !MasterGridCreator.MasterGrid[i].Mortality;
                }*/     //changing this to be only living cells are recorded and alters masterGrid after the fact
                if (count == 3 && MasterGridCreator.MasterGrid[i].Mortality == false)
                    //GridIterator.AddTo(MasterGridCreator.MasterGrid[i].X, MasterGridCreator.MasterGrid[i].Y);
                    keyarr.Add(i);
                else if ((count == 2 || count == 3) && MasterGridCreator.MasterGrid[i].Mortality == true)
                    //GridIterator.AddTo(MasterGridCreator.MasterGrid[i].X, MasterGridCreator.MasterGrid[i].Y);
                    keyarr.Add(i);
            }
            foreach (int i in MasterGridCreator.MasterGrid.Keys)
            {
                if(MasterGridCreator.MasterGrid[i].Mortality == false && keyarr.Contains(i) == true)
                    MasterGridCreator.MasterGrid[i].Mortality = !MasterGridCreator.MasterGrid[i].Mortality;
                else if (MasterGridCreator.MasterGrid[i].Mortality == true && keyarr.Contains(i) == false)
                    MasterGridCreator.MasterGrid[i].Mortality = !MasterGridCreator.MasterGrid[i].Mortality;
            }
        }
        //constructor
        public MasterGridCreator()
        {
            int i = 0;
            for (int y = 11; y <= 550; y += 11)
            {
                for (int x = 11; x <= 550; x += 11, i++)
                {
                    LivingCoordinate lC = new LivingCoordinate(x,y,false);
                    MasterGrid.Add(i, lC);
                }
            }
        }
    }
}
