namespace FurnitureRentalStore.View
{
    partial class MemberSearchForm
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
            this.fsd = new System.Windows.Forms.Label();
            this.dsf = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.dsfds = new System.Windows.Forms.Label();
            this.fdsf = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.memberIDLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.emailLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fsd
            // 
            this.fsd.AutoSize = true;
            this.fsd.Location = new System.Drawing.Point(55, 15);
            this.fsd.Name = "fsd";
            this.fsd.Size = new System.Drawing.Size(38, 13);
            this.fsd.TabIndex = 0;
            this.fsd.Text = "Name:";
            // 
            // dsf
            // 
            this.dsf.AutoSize = true;
            this.dsf.Location = new System.Drawing.Point(12, 40);
            this.dsf.Name = "dsf";
            this.dsf.Size = new System.Drawing.Size(81, 13);
            this.dsf.TabIndex = 1;
            this.dsf.Text = "Phone Number:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(98, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(100, 20);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Location = new System.Drawing.Point(98, 37);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(100, 20);
            this.phoneTextBox.TabIndex = 3;
            this.phoneTextBox.TextChanged += new System.EventHandler(this.phoneTextBox_TextChanged);
            // 
            // dsfds
            // 
            this.dsfds.AutoSize = true;
            this.dsfds.Location = new System.Drawing.Point(31, 110);
            this.dsfds.Name = "dsfds";
            this.dsfds.Size = new System.Drawing.Size(62, 13);
            this.dsfds.TabIndex = 4;
            this.dsfds.Text = "Member ID:";
            // 
            // fdsf
            // 
            this.fdsf.AutoSize = true;
            this.fdsf.Location = new System.Drawing.Point(53, 133);
            this.fdsf.Name = "fdsf";
            this.fdsf.Size = new System.Drawing.Size(38, 13);
            this.fdsf.TabIndex = 6;
            this.fdsf.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Address:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Phone: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "E-Mail:";
            // 
            // searchButton
            // 
            this.searchButton.Enabled = false;
            this.searchButton.Location = new System.Drawing.Point(204, 35);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 16;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // memberIDLabel
            // 
            this.memberIDLabel.AutoSize = true;
            this.memberIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memberIDLabel.Location = new System.Drawing.Point(100, 110);
            this.memberIDLabel.Name = "memberIDLabel";
            this.memberIDLabel.Size = new System.Drawing.Size(35, 13);
            this.memberIDLabel.TabIndex = 17;
            this.memberIDLabel.Text = "label2";
            this.memberIDLabel.Visible = false;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLabel.Location = new System.Drawing.Point(100, 133);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(35, 13);
            this.nameLabel.TabIndex = 18;
            this.nameLabel.Text = "label2";
            this.nameLabel.Visible = false;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.Location = new System.Drawing.Point(100, 162);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(35, 13);
            this.emailLabel.TabIndex = 19;
            this.emailLabel.Text = "label2";
            this.emailLabel.Visible = false;
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneLabel.Location = new System.Drawing.Point(100, 186);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(35, 13);
            this.phoneLabel.TabIndex = 20;
            this.phoneLabel.Text = "label2";
            this.phoneLabel.Visible = false;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressLabel.Location = new System.Drawing.Point(100, 210);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(35, 13);
            this.addressLabel.TabIndex = 21;
            this.addressLabel.Text = "label2";
            this.addressLabel.Visible = false;
            // 
            // MemberSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.phoneLabel);
            this.Controls.Add(this.emailLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.memberIDLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fdsf);
            this.Controls.Add(this.dsfds);
            this.Controls.Add(this.phoneTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.dsf);
            this.Controls.Add(this.fsd);
            this.Name = "MemberSearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search for members";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label fsd;
        private System.Windows.Forms.Label dsf;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.Label dsfds;
        private System.Windows.Forms.Label fdsf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label memberIDLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label addressLabel;
    }
}