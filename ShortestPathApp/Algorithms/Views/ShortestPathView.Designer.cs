namespace ShortestPathApp.Algorithms.Views
{
    partial class ShortestPathView
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
            this.weightsTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.weightsTable)).BeginInit();
            this.SuspendLayout();
            // 
            // weightsTable
            // 
            this.weightsTable.AllowUserToAddRows = false;
            this.weightsTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.weightsTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.weightsTable.Location = new System.Drawing.Point(3, 3);
            this.weightsTable.MultiSelect = false;
            this.weightsTable.Name = "weightsTable";
            this.weightsTable.ReadOnly = true;
            this.weightsTable.Size = new System.Drawing.Size(429, 58);
            this.weightsTable.TabIndex = 0;
            this.weightsTable.Click += new System.EventHandler(this.WeightsTable_Click);
            // 
            // ShortestPathView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.weightsTable);
            this.Name = "ShortestPathView";
            this.Size = new System.Drawing.Size(435, 64);
            ((System.ComponentModel.ISupportInitialize)(this.weightsTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView weightsTable;
    }
}
