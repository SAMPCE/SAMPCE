namespace SAMPCE
{
    partial class f_ibox
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
            this.l_msg = new System.Windows.Forms.Label();
            this.t_res = new System.Windows.Forms.TextBox();
            this.b_ok = new System.Windows.Forms.Button();
            this.b_cncl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // l_msg
            // 
            this.l_msg.Location = new System.Drawing.Point(12, 9);
            this.l_msg.Name = "l_msg";
            this.l_msg.Size = new System.Drawing.Size(247, 15);
            this.l_msg.TabIndex = 0;
            this.l_msg.Text = "label1";
            // 
            // t_res
            // 
            this.t_res.Location = new System.Drawing.Point(15, 27);
            this.t_res.Name = "t_res";
            this.t_res.Size = new System.Drawing.Size(244, 20);
            this.t_res.TabIndex = 1;
            this.t_res.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.t_res_KeyPress);
            // 
            // b_ok
            // 
            this.b_ok.Location = new System.Drawing.Point(103, 53);
            this.b_ok.Name = "b_ok";
            this.b_ok.Size = new System.Drawing.Size(75, 23);
            this.b_ok.TabIndex = 2;
            this.b_ok.Text = "Ok";
            this.b_ok.UseVisualStyleBackColor = true;
            this.b_ok.Click += new System.EventHandler(this.b_ok_Click);
            // 
            // b_cncl
            // 
            this.b_cncl.Location = new System.Drawing.Point(184, 53);
            this.b_cncl.Name = "b_cncl";
            this.b_cncl.Size = new System.Drawing.Size(75, 23);
            this.b_cncl.TabIndex = 3;
            this.b_cncl.Text = "Cancel";
            this.b_cncl.UseVisualStyleBackColor = true;
            this.b_cncl.Click += new System.EventHandler(this.b_cncl_Click);
            // 
            // f_ibox
            // 
            this.AcceptButton = this.b_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.b_cncl;
            this.ClientSize = new System.Drawing.Size(271, 85);
            this.Controls.Add(this.b_cncl);
            this.Controls.Add(this.b_ok);
            this.Controls.Add(this.t_res);
            this.Controls.Add(this.l_msg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "f_ibox";
            this.Text = "Title";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_msg;
        private System.Windows.Forms.TextBox t_res;
        private System.Windows.Forms.Button b_ok;
        private System.Windows.Forms.Button b_cncl;
    }
}