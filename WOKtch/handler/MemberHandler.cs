using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOKtch.repositories;

namespace WOKtch.handlers
{
    public class MemberHandler
    {
        public static bool checkEmailExist(string email)
        {
            if (MemberRepository.getMemberById(email) != null)
                return true;
            return false;
        }
        public static bool checkEmailandPasswordMatch(string email, string password)
        {
            Member m = MemberRepository.getMemberById(email);
            if(email == m.MemberEmail && password == m.MemberPassword)
            {
                return true;
            }
            return false;
        }
    }
}