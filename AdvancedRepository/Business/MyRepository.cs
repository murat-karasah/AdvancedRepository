using AdvancedRepository.Models;
using AdvancedRepository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedRepository.Business
{
    public class MyRepository
    {
      public class CategoriesRepository : BaseRepository<Categories>
        {

        }
        public class ProductsRepository : BaseRepository<Products>
        {

        }
        public class CustomersRepository : BaseRepository<Customers>
        {

        }

    }
}