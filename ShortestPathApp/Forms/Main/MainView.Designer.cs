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
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
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
            this.GraphControlView.Location = new System.Drawing.Point(449, 0);
            this.GraphControlView.Name = "GraphControlView";
            this.GraphControlView.Size = new System.Drawing.Size(216, 203);
            this.GraphControlView.TabIndex = 3;
            this.GraphControlView.Vertices = null;
            // 
            // shortestPathView1
            // 
            this.shortestPathView1.Location = new System.Drawing.Point(5, 379);
            this.shortestPathView1.Name = "shortestPathView1";
            this.shortestPathView1.NodesOrder = null;
            this.shortestPathView1.NodesWeight = null;
            this.shortestPathView1.Size = new System.Drawing.Size(435, 64);
            this.shortestPathView1.TabIndex = 6;
            // 
            // algorithmControlView1
            // 
            this.algorithmControlView1.BenchmarkTime = ((long)(0));
            this.algorithmControlView1.Location = new System.Drawing.Point(449, 201);
            this.algorithmControlView1.Name = "algorithmControlView1";
            this.algorithmControlView1.Size = new System.Drawing.Size(218, 254);
            this.algorithmControlView1.TabIndex = 7;
            this.algorithmControlView1.VertexCount = 0;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 461);
            this.Controls.Add(this.algorithmControlView1);
            this.Controls.Add(this.shortestPathView1);
            this.Controls.Add(this.GraphControlView);
            this.Controls.Add(this.tabControl1);
            this.MaximumSize = new System.Drawing.Size(682, 500);
            this.MinimumSize = new System.Drawing.Size(682, 500);
            this.Name = "MainView";
            this.Text = "Поиск кратчайшего пути в графе";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
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
    }
}

