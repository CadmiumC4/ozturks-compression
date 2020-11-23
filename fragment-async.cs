/*

  Module of asynchronous fragmenting.

*/


using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace CadmiumC4.IO.Compression
{
  partial class Compote
  {
      public extern int Force
      {
        get;
        set;
      }
      public extern DirectoryInfo TemporaryFolder
      {
        get;
        set;
      }
    
      private async void FragmentFile(FileStream file)
       {
           /*The fragment array.*/
            byte[] bytes;
            /*Let the fragment file array*/
            FileInfo[] fragments;
           /*fragment enumerator*/
           int fragment;
           //Let a temporary variable to keep the fragment.
            FileStream fragFile;
           /*First of all, we need to calculate the exponent.*/
            int byteCount = _forceField;
            /*and the fragment count.*/
            int fragmentCount = file.Length / _forceField;
            /*lastly, add the file-name array*/
           string[] fileNames = new string[fragmentCount];
           /*begin the fragmentation of the file*/
           for(fragment = 0;fragment < fragmentCount;fragment++)
           {
               //set the name of the fragment.
               fileNames[fragment] = string.Format(@"{0}\{1:X}",temporaryFolder.FullName,fragment);
           }
           //Create the files(virtually).
           for(fragment = 0; fragment < fragmentCount;fragment++)
           {
               fragments[fragment] = new FileInfo(fileNames[fragment]);
           }
           //Now, create the files really and write the fragments.
           for(fragment = 0; fragment < fragmentFile; fragment++)
           {
               fragFile = fragments[fragment].Create();
               //debug line
               if(!(fragFile.CanWrite && file.CanRead))
                   throw new IOException("Access to the file is denied.");
               //create the byte array.
               bytes = new byte[byteCount];
               
               //Read bytes from the file.
               await file.ReadAsync(bytes,0, byteCount);
               // And write them into the fragment.
               await fragFile.WriteAsync(bytes,0,byteCount);
               
               //Close the fragment file.
               fragFile.Close();
           }
  }
}
