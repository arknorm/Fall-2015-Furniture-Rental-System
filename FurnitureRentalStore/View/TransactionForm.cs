using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FurnitureRentalStore.Controller;
using FurnitureRentalStore.Model;

namespace FurnitureRentalStore.View
{
    public partial class TransactionForm : Form
    {
        private List<Item> items;
        private readonly RentalController rentalController;


        public TransactionForm()
        {
            this.InitializeComponent();
            this.rentalController = new RentalController();

        }

        public void GetListOfItems(List<Item> updatedItems)
        {
            this.items = updatedItems;

            foreach (var item in this.items)
            {
                if (!this.itemBindingSource.Contains(item))
                {
                    this.itemBindingSource.Add(item);
                }
            }

            this.cartDataGridView.Update();
            this.cartDataGridView.Refresh();
        }

        private void checkoutButton_Click(object sender, EventArgs e)
        {
            var transactionTotal = 0.0;

            var transaction = new RentalTransaction
            {
                EmployeeId = LogInForm.LoggedInEmployee.EmployeeId,
                MemberId = Convert.ToInt32(ItemSearchForm.MemberId),
                Date = DateTime.Now,
                TotalPrice = 0
            };
            this.rentalController.AddRentalTransaction(transaction);

            foreach (DataGridViewRow row in this.cartDataGridView.Rows)
            {
                var itemId = Convert.ToInt32(row.Cells[0].Value);
                var quantity = Convert.ToInt32(row.Cells[6].Value);
                var duration = Convert.ToInt32(row.Cells[7].Value);
                var dailyRate = Convert.ToDouble(row.Cells[4].Value);

                var rental = new Rental
                {
                    RentalTransactionId = this.rentalController.GetLastInsertedTransactionId(),
                    ItemId = Convert.ToInt32(itemId),
                    RentalTotal = (dailyRate * duration) * quantity,
                    DueDate = DateTime.Now.AddDays(Convert.ToDouble(duration)),
                    QuantityRented = Convert.ToInt32(quantity)
                };
                transactionTotal += rental.RentalTotal;
                this.rentalController.AddRental(rental);
            }

            this.rentalController.UpdateRentalTransactionTotalPrice(transactionTotal);

            MessageBox.Show("Rental successfull.");
            Dispose();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.cartDataGridView.SelectedRows)
            {
                this.cartDataGridView.Rows.Remove(item);
            }

            this.cartDataGridView.Update();
            this.cartDataGridView.Refresh();
        }

        private void cartDataGridView_Click(object sender, EventArgs e)
        {
            this.deleteButton.Enabled = true;
        }
    }
}
