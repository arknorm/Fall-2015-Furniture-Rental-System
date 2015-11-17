using System;

namespace FurnitureRentalStore.Model
{
    class RentalTransaction
    {
        /// <summary>
        /// Gets or sets the rental transaction identifier.
        /// </summary>
        /// <value>
        /// The rental transaction identifier.
        /// </value>
        public int RentalTransactionId { get; set; }

        /// <summary>
        /// Gets or sets the employee identifier.
        /// </summary>
        /// <value>
        /// The employee identifier.
        /// </value>
        public int EmployeeId { get; set; }

        /// <summary>
        /// Gets or sets the member identifier.
        /// </summary>
        /// <value>
        /// The member identifier.
        /// </value>
        public int MemberId { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the total price.
        /// </summary>
        /// <value>
        /// The total price.
        /// </value>
        public double TotalPrice { get; set; }
    }
}
