using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOKtch.repositories
{
    public class MemberRepository
    {
        static Database1Entities db = new Database1Entities();

        /*================================Member Repository========================================*/
            /*  Manipulate Member Database  */
        public static int addMembertoDatabase(Member m)
        {
            db.Members.Add(m);
            return db.SaveChanges();
        }
        public static int changeRoletoAdmin(string email)
        {
            Member m = db.Members.Find(email);
            m.MemberRole = 2;

            return db.SaveChanges();
        }
        public static int changeMemberPassword(Member m)
        {
            Member member = db.Members.Find(m.MemberEmail);
            member.MemberPassword = m.MemberPassword;
            return db.SaveChanges();
        }
        public static int deleteMemberFromDatabase(string email)
        {
            Member m = db.Members.Find(email);
            db.Members.Remove(m);
            return db.SaveChanges();
        }



            /*  GET Member Data  */
        public static List<Member> getAllMemberDetail()
        {
            return db.Members.ToList();
        }
        public static Member getMemberById(string email)
        {
            return db.Members.Find(email);
        }
        
    }
}