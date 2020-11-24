/*
	module of file concatenation (asynchronous)
*/



using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace CadmiumC4.IO.Compression
{
	partial class Compote
	{
		partial int _force;
		partial DirectoryInfo TemporaryFolder
		{
			
		}
		protected async void ConcatFiles(FileStream target)
		{
			FileInfo[] _files = TemporaryFolder.GetFiles();
			FileStream _partStream;
			byte[] _fragment = new byte[_force];
			
			if(!target.CanWrite)
				throw new IOException("File is not writeable! Access denied to file.");
			
			foreach(FileInfo _file in _files)
			{
				_partStream = _file.Open(FileMode.Open, FileAccess.Read);
				_partStream.Read(_fragment,0,_force);
				
				await target.WriteAsync(_fragment,0,_force);
				
				_partStream.Close();
			}
			
			
			
		}
	}
}