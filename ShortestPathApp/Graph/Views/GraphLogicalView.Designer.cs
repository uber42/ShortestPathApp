namespace ShortestPathApp.Graph.Views
{
    partial class GraphLogicalView
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
            this.graphPanel = new ShortestPathApp.Graph.Controls.GraphPanel();
            ((System.ComponentModel.ISupportInitialize)(this.graphPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // graphPanel1
            // 
            this.graphPanel.BackColor = System.Drawing.Color.Lavender;
            this.graphPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.graphPanel.Location = new System.Drawing.Point(0, 0);
            this.graphPanel.Name = "graphPanel1";
            this.graphPanel.Size = new System.Drawing.Size(435, 409);
            this.graphPanel.TabIndex = 0;
            this.graphPanel.TabStop = false;
            this.graphPanel.Vertices = null;
            // 
            // GraphLogicalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.graphPanel);
            this.Name = "GraphLogicalView";
            this.Size = new System.Drawing.Size(435, 409);
            ((System.ComponentModel.ISupportInitialize)(this.graphPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.GraphPanel graphPanel;
    }
}
