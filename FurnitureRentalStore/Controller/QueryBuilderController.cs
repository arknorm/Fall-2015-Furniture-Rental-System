using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureRentalStore.DAL.Repository;

namespace FurnitureRentalStore.Controller
{
    class QueryBuilderController
    {

        private QueryBuilderRepository repository;

        public QueryBuilderController()
        {
            this.repository = new QueryBuilderRepository();
        }

        public DataTable GetQueryResults(string query)
        {
            return this.repository.GetQueryResults(query);
        }
    }
}
