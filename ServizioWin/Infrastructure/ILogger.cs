using log4net.Core;

namespace ServizioWin.Infrastructure
{
    public interface ILogger
    {
        void WriteLog(string text);
        void WriteLog(string text, Level level);
    }
}