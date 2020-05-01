namespace ConsoleMediatorDemo.ChatApp
{
    public abstract class Chatroom
    {
        public abstract void Register(TeamMember member);

        public abstract void Send(string from, string message);
    }
}
