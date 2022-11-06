using LMSProject.Models;
using System.Reflection.Metadata;

namespace LMSProject.Services
{
    public class DocumentsRepo : IRepo<string, Documents>
    {
        private readonly LmsContext _context;

        public DocumentsRepo(LmsContext context)
        {
            _context = context;
        }
        public Documents Add(Documents item)
        {
            try
            {
                var doc = _context.UserDetails.SingleOrDefault(x => x.UserName == item.UserName);
                if (doc != null)
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
            return item;
        }

        public Documents Delete(string key)
        {
            var loan = Get(key);
            if (loan != null)
            {
                try
                {
                    _context.Documents.Remove(loan);
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

        public Documents Get(string key)
        {
            var loan = _context.Documents.FirstOrDefault(e => e.UserName == key);
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

        public ICollection<Documents> GetAll()
        {
            var loan = _context.Documents.ToList();
            return loan;
        }

        public Documents Update(Documents item)
        {
            var loan = Get(item.UserName);
            if (loan != null)
            {
                try
                {
                    loan.AadharNo = item.AadharNo;
                    loan.PanNo = item.PanNo;
                    loan.DL_No = item.DL_No;
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
    }
}
