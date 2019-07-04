using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobCounter
{
    class Proxy
    {
        public static Task<string> CallPython(string path)
        {
            var tcs = new TaskCompletionSource<string>();
            var userHome = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var start = new ProcessStartInfo
            {
                FileName = userHome + @"\AppData\Local\Programs\Python\Python36\python.exe",
                Arguments = string.Format("{0} {1}", @"..\..\..\countBlobs.py", path),
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true
            };

            
            using (var process = Process.Start(start))
            {
                process.Exited += (sender, args) =>
                {
                    tcs.SetResult(process.ExitCode.ToString());
                    process.Dispose();
                };
                using (var reader = process.StandardOutput)
                {
                    var result = reader.ReadToEnd();
                    tcs.SetResult(result);
                }
            }
            return tcs.Task;
        }
    }
}
