namespace ShortestPathApp.Graph.Views
{
    partial class GraphMatrixView
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
            this.Matrix = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.Matrix)).BeginInit();
            this.SuspendLayout();
            // 
            // Matrix
            // 
            this.Matrix.AllowUserToAddRows = false;
            this.Matrix.AllowUserToDeleteRows = false;
            this.Matrix.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Matrix.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.Matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Matrix.Location = new System.Drawing.Point(0, 0);
            this.Matrix.MultiSelect = false;
            this.Matrix.Name = "Matrix";
            this.Matrix.Size = new System.Drawing.Size(435, 276);
            this.Matrix.TabIndex = 0;
            this.Matrix.TabStop = false;
            this.Matrix.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.Matrix_DefaultValuesNeeded);
            // 
            // GraphMatrixView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Matrix);
            this.Name = "GraphMatrixView";
            this.Size = new System.Drawing.Size(435, 276);
            ((System.ComponentModel.ISupportInitialize)(this.Matrix)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView Matrix;
    }
}
