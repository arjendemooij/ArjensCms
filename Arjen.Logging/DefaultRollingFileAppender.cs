using log4net.Layout;

namespace Arjen.Logging
{
    public class DefaultRollingFileAppender : log4net.Appender.RollingFileAppender
    {
        public DefaultRollingFileAppender()
        {
            AppendToFile = true;
            RollingStyle = RollingMode.Date;
            DatePattern = "yyyyMMdd";
            Layout = new PatternLayout("%date %-5level %logger - %message%newline");

        }

    }
}
