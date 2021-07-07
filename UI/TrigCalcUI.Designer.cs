namespace TrigCalc2.UI
{
    partial class TrigCalcUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrigCalcUI));
            this.Side_a = new System.Windows.Forms.Label();
            this.Side_b = new System.Windows.Forms.Label();
            this.Side_c = new System.Windows.Forms.Label();
            this.Angle_A = new System.Windows.Forms.Label();
            this.Input_Side_a = new System.Windows.Forms.TextBox();
            this.Input_Side_b = new System.Windows.Forms.TextBox();
            this.Input_Side_c = new System.Windows.Forms.TextBox();
            this.Angle_C = new System.Windows.Forms.Label();
            this.Input_Angle_A = new System.Windows.Forms.TextBox();
            this.Input_Angle_B = new System.Windows.Forms.TextBox();
            this.Input_Angle_C = new System.Windows.Forms.TextBox();
            this.EnoughInfo = new System.Windows.Forms.Label();
            this.Angle_B = new System.Windows.Forms.Label();
            this.Button_Calculate = new System.Windows.Forms.Button();
            this.Button_Clear = new System.Windows.Forms.Button();
            this.Button_Redo = new System.Windows.Forms.Button();
            this.Button_RadDeg = new System.Windows.Forms.Button();
            this.Button_ColorTheme = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Button_ColorTheme)).BeginInit();
            this.SuspendLayout();
            // 
            // Side_a
            // 
            this.Side_a.AutoSize = true;
            this.Side_a.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Side_a.Location = new System.Drawing.Point(27, 47);
            this.Side_a.Name = "Side_a";
            this.Side_a.Size = new System.Drawing.Size(57, 18);
            this.Side_a.TabIndex = 0;
            this.Side_a.Text = "Side  a:";
            // 
            // Side_b
            // 
            this.Side_b.AutoSize = true;
            this.Side_b.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Side_b.Location = new System.Drawing.Point(27, 80);
            this.Side_b.Name = "Side_b";
            this.Side_b.Size = new System.Drawing.Size(57, 18);
            this.Side_b.TabIndex = 1;
            this.Side_b.Text = "Side  b:";
            // 
            // Side_c
            // 
            this.Side_c.AutoSize = true;
            this.Side_c.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Side_c.Location = new System.Drawing.Point(27, 116);
            this.Side_c.Name = "Side_c";
            this.Side_c.Size = new System.Drawing.Size(57, 18);
            this.Side_c.TabIndex = 2;
            this.Side_c.Text = "Side  c:";
            // 
            // Angle_A
            // 
            this.Angle_A.AutoSize = true;
            this.Angle_A.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Angle_A.Location = new System.Drawing.Point(27, 175);
            this.Angle_A.Name = "Angle_A";
            this.Angle_A.Size = new System.Drawing.Size(61, 18);
            this.Angle_A.TabIndex = 3;
            this.Angle_A.Text = "Angle A:";
            // 
            // Input_Side_a
            // 
            this.Input_Side_a.Location = new System.Drawing.Point(90, 46);
            this.Input_Side_a.Name = "Input_Side_a";
            this.Input_Side_a.Size = new System.Drawing.Size(43, 20);
            this.Input_Side_a.TabIndex = 6;
            this.Input_Side_a.Text = "0";
            // 
            // Input_Side_b
            // 
            this.Input_Side_b.Location = new System.Drawing.Point(90, 79);
            this.Input_Side_b.Name = "Input_Side_b";
            this.Input_Side_b.Size = new System.Drawing.Size(43, 20);
            this.Input_Side_b.TabIndex = 7;
            this.Input_Side_b.Text = "0";
            // 
            // Input_Side_c
            // 
            this.Input_Side_c.Location = new System.Drawing.Point(90, 115);
            this.Input_Side_c.Name = "Input_Side_c";
            this.Input_Side_c.Size = new System.Drawing.Size(43, 20);
            this.Input_Side_c.TabIndex = 8;
            this.Input_Side_c.Text = "0";
            // 
            // Angle_C
            // 
            this.Angle_C.AutoSize = true;
            this.Angle_C.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Angle_C.Location = new System.Drawing.Point(27, 245);
            this.Angle_C.Name = "Angle_C";
            this.Angle_C.Size = new System.Drawing.Size(63, 18);
            this.Angle_C.TabIndex = 5;
            this.Angle_C.Text = "Angle C:";
            this.Angle_C.Click += new System.EventHandler(this.label3_Click);
            // 
            // Input_Angle_A
            // 
            this.Input_Angle_A.Location = new System.Drawing.Point(90, 174);
            this.Input_Angle_A.Name = "Input_Angle_A";
            this.Input_Angle_A.Size = new System.Drawing.Size(43, 20);
            this.Input_Angle_A.TabIndex = 9;
            this.Input_Angle_A.Text = "0";
            // 
            // Input_Angle_B
            // 
            this.Input_Angle_B.Location = new System.Drawing.Point(90, 211);
            this.Input_Angle_B.Name = "Input_Angle_B";
            this.Input_Angle_B.Size = new System.Drawing.Size(43, 20);
            this.Input_Angle_B.TabIndex = 10;
            this.Input_Angle_B.Text = "0";
            // 
            // Input_Angle_C
            // 
            this.Input_Angle_C.Location = new System.Drawing.Point(90, 244);
            this.Input_Angle_C.Name = "Input_Angle_C";
            this.Input_Angle_C.Size = new System.Drawing.Size(43, 20);
            this.Input_Angle_C.TabIndex = 11;
            this.Input_Angle_C.Text = "0";
            // 
            // EnoughInfo
            // 
            this.EnoughInfo.AutoSize = true;
            this.EnoughInfo.Location = new System.Drawing.Point(39, 315);
            this.EnoughInfo.Name = "EnoughInfo";
            this.EnoughInfo.Size = new System.Drawing.Size(0, 13);
            this.EnoughInfo.TabIndex = 13;
            // 
            // Angle_B
            // 
            this.Angle_B.AutoSize = true;
            this.Angle_B.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Angle_B.Location = new System.Drawing.Point(27, 212);
            this.Angle_B.Name = "Angle_B";
            this.Angle_B.Size = new System.Drawing.Size(62, 18);
            this.Angle_B.TabIndex = 14;
            this.Angle_B.Text = "Angle B:";
            // 
            // Button_Calculate
            // 
            this.Button_Calculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Calculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Calculate.Image = ((System.Drawing.Image)(resources.GetObject("Button_Calculate.Image")));
            this.Button_Calculate.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_Calculate.Location = new System.Drawing.Point(30, 331);
            this.Button_Calculate.Name = "Button_Calculate";
            this.Button_Calculate.Size = new System.Drawing.Size(116, 40);
            this.Button_Calculate.TabIndex = 15;
            this.Button_Calculate.Text = "Calculate";
            this.Button_Calculate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Calculate.UseVisualStyleBackColor = true;
            this.Button_Calculate.Click += new System.EventHandler(this.Button_Calculate_Click);
            // 
            // Button_Clear
            // 
            this.Button_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Clear.Image = ((System.Drawing.Image)(resources.GetObject("Button_Clear.Image")));
            this.Button_Clear.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_Clear.Location = new System.Drawing.Point(30, 377);
            this.Button_Clear.Name = "Button_Clear";
            this.Button_Clear.Size = new System.Drawing.Size(54, 24);
            this.Button_Clear.TabIndex = 16;
            this.Button_Clear.Text = "Clear";
            this.Button_Clear.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Button_Clear.UseVisualStyleBackColor = true;
            this.Button_Clear.Click += new System.EventHandler(this.Button_Clear_Click);
            // 
            // Button_Redo
            // 
            this.Button_Redo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Redo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Redo.Image = ((System.Drawing.Image)(resources.GetObject("Button_Redo.Image")));
            this.Button_Redo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Button_Redo.Location = new System.Drawing.Point(90, 377);
            this.Button_Redo.Name = "Button_Redo";
            this.Button_Redo.Size = new System.Drawing.Size(56, 24);
            this.Button_Redo.TabIndex = 17;
            this.Button_Redo.Text = "Redo";
            this.Button_Redo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Button_Redo.UseVisualStyleBackColor = true;
            this.Button_Redo.Click += new System.EventHandler(this.Button_Redo_Click);
            // 
            // Button_RadDeg
            // 
            this.Button_RadDeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_RadDeg.Location = new System.Drawing.Point(90, 407);
            this.Button_RadDeg.Name = "Button_RadDeg";
            this.Button_RadDeg.Size = new System.Drawing.Size(56, 23);
            this.Button_RadDeg.TabIndex = 19;
            this.Button_RadDeg.UseVisualStyleBackColor = true;
            this.Button_RadDeg.Click += new System.EventHandler(this.RadDeg_Click);
            // 
            // Button_ColorTheme
            // 
            this.Button_ColorTheme.Image = ((System.Drawing.Image)(resources.GetObject("Button_ColorTheme.Image")));
            this.Button_ColorTheme.Location = new System.Drawing.Point(30, 407);
            this.Button_ColorTheme.Name = "Button_ColorTheme";
            this.Button_ColorTheme.Size = new System.Drawing.Size(20, 22);
            this.Button_ColorTheme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Button_ColorTheme.TabIndex = 20;
            this.Button_ColorTheme.TabStop = false;
            this.Button_ColorTheme.Click += new System.EventHandler(this.Button_ColorTheme_Click);
            // 
            // TrigCalcUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Button_ColorTheme);
            this.Controls.Add(this.Button_RadDeg);
            this.Controls.Add(this.Button_Redo);
            this.Controls.Add(this.Button_Clear);
            this.Controls.Add(this.Button_Calculate);
            this.Controls.Add(this.Angle_B);
            this.Controls.Add(this.EnoughInfo);
            this.Controls.Add(this.Input_Angle_C);
            this.Controls.Add(this.Input_Angle_B);
            this.Controls.Add(this.Input_Angle_A);
            this.Controls.Add(this.Input_Side_c);
            this.Controls.Add(this.Input_Side_b);
            this.Controls.Add(this.Input_Side_a);
            this.Controls.Add(this.Angle_C);
            this.Controls.Add(this.Angle_A);
            this.Controls.Add(this.Side_c);
            this.Controls.Add(this.Side_b);
            this.Controls.Add(this.Side_a);
            this.Name = "TrigCalcUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrigCalc";
            this.Load += new System.EventHandler(this.TrigCalcUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Button_ColorTheme)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Side_a;
        private System.Windows.Forms.Label Side_b;
        private System.Windows.Forms.Label Side_c;
        private System.Windows.Forms.Label Angle_A;
        private System.Windows.Forms.TextBox Input_Side_a;
        private System.Windows.Forms.TextBox Input_Side_b;
        private System.Windows.Forms.TextBox Input_Side_c;
        private System.Windows.Forms.Label Angle_C;
        private System.Windows.Forms.TextBox Input_Angle_A;
        private System.Windows.Forms.TextBox Input_Angle_B;
        private System.Windows.Forms.TextBox Input_Angle_C;
        private System.Windows.Forms.Label EnoughInfo;
        private System.Windows.Forms.Label Angle_B;
        private System.Windows.Forms.Button Button_Calculate;
        private System.Windows.Forms.Button Button_Clear;
        private System.Windows.Forms.Button Button_Redo;
        private System.Windows.Forms.Button Button_RadDeg;
        private System.Windows.Forms.PictureBox Button_ColorTheme;
    }
}

