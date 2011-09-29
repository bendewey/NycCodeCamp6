using System;
using System.Collections.Generic;
using System.Linq;
#if Metrostyle
using System.Threading.Tasks;
#endif

namespace CodeCamp.Core.DataAccess
{
    public interface IFileSystemHelper
    {
#if !Metrostyle
        bool FileExists(string file);
        string ReadFile(string file);
        void WriteFile(string file, string content);
#else
        Task<bool> FileExists(string file);
        Task<string> ReadFile(string file);
        void WriteFile(string file, string content);
#endif
    }
}
