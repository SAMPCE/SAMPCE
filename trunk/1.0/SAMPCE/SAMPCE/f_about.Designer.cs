namespace SAMPCE
{
    partial class f_about
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f_about));
            this.label3 = new System.Windows.Forms.Label();
            this.ll_ok = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.l_credits = new System.Windows.Forms.Label();
            this.tm_scroller = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(136, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 72);
            this.label3.TabIndex = 3;
            this.label3.Text = "This software is released under the Apache License.\r\n\r\nFor the full license, read" +
                " the LICENSE file or visit:\r\n<http://www.apache.org/licenses/LICENSE-2.0>\r\n";
            // 
            // ll_ok
            // 
            this.ll_ok.AutoSize = true;
            this.ll_ok.BackColor = System.Drawing.Color.White;
            this.ll_ok.Location = new System.Drawing.Point(307, 236);
            this.ll_ok.Name = "ll_ok";
            this.ll_ok.Size = new System.Drawing.Size(106, 13);
            this.ll_ok.TabIndex = 6;
            this.ll_ok.TabStop = true;
            this.ll_ok.Text = "Get on with our lives!";
            this.ll_ok.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_ok_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(134, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Credits && Mentions:";
            // 
            // l_credits
            // 
            this.l_credits.AutoEllipsis = true;
            this.l_credits.BackColor = System.Drawing.Color.White;
            this.l_credits.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_credits.Location = new System.Drawing.Point(136, 125);
            this.l_credits.Name = "l_credits";
            this.l_credits.Size = new System.Drawing.Size(277, 19);
            this.l_credits.TabIndex = 8;
            this.l_credits.Text = resources.GetString("l_credits.Text");
            // 
            // tm_scroller
            // 
            this.tm_scroller.Enabled = true;
            this.tm_scroller.Interval = 150;
            this.tm_scroller.Tick += new System.EventHandler(this.tm_scroller_Tick);
            // 
            // f_about
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Snow;
            this.BackgroundImage = global::SAMPCE.Properties.Resources.splsh;
            this.ClientSize = new System.Drawing.Size(425, 267);
            this.Controls.Add(this.l_credits);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ll_ok);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_about";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About SAM[P]CE";
            this.TransparencyKey = System.Drawing.Color.Snow;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel ll_ok;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label l_credits;
        private System.Windows.Forms.Timer tm_scroller;
    }
}