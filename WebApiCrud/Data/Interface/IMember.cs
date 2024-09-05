using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IMember
    {
        IEnumerable<Member> GetAllMembers();

        Member GetMember(int memberID);

        Member AddMember(Member member);
        //bool AddMember(Member member);
        //int AddMember(Member member);

        bool MemberAddRange(IEnumerable<Member> members);

        Member UpdateMember(int memberID, Member updateMember);

        Member DeleteMember(int memberID);
        Member DeleteMember(Member member);
    }
}
