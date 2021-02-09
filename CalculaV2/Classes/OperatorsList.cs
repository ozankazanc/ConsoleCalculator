using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaV2.Classes
{
    public class OperatorsList
    {
        /// <summary>
        ///  *, /, -, +, ^ operatörlerini içeren Char Listesi
        /// </summary>
        protected char[] AllOperators { get; }
        /// <summary>
        /// *, /, ^ operatörlerini içeren Char Listesi [M=Multiply, D=Divide, E= Exponent]
        /// </summary>
        protected char[] MDEOperators {get;}
        /// <summary>
        /// - ve + operatörlerini içeren Char Listesi [P=Plus, M=Minus]
        /// </summary>
        protected char[] PMOOperators { get; }
        /// <summary>
        /// //, /* vb. gibi işlem yapılmasını engelleyen ifadeleri bulunduran String Listesi
        /// </summary>
        protected string[] DuplicateOperators;

        public OperatorsList()
        {
            AllOperators = new char[] { '*', '/', '-', '+', '^' };
            MDEOperators = new char[] { '*', '/', '^' };
            PMOOperators = new char[] { '-', '+' };
            DuplicateOperators = CreateDuplicateOperands();
        }
        /// <summary>
        /// Arka arkaya tekrarlanan operatörlerin oluşturulduğu liste.
        /// </summary>
        /// <returns>String olarak bir liste döner.</returns>
        private string[] CreateDuplicateOperands()
        {
            DuplicateOperators = new string[AllOperators.Length * AllOperators.Length-2];
            int count = 0;
            for (int i = 0; i < AllOperators.Length; i++)
            {
                for (int k = 0; k < AllOperators.Length; k++)
                {
                    if((AllOperators[i] == '+' && AllOperators[k] =='-') || (AllOperators[i] == '-' && AllOperators[k] == '+'))
                    {

                    }
                    else
                    {
                        DuplicateOperators[count] = $"{AllOperators[i]}{AllOperators[k]}";
                        count++;
                    }
                }
                
            }
            
            return DuplicateOperators;
        }

        
    }
}
