using CalculaV2.Classes;
using System;

namespace CalculaV2
{
    class Program
    {
        static void Main(string[] args)
        {
            InputCorrect correct = new InputCorrect();
            ResolveOperation resolve = new ResolveOperation();
            string startValue = "0";
            string value="";
            Console.WriteLine(
                "-----------------------------Konsol Hesap Makinesi---------------------------\n" +
                "[-Çarpma, Bölme, Çıkarma, Toplama ve Üs Alma İşlemleri Gerçekleştirilebilir-]\n" +
                "[---------Yanyana olacak şekilde ve ya tek tek işlem yaptırılabilir.--------]\n" +
                "[---------------------[Örneğin = 3 / 2 + 55 - 3 ^ 5]------------------------]\n" +
                "[------------[x] Solda bulunan sayıya göre işlem devam edecektir.-----------]\n" +
                "[---------------Çıkış 'e' tuşuna basarak gerçekleştirilir.------------------]\n" +
                "[----------İşlemi temizleme 'c' tuşuna basarak gerçekleştirilir.------------]\n" +
                "[---------------------------------------------------------------------------]\n\n");

            Console.Write("İşlem ve ya işleme sokulacak sayıyı giriniz-->");
            
            

            do
            {
                value = Console.ReadLine();
                if (value=="c")
                {
                    startValue = "0";
                    Console.WriteLine("İşlem Temizlendi.");
                    Console.Write("[0]-->");
                }
                else if(value=="e")
                {
                    Console.WriteLine("Çıkış yapılıyor.");
                }
                else
                {
                    if (startValue == "0" && correct.OnlyDigit(value))
                    {
                        startValue = value;
                        Console.WriteLine($"[İşleme devam edilecek sayı = [{startValue}]");
                        Console.Write($"[{startValue}]-->");
                    }
                    else
                    {
                        if(correct.IsInputValueCorrect(value))
                        {
                            if(correct.IsOperatorStartChr(value[0]))
                            {
                                startValue = resolve.CalculateOperation(startValue+value);
                            }
                            else
                            {
                                startValue = resolve.CalculateOperation(value);
                                //Console.WriteLine($"[İşleme devam edilecek sayı değişmiştir = [{startValue}]");
                            }
                            Console.Write($"[{startValue}]-->");
                        }
                        else
                        {
                            Console.WriteLine($"{correct.ErrorMessage}");
                            Console.Write($"[{startValue}]-->");
                        }
                    }
                }
            } while (value != "e");
            
            
           
            
        }
    }
}
