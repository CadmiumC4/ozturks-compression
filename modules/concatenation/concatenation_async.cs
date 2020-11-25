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
		protected async void ConcatFiles(FileInfo target,string partFilePath)
		{
			FileInfo[] _files = (new DirectoryInfo(@$"{TemporaryFolder.FullPath}\{partFilePath}")).GetFiles();
			FileStream _partStream;
			FileStream _targetStream = target.OpenWrite();
			byte[] _fragment = new byte[_force];
			
			if(!_targetStream.CanWrite)
				throw new IOException("File is not writeable! Access denied to file.");
			
			foreach(FileInfo _file in _files)
			{
				_partStream = _file.Open(FileMode.Open, FileAccess.Read);
				_partStream.Read(_fragment,0,_force);
				
				await _targetStream.WriteAsync(_fragment,0,_force);
				
				_partStream.Close();
			}
			
			_targetStream.Close();
			
		}
	}
}
