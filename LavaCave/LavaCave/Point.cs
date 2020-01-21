using System;
namespace LavaCave
{
    public class Point
    {
        public int[] coord;
        public string cont;//content.
        public Point()
        {
            coord = new int[2] {0,0};
            cont = ".";
        }
        public Point(int[] coord, string cont)
        {
            this.coord = coord;
            this.cont = cont;
        }
        public Point(int[] coord)
        {
            this.coord = coord;
        }

        public override String ToString()
        {
            return cont;
        }

        public void SetCont(string cont)
        {
            this.cont = cont;
        }
    }
}
