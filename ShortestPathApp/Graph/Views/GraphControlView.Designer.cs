namespace ShortestPathApp.Graph.Views
{
    partial class GraphControlView
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.GraphControlGroupBox = new System.Windows.Forms.GroupBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.vertexCountValueLabel = new System.Windows.Forms.Label();
            this.vertexCountLabel = new System.Windows.Forms.Label();
            this.RemoveVertex = new System.Windows.Forms.Button();
            this.AddVertex = new System.Windows.Forms.Button();
            this.FakeReadButton = new System.Windows.Forms.Button();
            this.GraphControlGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // GraphControlGroupBox
            // 
            this.GraphControlGroupBox.Controls.Add(this.numericUpDown1);
            this.GraphControlGroupBox.Controls.Add(this.vertexCountValueLabel);
            this.GraphControlGroupBox.Controls.Add(this.vertexCountLabel);
            this.GraphControlGroupBox.Controls.Add(this.RemoveVertex);
            this.GraphControlGroupBox.Controls.Add(this.AddVertex);
            this.GraphControlGroupBox.Controls.Add(this.FakeReadButton);
            this.GraphControlGroupBox.Location = new System.Drawing.Point(3, 3);
            this.GraphControlGroupBox.Name = "GraphControlGroupBox";
            this.GraphControlGroupBox.Size = new System.Drawing.Size(210, 193);
            this.GraphControlGroupBox.TabIndex = 0;
            this.GraphControlGroupBox.TabStop = false;
            this.GraphControlGroupBox.Text = "Управление графом";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(6, 92);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(195, 20);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // vertexCountValueLabel
            // 
            this.vertexCountValueLabel.AutoSize = true;
            this.vertexCountValueLabel.Location = new System.Drawing.Point(96, 23);
            this.vertexCountValueLabel.Name = "vertexCountValueLabel";
            this.vertexCountValueLabel.Size = new System.Drawing.Size(0, 13);
            this.vertexCountValueLabel.TabIndex = 5;
            // 
            // vertexCountLabel
            // 
            this.vertexCountLabel.AutoSize = true;
            this.vertexCountLabel.Location = new System.Drawing.Point(6, 23);
            this.vertexCountLabel.Name = "vertexCountLabel";
            this.vertexCountLabel.Size = new System.Drawing.Size(84, 13);
            this.vertexCountLabel.TabIndex = 4;
            this.vertexCountLabel.Text = "Всего вершин: ";
            // 
            // RemoveVertex
            // 
            this.RemoveVertex.Location = new System.Drawing.Point(6, 118);
            this.RemoveVertex.Name = "RemoveVertex";
            this.RemoveVertex.Size = new System.Drawing.Size(198, 30);
            this.RemoveVertex.TabIndex = 3;
            this.RemoveVertex.Text = "Удалить вершину";
            this.RemoveVertex.UseVisualStyleBackColor = true;
            this.RemoveVertex.Click += new System.EventHandler(this.RemoveVertex_Click);
            // 
            // AddVertex
            // 
            this.AddVertex.Location = new System.Drawing.Point(6, 46);
            this.AddVertex.Name = "AddVertex";
            this.AddVertex.Size = new System.Drawing.Size(198, 30);
            this.AddVertex.TabIndex = 2;
            this.AddVertex.Text = "Добавить вершину";
            this.AddVertex.UseVisualStyleBackColor = true;
            this.AddVertex.Click += new System.EventHandler(this.AddVertex_Click);
            // 
            // FakeReadButton
            // 
            this.FakeReadButton.Location = new System.Drawing.Point(6, 154);
            this.FakeReadButton.Name = "FakeReadButton";
            this.FakeReadButton.Size = new System.Drawing.Size(198, 30);
            this.FakeReadButton.TabIndex = 0;
            this.FakeReadButton.Text = "Заполнить тестовыми значениями";
            this.FakeReadButton.UseVisualStyleBackColor = true;
            this.FakeReadButton.Click += new System.EventHandler(this.FakeReadButton_Click);
            // 
            // GraphControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GraphControlGroupBox);
            this.Name = "GraphControlView";
            this.Size = new System.Drawing.Size(216, 200);
            this.GraphControlGroupBox.ResumeLayout(false);
            this.GraphControlGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GraphControlGroupBox;
        private System.Windows.Forms.Button FakeReadButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label vertexCountValueLabel;
        private System.Windows.Forms.Label vertexCountLabel;
        private System.Windows.Forms.Button RemoveVertex;
        private System.Windows.Forms.Button AddVertex;
    }
}
