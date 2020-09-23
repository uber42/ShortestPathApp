/********************************************************************
	@created:	2020/09/16
	@filename: 	ImagesProvider.cs
	@author:	Pavel Chursin
*********************************************************************/

using System.Drawing;
using System.Reflection;

namespace ShortestPathApp.Graph.Resources.Images
{
    internal static class ImagesProvider
    {
        private static Assembly asm = Assembly.GetExecutingAssembly();

        public static readonly Bitmap GraphVertex = new Bitmap(asm.GetManifestResourceStream(ImagesResource.GraphVertex));
    }
}