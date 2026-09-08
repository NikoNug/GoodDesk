using GoodDesk.DataAccess;
using GoodDesk.DataModel;

namespace GoodDesk.API.Services
{
    public class UserSeeder
    {
        private readonly GoodDeskDBContext _context;
        private readonly PasswordService _passwordService;

        public UserSeeder(
            GoodDeskDBContext context,
            PasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        public void Seed()
        {
            if (_context.TBLMUsers.Any())
            {
                return;
            }

            var users = new List<TBLMUser>
            {
                new TBLMUser
                {
                    Username = "admin",
                    Email = "admin@gooddesk.local",
                    PasswordHash = _passwordService.HashPassword("Admin123!"),
                    RoleID = 1,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = DateTime.UtcNow
                },

                new TBLMUser
                {
                    Username = "itsupport",
                    Email = "itsupport@gooddesk.local",
                    PasswordHash = _passwordService.HashPassword("Support123!"),
                    RoleID = 2,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = DateTime.UtcNow
                },

                new TBLMUser
                {
                    Username = "requester",
                    Email = "requester@gooddesk.local",
                    PasswordHash = _passwordService.HashPassword("Requester123!"),
                    RoleID = 3,
                    IsActive = true,
                    CreatedBy = 1,
                    CreatedDate = DateTime.UtcNow
                }
            };

            _context.TBLMUsers.AddRange(users);
            _context.SaveChanges();
        }
    }
}