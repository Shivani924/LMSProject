using LMSProject.Models;

namespace LMSProject.Services
{
    public class UserDetailsRepo : IRepo<int, UserDetails>
    {

        private readonly LmsContext _context;

        public UserDetailsRepo(LmsContext context)
        {
            _context = context;
        }
        public UserDetails Add(UserDetails item)
        {
            /*try
            {
                _context.Add(item);
                _context.SaveChanges();
                return item;
            }*/
            try { 
            var user = _context.Logins.SingleOrDefault(x => x.Username == item.UserName);
            var check = _context.UserDetails.SingleOrDefault(x => x.UserName == item.UserName);

            if (user != null && check == null)
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

        public UserDetails Delete(int key)
        {
            var emp = Get(key);
            if (emp != null)
            {
                try
                {
                    _context.UserDetails.Remove(emp);
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

        public UserDetails Get(int key)
        {
            var emp = _context.UserDetails.FirstOrDefault(e => e.Id == key);
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

        public ICollection<UserDetails> GetAll()
        {
            var employees = _context.UserDetails.ToList();
            return employees;
        }

        public UserDetails Update(UserDetails item)
        {
            var emp = Get(item.Id);
            if (emp != null)
            {
                try
                {
                    emp.First_Name = item.First_Name;
                    emp.Last_Name = item.Last_Name;
                    emp.Address = item.Address;
                    emp.Phone_No = item.Phone_No;
                    emp.City = item.City;
                    emp.District = item.District;
                   /* emp.UserName = item.UserName;*/
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
