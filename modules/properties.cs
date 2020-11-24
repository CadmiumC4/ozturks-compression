using System;
using System.IO;
using System.IO.Compression
    ;
    
    
 namespace CadmiumC4.IO.Compression
 {
      public partial class Compote
      {
          private int _force;
          protected partial int ComputeForce(int exponent); 
          
          
          public DirectoryInfo TemporaryFolder
          {
             get;
             set; //maybe be replaced with 'init'.
          }
          
          public int Force
          {
            get => _force;
            set => _force = ComputeForce(value);
          }
      }
 }
