namespace FurnitureRentalStore.View
{
    partial class QueryBuilderForm
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
            this.queryBuilderDataGridView = new System.Windows.Forms.DataGridView();
            this.queryTextBox = new System.Windows.Forms.RichTextBox();
            this.executeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.queryBuilderDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // queryBuilderDataGridView
            // 
            this.queryBuilderDataGridView.AllowUserToAddRows = false;
            this.queryBuilderDataGridView.AllowUserToDeleteRows = false;
            this.queryBuilderDataGridView.AllowUserToResizeRows = false;
            this.queryBuilderDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.queryBuilderDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.queryBuilderDataGridView.Location = new System.Drawing.Point(12, 12);
            this.queryBuilderDataGridView.Name = "queryBuilderDataGridView";
            this.queryBuilderDataGridView.ReadOnly = true;
            this.queryBuilderDataGridView.RowHeadersVisible = false;
            this.queryBuilderDataGridView.Size = new System.Drawing.Size(685, 236);
            this.queryBuilderDataGridView.TabIndex = 0;
            // 
            // queryTextBox
            // 
            this.queryTextBox.Location = new System.Drawing.Point(12, 254);
            this.queryTextBox.Name = "queryTextBox";
            this.queryTextBox.Size = new System.Drawing.Size(685, 168);
            this.queryTextBox.TabIndex = 1;
            this.queryTextBox.Text = "";
            // 
            // executeButton
            // 
            this.executeButton.Location = new System.Drawing.Point(13, 429);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(99, 23);
            this.executeButton.TabIndex = 2;
            this.executeButton.Text = "Execute Query";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // QueryBuilderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 468);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.queryTextBox);
            this.Controls.Add(this.queryBuilderDataGridView);
            this.Name = "QueryBuilderForm";
            this.Text = "QueryBuilderForm";
            ((System.ComponentModel.ISupportInitialize)(this.queryBuilderDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView queryBuilderDataGridView;
        private System.Windows.Forms.RichTextBox queryTextBox;
        private System.Windows.Forms.Button executeButton;
    }
}