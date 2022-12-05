
using System;
using System.Drawing;

namespace oi2
{
	public class niblack: filter
	{

		protected override Color calcNewPix(Bitmap sourceIm, int x, int y)
		{
			int m_size = 3;                
            int T = 0;
			double k = 0.2;                        
			double sig = 0;
                for (int i = 0; i < sourceIm.Width; i++)
                {
                    for (int j = 0; j < sourceIm.Height; j++)
                    {
                        int radX = m_size / 2;
                        int radY = m_size / 2;

                        double new_color = 0;
                        for (int a = -radY; a <= radY; a++)
                        {
                            for (int b = -radX; b <= radX; b++)
                            {
                                int idX = Slice(i + b, 0, sourceIm.Width - 1);
                                int idY = Slice(j + a, 0, sourceIm.Height - 1);
                                Color neibCol = sourceIm.GetPixel(idX, idY);
                                new_color += neibCol.G;                                
                            }
                        }
                        new_color = new_color / (m_size * m_size);

                        for (int a = -radY; a <= radY; a++)
                        {
                            for (int b = -radX; b <= radX; b++)
                            {
                                int idX = Slice(i + b, 0, sourceIm.Width - 1);
                                int idY = Slice(j + a, 0, sourceIm.Height - 1);
                                Color neibCol = sourceIm.GetPixel(idX, idY);
                                sig += (neibCol.G - new_color) * (neibCol.G - new_color);
                            }
                        }
                        sig = Math.Sqrt(sig / Math.Pow(m_size, 2));

                        
                        T = (int)(new_color + k * sig);
                    }
                }
                
			Color sourceCol2 = sourceIm.GetPixel(x,y);
			Color resultCol = Color.FromArgb((int)(binSlice((int)(0.299*sourceCol2.R + 0.587*sourceCol2.G + 0.114*sourceCol2.B),T)),
			                                 (int)(binSlice((int)(0.299*sourceCol2.R + 0.587*sourceCol2.G + 0.114*sourceCol2.B),T)),
			                                 (int)(binSlice((int)(0.299*sourceCol2.R + 0.587*sourceCol2.G + 0.114*sourceCol2.B),T)));
			return resultCol;
                }
	}
}
