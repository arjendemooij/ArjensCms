using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net.Appender;
using log4net.Layout;

namespace Arjen.Logging
{
    public class DefaultDbAppender : log4net.Appender.AdoNetAppender
    {
        private bool _isBufferSizeSet = false;
        private bool _connectionTypeSet = false;


        public DefaultDbAppender()
        {

            ConnectionType = "System.Data.SqlClient.SqlConnection, System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

            BufferSize = 1;

            CommandText =
                "INSERT INTO Log ([Date],[Thread],[Level],[Logger],[Message],[Exception]) VALUES (@log_date, @thread, @log_level, @logger, @message, @exception)";

            RawLayoutConverter rlc = new RawLayoutConverter();
            var dateParam = new AdoNetAppenderParameter
            {
                DbType = DbType.DateTime,
                Size = -1,
                ParameterName = "@log_date",
                Layout = new RawTimeStampLayout()
            };

            var threadParam = new AdoNetAppenderParameter
            {
                DbType = DbType.String,
                Size = 255,
                ParameterName = "@thread",
                Layout = (IRawLayout)rlc.ConvertFrom(new PatternLayout("%thread"))
            };


            var loglevelParam = new AdoNetAppenderParameter
            {
                DbType = DbType.String,
                ParameterName = "@log_level",
                Size = 50,
                Layout = (IRawLayout)rlc.ConvertFrom(new PatternLayout("%level"))
            };


            var loggerParam = new AdoNetAppenderParameter
            {
                DbType = DbType.String,
                ParameterName = "@logger",
                Size = 255,
                Layout = (IRawLayout)rlc.ConvertFrom(new PatternLayout("%logger"))
            };


            var messageParam = new AdoNetAppenderParameter
            {
                DbType = DbType.String,
                ParameterName = "@message",
                Size = 4000,
                Layout = (IRawLayout)rlc.ConvertFrom(new PatternLayout("%message"))
            };


            var exceptionParam = new AdoNetAppenderParameter
            {
                DbType = DbType.String,
                ParameterName = "@exception",
                Size = 2000,
                Layout = (IRawLayout)rlc.ConvertFrom(new ExceptionLayout())
            };
            m_parameters = new ArrayList
                    {
                        dateParam,
                        threadParam,
                        loglevelParam,
                        loggerParam,
                        messageParam,
                        exceptionParam
                    };
        }


        public new string ConnectionString
        {
            get { return base.ConnectionString; }
            set
            {
                base.ConnectionString = ConfigurationManager.ConnectionStrings[value].ConnectionString;
            }
        }


        public new string ConnectionType
        {
            get { return base.ConnectionType; }
            set
            {
                base.ConnectionType = value;
                _connectionTypeSet = true;
            }
        }

        public new int BufferSize
        {
            get { return base.BufferSize; }
            set
            {
                base.BufferSize = value;
                _isBufferSizeSet = true;
            }
        }





    }
}
