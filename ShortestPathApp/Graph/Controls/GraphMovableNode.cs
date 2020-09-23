/********************************************************************
	@created:	2020/09/19
	@filename: 	GraphMovableNode.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Graph.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShortestPathApp.Graph.Controls
{
    internal class NodeViewMoveEventArgs : EventArgs
    {
        /// <summary>
        /// Узел
        /// </summary>
        public NodeGraph NodeView
        {
            get;
            private set;
        }

        /// <summary>
        /// Позиция на которую переместился узел
        /// </summary>
        public Point MovedPosition
        {
            get;
            private set;
        }

        /// <summary>
        /// Завершить перемещение
        /// </summary>
        public bool Cancel
        {
            get;
            set;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="node">Узел</param>
        /// <param name="newPostion">Новая позиция</param>
        public NodeViewMoveEventArgs(NodeGraph node, Point newPostion)
        {
            NodeView = node;
            MovedPosition = newPostion;
        }
    }

    /// <summary>
    /// Делегат для обработчиков событий перемещения
    /// </summary>
    /// <param name="args"></param>
    internal delegate void NodeViewMoveEventHandler(NodeViewMoveEventArgs e);

    internal static class GraphicComputing
    {
        /// <summary>
        /// Быстрое вычисление рассстояния между двумя точками
        /// </summary>
        /// <param name="dx">Разность x2 - x1</param>
        /// <param name="dy">Разность y2 - y1</param>
        /// <returns></returns>
        public static int CalcDistance(int dx, int dy)
        {
            if (dx < 0)
            {
                dx = -dx;
            }
            if (dy < 0)
            {
                dy = -dy;
            }

            if (dx < dy)
            {
                return (123 * dy + 51 * dx) / 128;
            }
            else
            {
                return (123 * dx + 51 * dy) / 128;
            }
        }
    }

    internal partial class NodeGraph : PictureBox
    {
        /// <summary>
        /// Нажата ли сейчас кнопка мыши над узлом
        /// </summary>
        public bool m_bIsPressed
        {
            get;
            set;
        }

        /// <summary>
        /// Позиция захвата
        /// </summary>
        private Point m_pCapturePoint
        {
            get;
            set;
        }

        /// <summary>
        /// Событие движения.
        /// </summary>
        public event NodeViewMoveEventHandler OnMove;

        /// <summary>
        /// Инициализации логики перемещения
        /// </summary>
        private void InitializeMovableLogic()
        {
            MouseDown += NodeGraph_MouseDown;
            MouseMove += NodeGraph_MouseMove;
            MouseUp += NodeGraph_MouseUp;
        }

        /// <summary>
        /// Обработчик нажатия на узел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeGraph_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_bIsPressed = false;
            }
        }

        /// <summary>
        /// Обработчик перемещения мыши по узлу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (!m_bIsPressed)
            {
                return;
            }

            var newPosition = new Point(
                Location.X - (m_pCapturePoint.X - e.X),
                Location.Y - (m_pCapturePoint.Y - e.Y)
                );
            var moveArgs = new NodeViewMoveEventArgs(this, newPosition);

            OnMove?.Invoke(moveArgs);

            if (moveArgs.Cancel)
            {
                return;
            }

            Location = moveArgs.MovedPosition;
            Parent.Refresh();
        }

        /// <summary>
        /// Обработчик отпускание кнопки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                m_bIsPressed = true;
                m_pCapturePoint = e.Location;
            }
        }
    }

    internal partial class GraphPanel : PictureBox, IGraphControl, IGraphOperations
    {
        /// <summary>
        /// Инициализация логики перемещения для узла в графе
        /// </summary>
        /// <param name="node">Узла</param>
        private void InitializeMovableLogic(NodeGraph node)
        {
            node.OnMove += Node_OnMove;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="e"></param>
        private void Node_OnMove(NodeViewMoveEventArgs e)
        {
            var node = e.NodeView;
            int nDiameter = Configuration.ms_nGraphNodeRadius * 2 + 1;

            for (int i = 0; i < Nodes.Count; i++)
            {
                if (Nodes[i] == node)
                {
                    continue;
                }

                int distance = GraphicComputing.CalcDistance(
                    e.MovedPosition.X - Nodes[i].Location.X,
                    e.MovedPosition.Y - Nodes[i].Location.Y
                    );
                if (distance <= nDiameter)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}