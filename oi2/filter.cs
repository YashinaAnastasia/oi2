
using System;
using System.Drawing;

namespace oi2
{
	public abstract class filter
	{
        protected abstract Color calcNewPix(Bitmap sourceIm, int x, int y);
        public Bitmap procIm(Bitmap sourceIm)
        {
            Bitmap resultIm = new Bitmap(sourceIm.Width, sourceIm.Height);
            for (int i = 0; i < sourceIm.Width; i++)
            {
                for (int j = 0; j < sourceIm.Height; j++) resultIm.SetPixel(i, j, calcNewPix(sourceIm, i, j));
            }
            return resultIm;
        }

        public int Slice(int val, int min, int max)
        {
            if (val < min) return min;
            if (val > max) return max;
            return val;
        }

        public int binSlice(int val, int level)
        {
            int resVal = 0;
            int maxVal = 255;
            if (val >= level) return maxVal;
            return resVal;
        }
    }
}
