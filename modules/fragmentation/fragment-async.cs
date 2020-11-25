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
    
      private async void FragmentFile(FileInfo file)
       {
           /*The fragment array.*/
            byte[] bytes;
            /*Let the fragment file array*/
            FileInfo[] fragments;
           /*fragment enumerator*/
           int fragment;
           //Let a temporary variable to keep the fragment.
            FileStream fragFile;
          //And let the stream for the file.
            FileStream inputFile = file.Open();
           /*First of all, we need to calculate the exponent.*/
            int byteCount = _forceField;
            /*and the fragment count.*/
            int fragmentCount = inputFile.Length / _forceField;
            /*lastly, add the file-name array*/
           string[] fileNames = new string[fragmentCount];
           /*begin the fragmentation of the file*/
           for(fragment = 0;fragment < fragmentCount;fragment++)
           {
               //set the name of the fragment.
               fileNames[fragment] = string.Format(@"{0}\{2}\{1:X}",temporaryFolder.FullName,fragment,file.Name);
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
               if(!(fragFile.CanWrite && inputFile.CanRead))
                   throw new IOException("Access to the file is denied.");
               //create the byte array.
               bytes = new byte[byteCount];
               
               //Read bytes from the file.
               await inputFile.ReadAsync(bytes,0, byteCount);
               // And write them into the fragment.
               await fragFile.WriteAsync(bytes,0,byteCount);
               
               //Close the fragment file.
               fragFile.Close();
           }
        inputFile.Close();
  }
}
