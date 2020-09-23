/********************************************************************
	@created:	2020/09/22
	@filename: 	GraphicsUtils.cs
	@author:	Pavel Chursin
*********************************************************************/

using System.Drawing;
using System.Windows.Forms;

namespace ShortestPathApp.Utils
{
    internal static class GraphicsUtils
    {
        public static Size GetStringSize(string sText, Font font)
        {
            Size size = TextRenderer.MeasureText(sText, font);
            return size;
        }
    }
}