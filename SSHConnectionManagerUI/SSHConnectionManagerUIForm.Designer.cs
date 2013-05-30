namespace SSHConnectionManagerUI
{
    partial class SSHConnectionManagerUIForm
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
            this.HosttextBox = new System.Windows.Forms.TextBox();
            this.UsernametextBox = new System.Windows.Forms.TextBox();
            this.PasswordtextBox = new System.Windows.Forms.TextBox();
            this.PorttextBox = new System.Windows.Forms.TextBox();
            this.Hostlabel = new System.Windows.Forms.Label();
            this.Usernamelabel = new System.Windows.Forms.Label();
            this.Passwordlabel = new System.Windows.Forms.Label();
            this.Portlabel = new System.Windows.Forms.Label();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            this.NametextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HosttextBox
            // 
            this.HosttextBox.Location = new System.Drawing.Point(84, 40);
            this.HosttextBox.Name = "HosttextBox";
            this.HosttextBox.Size = new System.Drawing.Size(188, 20);
            this.HosttextBox.TabIndex = 1;
            // 
            // UsernametextBox
            // 
            this.UsernametextBox.Location = new System.Drawing.Point(84, 66);
            this.UsernametextBox.Name = "UsernametextBox";
            this.UsernametextBox.Size = new System.Drawing.Size(188, 20);
            this.UsernametextBox.TabIndex = 2;
            // 
            // PasswordtextBox
            // 
            this.PasswordtextBox.Location = new System.Drawing.Point(84, 92);
            this.PasswordtextBox.Name = "PasswordtextBox";
            this.PasswordtextBox.PasswordChar = '*';
            this.PasswordtextBox.Size = new System.Drawing.Size(188, 20);
            this.PasswordtextBox.TabIndex = 3;
            // 
            // PorttextBox
            // 
            this.PorttextBox.Location = new System.Drawing.Point(84, 118);
            this.PorttextBox.Name = "PorttextBox";
            this.PorttextBox.Size = new System.Drawing.Size(188, 20);
            this.PorttextBox.TabIndex = 4;
            // 
            // Hostlabel
            // 
            this.Hostlabel.AutoSize = true;
            this.Hostlabel.Location = new System.Drawing.Point(53, 43);
            this.Hostlabel.Name = "Hostlabel";
            this.Hostlabel.Size = new System.Drawing.Size(32, 13);
            this.Hostlabel.TabIndex = 4;
            this.Hostlabel.Text = "Host:";
            this.Hostlabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Usernamelabel
            // 
            this.Usernamelabel.AutoSize = true;
            this.Usernamelabel.Location = new System.Drawing.Point(27, 69);
            this.Usernamelabel.Name = "Usernamelabel";
            this.Usernamelabel.Size = new System.Drawing.Size(58, 13);
            this.Usernamelabel.TabIndex = 5;
            this.Usernamelabel.Text = "Username:";
            this.Usernamelabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Passwordlabel
            // 
            this.Passwordlabel.AutoSize = true;
            this.Passwordlabel.Location = new System.Drawing.Point(30, 95);
            this.Passwordlabel.Name = "Passwordlabel";
            this.Passwordlabel.Size = new System.Drawing.Size(56, 13);
            this.Passwordlabel.TabIndex = 6;
            this.Passwordlabel.Text = "Password:";
            this.Passwordlabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Portlabel
            // 
            this.Portlabel.AutoSize = true;
            this.Portlabel.Location = new System.Drawing.Point(57, 121);
            this.Portlabel.Name = "Portlabel";
            this.Portlabel.Size = new System.Drawing.Size(29, 13);
            this.Portlabel.TabIndex = 7;
            this.Portlabel.Text = "Port:";
            this.Portlabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Location = new System.Drawing.Point(197, 144);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelbutton.TabIndex = 9;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(116, 144);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 8;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // NametextBox
            // 
            this.NametextBox.Location = new System.Drawing.Point(84, 14);
            this.NametextBox.Name = "NametextBox";
            this.NametextBox.Size = new System.Drawing.Size(188, 20);
            this.NametextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SSHConnectionManagerUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 178);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NametextBox);
            this.Controls.Add(this.OKbutton);
            this.Controls.Add(this.Cancelbutton);
            this.Controls.Add(this.Portlabel);
            this.Controls.Add(this.Passwordlabel);
            this.Controls.Add(this.Usernamelabel);
            this.Controls.Add(this.Hostlabel);
            this.Controls.Add(this.PorttextBox);
            this.Controls.Add(this.PasswordtextBox);
            this.Controls.Add(this.UsernametextBox);
            this.Controls.Add(this.HosttextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SSHConnectionManagerUIForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "SSHConnectionManager";
            this.Load += new System.EventHandler(this.SSHConnectionManagerUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HosttextBox;
        private System.Windows.Forms.TextBox UsernametextBox;
        private System.Windows.Forms.TextBox PasswordtextBox;
        private System.Windows.Forms.TextBox PorttextBox;
        private System.Windows.Forms.Label Hostlabel;
        private System.Windows.Forms.Label Usernamelabel;
        private System.Windows.Forms.Label Passwordlabel;
        private System.Windows.Forms.Label Portlabel;
        private System.Windows.Forms.Button Cancelbutton;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.TextBox NametextBox;
        private System.Windows.Forms.Label label1;
    }
}