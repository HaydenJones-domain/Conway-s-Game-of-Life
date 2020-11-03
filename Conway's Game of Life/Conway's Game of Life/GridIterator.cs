using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Conway_s_Game_of_Life
{
    class GridIterator
    {
        //fields/properties
        public static List<Region> LivingCells;

        //methods

        public static void AddTo(int x, int y)
        {
            Region region1 = new Region(new Rectangle(x,y,10,10));
            RegionData region1Data = region1.GetRegionData();
            byte[] data1;
            data1 = region1Data.Data;
            Region region2 = new Region();
            RegionData region2Data = region2.GetRegionData();

            region2Data.Data = data1;
            Region cell = new Region(region2Data);
            region1.Dispose();
            region2.Dispose();

            GridIterator.LivingCells.Add(cell);
        }

        //constructors
        public GridIterator()
        {
            LivingCells = new List<Region>();
        }
    }
}
