using System;
using System.Windows.Forms;
using FurnitureRentalStore.Controller;
using FurnitureRentalStore.Model;
using FurnitureRentalStore.View.DialogBox;

namespace FurnitureRentalStore.View
{
    public partial class ItemSearchForm : Form
    {

        private readonly ItemController itemController;
        private readonly RentalController rentalController;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemSearchForm"/> class.
        /// </summary>
        public ItemSearchForm()
        {
            this.InitializeComponent();

            this.itemController = new ItemController();
            this.rentalController = new RentalController();

        }

        /// <summary>
        /// Handles the Click event of the styleSearchButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void styleSearchButton_Click(object sender, EventArgs e)
        {
            this.itemBindingSource.Clear();

            var items = this.itemController.GetByStyle(this.styleTextBox.Text);

            foreach (var item in items)
            {
                this.itemBindingSource.Add(item);
            }
        }

        /// <summary>
        /// Handles the Click event of the catagorySearchButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void catagorySearchButton_Click(object sender, EventArgs e)
        {
            this.itemBindingSource.Clear();

            var items = this.itemController.GetByCatagory(this.catagoryTextBox.Text);

            foreach (var item in items)
            {
                this.itemBindingSource.Add(item);
            }
        }

        /// <summary>
        /// Handles the Click event of the idSearchButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void idSearchButton_Click(object sender, EventArgs e)
        {
            this.itemBindingSource.Clear();

            int numVal = Int32.Parse(this.idTextBox.Text);

            var item = this.itemController.GetById(numVal);

            this.itemBindingSource.Add(item);
        }

        /// <summary>
        /// Handles the Click event of the rentItemButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void rentItemButton_Click(object sender, EventArgs e)
        {
            var transaction = new RentalTransaction
            {
                EmployeeId = 1,
                MemberId = 8,
                Date = DateTime.Now,
                TotalPrice = 0
            };

            this.rentalController.AddRentalTransaction(transaction);

            foreach (DataGridViewRow row in this.itemDataGridView.SelectedRows)
            {
                var itemId = row.Cells[0].Value;

                var rental = new Rental
                {
                    RentalTransactionId = this.rentalController.GetLastInsertedTransactionId(),
                    ItemId = Convert.ToInt32(itemId),
                    RentalTotal = 0,
                    DueDate = new DateTime(),
                    QuantityRented = this.itemDataGridView.SelectedRows.Count
                };
                this.rentalController.AddRental(rental);
            }

            var successfulDialog = new SuccessfulRentalDialogBox { StartPosition = FormStartPosition.CenterScreen };

            successfulDialog.ShowDialog(this);
            successfulDialog.Dispose();
            Dispose();
        }

        private void itemDataGridView_Click(object sender, EventArgs e)
        {
            this.rentItemButton.Enabled = (this.itemDataGridView.SelectedRows.Count > 0);
        }

        private void itemDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.itemDataGridView.ClearSelection();
        }
    }
}
