namespace ColourPicker
{
    partial class GUI
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
            this.b_colour = new System.Windows.Forms.Button();
            this.cd_main = new System.Windows.Forms.ColorDialog();
            this.pb_preview = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.b_paste = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.b_tng = new System.Windows.Forms.Button();
            this.t_ref = new System.Windows.Forms.TextBox();
            this.trb_alpha = new System.Windows.Forms.TrackBar();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_alpha)).BeginInit();
            this.SuspendLayout();
            // 
            // b_colour
            // 
            this.b_colour.Location = new System.Drawing.Point(12, 25);
            this.b_colour.Name = "b_colour";
            this.b_colour.Size = new System.Drawing.Size(287, 23);
            this.b_colour.TabIndex = 0;
            this.b_colour.Text = "Click here to pick a colour!";
            this.b_colour.UseVisualStyleBackColor = true;
            this.b_colour.Click += new System.EventHandler(this.b_colour_Click);
            // 
            // cd_main
            // 
            this.cd_main.AnyColor = true;
            this.cd_main.FullOpen = true;
            // 
            // pb_preview
            // 
            this.pb_preview.Location = new System.Drawing.Point(12, 149);
            this.pb_preview.Name = "pb_preview";
            this.pb_preview.Size = new System.Drawing.Size(287, 27);
            this.pb_preview.TabIndex = 1;
            this.pb_preview.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Step 1:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Step 2:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(181, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Preview. Do you like it?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Step 3:";
            // 
            // b_paste
            // 
            this.b_paste.Location = new System.Drawing.Point(12, 209);
            this.b_paste.Name = "b_paste";
            this.b_paste.Size = new System.Drawing.Size(287, 23);
            this.b_paste.TabIndex = 6;
            this.b_paste.Text = "Click here to paste at the cursor\'s pos!";
            this.b_paste.UseVisualStyleBackColor = true;
            this.b_paste.Click += new System.EventHandler(this.b_paste_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(287, 23);
            this.label5.TabIndex = 7;
            this.label5.Text = "OR";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // b_tng
            // 
            this.b_tng.Location = new System.Drawing.Point(130, 261);
            this.b_tng.Name = "b_tng";
            this.b_tng.Size = new System.Drawing.Size(169, 23);
            this.b_tng.TabIndex = 9;
            this.b_tng.Text = "Name it and add #DEFINE!";
            this.b_tng.UseVisualStyleBackColor = true;
            this.b_tng.Click += new System.EventHandler(this.b_tng_Click);
            // 
            // t_ref
            // 
            this.t_ref.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.t_ref.Location = new System.Drawing.Point(15, 263);
            this.t_ref.MaxLength = 256;
            this.t_ref.Name = "t_ref";
            this.t_ref.Size = new System.Drawing.Size(109, 20);
            this.t_ref.TabIndex = 10;
            this.t_ref.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_ref_KeyPress);
            // 
            // trb_alpha
            // 
            this.trb_alpha.LargeChange = 15;
            this.trb_alpha.Location = new System.Drawing.Point(12, 77);
            this.trb_alpha.Maximum = 255;
            this.trb_alpha.Name = "trb_alpha";
            this.trb_alpha.Size = new System.Drawing.Size(287, 45);
            this.trb_alpha.SmallChange = 5;
            this.trb_alpha.TabIndex = 11;
            this.trb_alpha.TickFrequency = 10;
            this.trb_alpha.Value = 255;
            this.trb_alpha.Scroll += new System.EventHandler(this.trb_alpha_Scroll);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(287, 23);
            this.label6.TabIndex = 12;
            this.label6.Text = "And Alpha";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 296);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.t_ref);
            this.Controls.Add(this.b_tng);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.b_paste);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_preview);
            this.Controls.Add(this.b_colour);
            this.Controls.Add(this.trb_alpha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ColourPicker";
            this.Load += new System.EventHandler(this.GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_alpha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_colour;
        private System.Windows.Forms.ColorDialog cd_main;
        private System.Windows.Forms.PictureBox pb_preview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button b_paste;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button b_tng;
        private System.Windows.Forms.TextBox t_ref;
        private System.Windows.Forms.TrackBar trb_alpha;
        private System.Windows.Forms.Label label6;
    }
}