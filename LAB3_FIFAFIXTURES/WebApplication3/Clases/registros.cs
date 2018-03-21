using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Clases
{
    public class registros
    {        
        public void escribirArchivo(string escribe)
        {
            try
            {

                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("C:\\Users\\walte\\Desktop\\Test.txt");

                //Write a line of text
                sw.WriteLine(escribe);

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}