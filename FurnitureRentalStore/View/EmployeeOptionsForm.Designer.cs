namespace FurnitureRentalStore.View
{
    partial class EmployeeOptionsForm
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
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.registerCustomerButton = new System.Windows.Forms.Button();
            this.itemSearchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Location = new System.Drawing.Point(13, 13);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(35, 13);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "label1";
            // 
            // registerCustomerButton
            // 
            this.registerCustomerButton.Location = new System.Drawing.Point(76, 55);
            this.registerCustomerButton.Name = "registerCustomerButton";
            this.registerCustomerButton.Size = new System.Drawing.Size(117, 23);
            this.registerCustomerButton.TabIndex = 1;
            this.registerCustomerButton.Text = "Register Customer";
            this.registerCustomerButton.UseVisualStyleBackColor = true;
            this.registerCustomerButton.Click += new System.EventHandler(this.registerCustomerButton_Click);
            // 
            // itemSearchButton
            // 
            this.itemSearchButton.Location = new System.Drawing.Point(76, 84);
            this.itemSearchButton.Name = "itemSearchButton";
            this.itemSearchButton.Size = new System.Drawing.Size(117, 23);
            this.itemSearchButton.TabIndex = 2;
            this.itemSearchButton.Text = "Item Search";
            this.itemSearchButton.UseVisualStyleBackColor = true;
            this.itemSearchButton.Click += new System.EventHandler(this.itemSearchButton_Click);
            // 
            // EmployeeOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.itemSearchButton);
            this.Controls.Add(this.registerCustomerButton);
            this.Controls.Add(this.welcomeLabel);
            this.Name = "EmployeeOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Button registerCustomerButton;
        private System.Windows.Forms.Button itemSearchButton;
    }
}