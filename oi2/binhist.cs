
using System;
using System.Drawing;

namespace oi2
{
	public class binhist:filter
	{
        protected override Color calcNewPix(Bitmap sourceIm, int x, int y)
        {
            int[] gist = new int[256];
            for (int i = 0; i < 256; i++)
            {
                gist[i] = 0;
            }
            for (int i = 0; i < sourceIm.Width; i++)
            {
                for (int j = 0; j < sourceIm.Height; j++)
                {
                    gist[sourceIm.GetPixel(i, j).R]++;
                }
            }
            int sum = 0;
            int sumV = 0;
            Color sourceCol = sourceIm.GetPixel(x, y);
            for (int i = (int)(0 + 256 * 0.05f); i < (int)(256 - 256 * 0.05f); i++)
            {
                sum += i;
                sumV += i * gist[i];
            }

            int new_T = (int)(sumV / sum);
            Color resultCol = Color.FromArgb((int)(binSlice((int)(sourceCol.R), new_T)),
                                             (int)(binSlice((int)(sourceCol.R), new_T)),
                                             (int)(binSlice((int)(sourceCol.R), new_T)));
            return resultCol;
        }
    }
}


