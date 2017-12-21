using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCP70483cs.Exam
{
    class DisposableResourceHolder : IDisposable
    {
        private SqlConnection resource; // handle to a resource

        public DisposableResourceHolder()
        {
            this.resource = null; // actually allocates the unmanaged resrouce. 
        }

        public void Dispose()
        {
            // manually dispose, so suppress gc.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DisposableResourceHolder()
        {
            // if manage resource, relase by gc.
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // if resource is already null, nothing to do.
                // prevent duplicate relase.
                if (resource != null) resource.Dispose();
            }
        }
    }
}
