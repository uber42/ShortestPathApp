namespace ShortestPathApp.Forms.Main
{
    partial class MainView
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GraphMatrixView = new ShortestPathApp.Graph.Views.GraphMatrixView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.graphLogicalView1 = new ShortestPathApp.Graph.Views.GraphLogicalView();
            this.GraphControlView = new ShortestPathApp.Graph.Views.GraphControlView();
            this.shortestPathView1 = new ShortestPathApp.Algorithms.Views.ShortestPathView();
            this.algorithmControlView1 = new ShortestPathApp.Algorithms.Views.AlgorithmControlView();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.routingControl1 = new ShortestPathApp.Routing.Views.RoutingControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GraphMatrixView
            // 
            this.GraphMatrixView.Location = new System.Drawing.Point(0, 0);
            this.GraphMatrixView.Name = "GraphMatrixView";
            this.GraphMatrixView.Size = new System.Drawing.Size(438, 276);
            this.GraphMatrixView.TabIndex = 0;
            this.GraphMatrixView.Vertices = null;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(446, 376);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.GraphMatrixView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(438, 350);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Матрица";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.graphLogicalView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(438, 350);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Граф";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // graphLogicalView1
            // 
            this.graphLogicalView1.Location = new System.Drawing.Point(0, 0);
            this.graphLogicalView1.Name = "graphLogicalView1";
            this.graphLogicalView1.Size = new System.Drawing.Size(435, 346);
            this.graphLogicalView1.TabIndex = 0;
            this.graphLogicalView1.Vertices = null;
            // 
            // GraphControlView
            // 
            this.GraphControlView.Location = new System.Drawing.Point(3, 3);
            this.GraphControlView.Name = "GraphControlView";
            this.GraphControlView.Size = new System.Drawing.Size(216, 297);
            this.GraphControlView.TabIndex = 3;
            this.GraphControlView.Vertices = null;
            // 
            // shortestPathView1
            // 
            this.shortestPathView1.Location = new System.Drawing.Point(461, 313);
            this.shortestPathView1.Name = "shortestPathView1";
            this.shortestPathView1.NodesOrder = null;
            this.shortestPathView1.NodesWeight = null;
            this.shortestPathView1.Size = new System.Drawing.Size(435, 64);
            this.shortestPathView1.TabIndex = 6;
            // 
            // algorithmControlView1
            // 
            this.algorithmControlView1.Location = new System.Drawing.Point(6, 6);
            this.algorithmControlView1.Name = "algorithmControlView1";
            this.algorithmControlView1.Size = new System.Drawing.Size(218, 155);
            this.algorithmControlView1.TabIndex = 7;
            this.algorithmControlView1.VertexCount = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(671, 2);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(233, 305);
            this.tabControl2.TabIndex = 8;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.algorithmControlView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(225, 279);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Кратчайщие пути";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.routingControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(225, 279);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Маршрутизация";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // routingControl1
            // 
            this.routingControl1.Location = new System.Drawing.Point(5, 1);
            this.routingControl1.Name = "routingControl1";
            this.routingControl1.Size = new System.Drawing.Size(216, 275);
            this.routingControl1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.GraphControlView);
            this.panel1.Location = new System.Drawing.Point(449, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 302);
            this.panel1.TabIndex = 9;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(908, 385);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.shortestPathView1);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(924, 424);
            this.MinimumSize = new System.Drawing.Size(924, 424);
            this.Name = "MainView";
            this.Text = "Поиск кратчайшего пути в графе";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Graph.Views.GraphMatrixView GraphMatrixView;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Graph.Views.GraphControlView GraphControlView;
        private Graph.Views.GraphLogicalView graphLogicalView1;
        private Algorithms.Views.ShortestPathView shortestPathView1;
        private Algorithms.Views.AlgorithmControlView algorithmControlView1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private Routing.Views.RoutingControl routingControl1;
        private System.Windows.Forms.Panel panel1;
    }
}

