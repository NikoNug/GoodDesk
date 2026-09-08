using Microsoft.AspNetCore.Mvc;
using GoodDesk.ViewModel.Auth;
using GoodDesk.DataAccess;
using Microsoft.Identity.Client.NativeInterop;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace GoodDesk.API.Services
{
    public class AuthService
    {
        private readonly GoodDeskDBContext _context;
        private readonly PasswordService _passwordService;
        private readonly JwtTokenService _jwtTokenService;

        public AuthService(GoodDeskDBContext context, PasswordService passwordService, JwtTokenService jwtTokenService)
        {
            _context = context;
            _passwordService = passwordService;
            _jwtTokenService = jwtTokenService;
        }

        public async Task<VMLoginResponse?> LoginAsync(VMLoginRequest request)
        {
            var user = await _context.TBLMUsers.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null) return null;
            if (!user.IsActive) return null;

            var isPasswordValid = _passwordService.VerifyPassword(request.Password, user.PasswordHash);
            if (!isPasswordValid) return null;

            var jwt = _jwtTokenService.GenerateToken(user);

            return new VMLoginResponse
            {
                Token = jwt.Token,
                ExpiredAt = jwt.ExpiredAt
            };
        }
    }
}
