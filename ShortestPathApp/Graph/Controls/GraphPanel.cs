/********************************************************************
	@created:	2020/09/18
	@filename: 	GraphPanel.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Graph.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ShortestPathApp.Graph.Controls
{
    internal partial class GraphPanel : PictureBox, IGraphControl, IGraphOperations
    {
        /// <summary>
        /// Матрица графа
        /// </summary>
        private List<List<int>> m_lVertices;

        /// <summary>
        /// Кратчайший путь
        /// </summary>
        private List<Tuple<bool, int>> m_lMinPath;

        public GraphPanel()
        {
            m_bIsCoordsInit = false;
            Nodes = new List<NodeGraph>();
            m_lMinPath = new List<Tuple<bool, int>>();
        }

        /// <summary>
        /// Матрица
        /// </summary>
        public List<List<int>> Vertices
        {
            get
            {
                return m_lVertices;
            }
            set
            {
                m_lVertices = value;
                if (m_lVertices != null)
                {
                    Initialize(m_lVertices.Count);
                }
            }
        }


        public void SetMinPath(List<int> path)
        {
            if (path == null)
            {
                return;
            }

            if (Nodes.Count != Vertices.Count)
            {
                InvalidateNodes();
            }

            InvalidateMinPath();

            for (int i = 0; i < path.Count; i++)
            {
                m_lMinPath[path[i]] = Tuple.Create(true, i + 1);

                Nodes[path[i]].IsIncludedInPath = true;
            }

            Invalidate();
        }

        /// <summary>
        /// Изображения узлов
        /// </summary>
        private List<NodeGraph> Nodes
        {
            get;
            set;
        }

        /// <summary>
        /// Инциализированны ли координаты
        /// </summary>
        private bool m_bIsCoordsInit
        {
            get;
            set;
        }

        /// <summary>
        /// Создать новый узел
        /// </summary>
        private void CreateNode()
        {
            NodeGraph node = new NodeGraph();
            node.Parent = this;
            node.Visible = true;
            node.nNodeNumber = Nodes.Count + 1;

            InitializeMovableLogic(node);

            Nodes.Add(node);
        }

        /// <summary>
        /// Инициализировать представления узлов в количестве
        /// </summary>
        /// <param name="nVertexCount">Количество узлов</param>
        private void Initialize(int nVertexCount)
        {
            lock (Nodes)
            {
                for (int i = 0; i < nVertexCount; i++)
                {
                    CreateNode();
                }
            }
        }

        /// <summary>
        /// Отчистить узлы
        /// </summary>
        private void DisposeNodes()
        {
            lock (Nodes)
            {
                for (int i = 0; i < Nodes.Count; i++)
                {
                    Nodes[i].Hide();
                }
                Nodes.Clear();
            }
        }

        private void InvalidateMinPath()
        {
            m_lMinPath.Clear();
            for (int i = 0; i < m_lVertices.Count; i++)
            {
                Nodes[i].IsIncludedInPath = false;
                m_lMinPath.Add(Tuple.Create(false, 0));
            }
        }

        /// <summary>
        /// Обновить номера узлов
        /// </summary>
        /// <param name="nBegin">С какого узла начать восстановление</param>
        private void RefreshNumbers(int nBegin = 0)
        {
            for (int i = nBegin; i < Nodes.Count; i++)
            {
                Nodes[i].nNodeNumber = i + 1;
                Nodes[i].InvalidateCache();
            }
        }

        /// <summary>
        /// Посчитать координаты
        /// </summary>
        private void CalcCoords()
        {
            if (Vertices.Count < 1)
            {
                return;
            }

            int nCount = Vertices.Count;
            int nRadius = Configuration.ms_nGraphRaduis;
            int nNodeRadius = Configuration.ms_nGraphNodeRadius;
            int nNodeDiameter = nNodeRadius * 2;
            int nBorderRadius = Configuration.ms_nGraphRaduis - Configuration.ms_nGraphNodeRadius;

            double dAngleOffset = 2 * Math.PI / nCount;
            double dCurrentAngle = 0.0;

            for (int i = 0; i < nCount; i++)
            {
                double x = nRadius * Math.Cos(dCurrentAngle);
                double y = nRadius * Math.Sin(dCurrentAngle);

                dCurrentAngle += dAngleOffset;

                int locX = Width / 2 - (int)(x);
                int locY = Height / 2 - nNodeDiameter - (int)(y);
                Point point = new Point(locX - nNodeRadius, locY - nNodeRadius);

                Nodes[i].Location = point;
            }

            m_bIsCoordsInit = true;
        }

        private void InvalidateCoords()
        {
            m_bIsCoordsInit = false;
        }

        private void InvalidateNodes()
        {
            DisposeNodes();
            InvalidateCoords();

            Initialize(Vertices.Count);
        }

        /// <summary>
        /// Переопределение метода рисования при инвалидации
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);

            if (Vertices == null)
            {
                return;
            }

            if (Vertices.Count != Nodes.Count)
            {
                InvalidateNodes();
            }

            if (!m_bIsCoordsInit)
            {
                CalcCoords();
            }

            int nNodeRadius = Configuration.ms_nGraphNodeRadius;
            int nCount = Vertices.Count;
            Graphics g = e.Graphics;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;

            for (int i = 0; i < nCount; i++)
            {
                for (int j = 0; j < nCount; j++)
                {
                    if (i != j && Vertices[i][j] != 0)
                    {
                        Point nBeginVertex = new Point(
                            Nodes[i].Location.X + nNodeRadius,
                            Nodes[i].Location.Y + nNodeRadius
                            );
                        Point nEndVertex = new Point(
                            Nodes[j].Location.X + nNodeRadius,
                            Nodes[j].Location.Y + nNodeRadius
                            );

                        int xDiff = nBeginVertex.X - nEndVertex.X;
                        int yDiff = nBeginVertex.Y - nEndVertex.Y;
                        double nDistance = Math.Sqrt(xDiff * xDiff + yDiff * yDiff);

                        double angle = Math.Atan((double)yDiff / xDiff);
                        int xCenter = nBeginVertex.X;
                        int yCenter = nBeginVertex.Y;

                        if (xDiff >= 0 && yDiff >= 0 ||
                            xDiff >= 0 && yDiff <= 0)
                        {
                            angle += Math.PI;
                        }

                        nEndVertex.X = (int)((nDistance - nNodeRadius) * Math.Cos(angle)) + xCenter;
                        nEndVertex.Y = (int)((nDistance - nNodeRadius) * Math.Sin(angle)) + yCenter;


                        Pen linePen = GraphPanelTools.GraphArrowPen;
                        if (m_lMinPath != null && m_lMinPath.Count == Vertices.Count &&
                           m_lMinPath[i].Item2 + 1 == m_lMinPath[j].Item2 &&
                           m_lMinPath[i].Item1 && m_lMinPath[j].Item1)
                        {
                            linePen = GraphPanelTools.GraphPathArrowPen;
                        }

                        g.DrawLine(
                            linePen,
                            nBeginVertex,
                            nEndVertex
                            );

                        Point nMiddle = new Point(
                            (nBeginVertex.X + nEndVertex.X) / 2,
                            (nBeginVertex.Y + nEndVertex.Y) / 2
                            );

                        if (Vertices[j][i] == Vertices[i][j] && j < i ||
                           Vertices[j][i] != Vertices[i][j])
                        {
                            g.DrawString(
                            Vertices[i][j].ToString(),
                            GraphPanelTools.GraphFont,
                            Brushes.Black,
                            nMiddle
                            );
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Добавить вершину
        /// </summary>
        public void AddVertex()
        {
            CreateNode();
            InvalidateCoords();
            InvalidateMinPath();
            Invalidate();
        }

        /// <summary>
        /// Удалить вершину
        /// </summary>
        /// <param name="nvertex">Номер вершины</param>
        public void RemoveVertex(int nvertex)
        {
            Nodes[nvertex].Dispose();
            Nodes.RemoveAt(nvertex);

            RefreshNumbers(nvertex);
            InvalidateCoords();
            InvalidateMinPath();
            Invalidate();
        }

        /// <summary>
        /// Установить вес
        /// </summary>
        /// <param name="nvertexFirst">Начальная вершина</param>
        /// <param name="nvertexSecond">Конечная вершина</param>
        /// <param name="nWeight">Вес</param>
        public void SetEdge(int nvertexFirst, int nvertexSecond, int nWeight)
        {
            InvalidateMinPath();
            Invalidate();
        }

        /// <summary>
        /// Инструменты рисования графа
        /// </summary>
        internal static class GraphPanelTools
        {
            public static Pen GraphArrowPen = new Pen(Color.Gray, 1);

            public static Pen GraphPathArrowPen = new Pen(Color.Red, 3);

            public static Font GraphFont = new Font(FontFamily.GenericSansSerif, 13f, FontStyle.Bold);

            private static AdjustableArrowCap ArrowCap = new AdjustableArrowCap(5, 5, true);

            static GraphPanelTools()
            {
                GraphArrowPen.CustomEndCap = ArrowCap;
                GraphPathArrowPen.CustomEndCap = ArrowCap;
            }
        }
    }
}