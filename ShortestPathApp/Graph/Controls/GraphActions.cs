using ShortestPathApp.Graph.Interfaces;
using System.Windows.Forms;

namespace ShortestPathApp.Graph.Controls
{
    internal partial class NodeGraph : PictureBox
    {
        private void InitializeNodeGraphActions()
        {
            // TODO : Subscribe on right mouse button click for context menu
        }
    }

    internal partial class GraphPanel : PictureBox, IGraphControl, IGraphOperations
    {
        internal enum EDrawEdges
        {
            /// <summary>
            /// Рисовать дуги
            /// </summary>
            Draw,

            /// <summary>
            /// Рисовать только пути
            /// </summary>
            DrawOnlyPath,

            /// <summary>
            /// Не рисовать
            /// </summary>
            None
        }

        private void InitializeActions()
        {
            MouseClick += GraphPanel_MouseClick;
        }

        private void GraphPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu = new ContextMenuStrip();
                menu.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
                this.ContextMenuStrip = menu;

                ToolStripMenuItem item = new ToolStripMenuItem("Реорганизовать");
                item.Click += (obj, args) =>
                {
                    m_bIsCoordsInit = false;
                    Invalidate();
                };
                menu.Items.Add(item);



                menu.Items.Add(new ToolStripSeparator());

                CheckBox cbDrawWeights = new CheckBox();
                cbDrawWeights.Text = "Рисовать веса";
                cbDrawWeights.Checked = m_fDrawWeights;
                cbDrawWeights.Click += (obj, args) =>
                {
                    var checkBox = obj as CheckBox;
                    if (checkBox.Checked)
                    {
                        m_fDrawWeights = true;
                    }
                    else
                    {
                        m_fDrawWeights = false;
                    }

                    Invalidate();
                    menu.Close();
                };
                ToolStripControlHost cbHost = new ToolStripControlHost(cbDrawWeights);
                menu.Items.Add(cbHost);

                menu.Items.Add(new ToolStripSeparator());

                CheckBox cbDrawEdges = new CheckBox();
                CheckBox cbNonDrawEdges = new CheckBox();
                CheckBox cbDrawOnlyPathEdges = new CheckBox();

                cbDrawEdges.Text = "Рисовать дуги";
                cbDrawEdges.Checked = m_eDrawEdges == EDrawEdges.Draw;
                cbDrawEdges.Click += (obj, args) =>
                {
                    cbNonDrawEdges.Checked = false;
                    cbDrawOnlyPathEdges.Checked = false;

                    m_eDrawEdges = EDrawEdges.Draw;

                    Invalidate();
                    menu.Close();
                };
                cbHost = new ToolStripControlHost(cbDrawEdges);
                menu.Items.Add(cbHost);

                
                cbDrawOnlyPathEdges.Text = "Рисовать пути";
                cbDrawOnlyPathEdges.Checked = m_eDrawEdges == EDrawEdges.DrawOnlyPath;
                cbDrawOnlyPathEdges.Click += (obj, args) =>
                {
                    cbDrawEdges.Checked = false;
                    cbNonDrawEdges.Checked = false;

                    m_eDrawEdges = EDrawEdges.DrawOnlyPath;

                    Invalidate();
                    menu.Close();
                };
                cbHost = new ToolStripControlHost(cbDrawOnlyPathEdges);
                menu.Items.Add(cbHost);

                
                cbNonDrawEdges.Text = "Не рисовать дуги";
                cbNonDrawEdges.Checked = m_eDrawEdges == EDrawEdges.None;
                cbNonDrawEdges.Click += (obj, args) =>
                {
                    cbDrawEdges.Checked = false;
                    cbDrawOnlyPathEdges.Checked = false;

                    m_eDrawEdges = EDrawEdges.None;

                    Invalidate();
                    menu.Close();
                };
                cbHost = new ToolStripControlHost(cbNonDrawEdges);
                menu.Items.Add(cbHost);
            }
        }
    }
}