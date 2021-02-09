using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaV2.Classes
{
    class ResolveOperation : OperatorsList
    {
        private string LeftNumber { get; set; } = string.Empty;
        private string RightNumber { get; set; } = string.Empty;
        private int OperandIndex { get; set; }
        public char[] Operators { get; set; }
        private bool LeftLimit { get; set; } = false;
        private bool RightLimit { get; set; } = false;
        private bool LeftPlusLimit { get; set; } = false;
        private bool RightPlusLimit { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Input olarak gelen string değer</param>
        /// <param name="operand">İşlem önceliğine göre gelen operator</param>
        /// <returns></returns>
        public string Resolve(string value, char operand)
        {
            ///Eğer input içerisinde +- ve -+ ifadeleri var ise -'ye dönüştürülüyor.
            while (value.Contains("+-") || value.Contains("-+"))
            {
                value = value.Replace("+-", "-");
                value = value.Replace("-+", "-");
            }

            while (value.Contains(operand))
            {
                OperandIndex = value.LastIndexOf(operand);

                if (value.StartsWith('-') && MinusControl(value))
                {
                    return value;
                }
                for (int i = OperandIndex + 1; i < value.Length; i++) // OPERANDIN SAĞ TARAFINDAKİ SAYIYI BULMA İŞLEMİ
                {
                    if (value[OperandIndex + 1] == '+' && !RightPlusLimit)
                    {
                        RightPlusLimit = true;
                    }
                    else if (value[i] == '-' && !RightLimit)
                    {
                        RightNumber += value[i].ToString();
                        RightLimit = true;
                    }
                    else if (OperatorControl(value[i]))
                    {
                        RightNumber += value[i].ToString();
                        RightLimit = true;
                    }
                    else
                    {
                        i = value.Length; //Çıkış
                    }

                }
                for (int i = OperandIndex - 1; i >= 0; i--) // OPERANDIN SOL TARAFINDAKİ SAYIYI BULMA İŞLEMİ
                {
                    if (value[OperandIndex - 1] == '+' && !LeftPlusLimit)
                    {
                        LeftNumber += value[i].ToString();
                        LeftPlusLimit = true;
                    }
                    else if (value[i] == '-' && !LeftLimit)
                    {
                        LeftNumber += value[i].ToString();
                        RightLimit = true;
                        i = 0; //Çıkış
                    }
                    else if (OperatorControl(value[i]))
                    {
                        LeftNumber += value[i].ToString();
                    }
                    else
                    {
                        i = 0; //Çıkış
                    }
                }

                LeftNumber = ReverseForLeftNumber(LeftNumber);
                string changeValue = LeftNumber + operand + RightNumber;
                LeftNumber = LeftPlusLimit == true ? LeftNumber.Remove(LeftNumber.Length - 1, 1) : LeftNumber;
                string sonuc = CalculateOperand.Calculate(LeftNumber, RightNumber, operand);
                value = value.Replace(changeValue, sonuc);
                LeftNumber = string.Empty;
                RightNumber = string.Empty;
                LeftLimit = false;
                RightLimit = false;
                LeftPlusLimit = false;
                RightPlusLimit = false;


            }
            return value;
        }

        /// <summary>
        /// Operator bulundaktan sonra soldaki ve sağdaki sayıyı bulmak için, tek tek gezilen karakterlerin operatör olma durumu kontrol edilir.
        /// Örneğin 3*35/7, algoritma / operatorünü bulur ve soldaki karakterlerde ikinci operatörü aramaya başlar. * operatörünü yakalanınca 35 ifadesi ve soldaki sayı bulunmuş olur. 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool OperatorControl(char value) 
        {
            bool isFinish = true;

            foreach (var _operator in AllOperators)
                if (value == _operator)
                    isFinish = false;

            return isFinish;
        }
        /// <summary>
        /// Sadece negatif bir sayının girişi yapılmışsa başka operatör var mı diye kontrol sağlanır.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool MinusControl(string value)
        {
            bool onlyNegative = true;

            value = value.Remove(0, 1);

            foreach (var _operator in AllOperators)
                if (value.Contains(_operator))
                {
                    onlyNegative = false;
                    break;
                }
            return onlyNegative;
        }
        private string ReverseForLeftNumber(string leftNumber)
        {
            char[] array = leftNumber.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }
        /// <summary>
        /// İşlem önceliğine dikkat edildiğinden gelen input içerisinde sırasıyla üs,bölme,çarpma,çıkarma ve toplama 
        /// işlemleri çözümlenir.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string CalculateOperation(string value)
        {
            if (value.Contains('^'))
            {
                value = Resolve(value, '^');
            }
            if (value.Contains('/'))
            {
                value = Resolve(value, '/');
            }
            if (value.Contains('*'))
            {
                value = Resolve(value, '*');
            }
            if (value.Contains('+'))
            {
                value = Resolve(value, '+');
            }
            if (value.Contains('-'))
            {
                value = Resolve(value, '-');
            }
            return value;
        }
    }
}

