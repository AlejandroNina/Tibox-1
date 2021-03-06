﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;
using Dapper.Contrib.Extensions;
using Dapper;

namespace Tibox.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public Customer SearchByNames(string firstName, string lastName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@firstName", firstName);
                parameters.Add("@lastName", lastName);

                return connection
                        .QueryFirst<Customer>("dbo.SearchByNames", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Customer CustomerWithOrders(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@customerId", id);
                using (var multi = connection.QueryMultiple("dbo.CustomerWithOrders", parameters, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var profile = multi.Read<Customer>().Single();
                    profile.Orders = multi.Read<Order>();
                    return profile;
                }                
            }
        }
    }
}
