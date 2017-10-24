using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Example2
{
    class Example2_84 : IDisposable
    {
        private IntPtr unmanagedBuffer;
        public FileStream Stream { get; private set; }

        public Example2_84()
        {
            CreateBuffer();
            this.Stream = File.Open("temp.dat", FileMode.Create);
        }

        private void CreateBuffer()
        {
            byte[] data = new byte[1024];
            new Random().NextBytes(data);
            unmanagedBuffer = Marshal.AllocHGlobal(data.Length);
            Marshal.Copy(data, 0, unmanagedBuffer, data.Length);
        }

        ~Example2_84()
        {
            Dispose(false);
        }

        public void Close()
        {
            Dispose();
        }

        private void Dispose(bool disposing)
        {
            Marshal.FreeHGlobal(unmanagedBuffer);
            ReleaseUnmanagedResources();
            if (disposing)
            {
                Stream?.Dispose();
            }
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
