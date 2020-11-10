namespace ShortestPathApp.Algorithms.Views
{
    partial class AlgorithmControlView
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
            if (disposing && (components != null))
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ExecutionTimeValueLabel = new System.Windows.Forms.Label();
            this.ExecutionTimeLabel = new System.Windows.Forms.Label();
            this.algorithmsComboBox = new System.Windows.Forms.ComboBox();
            this.executeButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.executeGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.benchmarkStartButton = new System.Windows.Forms.Button();
            this.iShortestPathAlgorithmBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iShortestPathAlgorithmBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.executeGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iShortestPathAlgorithmBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iShortestPathAlgorithmBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ExecutionTimeValueLabel);
            this.groupBox1.Controls.Add(this.ExecutionTimeLabel);
            this.groupBox1.Controls.Add(this.algorithmsComboBox);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(207, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Алгоритм";
            // 
            // ExecutionTimeValueLabel
            // 
            this.ExecutionTimeValueLabel.AutoSize = true;
            this.ExecutionTimeValueLabel.Location = new System.Drawing.Point(119, 53);
            this.ExecutionTimeValueLabel.Name = "ExecutionTimeValueLabel";
            this.ExecutionTimeValueLabel.Size = new System.Drawing.Size(0, 13);
            this.ExecutionTimeValueLabel.TabIndex = 2;
            // 
            // ExecutionTimeLabel
            // 
            this.ExecutionTimeLabel.AutoSize = true;
            this.ExecutionTimeLabel.Location = new System.Drawing.Point(6, 53);
            this.ExecutionTimeLabel.Name = "ExecutionTimeLabel";
            this.ExecutionTimeLabel.Size = new System.Drawing.Size(106, 13);
            this.ExecutionTimeLabel.TabIndex = 1;
            this.ExecutionTimeLabel.Text = "Время исполнения:";
            // 
            // algorithmsComboBox
            // 
            this.algorithmsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algorithmsComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.algorithmsComboBox.FormattingEnabled = true;
            this.algorithmsComboBox.Items.AddRange(new object[] {
            "Алгоритм Дейкстры",
            "Алгоритм Флойда"});
            this.algorithmsComboBox.Location = new System.Drawing.Point(6, 25);
            this.algorithmsComboBox.Name = "algorithmsComboBox";
            this.algorithmsComboBox.Size = new System.Drawing.Size(198, 21);
            this.algorithmsComboBox.TabIndex = 0;
            this.algorithmsComboBox.SelectedIndexChanged += new System.EventHandler(this.AlgorithmsComboBox_SelectedIndexChanged);
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(6, 45);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(198, 23);
            this.executeButton.TabIndex = 1;
            this.executeButton.Text = "Выполнить";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(6, 19);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(198, 20);
            this.numericUpDown1.TabIndex = 2;
            // 
            // executeGroupBox
            // 
            this.executeGroupBox.Controls.Add(this.numericUpDown1);
            this.executeGroupBox.Controls.Add(this.executeButton);
            this.executeGroupBox.Location = new System.Drawing.Point(3, 81);
            this.executeGroupBox.Name = "executeGroupBox";
            this.executeGroupBox.Size = new System.Drawing.Size(207, 75);
            this.executeGroupBox.TabIndex = 3;
            this.executeGroupBox.TabStop = false;
            this.executeGroupBox.Text = "Выполнить для узла";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.benchmarkStartButton);
            this.groupBox2.Location = new System.Drawing.Point(3, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(207, 55);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Бенчмарк";
            // 
            // benchmarkStartButton
            // 
            this.benchmarkStartButton.Location = new System.Drawing.Point(6, 19);
            this.benchmarkStartButton.Name = "benchmarkStartButton";
            this.benchmarkStartButton.Size = new System.Drawing.Size(198, 23);
            this.benchmarkStartButton.TabIndex = 3;
            this.benchmarkStartButton.Text = "Выполнить";
            this.benchmarkStartButton.UseVisualStyleBackColor = true;
            this.benchmarkStartButton.Click += new System.EventHandler(this.BenchmarkStartButton_Click);
            // 
            // iShortestPathAlgorithmBindingSource
            // 
            this.iShortestPathAlgorithmBindingSource.DataSource = typeof(ShortestPathApp.Algorithms.Interfaces.IShortestPathAlgorithm);
            // 
            // iShortestPathAlgorithmBindingSource1
            // 
            this.iShortestPathAlgorithmBindingSource1.DataSource = typeof(ShortestPathApp.Algorithms.Interfaces.IShortestPathAlgorithm);
            // 
            // AlgorithmControlView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.executeGroupBox);
            this.Controls.Add(this.groupBox1);
            this.Name = "AlgorithmControlView";
            this.Size = new System.Drawing.Size(218, 257);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.executeGroupBox.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.iShortestPathAlgorithmBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iShortestPathAlgorithmBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox algorithmsComboBox;
        private System.Windows.Forms.BindingSource iShortestPathAlgorithmBindingSource;
        private System.Windows.Forms.BindingSource iShortestPathAlgorithmBindingSource1;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.GroupBox executeGroupBox;
        private System.Windows.Forms.Label ExecutionTimeValueLabel;
        private System.Windows.Forms.Label ExecutionTimeLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button benchmarkStartButton;
    }
}
