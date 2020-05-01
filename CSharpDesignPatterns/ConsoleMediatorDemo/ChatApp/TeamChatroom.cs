using System.Collections.Generic;

namespace ConsoleMediatorDemo.ChatApp
{
    public class TeamChatroom : Chatroom
    {
        private readonly List<TeamMember> _members = new List<TeamMember>();

        public override void Register(TeamMember member)
        {
            member.SetChatroom(this);
            _members.Add(member);
        }

        public override void Send(string from, string message)
        {
            _members.ForEach(m => m.Receive(from, message));
        }

        public void RegisterMembers(params TeamMember[] members)
        {
            foreach (var member in members)
            {
                Register(member);
            }
        }
    }
}
