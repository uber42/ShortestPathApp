/********************************************************************
	@created:	2020/09/19
	@filename: 	NodeGraph.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Utils;
using System.Drawing;
using System.Windows.Forms;

namespace ShortestPathApp.Graph.Controls
{
    internal partial class NodeGraph : PictureBox
    {
        private bool m_bIsIncludedInPath;

        /// <summary>
        /// Номер узла
        /// </summary>
        public int nNodeNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Входит ли узел в кратчайший путь
        /// </summary>
        public bool IsIncludedInPath
        {
            get
            {
                return m_bIsIncludedInPath;
            }
            set
            {
                m_bIsIncludedInPath = value;
                InvalidateCache();
            }
        }

        public NodeGraph()
        {
            InitializeMovableLogic();

            BackColor = Color.Transparent;
            Size = new Size(Configuration.ms_nGraphNodeRadius * 2 + 3, Configuration.ms_nGraphNodeRadius * 2 + 3);

            m_Cache = null;
            m_bIsIncludedInPath = false;
        }

        /// <summary>
        /// Кэш представления
        /// </summary>
        private Bitmap m_Cache
        {
            get;
            set;
        }

        /// <summary>
        /// Инвалидировать кэш изображение
        /// </summary>
        public void InvalidateCache()
        {
            m_Cache = null;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            if (m_Cache != null)
            {
                pe.Graphics.DrawImage(m_Cache, 0, 0);
                return;
            }

            int nDiameter = Configuration.ms_nGraphNodeRadius * 2;
            Pen pen = new Pen(Color.Black, 2);
            Font font = SystemFonts.DefaultFont;
            string sNodeNumber = nNodeNumber.ToString();
            Size numSize = GraphicsUtils.GetStringSize(sNodeNumber, font);
            Brush textColor = Brushes.Black;

            if (IsIncludedInPath)
            {
                textColor = Brushes.Red;
                pen = new Pen(Color.Red, 2);
            }

            m_Cache = new Bitmap(Size.Width, Size.Height);
            m_Cache.MakeTransparent();

            using (var g = Graphics.FromImage(m_Cache))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.FillEllipse(
                    Brushes.Bisque,
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

            pe.Graphics.DrawImage(m_Cache, 0, 0);
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