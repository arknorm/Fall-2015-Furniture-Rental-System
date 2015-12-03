using System.Collections.Generic;
using FurnitureRentalStore.DAL.Repository;
using FurnitureRentalStore.Model;

namespace FurnitureRentalStore.Controller
{
    class RentalController
    {
        private readonly RentalRepository rentalRepository;
        private readonly RentalTransactionRepository rentalTransactionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RentalController"/> class.
        /// </summary>
        public RentalController()
        {
            this.rentalRepository = new RentalRepository();
            this.rentalTransactionRepository = new RentalTransactionRepository();
        }

        /// <summary>
        /// Adds the specified rental.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        public void AddRentalTransaction(RentalTransaction transaction)
        {
            this.rentalTransactionRepository.Add(transaction);
        }

        public void AddRental(Rental rental)
        {
            this.rentalRepository.Add(rental);
        }

        public List<RentalTransaction> GetAll()
        {
            return this.rentalTransactionRepository.GetAll();
        }

        public void UpdateRentalTransactionTotalPrice(double price)
        {
            this.rentalTransactionRepository.UpdateRentalTransactionPrice(price);
        }

        public int GetLastInsertedTransactionId()
        {
            return this.rentalTransactionRepository.GetTransactionId();
        }

        public List<Rental> GetAllRentals()
        {
            return this.rentalRepository.GetAll();
        } 
    }
}
