using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaV2.Classes
{
    public static class CharExtension
    {
        private static char[] AllOperators = new char[] { '*', '/', '-', '+', '^' };
        /// <summary>
        /// Gelen char ifadesinin operatör olup olmadığının kontrolünü sağlar.
        /// Char değişkenler için implement edilmiş extension method.
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public static bool IsOperand(this char chr)
        {
            bool isOperand = false;

            foreach (var operand in AllOperators)
            {
                if(operand==chr)
                {
                    isOperand = true;
                    break;
                }
            }
            return isOperand;
        }

        
    }
}
