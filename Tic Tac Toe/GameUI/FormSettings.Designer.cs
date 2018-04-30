namespace GameUI
{
    public partial class FormGameSettings
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_Player2 = new System.Windows.Forms.CheckBox();
            this.TextBox_Player1Name = new System.Windows.Forms.TextBox();
            this.TextBox_Player2Name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.NumericUpDown_Rows = new System.Windows.Forms.NumericUpDown();
            this.NumericUpDown_Cols = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Rows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Cols)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Players:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Player 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Player 2:";
            // 
            // checkBox_Player2
            // 
            this.checkBox_Player2.AccessibleName = "checkbox_Player2Name";
            this.checkBox_Player2.AutoSize = true;
            this.checkBox_Player2.Location = new System.Drawing.Point(26, 62);
            this.checkBox_Player2.Name = "checkBox_Player2";
            this.checkBox_Player2.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Player2.TabIndex = 3;
            this.checkBox_Player2.UseVisualStyleBackColor = true;
            this.checkBox_Player2.CheckedChanged += new System.EventHandler(this.checkBox_Player2_CheckedChanged);
            // 
            // TextBox_Player1Name
            // 
            this.TextBox_Player1Name.AccessibleName = "TextBox_Player1Name";
            this.TextBox_Player1Name.Location = new System.Drawing.Point(97, 37);
            this.TextBox_Player1Name.Name = "TextBox_Player1Name";
            this.TextBox_Player1Name.Size = new System.Drawing.Size(100, 20);
            this.TextBox_Player1Name.TabIndex = 4;
            this.TextBox_Player1Name.TextChanged += new System.EventHandler(this.TextBox_Player1Name_TextChanged);
            // 
            // TextBox_Player2Name
            // 
            this.TextBox_Player2Name.AccessibleName = "TextBox_Player2Name";
            this.TextBox_Player2Name.Enabled = false;
            this.TextBox_Player2Name.Location = new System.Drawing.Point(97, 59);
            this.TextBox_Player2Name.Name = "TextBox_Player2Name";
            this.TextBox_Player2Name.Size = new System.Drawing.Size(100, 20);
            this.TextBox_Player2Name.TabIndex = 5;
            this.TextBox_Player2Name.Text = "[Computer]";
            this.TextBox_Player2Name.TextChanged += new System.EventHandler(this.TextBox_Player2Name_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Board Size:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Rows:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Cols:";
            // 
            // NumericUpDown_Rows
            // 
            this.NumericUpDown_Rows.AccessibleName = "NumericUpDown_Rows";
            this.NumericUpDown_Rows.Location = new System.Drawing.Point(73, 116);
            this.NumericUpDown_Rows.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NumericUpDown_Rows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumericUpDown_Rows.Name = "NumericUpDown_Rows";
            this.NumericUpDown_Rows.Size = new System.Drawing.Size(36, 20);
            this.NumericUpDown_Rows.TabIndex = 9;
            this.NumericUpDown_Rows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumericUpDown_Rows.ValueChanged += new System.EventHandler(this.NumericUpDown_Rows_ValueChanged);
            // 
            // NumericUpDown_Cols
            // 
            this.NumericUpDown_Cols.AccessibleName = "NumericUpDown_Cols";
            this.NumericUpDown_Cols.BackColor = System.Drawing.SystemColors.Window;
            this.NumericUpDown_Cols.Location = new System.Drawing.Point(160, 117);
            this.NumericUpDown_Cols.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.NumericUpDown_Cols.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumericUpDown_Cols.Name = "NumericUpDown_Cols";
            this.NumericUpDown_Cols.Size = new System.Drawing.Size(36, 20);
            this.NumericUpDown_Cols.TabIndex = 10;
            this.NumericUpDown_Cols.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NumericUpDown_Cols.ValueChanged += new System.EventHandler(this.NumericUpDown_Cols_ValueChanged);
            // 
            // button1
            // 
            this.button1.AccessibleName = "Button_Start";
            this.button1.Location = new System.Drawing.Point(19, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Start!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.Enabled = false;
            // 
            // FormGameSettings
            // 
            this.AccessibleName = "Game Settings";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 192);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.NumericUpDown_Cols);
            this.Controls.Add(this.NumericUpDown_Rows);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextBox_Player2Name);
            this.Controls.Add(this.TextBox_Player1Name);
            this.Controls.Add(this.checkBox_Player2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.ShowIcon = false;
            this.Text = "Game Settings";
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Rows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Cols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox_Player2;
        private System.Windows.Forms.TextBox TextBox_Player1Name;
        private System.Windows.Forms.TextBox TextBox_Player2Name;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Rows;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Cols;
        private System.Windows.Forms.Button button1;
    }
}