using System;

namespace FurnitureRentalStore.Model
{
    class Rental
    {
        /// <summary>
        /// Gets or sets the rental transaction identifier.
        /// </summary>
        /// <value>
        /// The rental transaction identifier.
        /// </value>
        public int RentalTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the item identifier.
        /// </summary>
        /// <value>
        /// The item identifier.
        /// </value>
        public int ItemId { get; set; }

        /// <summary>
        /// Gets or sets the rental total.
        /// </summary>
        /// <value>
        /// The rental total.
        /// </value>
        public double RentalTotal { get; set; }

        /// <summary>
        /// Gets or sets the due date.
        /// </summary>
        /// <value>
        /// The due date.
        /// </value>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Gets or sets the quantity rented.
        /// </summary>
        /// <value>
        /// The quantity rented.
        /// </value>
        public int QuantityRented { get; set; }
    }
}
