using CustomerInquiry.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiryTestClass
{
    public class InMemoryDbContextFactory
    {
        public ApplicationDbContext GetApplicationDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                            .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                            .Options;
            var dbContext = new ApplicationDbContext(options);

            return dbContext;
        }
    }
}
