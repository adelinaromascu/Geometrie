
namespace Geome_0317
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_3color = new System.Windows.Forms.Button();
            this.button_Dual = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button_Colorful = new System.Windows.Forms.Button();
            this.checkBox_Show_cordinates = new System.Windows.Forms.CheckBox();
            this.output = new System.Windows.Forms.TextBox();
            this.checkBox_separatorLine = new System.Windows.Forms.CheckBox();
            this.button_Triangulate = new System.Windows.Forms.Button();
            this.draw_polygon = new System.Windows.Forms.Button();
            this.btn_addPoint = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(979, 626);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_3color);
            this.panel1.Controls.Add(this.button_Dual);
            this.panel1.Controls.Add(this.button_Colorful);
            this.panel1.Controls.Add(this.output);
            this.panel1.Controls.Add(this.checkBox_separatorLine);
            this.panel1.Controls.Add(this.button_Triangulate);
            this.panel1.Controls.Add(this.draw_polygon);
            this.panel1.Controls.Add(this.btn_addPoint);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.btn_clear);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.checkBox_Show_cordinates);
            this.panel1.Location = new System.Drawing.Point(1008, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 626);
            this.panel1.TabIndex = 2;
            // 
            // button_3color
            // 
            this.button_3color.Location = new System.Drawing.Point(106, 420);
            this.button_3color.Name = "button_3color";
            this.button_3color.Size = new System.Drawing.Size(89, 68);
            this.button_3color.TabIndex = 23;
            this.button_3color.Text = "3-color";
            this.button_3color.UseVisualStyleBackColor = true;
            this.button_3color.Click += new System.EventHandler(this.button_3color_Click);
            // 
            // button_Dual
            // 
            this.button_Dual.Location = new System.Drawing.Point(106, 346);
            this.button_Dual.Name = "button_Dual";
            this.button_Dual.Size = new System.Drawing.Size(83, 68);
            this.button_Dual.TabIndex = 22;
            this.button_Dual.Text = "Dual";
            this.button_Dual.UseVisualStyleBackColor = true;
            this.button_Dual.Click += new System.EventHandler(this.button_Dual_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBox1.Location = new System.Drawing.Point(129, 207);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(18, 17);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button_Colorful
            // 
            this.button_Colorful.Location = new System.Drawing.Point(11, 460);
            this.button_Colorful.Name = "button_Colorful";
            this.button_Colorful.Size = new System.Drawing.Size(89, 68);
            this.button_Colorful.TabIndex = 19;
            this.button_Colorful.Text = "Coloreaza";
            this.button_Colorful.UseVisualStyleBackColor = true;
            this.button_Colorful.Click += new System.EventHandler(this.button_Colorful_Click);
            // 
            // checkBox_Show_cordinates
            // 
            this.checkBox_Show_cordinates.AutoSize = true;
            this.checkBox_Show_cordinates.Location = new System.Drawing.Point(164, 207);
            this.checkBox_Show_cordinates.Name = "checkBox_Show_cordinates";
            this.checkBox_Show_cordinates.Size = new System.Drawing.Size(18, 17);
            this.checkBox_Show_cordinates.TabIndex = 18;
            this.checkBox_Show_cordinates.UseVisualStyleBackColor = true;
            this.checkBox_Show_cordinates.CheckedChanged += new System.EventHandler(this.checkBox_Show_cordinates_CheckedChanged);
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(13, 165);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output.Size = new System.Drawing.Size(264, 118);
            this.output.TabIndex = 15;
            this.output.TextChanged += new System.EventHandler(this.output_TextChanged);
            // 
            // checkBox_separatorLine
            // 
            this.checkBox_separatorLine.AutoSize = true;
            this.checkBox_separatorLine.Location = new System.Drawing.Point(93, 207);
            this.checkBox_separatorLine.Name = "checkBox_separatorLine";
            this.checkBox_separatorLine.Size = new System.Drawing.Size(18, 17);
            this.checkBox_separatorLine.TabIndex = 14;
            this.checkBox_separatorLine.UseVisualStyleBackColor = true;
            this.checkBox_separatorLine.CheckedChanged += new System.EventHandler(this.checkBox_separatorLine_CheckedChanged);
            // 
            // button_Triangulate
            // 
            this.button_Triangulate.Location = new System.Drawing.Point(11, 386);
            this.button_Triangulate.Name = "button_Triangulate";
            this.button_Triangulate.Size = new System.Drawing.Size(89, 68);
            this.button_Triangulate.TabIndex = 13;
            this.button_Triangulate.Text = "Triangulare";
            this.button_Triangulate.UseVisualStyleBackColor = true;
            this.button_Triangulate.Click += new System.EventHandler(this.button_Triangulate_Click);
            // 
            // draw_polygon
            // 
            this.draw_polygon.Location = new System.Drawing.Point(13, 312);
            this.draw_polygon.Name = "draw_polygon";
            this.draw_polygon.Size = new System.Drawing.Size(87, 68);
            this.draw_polygon.TabIndex = 6;
            this.draw_polygon.Text = "Deseneaza";
            this.draw_polygon.UseVisualStyleBackColor = true;
            this.draw_polygon.Click += new System.EventHandler(this.draw_polygon_Click);
            // 
            // btn_addPoint
            // 
            this.btn_addPoint.Location = new System.Drawing.Point(119, 80);
            this.btn_addPoint.Name = "btn_addPoint";
            this.btn_addPoint.Size = new System.Drawing.Size(97, 36);
            this.btn_addPoint.TabIndex = 2;
            this.btn_addPoint.Text = "Adauga";
            this.btn_addPoint.UseVisualStyleBackColor = true;
            this.btn_addPoint.Click += new System.EventHandler(this.btn_addPoint_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 22);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 40);
            this.textBox1.TabIndex = 2;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(3, 80);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(99, 36);
            this.btn_clear.TabIndex = 1;
            this.btn_clear.Text = "Sterge";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1314, 650);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_addPoint;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Button draw_polygon;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button button_Triangulate;
        private System.Windows.Forms.Button button_Colorful;
        private System.Windows.Forms.Button button_Dual;
        private System.Windows.Forms.Button button_3color;
        private System.Windows.Forms.TextBox output;
        private System.Windows.Forms.CheckBox checkBox_Show_cordinates;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox_separatorLine;
    }
}

