using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDisposeModel
{
	/// <summary>
	/// This class is a common Dispose implementation model
	/// 1. Disposal can only be executed once, add a flag
	/// 2. Call IDispose.Dispose() should free managed/unmanaged res, set the flag 
	/// and take this off Finalization Queue
	/// 3. In the finalizer, if it is not marked as disposed, just free unmanaged res and set flag 
	/// </summary>
    public class DisposeExample : IDisposable
    {
		// Pointer to an external unmanaged resource
		private IntPtr m_handle;

		//Other managed resource
		private Component m_component = new Component();

		// Track dispose status
		private Boolean m_disposed = false;

		public DisposeExample(
			IntPtr i_handle
			)
		{
			m_handle = i_handle;
		}

		// public implementation of IDisposable.Dispose
		public void Dispose()
		{
			// It is a manual disposal
			Dispose(true);

			// Notify GC that no need to Finalize this object
			// Actually take this object off Finalization Queue
			GC.SuppressFinalize(this);
		}

		[System.Runtime.InteropServices.DllImport("Kernel32")]
		private extern static Boolean CloseHandle(IntPtr handle);

		private void Dispose(
			Boolean i_manualDispose
			)
		{
			if (!m_disposed)
			{
				// If it is a manual disposal, we will dispose managed resource and unmanaged res
				if (i_manualDispose)
				{
					m_component.Dispose();
				}

				// No matter it is a manual or calling from finalizer, unmanaged res must be freed
				CloseHandle(m_handle);
				m_handle = IntPtr.Zero;

				// Mark this object disposed.
				m_disposed = true;
			}
		}

		~DisposeExample()
		{
			// If this is called, at this point, we will only try to close unmanaged resource
			// As managed resource is under control of GC - Just ignore it
			Dispose(false);
		}
    }
}
