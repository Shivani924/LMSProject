using LMSProject.Models;

namespace LMSProject.Services
{
    public class LoginRepo : IRepo<string, Login>
    {
        private readonly LmsContext _context;

        public LoginRepo(LmsContext context)
        {
            _context = context;
        }

        public Login Add(Login item)
        {
            try
            {
                _context.Logins.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public Login Delete(string key)
        {
            throw new NotImplementedException();
        }

        public Login Get(string key)
        {
            var user = _context.Logins.FirstOrDefault(u => u.Username == key);
            return user;
        }

        public ICollection<Login> GetAll()
        {
            if (_context.Logins.Count() > 0)
                return _context.Logins.ToList();
            return null;
        }

        public Login Update(Login item)
        {
            throw new NotImplementedException();
        }
    }
}
