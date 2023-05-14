using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public sealed class Log:ILog
    {
        private Log()
        { 
        
        }
        private static readonly Lazy<Log> instance= new Lazy<Log>(() => new Log());
        public static Log GetInstance
        {
            get
            { 
            return instance.Value;
            }
        }

        public void LogException(string message)
        {
            string filename = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToShortDateString());
            string logfilepath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, filename);
            StringBuilder sb=new StringBuilder();
            sb.Append(message);
            using (StreamWriter writer=new StreamWriter(logfilepath,true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
            
        
        }
    }
}
