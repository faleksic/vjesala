using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Vjesala
{
    class Rijec
    {
        private string rjesenje;
        private char[] rjesenjePoSlovima;
        private int brojPromasaja = 0;

        public string Rjesenje
        {
            get { return rjesenje; }
        }

        public int BrojPromasaja
        {
            get { return brojPromasaja; }
        }

        public char[] RjesenjePoSlovima
        {
            get { return rjesenjePoSlovima; }
        }
         
        public Rijec()
        {
            string[] rijeci = File.ReadAllLines(@"C:\Users\filip\Desktop\rijeci.txt");
            Random random = new Random();
            int randomBroj = random.Next(0, rijeci.Length);

            rjesenje = rijeci[randomBroj];
            rjesenjePoSlovima = new char[rjesenje.Length];

            for (int i = 0; i < rjesenje.Length; i++)
            {
                rjesenjePoSlovima[i] = '-';
            }            
        }

        public string ProvjeriSlovo(char slovo)
        {
            bool pogodak = false;

            for (int i = 0; i < rjesenje.Length; i++)
            {
                if(rjesenje[i] == slovo)
                {
                    rjesenjePoSlovima[i] = slovo;
                    pogodak = true;
                }
            }

            if(!pogodak)
                    brojPromasaja++;
            
            return new string(rjesenjePoSlovima);
        }
    }
}
