using System;

namespace EncryptDecrypt
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            String plaintext = "This is a private encrypted message";
            char[,] tCiphertext = { {'I','E','U','B','O','I','P','I'},
                                    {'N','S','C','L','F','S','O','B'},
                                    {'D','T','T','E','T','I','S','L'},
                                    {'E','R','A','S','W','M','S','E'} };
            String sCiphertext = "SZXPVIH ZIV GVMZXRLFH";
            String vCiphertext = "LLGLV BQ QQHVG GF JUTSBLY";

            // KEYS
            char[] subAlphabet = {'Z', 'Y', 'X', 'W', 'V', 'U', 'T', 'S', 'R', 'Q', 'P', 'O', 'N', 'M', 'L', 'K', 'J', 'I', 'H', 'G', 'F', 'E', 'D', 'C', 'A', 'B'};
            String vKey = "SECURITY";
            String vignere = "THERE TX SYDTM PX QWBOZRH       ";

            static int charToIndex(char[] alpha, char c)
            {
                for (int x = 0; x < alpha.Length; x++)
                    if (Char.ToUpper(c) == alpha[x]) return x;
                return 99;
            }
            static char indexToChar(char[] alpha, int i)
            {
                if (i>=0 && i<=25) return alpha[i];
                else               return ' ';
            }

            /** CAESAR CIPHER **/
            string caesarEncrypted = "";
            for (int i = 0; i < plaintext.Length; i++) {
                int index = charToIndex(alphabet, plaintext[i]);

                if (0 <= index && index <= 25)
                    caesarEncrypted = string.Concat(caesarEncrypted, indexToChar(alphabet, (index + 15) % 26) );
                else
                    caesarEncrypted = string.Concat(caesarEncrypted, ' ');
            }

            Console.WriteLine("Original Message:                {0}", plaintext);
            Console.WriteLine("Caesar Cipher, Encrypted:        {0}", caesarEncrypted);

            /** TRANSPOSITION CIPHER **/
            string[] trnEncrypted = { "","","","" };
            string trnPlain = plaintext.ToUpper().Replace(" ", "");
            if(trnPlain.Length % 4 != 0)
            {
                for(int i = 0; i < (trnPlain.Length % 4); i++)
                    trnPlain = string.Concat(trnPlain, 'X');
            }
            for (int i = 0; i < trnPlain.Length; i++)
            {
                switch (i % 4)
                {
                    case 0: trnEncrypted[0] = string.Concat(trnEncrypted[0], trnPlain[i]);
                        break;
                    case 1: trnEncrypted[1] = string.Concat(trnEncrypted[1], trnPlain[i]);
                        break;
                    case 2: trnEncrypted[2] = string.Concat(trnEncrypted[2], trnPlain[i]);
                        break;
                    case 3: trnEncrypted[3] = string.Concat(trnEncrypted[3], trnPlain[i]);
                        break;
                    default: break;
                }
            }
            Console.WriteLine("Transposition Cipher, Encrypted: {0}", trnEncrypted[0]);
            Console.WriteLine("                                 {0}", trnEncrypted[1]);
            Console.WriteLine("                                 {0}", trnEncrypted[2]);
            Console.WriteLine("                                 {0}", trnEncrypted[3]);

            /** SUBSTITUTION CIPHER **/
            string subEncrypted = "";
            for (int i = 0; i < plaintext.Length; i++)
            {
                int index = charToIndex(alphabet, plaintext[i]);

                if (0 <= index && index <= 25)
                    subEncrypted = string.Concat(subEncrypted, indexToChar(subAlphabet, index));
                else
                    subEncrypted = string.Concat(subEncrypted, ' ');
            }
            Console.WriteLine("Substitution Cipher, Encrypted:  {0}", subEncrypted);

            /** VIGNERE CIPHER **/
            string vigEncrypted = "";
            string vigPlain = plaintext.ToUpper().Replace(" ", "");
            for (int i = 0; i < vigPlain.Length; i++)
            {
                int plainIndex = charToIndex(alphabet, vigPlain[i]);
                int keyIndex = charToIndex(alphabet, vKey[i % vKey.Length]);
                if (0 <= plainIndex && plainIndex <= 25)
                    vigEncrypted = string.Concat(vigEncrypted, indexToChar(alphabet, (plainIndex+keyIndex) % 26 ));
            }
            Console.WriteLine("Vignere Cipher, Encrypted:       {0}", vigEncrypted);
        }
    }
}
