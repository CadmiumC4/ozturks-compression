using System;
using System.IO;
using System.IO.Compression;

namespace CadmiumC4.IO.Compression
{
  partial class Compote
  {
    public Compote(int force)
    {
      _force = CalculateForce(force);
    }
    public Compote():this(3){}
  }
  
  
}
