using Data.Interface;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class MemberRepository : IMember
    {
        List<Member> memberList = new List<Member>()
        {
            new Member()
            {
                MemberID = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@contoso.com",
                Address = "Texas USA"
            },
            new Member()
            {
                MemberID = 2,
                FirstName = "Jeyn",
                LastName = "Doe",
                Email = "jeyn.doe@contoso.com",
                Address = "NewYork USA"
            },
            new Member()
            {
                MemberID = 3,
                FirstName = "Tom",
                LastName = "Doe",
                Email = "john.doe@contoso.com",
                Address = "Utah USA"
            },
            new Member()
            {
                MemberID = 4,
                FirstName = "Joe",
                LastName = "Doe",
                Email = "joe.doe@contoso.com",
                Address = "Miami USA"
            }
        };
        public Member AddMember(Member member)
        {
            memberList.Add(member);
            return member;
        }

        public Member DeleteMember(int memberID)
        {
            Member member = memberList.FirstOrDefault(x=>x.MemberID == memberID);
            memberList.Remove(member);
            return member;
        }

        public Member DeleteMember(Member member)
        {
            memberList.Remove(member);
            return member;
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return memberList;
        }

        public Member GetMember(int memberID)
        {
            Member member = memberList.SingleOrDefault(x=>x.MemberID == memberID);

            //var member = (from member in memberList
            //                 where member.MemberID == memberID
            //                 select member);
            return member;
        }

        public bool MemberAddRange(IEnumerable<Member> members)
        {
            memberList.AddRange(members);
            return true;
        }

        public Member UpdateMember(int memberID, Member updateMember)
        {
            Member member = memberList.FirstOrDefault(x=>x.MemberID == memberID);
            member.FirstName = updateMember.FirstName;
            member.LastName = updateMember.LastName;
            member.Email = updateMember.Email;
            member.Address = updateMember.Address;

            return member;
        }
    }
}
