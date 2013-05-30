namespace SSHFTPTaskUI
{
    partial class SSHFTPTaskUIForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.OperationTypecomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SendFilesPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SendFilesDestinationdirectorytextBox = new System.Windows.Forms.TextBox();
            this.SendFilesSourceConnectioncomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ReceiveFilesPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DestinationConnectioncomboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ReceiveFilesSourceFiletextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SSHConnectioncomboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.OKbutton = new System.Windows.Forms.Button();
            this.Cancelbutton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SendFilesPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ReceiveFilesPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.OperationTypecomboBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(523, 27);
            this.panel1.TabIndex = 0;
            // 
            // OperationTypecomboBox
            // 
            this.OperationTypecomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OperationTypecomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.OperationTypecomboBox.FormattingEnabled = true;
            this.OperationTypecomboBox.Items.AddRange(new object[] {
            "Send Files",
            "Receive Files"});
            this.OperationTypecomboBox.Location = new System.Drawing.Point(95, 3);
            this.OperationTypecomboBox.Name = "OperationTypecomboBox";
            this.OperationTypecomboBox.Size = new System.Drawing.Size(425, 21);
            this.OperationTypecomboBox.TabIndex = 2;
            this.OperationTypecomboBox.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Operation Type: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SendFilesPanel
            // 
            this.SendFilesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SendFilesPanel.BackColor = System.Drawing.SystemColors.Control;
            this.SendFilesPanel.Controls.Add(this.groupBox1);
            this.SendFilesPanel.Location = new System.Drawing.Point(13, 80);
            this.SendFilesPanel.Name = "SendFilesPanel";
            this.SendFilesPanel.Size = new System.Drawing.Size(523, 80);
            this.SendFilesPanel.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.SendFilesDestinationdirectorytextBox);
            this.groupBox1.Controls.Add(this.SendFilesSourceConnectioncomboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Send Files";
            // 
            // SendFilesDestinationdirectorytextBox
            // 
            this.SendFilesDestinationdirectorytextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SendFilesDestinationdirectorytextBox.Location = new System.Drawing.Point(120, 40);
            this.SendFilesDestinationdirectorytextBox.Name = "SendFilesDestinationdirectorytextBox";
            this.SendFilesDestinationdirectorytextBox.Size = new System.Drawing.Size(388, 20);
            this.SendFilesDestinationdirectorytextBox.TabIndex = 3;
            // 
            // SendFilesSourceConnectioncomboBox
            // 
            this.SendFilesSourceConnectioncomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SendFilesSourceConnectioncomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SendFilesSourceConnectioncomboBox.FormattingEnabled = true;
            this.SendFilesSourceConnectioncomboBox.Location = new System.Drawing.Point(113, 13);
            this.SendFilesSourceConnectioncomboBox.Name = "SendFilesSourceConnectioncomboBox";
            this.SendFilesSourceConnectioncomboBox.Size = new System.Drawing.Size(395, 21);
            this.SendFilesSourceConnectioncomboBox.TabIndex = 2;
            this.SendFilesSourceConnectioncomboBox.SelectedIndexChanged += new System.EventHandler(this.SendFilesSourceConnectioncomboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Destination Directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Source Connection:";
            // 
            // ReceiveFilesPanel
            // 
            this.ReceiveFilesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ReceiveFilesPanel.BackColor = System.Drawing.SystemColors.Control;
            this.ReceiveFilesPanel.Controls.Add(this.groupBox2);
            this.ReceiveFilesPanel.Location = new System.Drawing.Point(13, 166);
            this.ReceiveFilesPanel.Name = "ReceiveFilesPanel";
            this.ReceiveFilesPanel.Size = new System.Drawing.Size(523, 78);
            this.ReceiveFilesPanel.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.DestinationConnectioncomboBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.ReceiveFilesSourceFiletextBox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(6, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(514, 68);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Receive Files";
            // 
            // DestinationConnectioncomboBox
            // 
            this.DestinationConnectioncomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DestinationConnectioncomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DestinationConnectioncomboBox.FormattingEnabled = true;
            this.DestinationConnectioncomboBox.Location = new System.Drawing.Point(132, 39);
            this.DestinationConnectioncomboBox.Name = "DestinationConnectioncomboBox";
            this.DestinationConnectioncomboBox.Size = new System.Drawing.Size(376, 21);
            this.DestinationConnectioncomboBox.TabIndex = 3;
            this.DestinationConnectioncomboBox.SelectedIndexChanged += new System.EventHandler(this.DestinationConnectioncomboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Destination Connection:";
            // 
            // ReceiveFilesSourceFiletextBox
            // 
            this.ReceiveFilesSourceFiletextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ReceiveFilesSourceFiletextBox.Location = new System.Drawing.Point(75, 13);
            this.ReceiveFilesSourceFiletextBox.Name = "ReceiveFilesSourceFiletextBox";
            this.ReceiveFilesSourceFiletextBox.Size = new System.Drawing.Size(433, 20);
            this.ReceiveFilesSourceFiletextBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Source File:";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.SSHConnectioncomboBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(13, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(523, 27);
            this.panel2.TabIndex = 3;
            // 
            // SSHConnectioncomboBox
            // 
            this.SSHConnectioncomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SSHConnectioncomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SSHConnectioncomboBox.FormattingEnabled = true;
            this.SSHConnectioncomboBox.Location = new System.Drawing.Point(98, 3);
            this.SSHConnectioncomboBox.Name = "SSHConnectioncomboBox";
            this.SSHConnectioncomboBox.Size = new System.Drawing.Size(422, 21);
            this.SSHConnectioncomboBox.TabIndex = 1;
            this.SSHConnectioncomboBox.SelectedIndexChanged += new System.EventHandler(this.SSHConnectioncomboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "SSH Connection:";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.OKbutton);
            this.panel3.Controls.Add(this.Cancelbutton);
            this.panel3.Location = new System.Drawing.Point(13, 250);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(523, 29);
            this.panel3.TabIndex = 4;
            // 
            // OKbutton
            // 
            this.OKbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKbutton.Location = new System.Drawing.Point(364, 3);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 0;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            this.OKbutton.Click += new System.EventHandler(this.OKbutton_Click);
            // 
            // Cancelbutton
            // 
            this.Cancelbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cancelbutton.Location = new System.Drawing.Point(445, 3);
            this.Cancelbutton.Name = "Cancelbutton";
            this.Cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.Cancelbutton.TabIndex = 1;
            this.Cancelbutton.Text = "Cancel";
            this.Cancelbutton.UseVisualStyleBackColor = true;
            this.Cancelbutton.Click += new System.EventHandler(this.Cancelbutton_Click);
            // 
            // SSHFTPTaskUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 292);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ReceiveFilesPanel);
            this.Controls.Add(this.SendFilesPanel);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(564, 330);
            this.Name = "SSHFTPTaskUIForm";
            this.Text = "SSH FTP Task";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.SendFilesPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ReceiveFilesPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox OperationTypecomboBox;
        private System.Windows.Forms.Panel SendFilesPanel;
        private System.Windows.Forms.Panel ReceiveFilesPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox SendFilesSourceConnectioncomboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SendFilesDestinationdirectorytextBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox DestinationConnectioncomboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ReceiveFilesSourceFiletextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox SSHConnectioncomboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button OKbutton;
        private System.Windows.Forms.Button Cancelbutton;
    }
}