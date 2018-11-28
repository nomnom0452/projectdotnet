using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOKtch.factories
{
    public class MemberFactory
    {
        public static Member createMember(string memberName, string memberEmail,
                string password, string Membergender, string memberDoB, string ProfilePicture,
                string memberPhone, string memberAddress)
        {
            return new Member()
            {
                MemberName = memberName,
                MemberEmail = memberEmail,
                MemberPassword = password,
                MemberGender = Membergender,
                MemberDoB = Convert.ToDateTime(memberDoB),
                MemberProfilePicture = ProfilePicture,
                MemberPhoneNumber = memberPhone,
                MemberAddress = memberAddress,
                MemberRole = 1
            };
        }
    }
}