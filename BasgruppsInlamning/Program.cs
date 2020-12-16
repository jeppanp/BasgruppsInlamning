using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System.Xml.Serialization;
using Microsoft.VisualBasic.FileIO;

namespace BasgruppsInlamning
{
    class Program
    {
        
        static void Main(string[] args)
        {
            BaseGroupLogic baseGroupLogic = new BaseGroupLogic();           //instantiate an object from the class where I run the program. 
            baseGroupLogic.Run();
        }




    }
}
