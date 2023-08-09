using System;
using Microsoft.EntityFrameworkCore;
using warteg.Models;
using warteg.Data;

namespace warteg.Repositories
{
    public class PaymentRepository
    {
        private readonly WartegDbContext _dbContext;

        public PaymentRepository(WartegDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreatePayment(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }

            _dbContext.Payments.Add(payment);
            _dbContext.SaveChanges();
        }

        public void ProcessPayment(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentNullException(nameof(payment));
            }

            _dbContext.Payments.Add(payment);
            _dbContext.SaveChanges();
        }

    }
}
