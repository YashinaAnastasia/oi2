
using System;
using System.Drawing;

namespace oi2
{
	public class globalfilt:filter
	{

		protected override Color calcNewPix(Bitmap sourceIm, int x, int y)
		{
			Color sourceCol = sourceIm.GetPixel(x,y);
			
			Color resultCol = Color.FromArgb((int)(binSlice((int)(0.299*sourceCol.R + 0.587*sourceCol.G + 0.114*sourceCol.B),128)),
			                                 (int)(binSlice((int)(0.299*sourceCol.R + 0.587*sourceCol.G + 0.114*sourceCol.B),128)),
			                                 (int)(binSlice((int)(0.299*sourceCol.R + 0.587*sourceCol.G + 0.114*sourceCol.B),128)));
			return resultCol;
		}
	}
}


