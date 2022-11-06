using LMSProject.Models;

namespace LMSProject.Services
{
    /* public class LoanDetailsRepo : IRepo<int, LoanDetails>*/
    public class LoanDetailsRepo : ILoan<int, LoanDetails>
    {

        private readonly LmsContext _context;

        public LoanDetailsRepo(LmsContext context)
        {
            _context = context;
        }
        public LoanDetails Add(LoanDetails item)
        {
            /*try
            {
                _context.Add(item);
                _context.SaveChanges();
                return item;
            }*/
            try
            {
                var loans = _context.UserDetails.SingleOrDefault(x => x.UserName == item.UserName);
                var checkAadhar = _context.Documents.SingleOrDefault(x=>x.UserName==item.UserName);
                if (loans != null && checkAadhar!=null)
                {
                    _context.Add(item);
                    _context.SaveChanges();
                    return item;
                }
                return null;
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public LoanDetails Delete(int key)
        {
            var loan = Get(key);
            if (loan != null)
            {
                try
                {
                    _context.LoanDetails.Remove(loan);
                    _context.SaveChanges();
                    return loan;
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
            var loan = _context.LoanDetails.FirstOrDefault(e => e.LoanId == key);
            if (loan != null)
            {
                try
                {
                    return loan;
                }
                catch (Exception e)
                {
                }
            }
            return null;
        }

        public ICollection<LoanDetails> GetAll()
        {
            var loan = _context.LoanDetails.ToList();
            return loan;
        }

        public LoanDetails Update(LoanDetails item)
        {

            var loan = Get(item.LoanId);
            if (loan != null)
            {
                try
                {
                    loan.Amount = item.Amount;
                    loan.currentdate = item.currentdate;
                    loan.LoanType = item.LoanType;
                  
                  /* loan.LoanStatus = item.LoanStatus;*/

                    _context.SaveChanges();
                    return loan;
                }
                catch (Exception e)
                {

                    throw;
                }
            }
            return null;
        }

        public LoanDetails UpdateStatus(LoanDetails item)
        {
            var user = Get(item.LoanId);
            if (user != null)
            {
                try
                {
                    user.LoanStatus = item.LoanStatus;
                    _context.SaveChanges();
                    return user;
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
