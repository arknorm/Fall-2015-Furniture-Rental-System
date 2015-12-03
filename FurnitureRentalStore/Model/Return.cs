using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureRentalStore.Model
{
    class Return
    {
        /// <summary>
        /// Gets or sets the return transaction identifier.
        /// </summary>
        /// <value>
        /// The return transaction identifier.
        /// </value>
        public int ReturnTransactionId { get; set; }

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
        /// Gets or sets the fine total.
        /// </summary>
        /// <value>
        /// The fine total.
        /// </value>
        public double FineTotal { get; set; }

        /// <summary>
        /// Gets or sets the quantity returned.
        /// </summary>
        /// <value>
        /// The quantity returned.
        /// </value>
        public int QuantityReturned { get; set; }
    }
}
