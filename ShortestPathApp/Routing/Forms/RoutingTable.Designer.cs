namespace ShortestPathApp.Routing.Forms
{
    partial class RoutingTable
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
            this.graphMatrixView1 = new ShortestPathApp.Graph.Views.GraphMatrixView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // graphMatrixView1
            // 
            this.graphMatrixView1.Location = new System.Drawing.Point(1, 49);
            this.graphMatrixView1.Name = "graphMatrixView1";
            this.graphMatrixView1.Size = new System.Drawing.Size(435, 276);
            this.graphMatrixView1.TabIndex = 0;
            this.graphMatrixView1.Vertices = null;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(298, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Очистить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // RoutingTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 327);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.graphMatrixView1);
            this.Name = "RoutingTable";
            this.Text = "RoutingTable";
            this.Load += new System.EventHandler(this.RoutingTable_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Graph.Views.GraphMatrixView graphMatrixView1;
        private System.Windows.Forms.Button button1;
    }
}