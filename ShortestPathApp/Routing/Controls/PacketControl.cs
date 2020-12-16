/********************************************************************
	@created:	2020/12/08
	@filename: 	NodeGraph.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Routing.Interfaces;
using ShortestPathApp.Utils;
using System.Drawing;
using System.Windows.Forms;

namespace ShortestPathApp.Graph.Controls
{
    public partial class PacketControl : PictureBox, IPacketControl, ICachedControl
    {
        /// <summary>
        /// Номер пакета
        /// </summary>
        public int nPacketNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Эпоха пакета
        /// </summary>
        public int nPacketTerm
        {
            get;
            set;
        }

        public PacketControl(int nPacketNumber, Point beginPoint)
        {                        
            BackColor = Color.Transparent;
            Size = new Size(Configuration.ms_nPacketRadius * 2 + 3, Configuration.ms_nPacketRadius * 2 + 3);

            Location = beginPoint;

            this.nPacketNumber = nPacketNumber;
            nPacketTerm = 0;
            Cache = null;

            BringToFront();
        }

        /// <summary>
        /// Кэш представления
        /// </summary>
        public Bitmap Cache
        {
            get;
            set;
        }

        /// <summary>
        /// Инвалидировать кэш изображение
        /// </summary>
        public void InvalidateCache()
        {
            Cache = null;
        }

        /// <summary>
        /// Закеширован ли контрол
        /// </summary>
        /// <returns></returns>
        public bool IsCached()
        {
            return Cache != null;
        }

        /// <summary>
        /// Создать кэш
        /// </summary>
        public void MakeCache()
        {
            int nDiameter = Configuration.ms_nPacketRadius * 2;
            Pen pen = new Pen(Color.Black, 2);
            Font font = SystemFonts.DefaultFont;
            string sNodeNumber = nPacketNumber.ToString();
            Size numSize = GraphicsUtils.GetStringSize(sNodeNumber, font);
            Brush textColor = Brushes.Black;

            Cache = new Bitmap(Size.Width, Size.Height);
            Cache.MakeTransparent();

            using (var g = Graphics.FromImage(Cache))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.FillEllipse(
                    Brushes.White,
                    new RectangleF(
                        new Point(1, 1),
                        new Size(nDiameter, nDiameter)
                        )
                    );

                g.DrawEllipse(
                    pen,
                    new RectangleF(
                        new Point(1, 1),
                        new Size(nDiameter, nDiameter)
                        )
                    );

                g.DrawString(
                    sNodeNumber,
                    font,
                    textColor,
                    new PointF(
                        1 + Width / 2 - numSize.Width / 2,
                        1 + Height / 2 - numSize.Height / 2
                        )
                    );
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (IsCached())
            {
                pe.Graphics.DrawImage(Cache, 0, 0);
                return;
            }

            MakeCache();

            pe.Graphics.DrawImage(Cache, 0, 0);
        }

        public void Send(Point pFrom, Point pTo)
        {

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            Graphics g = e.Graphics;

            if (Parent != null)
            {
                int index = Parent.Controls.GetChildIndex(this);
                for (int i = Parent.Controls.Count - 1; i > index; i--)
                {
                    Control c = Parent.Controls[i];

                    if (c.Bounds.IntersectsWith(Bounds) && c.Visible)
                    {
                        Bitmap bmp = new Bitmap(c.Width, c.Height, g);
                        c.DrawToBitmap(bmp, c.ClientRectangle);
                        g.TranslateTransform(c.Left - Left, c.Top - Top);
                        g.DrawImageUnscaled(bmp, Point.Empty);
                        g.TranslateTransform(Left - c.Left, Top - c.Top);
                        bmp.Dispose();
                    }
                }
            }
        }
    }
}