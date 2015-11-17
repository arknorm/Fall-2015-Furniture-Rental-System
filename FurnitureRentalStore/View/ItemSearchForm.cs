﻿using System;
using System.Windows.Forms;
using FurnitureRentalStore.Controller;

namespace FurnitureRentalStore.View
{
    public partial class ItemSearchForm : Form
    {

        private readonly ItemController itemController;

        public ItemSearchForm()
        {
            this.InitializeComponent();

            this.itemController = new ItemController();
        }

        private void styleSearchButton_Click(object sender, EventArgs e)
        {

            this.itemBindingSource.Clear();

            var items = this.itemController.GetByStyle(styleTextBox.Text);

            foreach (var item in items)
            {
                itemBindingSource.Add(item);
            }
        }

        private void catagorySearchButton_Click(object sender, EventArgs e)
        {

            itemBindingSource.Clear();

            var items = itemController.GetByCatagory(catagoryTextBox.Text);

            foreach (var item in items)
            {
                itemBindingSource.Add(item);
            }

        }

        private void idSearchButton_Click(object sender, EventArgs e)
        {

            itemBindingSource.Clear();

            int numVal = Int32.Parse(idTextBox.Text);

            var item = itemController.GetById(numVal);

            itemBindingSource.Add(item);
        }
    }
}