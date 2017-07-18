using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRedirector
{
    public class ConsoleRedirectToFile : IConsoleOutputRedirector
    {
        private static readonly String DefaultLogFile = @".\DefaultOutputFile.log";

        private String m_outputFile;

        private FileStream m_fileStream;

        private StreamWriter m_streamWriter;

        private Boolean m_outputOpened;

        private static readonly TextWriter ConsoleDefaultOutput = Console.Out;

        //try
        //{
        //    fs = new FileStream(@".\Console.log", FileMode.OpenOrCreate, FileAccess.Write);
        //    sw = new StreamWriter(fs);
        //    Console.WriteLine("Successfully redirect");
        //}
        //catch
        //{ 
        //    Console.WriteLine("Can not redirect console..");
        //}

        public Boolean OpenOutput()
        {

            try
            {
                m_fileStream = new FileStream(m_outputFile, FileMode.OpenOrCreate, FileAccess.Write);
                m_streamWriter = new StreamWriter(m_fileStream);
                m_outputOpened = true;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean IsOutputOpened
        {
            get
            {
                return m_outputOpened;
            }
        }

        public void SetOutput()
        {
            if (m_outputOpened)
            {
                Console.SetOut(m_streamWriter);
            }
            else
            {
                throw new NullReferenceException("Make sure output is opened before Set output.");
            }
        }

        public void RestoreOutput()
        {
            Console.SetOut(ConsoleDefaultOutput);
        }

        public void CloseOutput()
        {
            if (m_outputOpened)
            {
                m_streamWriter.Close();
                m_fileStream.Close();
            }
        }

        public ConsoleRedirectToFile(
            String i_outputFile
            )
        {
            m_outputFile = i_outputFile;
        }

        public ConsoleRedirectToFile()
            : this(DefaultLogFile)
        { }
    }
}
