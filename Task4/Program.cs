using System;
using System.Collections.Generic;

//Для полного закрепления понимания простых типов найдите любой чек, либо фотографию этого чека в интернете и схематично нарисуйте его в консоли, 
//только за место динамических, по вашему мнению, данных (это может быть дата, название магазина, сумма покупок) подставляйте переменные, которые 
//были заранее заготовлены до вывода на консоль.
namespace Task4
{
    class Program
    {
       
        static void Main(string[] args)
        {
            string bankName = "ПАО СБЕРБАНК";
            string shopName = "АВТОЦЕНТР";
            string shopAddress_line1 = "г. Сатка, Саткинский р-н.";
            string shopAddress_line2 = "ул. 50 лет ВЛКСМ, дом 3";
            long phoneNumber = 9127963061;
            DateTime paymentDateTime = new DateTime(2021, 1, 15, 16, 28, 0);
            string terminalID = "0086343";
            string merchantID = "860000006429";
            string clientCardType = "MASTERCARD";
            string clientCardTypeID = "A0000000041010";
            string clintCardNumberMasked = "********3897";
            decimal totalRubl = 370;
            decimal commision = 0;
            bool isApproved = true;
            bool isRequiredClientSign = false;
            long authCode = 150469;
            long linkNumber = 744129195039;
            int salesReceiptNumber = 30;
            string someCode = "92ABD87FF99900EA92ABD87FF99900EA";

            int blankWidth = 32;

            for (int i = 0; i < blankWidth; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
            Console.SetCursorPosition(blankWidth / 2 - bankName.Length / 2, 1);
            Console.WriteLine(bankName);

            Console.SetCursorPosition(blankWidth / 2 - shopName.Length / 2, 2);
            Console.WriteLine(shopName);

            Console.SetCursorPosition(blankWidth / 2 - shopAddress_line1.Length / 2, 3);
            Console.WriteLine(shopAddress_line1);

            Console.SetCursorPosition(blankWidth / 2 - shopAddress_line2.Length / 2, 4);
            Console.WriteLine(shopAddress_line2);

            string tmpStr = $"т. {phoneNumber:+7 ###-###-##-##}";
            Console.SetCursorPosition(blankWidth / 2 - tmpStr.Length / 2, 5);
            Console.WriteLine(tmpStr);

            Console.Write($"{paymentDateTime.ToShortDateString()} {paymentDateTime.ToShortTimeString()}");
            Console.SetCursorPosition(blankWidth - 8, 6);
            Console.WriteLine($"ЧЕК {salesReceiptNumber:d4}");

            Console.Write(bankName);
            Console.SetCursorPosition(blankWidth - 6, 7);
            Console.WriteLine("Оплата");

            Console.Write("Терминал:");
            Console.SetCursorPosition(blankWidth - terminalID.Length, 8);
            Console.WriteLine(terminalID);

            Console.Write("Мерчант:");
            Console.SetCursorPosition(blankWidth - merchantID.Length, 9);
            Console.WriteLine(merchantID);

            Console.Write(clientCardType);
            Console.SetCursorPosition(blankWidth - clientCardTypeID.Length, 10);
            Console.WriteLine(clientCardTypeID);

            Console.Write("Карта: (Е4)");
            Console.SetCursorPosition(blankWidth - clintCardNumberMasked.Length, 11);
            Console.WriteLine(clintCardNumberMasked);

            Console.WriteLine("Сумма (Руб):");

            string totalStr = $"{totalRubl:F2}";
            Console.SetCursorPosition(blankWidth - totalStr.Length, 13);
            Console.WriteLine(totalStr);

            Console.WriteLine($"Комиссия за операцию - {commision} Руб");

            Console.SetCursorPosition(blankWidth / 2 - 4, 15);
            Console.WriteLine(isApproved ? "ОДОБРЕНО" : "ОТКАЗАНО");

            Console.Write("Код авторизации:");
            Console.SetCursorPosition(blankWidth - authCode.ToString().Length, 16);
            Console.WriteLine(authCode);

            Console.Write("Номер ссылки:");
            Console.SetCursorPosition(blankWidth - linkNumber.ToString().Length, 17);
            Console.WriteLine(linkNumber);

            string strSign = isRequiredClientSign ? "" : "не ";
            Console.WriteLine($"  Подпись клиента {strSign}требуется");

            Console.WriteLine(someCode);

            for (int i = 0; i < blankWidth; i++)
            {
                Console.Write("=");
            }


        }
    }
}
