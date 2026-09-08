using System;
using System.Collections.Generic;
using System.Text;

namespace GoodDesk.ViewModel.Auth
{
    public class VMLoginResponse
    {
        public string Token { get; set; } = null!;
        public DateTime ExpiredAt { get; set; }
    }
}
