namespace FurnitureRentalStore.View.DialogBox
{
    partial class SuccessfulRentalDialogBox
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
            this.rentSuccessLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rentSuccessLabel
            // 
            this.rentSuccessLabel.AutoSize = true;
            this.rentSuccessLabel.Location = new System.Drawing.Point(23, 31);
            this.rentSuccessLabel.Name = "rentSuccessLabel";
            this.rentSuccessLabel.Size = new System.Drawing.Size(238, 13);
            this.rentSuccessLabel.TabIndex = 0;
            this.rentSuccessLabel.Text = "You have successfully added item(s) to your cart!";
            // 
            // SuccessfulRentalDialogBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 74);
            this.Controls.Add(this.rentSuccessLabel);
            this.Name = "SuccessfulRentalDialogBox";
            this.Text = "Success!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label rentSuccessLabel;
    }
}