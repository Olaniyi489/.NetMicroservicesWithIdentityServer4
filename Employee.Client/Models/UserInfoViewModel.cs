using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Client.Models
{
    public class UserInfoViewModel
    {
        public Dictionary<string, string> UserInfoDictionary { get; private set; } = null;

        public UserInfoViewModel(Dictionary<string, string> userInfoDictionary)
        {
            UserInfoDictionary = userInfoDictionary;
        }
    }
}
