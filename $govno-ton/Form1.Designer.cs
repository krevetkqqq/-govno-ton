namespace GeckoTerminalGraph
{
    partial class MainForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.name = new System.Windows.Forms.Label();
            this.cost = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cost2 = new System.Windows.Forms.Label();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(5, 2);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(80, 13);
            this.name.TabIndex = 0;
            this.name.Text = "$GOVNO/TON";
            // 
            // cost
            // 
            this.cost.AutoSize = true;
            this.cost.Location = new System.Drawing.Point(22, 15);
            this.cost.Name = "cost";
            this.cost.Size = new System.Drawing.Size(32, 13);
            this.cost.TabIndex = 1;
            this.cost.Text = "price";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(238, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 22);
            this.button1.TabIndex = 2;
            this.button1.Text = "next";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "$GOVNO/USDT";
            // 
            // cost2
            // 
            this.cost2.AutoSize = true;
            this.cost2.Location = new System.Drawing.Point(23, 44);
            this.cost2.Name = "cost2";
            this.cost2.Size = new System.Drawing.Size(38, 13);
            this.cost2.TabIndex = 5;
            this.cost2.Text = "price2";
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(166, 43);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(66, 22);
            this.buttonNext.TabIndex = 6;
            this.buttonNext.Text = "Вкл/Выкл";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(140, 43);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(20, 22);
            this.buttonPrevious.TabIndex = 7;
            this.buttonPrevious.Text = "prev";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::_govno_ton.Properties.Resources.pin2;
            this.button2.Location = new System.Drawing.Point(237, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(24, 24);
            this.button2.TabIndex = 8;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.Location = new System.Drawing.Point(-3, -3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(273, 31);
            this.panel.TabIndex = 9;
            this.panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.panel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            this.panel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(266, 76);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.cost2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cost);
            this.Controls.Add(this.name);
            this.Controls.Add(this.panel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Opacity = 0.8D;
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "$GOVNO/USDT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Label cost;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label cost2;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel;
    }
}

