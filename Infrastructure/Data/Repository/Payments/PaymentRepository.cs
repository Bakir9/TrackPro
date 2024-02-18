
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PaymentRepository : IPaymentRepository
    {
        public readonly StoreContext _context;
        public PaymentRepository(StoreContext context)
        {
            _context = context;
        }

        public void Create(Payment payment)
        {
            _context.Set<Payment>().Add(payment);
        }

        public void Delete(Payment payment)
        {
           _context.Set<Payment>().Remove(payment);
        }

        public async Task<Payment> GetPaymentById(int id)
        {
             return await _context.Payments
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Payment>> GetPaymentMethods()
        {   
            return await _context.Payments.ToListAsync();
        }

        public async Task<ICollection<Payment>> GetPaymentUsers()
        {
           return await _context.Payments
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Payment payment)
        {
            _context.Set<Payment>().Update(payment);
        }
    }
}