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
    public partial class ManageItemsForm : Form
    {
        private readonly ItemController itemController;

        public ManageItemsForm()
        {
            InitializeComponent();

            this.itemController = new ItemController();

            populateDataGridView(this.itemController.GetAllItems());

            this.editItemButton.Enabled = false;
            this.deleteItemButton.Enabled = false;
        }

        private void populateDataGridView(List<Item> items)
        {
            this.itemBindingSource.Clear();

            foreach (var item in items)
            {
                this.itemBindingSource.Add(item);
            }
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            new ItemSetupForm().Show();

            Dispose();
        }

        private void editItemButton_Click(object sender, EventArgs e)
        {

            DataGridViewRow selectedRow = itemDataGridView.SelectedRows[0];

            int itemID = Int32.Parse(selectedRow.Cells["itemIdDataGridViewTextBoxColumn"].Value.ToString());

            Item anItem = this.itemController.GetById(itemID);

            new ItemUpdateForm(anItem).Show();

            Dispose();


        }

        private void deleteItemButton_Click(object sender, EventArgs e)
        {


            DataGridViewRow selectedRow = itemDataGridView.SelectedRows[0];

            int itemID = Int32.Parse(selectedRow.Cells["itemIdDataGridViewTextBoxColumn"].Value.ToString());

            itemController.DeleteItem(itemID);

            populateDataGridView(this.itemController.GetAllItems());
        }

        private void employeeDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            this.editItemButton.Enabled = true;
            this.deleteItemButton.Enabled = true;
        }
    }
}

