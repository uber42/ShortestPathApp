/********************************************************************
	@created:	2020/09/16
	@filename: 	Program.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Forms.Main;
using System;
using System.Windows.Forms;

namespace ShortestPathApp
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());
        }
    }
}