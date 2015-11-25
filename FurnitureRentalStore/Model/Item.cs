namespace FurnitureRentalStore.Model
{
    public class Item
    {

        /// <summary>
        /// Gets or sets the ItemID.
        /// </summary>
        /// <value>
        /// The ItemID.
        /// </value>
        public int ItemID { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the style.
        /// </summary>
        /// <value>
        /// The style.
        /// </value>
        public string Style { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the daily rate.
        /// </summary>
        /// <value>
        /// The daily rate.
        /// </value>
        public double DailyRate { get; set; }

        /// <summary>
        /// Gets or sets the fine rate.
        /// </summary>
        /// <value>
        /// The fine rate.
        /// </value>
        public double FineRate { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>
        /// The quantity.
        /// </value>
        public int Quantity { get; set; }
    }
}

