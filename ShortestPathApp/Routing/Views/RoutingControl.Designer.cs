namespace ShortestPathApp.Routing.Views
{
    partial class RoutingControl
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
            this.sendButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lifetimeLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.packetCountLabel = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.lifetimeCount = new System.Windows.Forms.NumericUpDown();
            this.countNumber = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.algorithmList = new System.Windows.Forms.ComboBox();
            this.methodList = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lifetimeCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(10, 244);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(87, 23);
            this.sendButton.TabIndex = 21;
            this.sendButton.Text = "Отправить";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Узел приемник";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Узел отправитель";
            // 
            // lifetimeLabel
            // 
            this.lifetimeLabel.AutoSize = true;
            this.lifetimeLabel.Location = new System.Drawing.Point(11, 120);
            this.lifetimeLabel.Name = "lifetimeLabel";
            this.lifetimeLabel.Size = new System.Drawing.Size(113, 13);
            this.lifetimeLabel.TabIndex = 20;
            this.lifetimeLabel.Text = "Время жизни пакета";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(10, 218);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(198, 20);
            this.numericUpDown1.TabIndex = 23;
            // 
            // packetCountLabel
            // 
            this.packetCountLabel.AutoSize = true;
            this.packetCountLabel.Location = new System.Drawing.Point(11, 78);
            this.packetCountLabel.Name = "packetCountLabel";
            this.packetCountLabel.Size = new System.Drawing.Size(110, 13);
            this.packetCountLabel.TabIndex = 19;
            this.packetCountLabel.Text = "Количество пакетов";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(10, 176);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(198, 20);
            this.numericUpDown2.TabIndex = 22;
            // 
            // lifetimeCount
            // 
            this.lifetimeCount.Location = new System.Drawing.Point(10, 136);
            this.lifetimeCount.Name = "lifetimeCount";
            this.lifetimeCount.Size = new System.Drawing.Size(198, 20);
            this.lifetimeCount.TabIndex = 18;
            // 
            // countNumber
            // 
            this.countNumber.Location = new System.Drawing.Point(10, 94);
            this.countNumber.Name = "countNumber";
            this.countNumber.Size = new System.Drawing.Size(198, 20);
            this.countNumber.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Алгоритм";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Метод";
            // 
            // algorithmList
            // 
            this.algorithmList.FormattingEnabled = true;
            this.algorithmList.Items.AddRange(new object[] {
            "Случайная маршрутизация",
            "Лавинная маршрутизация",
            "По предыдущему опыту"});
            this.algorithmList.Location = new System.Drawing.Point(10, 54);
            this.algorithmList.Name = "algorithmList";
            this.algorithmList.Size = new System.Drawing.Size(198, 21);
            this.algorithmList.TabIndex = 14;
            // 
            // methodList
            // 
            this.methodList.FormattingEnabled = true;
            this.methodList.Items.AddRange(new object[] {
            "Дейтаграммная передача",
            "Виртуальные каналы"});
            this.methodList.Location = new System.Drawing.Point(10, 16);
            this.methodList.Name = "methodList";
            this.methodList.Size = new System.Drawing.Size(198, 21);
            this.methodList.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(117, 244);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "Стоп";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // RoutingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lifetimeLabel);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.packetCountLabel);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.lifetimeCount);
            this.Controls.Add(this.countNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.algorithmList);
            this.Controls.Add(this.methodList);
            this.Name = "RoutingControl";
            this.Size = new System.Drawing.Size(216, 274);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lifetimeCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lifetimeLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label packetCountLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown lifetimeCount;
        private System.Windows.Forms.NumericUpDown countNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox algorithmList;
        private System.Windows.Forms.ComboBox methodList;
        private System.Windows.Forms.Button button1;
    }
}
