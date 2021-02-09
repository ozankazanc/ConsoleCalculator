using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaV2.Classes
{
    /// <summary>
    /// Klavyeden girilen değerin kontrolünü sağlayan methodların bulunduğu sınıf.
    /// </summary>
    public class InputCorrect : OperatorsList
    {
        private string Value { get; set; }
        public string ErrorMessage { get; set; }

        public List<Parenthesis> ParenthesisIndex;
        public InputCorrect()
        {
            ParenthesisIndex = new List<Parenthesis>();
        }

        /// <summary>
        /// Input olarak gelen string ifadenin yani işlemin, kontolü sağlanır.
        /// </summary>
        /// <param name="value">Klavyeden girilen string input değer</param>
        /// <returns>Bool olarak geri dönüş sağlanır.</returns>
        public bool IsInputValueCorrect(string value)
        {
            Value = value;
            if (value.Length == 0)
            {
                ErrorMessage = "[Uyarı: İşlem boş geçilemez. Lütfen işlem girişi yapın.]";
                return false;
            }
            else
            {
                if (IsLastCharacteranOperand())
                {
                    ErrorMessage = "[Uyarı: İşlemin sonunda /,*,+,-,^ bulunamaz. İşlemin doğru girildiğinden emin olun.]";
                    return false;
                }
                else
                {
                    if (!IsDigitOrOperandValue())
                    {
                        ErrorMessage = "[Uyarı: İşlem sadece rakamlar ve /,*,+,-,^ karakterlerini içermelidir.]";
                        return false;
                    }
                    else
                    {
                        if (IsDuplicateOperands())
                        {
                            ErrorMessage = "[Uyarı: İşlem içerisinde //,** vb. ifadeler bulunamaz. İşlemin doğru girildiğinden emin olun.]";
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Yanyana bulunan ve işlemin çözülmesini engelleyen operatörlerin kontrolünü sağlar. Örneğin //,+* vb
        /// </summary>
        /// <returns>Bool değer olarak dönüş sağlar</returns>
        private bool IsDuplicateOperands()
        {
            bool isDuplicateCorrect = false;
            foreach (string duplicateOperand in DuplicateOperators)
            {
                if (Value.Contains(duplicateOperand))
                {
                    isDuplicateCorrect = true;
                    break;
                }
            }
            return isDuplicateCorrect;
        }
        /// <summary>
        /// Input olarak gelen string değerin yani işlemin, son Index'inin operator olma durumunda işlem çözülemediği için kontrol sağlanır. Örneğin 3+5/
        /// </summary>
        /// <returns>Bool değer olarak dönüş sağlanır</returns>
        private bool IsLastCharacteranOperand()
        {
            char c = Value[Value.Length - 1];
            return c.IsOperand();
        }
        /// <summary>
        /// Input olarak gelen string değerin yani işlemin, harf ve ya işlemin çözülmesini engelleyen bir karakterin girilmesi durumunda kontrol sağlanır. Örneğin 3a/5
        /// </summary>
        /// <returns>Bool değer olarak dönüş sağlanır</returns>
        private bool IsDigitOrOperandValue()
        {
            bool isDigitOrOperandValue = true;

            foreach (char chr in Value)
            {
                if (!char.IsDigit(chr) && !chr.IsOperand())
                {
                    isDigitOrOperandValue = false;
                    break;
                }
            }
            return isDigitOrOperandValue;
        }
        /// <summary>
        /// Eğer sadece sayı girilirse örneğin 55, girilen sağı işlem başlangıcı olarak belirlenir. Sadece sayı olma kontolü burada sağlanır.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Bool değer olarak dönüş sağlanır</returns>
        public bool OnlyDigit(string value)
        {
            foreach (char chr in value)
            {
                if (!char.IsDigit(chr))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Inputun ilk karakterinin operatör olma durumunun kontrolü sağlanır.
        /// Eğer gelen inputun başlangıç ifadesi operatör ise, işlem sonucu ile input birlikte işleme sokulur. 
        /// Eğer gelen inputun başlangıç ifadesi operatör değil ise, input tek başına işlenir ve işlem sonucuna atılır.
        /// Örneğin [5]--> +2 ise [7]--> şeklinde devam eder.
        /// [5]--> 2 ise [2]--> şeklinde devam eder.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsOperatorStartChr(char value)
        {
            foreach (char chr in AllOperators)
            {
                if (chr == value)
                {
                    return true;
                }
            }
            return false;
        }

    }
    public class Parenthesis
    {
        public string InsideValue { get; set; }
        public int? LeftParenthesisIndex { get; set; }
        public int? RightParenthesisIndex { get; set; } = null;
        public bool CheckOpenClose { get; set; } = false;
    }
}
