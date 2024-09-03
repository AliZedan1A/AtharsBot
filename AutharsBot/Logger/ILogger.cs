using Discord;

namespace AtharsBot.Logger
{
    public interface ILogger
    {
        public Task Log(LogMessage message);
    }
}
