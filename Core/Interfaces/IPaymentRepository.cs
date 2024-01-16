using Core.Entities;

namespace Core.Interfaces
{
    public interface IPaymentRepository
    {
       Task<ICollection<Payment>> GetPaymentMethods();
       void Create(Payment payment);
       void Update(Payment payment);
       void Delete(Payment payment);
       Task<Payment> GetPaymentById(int id);
       Task SaveAsync();
       Task<ICollection<Payment>> GetPaymentUsers();
    }
}