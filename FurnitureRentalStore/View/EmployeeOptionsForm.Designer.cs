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
            this.logOutButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.adminBox = new System.Windows.Forms.GroupBox();
            this.queryBuilderButton = new System.Windows.Forms.Button();
            this.manageItemsButton = new System.Windows.Forms.Button();
            this.manageEmployeesButton = new System.Windows.Forms.Button();
            this.returnButton = new System.Windows.Forms.Button();
            this.adminBox.SuspendLayout();
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
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(197, 8);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(75, 23);
            this.logOutButton.TabIndex = 3;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(76, 113);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(117, 23);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Search for Members";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // adminBox
            // 
            this.adminBox.Controls.Add(this.queryBuilderButton);
            this.adminBox.Controls.Add(this.manageItemsButton);
            this.adminBox.Controls.Add(this.manageEmployeesButton);
            this.adminBox.Enabled = false;
            this.adminBox.Location = new System.Drawing.Point(40, 190);
            this.adminBox.Name = "adminBox";
            this.adminBox.Size = new System.Drawing.Size(184, 113);
            this.adminBox.TabIndex = 5;
            this.adminBox.TabStop = false;
            this.adminBox.Text = "Admin Options";
            // 
            // queryBuilderButton
            // 
            this.queryBuilderButton.Location = new System.Drawing.Point(36, 78);
            this.queryBuilderButton.Name = "queryBuilderButton";
            this.queryBuilderButton.Size = new System.Drawing.Size(116, 23);
            this.queryBuilderButton.TabIndex = 2;
            this.queryBuilderButton.Text = "Query Builder";
            this.queryBuilderButton.UseVisualStyleBackColor = true;
            this.queryBuilderButton.Click += new System.EventHandler(this.queryBuilderButton_Click);
            // 
            // manageItemsButton
            // 
            this.manageItemsButton.Location = new System.Drawing.Point(36, 48);
            this.manageItemsButton.Name = "manageItemsButton";
            this.manageItemsButton.Size = new System.Drawing.Size(117, 23);
            this.manageItemsButton.TabIndex = 1;
            this.manageItemsButton.Text = "Manage Items";
            this.manageItemsButton.UseVisualStyleBackColor = true;
            this.manageItemsButton.Click += new System.EventHandler(this.manageItemsButton_Click);
            // 
            // manageEmployeesButton
            // 
            this.manageEmployeesButton.Location = new System.Drawing.Point(36, 19);
            this.manageEmployeesButton.Name = "manageEmployeesButton";
            this.manageEmployeesButton.Size = new System.Drawing.Size(117, 23);
            this.manageEmployeesButton.TabIndex = 0;
            this.manageEmployeesButton.Text = "Manage Employees";
            this.manageEmployeesButton.UseVisualStyleBackColor = true;
            this.manageEmployeesButton.Click += new System.EventHandler(this.manageEmployeesButton_Click);
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(76, 142);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(117, 23);
            this.returnButton.TabIndex = 6;
            this.returnButton.Text = "Return";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // EmployeeOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 315);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.adminBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.itemSearchButton);
            this.Controls.Add(this.registerCustomerButton);
            this.Controls.Add(this.welcomeLabel);
            this.Name = "EmployeeOptionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee Options";
            this.adminBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.Button registerCustomerButton;
        private System.Windows.Forms.Button itemSearchButton;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.GroupBox adminBox;
        private System.Windows.Forms.Button queryBuilderButton;
        private System.Windows.Forms.Button manageItemsButton;
        private System.Windows.Forms.Button manageEmployeesButton;
        private System.Windows.Forms.Button returnButton;
    }
}