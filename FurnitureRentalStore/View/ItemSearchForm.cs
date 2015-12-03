using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using FurnitureRentalStore.Controller;
using FurnitureRentalStore.Model;
using FurnitureRentalStore.View.DialogBox;

namespace FurnitureRentalStore.View
{
    public partial class ItemSearchForm : Form
    {
        public static int MemberId;
        //delegates to update list 
        public delegate void ListOfItemsInCart(List<Item> items);
        public ListOfItemsInCart Items;

        private readonly ItemController itemController;
        private readonly List<Item> cartItems;
        private readonly TransactionForm cart;
        private int count = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemSearchForm"/> class.
        /// </summary>
        public ItemSearchForm()
        {
            this.InitializeComponent();

            this.itemController = new ItemController();
            this.cartItems = new List<Item>();
            this.cart = new TransactionForm();
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
        /// Handles the Click event of the categorySearchButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void categorySearchButton_Click(object sender, EventArgs e)
        {
            this.itemBindingSource.Clear();

            var items = this.itemController.GetBycategory(this.categoryTextBox.Text);

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

        private void itemDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.itemDataGridView.ClearSelection();
        }

        private void memberIDTextBox_TextChanged(object sender, EventArgs e)
        {
            MemberId = Convert.ToInt32(this.memberIDTextBox.Text);
            this.addCartButton.Enabled = (this.itemDataGridView.SelectedRows.Count > 0) && !string.IsNullOrWhiteSpace(this.memberIDTextBox.Text);
        }

        private void itemDataGridView_Click(object sender, EventArgs e)
        {
            this.addCartButton.Enabled = (this.itemDataGridView.SelectedRows.Count > 0) && !string.IsNullOrWhiteSpace(this.memberIDTextBox.Text);
        }

        private void addCartButton_Click(object sender, EventArgs e)
        {
            this.Items += this.cart.GetListOfItems;

            foreach (DataGridViewRow row in this.itemDataGridView.SelectedRows)
            {
                Item item = row.DataBoundItem as Item;
                if (item != null)
                {
                    this.cartItems.Add(item);
                }
            }

            //Notify the subscribers
            this.Items(this.cartItems);

            var successfulDialog = new SuccessfulRentalDialogBox { StartPosition = FormStartPosition.CenterScreen };

            successfulDialog.ShowDialog(this);
            successfulDialog.Dispose();
        }

        private void viewCartButton_Click(object sender, EventArgs e)
        {
            this.viewCartButton.Enabled = false;
            this.cart.Show();
        }
    }
}
