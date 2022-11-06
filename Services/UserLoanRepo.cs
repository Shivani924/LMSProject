using LMSProject.Models;

namespace LMSProject.Services
{
    public class UserLoanRepo : IRepo<int, UserLoan>
    {
        private readonly LmsContext _context;

        public UserLoanRepo(LmsContext context)
        {
            _context = context;
        }
        public UserLoan Add(UserLoan item)
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

        public UserLoan Delete(int key)
        {
            var emp = Get(key);
            if (emp != null)
            {
                try
                {
                    _context.UserLoans.Remove(emp);
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

        public UserLoan Get(int key)
        {
            var emp = _context.UserLoans.FirstOrDefault(e => e.Id == key);
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

        public ICollection<UserLoan> GetAll()
        {
            var employees = _context.UserLoans.ToList();
            return employees;
        }

        public UserLoan Update(UserLoan item)
        {
            var emp = Get(item.Id);
            if (emp != null)
            {
                try
                {
                    emp.LoanNo = item.LoanNo;
                    emp.LoanStatus = item.LoanStatus;
                    emp.UserId = item.UserId;
                    emp.LoanDetails_Id = item.LoanDetails_Id;
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
