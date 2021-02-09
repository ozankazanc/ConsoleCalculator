using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaV2.Classes
{
    /// <summary>
    /// Operandın hesaplanmasını sağlayan içerikleri bulunduran sınıf
    /// </summary>
    class CalculateOperand
    {
        private static double LeftNumber { get; set; }
        private static double RightNumber { get; set; }
        /// <summary>
        /// Gelen operand operatöre göre hesaplanır ve input olarak girilen işlem içerise, çözülmüş hali geri gönderilir.
        /// </summary>
        /// <param name="leftnumber">string değer olarak operatörün solundaki sayı</param>
        /// <param name="rightnumber">string değer olarak operatörün sağındaki sayı</param>
        /// <param name="_operator">char değer olarak operatör</param>
        /// <returns>Geriye string sayı ve ya rakam döner.</returns>
        public static string Calculate(string leftnumber, string rightnumber, char _operator)
        {
            double result = 0;
            try
            {
                LeftNumber = double.Parse(leftnumber);
                RightNumber = double.Parse(rightnumber);
                switch (_operator)
                {
                    case '^':
                        result = Math.Pow(LeftNumber, RightNumber);
                        break;
                    case '/':
                        result = LeftNumber / RightNumber;
                        break;
                    case '*':
                        result = LeftNumber * RightNumber;
                        break;
                    case '-':
                        result = LeftNumber - RightNumber;
                        break;
                    case '+':
                        result = LeftNumber + RightNumber;
                        break;
                    default:
                        break;
                }
                return result.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine($"İşlem sonucun uzunluğu sebebiyle hesaplama yapılamadı. Hata Açıklaması: {e.Message}");
                return "0";
            }
            
        }
    }
}
