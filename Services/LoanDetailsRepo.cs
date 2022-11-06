using LMSProject.Models;

namespace LMSProject.Services
{
    public class LoanDetailsRepo : IRepo<int, LoanDetails>
    {

        private readonly LmsContext _context;

        public LoanDetailsRepo(LmsContext context)
        {
            _context = context;
        }
        public LoanDetails Add(LoanDetails item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public LoanDetails Delete(int key)
        {
            var emp = Get(key);
            if (emp != null)
            {
                try
                {
                    _context.LoanDetails.Remove(emp);
                    _context.SaveChanges();
                    return emp;
                }
                catch (Exception e)
                {

                    throw;
                }
            }
            return null;

        }

        public LoanDetails Get(int key)
        {
            var emp = _context.LoanDetails.FirstOrDefault(e => e.LoanId == key);
            if (emp != null)
            {
                try
                {
                    return emp;
                }
                catch (Exception e)
                {
                }
            }
            return null;
        }

        public ICollection<LoanDetails> GetAll()
        {
            var employees = _context.LoanDetails.ToList();
            return employees;
        }

        public LoanDetails Update(LoanDetails item)
        {

            var emp = Get(item.LoanId);
            if (emp != null)
            {
                try
                {
                    emp.Amount = item.Amount;
                    emp.DateTime = item.DateTime;
                    emp.LoanType = item.LoanType;
                    emp.UserName = item.UserName;
                    _context.SaveChanges();
                    return emp;
                }
                catch (Exception e)
                {

                    throw;
                }
            }
            return null;
        }
    }
}
