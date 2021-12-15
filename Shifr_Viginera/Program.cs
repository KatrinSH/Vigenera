using System;
using System.Collections.Generic;

namespace Shifr_Viginera
{
    class MainClass : Trans
    {           
            static void Main(string[] args)
            {

                Console.WriteLine("Enter your text");
                string text = CheckText(Console.ReadLine());
                Console.WriteLine("Enter your key");
                string key = CheckText(Console.ReadLine());
                int count = 0;
                if (key.Length < text.Length)
                {
                    for (int i = key.Length; i < text.Length; i++)
                    {

                        key += key[count];
                        count++;
                        if (count == key.Length)
                        {
                            count = 0;
                        }
                    }
                }
                if (key.Length > text.Length)
                {
                    key = key.Substring(0, text.Length);
                }
                string encrypt_mess = Vigenere_encrypt(text, key);

                Console.WriteLine("Your encrypted message is:");
                Console.WriteLine(encrypt_mess);
                Console.WriteLine("Your decrypted message is:");
                Console.WriteLine(Vigenere_decrypt(encrypt_mess, key));
            }

            static string CheckText(string text)
            {
                int mistake_counter;
                do
                {
                    mistake_counter = 0;
                    foreach (char ch in text)
                    {
                        if (!Char.IsLetter(ch))
                        {
                            mistake_counter++;
                        }
                    }
                    if (mistake_counter > 0)
                    {
                        Console.WriteLine("This text should contain only letters, enter again");
                        text = Console.ReadLine();
                    }
                } while (mistake_counter > 0);
                return text.ToLower();

            }

            static string Vigenere_encrypt(string text, string key)
            {

                string result = "";

                for (int i = 0; i < text.Length; i++)
                {
                    int encrypt_key = vigenere_reverse[text[i]] + vigenere_reverse[key[i]];
                    if (encrypt_key > 25)
                    {
                        encrypt_key -= 26;
                    }
                    result += vigenere[encrypt_key];
                }
                return result;
            }


            static string Vigenere_decrypt(string text, string key)
            {

                string result = "";
                for (int i = 0; i < text.Length; i++)
                {

                    int decrypt_number = (vigenere_reverse[text[i]] - vigenere_reverse[key[i]]) + 26;
                    if (decrypt_number > 25)
                    {
                        decrypt_number -= 26;
                    }
                    result += vigenere[decrypt_number];

                }
                return result;
            }
        
    }
}
 
