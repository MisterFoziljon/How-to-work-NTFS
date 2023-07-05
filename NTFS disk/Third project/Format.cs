using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third_project
{
    internal class Format
    {
        public Format()
        { }
        public string Unlikdan_un_oltilikka(long son_i)
        {
            string un_oltilik = "";
            while (son_i > 0)
            {
                long qoldiq = son_i % 16;
                switch (qoldiq)
                {
                    case 0: un_oltilik = "0" + un_oltilik; break;
                    case 1: un_oltilik = "1" + un_oltilik; break;
                    case 2: un_oltilik = "2" + un_oltilik; break;
                    case 3: un_oltilik = "3" + un_oltilik; break;
                    case 4: un_oltilik = "4" + un_oltilik; break;
                    case 5: un_oltilik = "5" + un_oltilik; break;
                    case 6: un_oltilik = "6" + un_oltilik; break;
                    case 7: un_oltilik = "7" + un_oltilik; break;
                    case 8: un_oltilik = "8" + un_oltilik; break;
                    case 9: un_oltilik = "9" + un_oltilik; break;
                    case 10: un_oltilik = "A" + un_oltilik; break;
                    case 11: un_oltilik = "B" + un_oltilik; break;
                    case 12: un_oltilik = "C" + un_oltilik; break;
                    case 13: un_oltilik = "D" + un_oltilik; break;
                    case 14: un_oltilik = "E" + un_oltilik; break;
                    case 15: un_oltilik = "F" + un_oltilik; break;
                }
                son_i /= 16;
            }
            return un_oltilik;
        }

        public long Un_oltilikdan_unlikka(string Massiv)
        {
            long unlik = 0;
            for (int i = 0; i < Massiv.Length; i++)
            {
                switch (Massiv[i])
                {
                    case '0': unlik += (long)(0 * Math.Pow(16, Massiv.Length - i - 1)); break;
                    case '1': unlik += (long)(1 * Math.Pow(16, Massiv.Length - i - 1)); break;
                    case '2': unlik += (long)(2 * Math.Pow(16, Massiv.Length - i - 1)); break;
                    case '3': unlik += (long)(3 * Math.Pow(16, Massiv.Length - i - 1)); break;
                    case '4': unlik += (long)(4 * Math.Pow(16, Massiv.Length - i - 1)); break;
                    case '5': unlik += (long)(5 * Math.Pow(16, Massiv.Length - i - 1)); break;
                    case '6': unlik += (long)(6 * Math.Pow(16, Massiv.Length - i - 1)); break;
                    case '7': unlik += (long)(7 * Math.Pow(16, Massiv.Length - i - 1)); break;
                    case '8': unlik += (long)(8 * Math.Pow(16, Massiv.Length - i - 1)); break;
                    case '9': unlik += (long)(9 * Math.Pow(16, Massiv.Length - i - 1)); break;
                    case 'A': unlik += (long)(10 * Math.Pow(16, Massiv.Length - i - 1)); break;
                    case 'B': unlik += (long)(11 * Math.Pow(16, Massiv.Length - i - 1)); break;
                    case 'C': unlik += (long)(12 * Math.Pow(16, Massiv.Length - i - 1)); break;
                    case 'D': unlik += (long)(13 * Math.Pow(16, Massiv.Length - i - 1)); break;
                    case 'E': unlik += (long)(14 * Math.Pow(16, Massiv.Length - i - 1)); break;
                    case 'F': unlik += (long)(15 * Math.Pow(16, Massiv.Length - i - 1)); break;
                }
            }
            return unlik;
        }
    }
}
