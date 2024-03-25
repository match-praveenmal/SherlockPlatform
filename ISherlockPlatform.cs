using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherlockPlatform
{
    public interface ISherlockAuthGen
    {
        public Task<string> GenerateToken(string secret);
        public Task<SherlockAuth> GetToken();
    }
}
