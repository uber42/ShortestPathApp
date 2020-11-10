namespace ShortestPathApp.Forms.Main
{
    partial class BenchmarkForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dijkstraGraphMatrixView = new ShortestPathApp.Graph.Views.GraphMatrixView();
            this.FloydGraphMatrixView = new ShortestPathApp.Graph.Views.GraphMatrixView();
            this.dijkstraNameLabel = new System.Windows.Forms.Label();
            this.floydNameLabel = new System.Windows.Forms.Label();
            this.DijkstraTimeExecutionLabel = new System.Windows.Forms.Label();
            this.DijkstraTimeExecutionValueLabel = new System.Windows.Forms.Label();
            this.FloydTimeExecutionValueLabel = new System.Windows.Forms.Label();
            this.FloydTimeExecutionLabel = new System.Windows.Forms.Label();
            this.DijkstraBenchButton = new System.Windows.Forms.Button();
            this.FloydBenchButton = new System.Windows.Forms.Button();
            this.BothBenchButton = new System.Windows.Forms.Button();
            this.generateButton = new System.Windows.Forms.Button();
            this.graphMatrixView1 = new ShortestPathApp.Graph.Views.GraphMatrixView();
            this.graphMatrixView2 = new ShortestPathApp.Graph.Views.GraphMatrixView();
            this.SuspendLayout();
            // 
            // dijkstraGraphMatrixView
            // 
            this.dijkstraGraphMatrixView.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.dijkstraGraphMatrixView.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dijkstraGraphMatrixView.Location = new System.Drawing.Point(12, 12);
            this.dijkstraGraphMatrixView.Name = "dijkstraGraphMatrixView";
            this.dijkstraGraphMatrixView.Size = new System.Drawing.Size(436, 276);
            this.dijkstraGraphMatrixView.TabIndex = 0;
            this.dijkstraGraphMatrixView.Vertices = null;
            // 
            // FloydGraphMatrixView
            // 
            this.FloydGraphMatrixView.Location = new System.Drawing.Point(454, 12);
            this.FloydGraphMatrixView.Name = "FloydGraphMatrixView";
            this.FloydGraphMatrixView.Size = new System.Drawing.Size(436, 276);
            this.FloydGraphMatrixView.TabIndex = 1;
            this.FloydGraphMatrixView.Vertices = null;
            // 
            // dijkstraNameLabel
            // 
            this.dijkstraNameLabel.AutoSize = true;
            this.dijkstraNameLabel.Location = new System.Drawing.Point(177, 291);
            this.dijkstraNameLabel.Name = "dijkstraNameLabel";
            this.dijkstraNameLabel.Size = new System.Drawing.Size(111, 13);
            this.dijkstraNameLabel.TabIndex = 2;
            this.dijkstraNameLabel.Text = "Алгоритм Дейкстры";
            // 
            // floydNameLabel
            // 
            this.floydNameLabel.AutoSize = true;
            this.floydNameLabel.Location = new System.Drawing.Point(607, 291);
            this.floydNameLabel.Name = "floydNameLabel";
            this.floydNameLabel.Size = new System.Drawing.Size(100, 13);
            this.floydNameLabel.TabIndex = 3;
            this.floydNameLabel.Text = "Алгоритм Флойда";
            // 
            // DijkstraTimeExecutionLabel
            // 
            this.DijkstraTimeExecutionLabel.AutoSize = true;
            this.DijkstraTimeExecutionLabel.Location = new System.Drawing.Point(177, 313);
            this.DijkstraTimeExecutionLabel.Name = "DijkstraTimeExecutionLabel";
            this.DijkstraTimeExecutionLabel.Size = new System.Drawing.Size(105, 13);
            this.DijkstraTimeExecutionLabel.TabIndex = 4;
            this.DijkstraTimeExecutionLabel.Text = "Время выполнения";
            // 
            // DijkstraTimeExecutionValueLabel
            // 
            this.DijkstraTimeExecutionValueLabel.AutoSize = true;
            this.DijkstraTimeExecutionValueLabel.Location = new System.Drawing.Point(289, 313);
            this.DijkstraTimeExecutionValueLabel.Name = "DijkstraTimeExecutionValueLabel";
            this.DijkstraTimeExecutionValueLabel.Size = new System.Drawing.Size(0, 13);
            this.DijkstraTimeExecutionValueLabel.TabIndex = 5;
            // 
            // FloydTimeExecutionValueLabel
            // 
            this.FloydTimeExecutionValueLabel.AutoSize = true;
            this.FloydTimeExecutionValueLabel.Location = new System.Drawing.Point(719, 313);
            this.FloydTimeExecutionValueLabel.Name = "FloydTimeExecutionValueLabel";
            this.FloydTimeExecutionValueLabel.Size = new System.Drawing.Size(0, 13);
            this.FloydTimeExecutionValueLabel.TabIndex = 7;
            // 
            // FloydTimeExecutionLabel
            // 
            this.FloydTimeExecutionLabel.AutoSize = true;
            this.FloydTimeExecutionLabel.Location = new System.Drawing.Point(607, 313);
            this.FloydTimeExecutionLabel.Name = "FloydTimeExecutionLabel";
            this.FloydTimeExecutionLabel.Size = new System.Drawing.Size(105, 13);
            this.FloydTimeExecutionLabel.TabIndex = 6;
            this.FloydTimeExecutionLabel.Text = "Время выполнения";
            // 
            // DijkstraBenchButton
            // 
            this.DijkstraBenchButton.Location = new System.Drawing.Point(142, 337);
            this.DijkstraBenchButton.Name = "DijkstraBenchButton";
            this.DijkstraBenchButton.Size = new System.Drawing.Size(150, 23);
            this.DijkstraBenchButton.TabIndex = 8;
            this.DijkstraBenchButton.Text = "Выполнить Дейкстру";
            this.DijkstraBenchButton.UseVisualStyleBackColor = true;
            this.DijkstraBenchButton.Click += new System.EventHandler(this.DijkstraBenchButton_Click);
            // 
            // FloydBenchButton
            // 
            this.FloydBenchButton.Location = new System.Drawing.Point(298, 337);
            this.FloydBenchButton.Name = "FloydBenchButton";
            this.FloydBenchButton.Size = new System.Drawing.Size(150, 23);
            this.FloydBenchButton.TabIndex = 9;
            this.FloydBenchButton.Text = "Выполнить Флойда";
            this.FloydBenchButton.UseVisualStyleBackColor = true;
            this.FloydBenchButton.Click += new System.EventHandler(this.FloydBenchButton_Click);
            // 
            // BothBenchButton
            // 
            this.BothBenchButton.Location = new System.Drawing.Point(454, 337);
            this.BothBenchButton.Name = "BothBenchButton";
            this.BothBenchButton.Size = new System.Drawing.Size(150, 23);
            this.BothBenchButton.TabIndex = 10;
            this.BothBenchButton.Text = "Выполнить Оба";
            this.BothBenchButton.UseVisualStyleBackColor = true;
            this.BothBenchButton.Click += new System.EventHandler(this.BothBenchButton_Click);
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(610, 337);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(150, 23);
            this.generateButton.TabIndex = 11;
            this.generateButton.Text = "Заполнить матрицы";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // graphMatrixView1
            // 
            this.graphMatrixView1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.graphMatrixView1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.graphMatrixView1.Location = new System.Drawing.Point(12, 366);
            this.graphMatrixView1.Name = "graphMatrixView1";
            this.graphMatrixView1.Size = new System.Drawing.Size(436, 276);
            this.graphMatrixView1.TabIndex = 12;
            this.graphMatrixView1.Vertices = null;
            // 
            // graphMatrixView2
            // 
            this.graphMatrixView2.Location = new System.Drawing.Point(454, 366);
            this.graphMatrixView2.Name = "graphMatrixView2";
            this.graphMatrixView2.Size = new System.Drawing.Size(436, 276);
            this.graphMatrixView2.TabIndex = 13;
            this.graphMatrixView2.Vertices = null;
            // 
            // BenchmarkForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(896, 657);
            this.Controls.Add(this.graphMatrixView2);
            this.Controls.Add(this.graphMatrixView1);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.BothBenchButton);
            this.Controls.Add(this.FloydBenchButton);
            this.Controls.Add(this.DijkstraBenchButton);
            this.Controls.Add(this.FloydTimeExecutionValueLabel);
            this.Controls.Add(this.FloydTimeExecutionLabel);
            this.Controls.Add(this.DijkstraTimeExecutionValueLabel);
            this.Controls.Add(this.DijkstraTimeExecutionLabel);
            this.Controls.Add(this.floydNameLabel);
            this.Controls.Add(this.dijkstraNameLabel);
            this.Controls.Add(this.FloydGraphMatrixView);
            this.Controls.Add(this.dijkstraGraphMatrixView);
            this.Name = "BenchmarkForm";
            this.Text = "BenchmarkForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Graph.Views.GraphMatrixView dijkstraGraphMatrixView;
        private Graph.Views.GraphMatrixView FloydGraphMatrixView;
        private System.Windows.Forms.Label floydNameLabel;
        private System.Windows.Forms.Label DijkstraTimeExecutionLabel;
        private System.Windows.Forms.Label DijkstraTimeExecutionValueLabel;
        private System.Windows.Forms.Label FloydTimeExecutionValueLabel;
        private System.Windows.Forms.Label FloydTimeExecutionLabel;
        private System.Windows.Forms.Button DijkstraBenchButton;
        private System.Windows.Forms.Button FloydBenchButton;
        private System.Windows.Forms.Button BothBenchButton;
        private System.Windows.Forms.Label dijkstraNameLabel;
        private System.Windows.Forms.Button generateButton;
        private Graph.Views.GraphMatrixView graphMatrixView1;
        private Graph.Views.GraphMatrixView graphMatrixView2;
    }
}