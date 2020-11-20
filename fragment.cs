/*
    The file fragmenting module
*/

using System;
using System.IO;
using System.IO.Compression;

namespace CadmiumC4.IO.Compression
{
   partial class Compote
   {
       protected int CalculateForce(int force)
       {
            /* variables for compression

                forceval: the returning value.
                exponent: the exponent of 2.
            */
           int forceval, exponent;

           /* force has to be in the range 1..4 */
           if((force > 4) || (force < 1))
            throw new OverflowException();

           /*calculating the exponent*/

           exponent = 11 - force;
           forceval = 2;
           for(int iota = exponent;iota > 0; iota--)
            forceval *= 2;

            /*return*/

            return forceval;

       }
       public void FragmentFile(FileStream file, int power)
       {
           /*The fragment array.*/
            byte[] bytes;
            /*Let the file array*/
            FileInfo[] files;
           /*First of all, we need to calculate the exponent.*/
            int byteCount = CalculateForce(power);
            /*and the fragment count.*/
            

           /*begin the fragmentation of the file*/
           //while()
       }

   }
}