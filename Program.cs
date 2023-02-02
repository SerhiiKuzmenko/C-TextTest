using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http.Headers;
using System.Text;

namespace MyMemoryCs
{
   
    internal class Program
    {

        

        static void Main(string[] args)
        {
            string ourText, ourText1;

            char[] chars = {'(', ')', '.', ',', '!', '?', '\'', '\"', '-', '+', '\n'};//массив исключений

            ourText1 = Console.ReadLine();
            
            ourText = ourText1.ToLower(); 
            ourText.Trim();

            char[] tmps = ourText.ToCharArray(); //конвертируем строку в массив символов

            for (int i = 0; i < tmps.Length; i++) //сравниваем каждий символ с нашими исключениями
            {
                for(int j = 0; j < chars.Length; j++)
                {
                    if (tmps[i] == chars[j])
                    {
                        tmps[i] = ' ';
                    }
                }
                
            }

            ourText = new string(tmps);//делаем из символов обратно строку


            
            
            

            string[] strings = ourText.Split(" ");//разбиваем строку на массив строк через пробелы


            

            string[] clearText = new string[strings.Length];

            //Console.WriteLine(strings.Length);

            for(int i = 0; i < clearText.Length; i++)//убираем слова, которые повторяются
            {
                for(int j = i+1; j < strings.Length; j++)
                {
                    if (strings[i] == strings[j])
                    {
                        strings[j] = " ";
                        
                    }
                    else
                    {
                        clearText[i] = strings[i];
                    }
                    
                }
            }
            for(int i = 0; i < clearText.Length-1; i++)
            {
                if(strings[clearText.Length - 1] == strings[i]) {
                    break;
                }
                clearText[clearText.Length - 1] = strings[clearText.Length - 1];
            }
            


            

            

            string[] finalClearText = new string[clearText.Length];
            int t = 0;

            for (int i = 0; i < finalClearText.Length; i++)//убираем лишние пробелы
            {
                for(int j = t; j < clearText.Length; j++)
                {
                    if (clearText[j]!=" " && clearText[j]!="")
                    {
                        finalClearText[i] = clearText[j];
                        t = j+1;
                        break;
                    }
                }
            }

            
            

            int counter = 0;

            for(int i = 0; i < finalClearText.Length; i++)//здесь ми считаем количество пустых строк
            {
                if (string.IsNullOrWhiteSpace(finalClearText[i]) )
                {
                    counter++;
                }
            }


            
            
            char[] resultArray = new char[finalClearText.Length - counter];

           

            for (int j = 0; j < resultArray.Length; j++)//В этом цикле набираем массив символов, которые в каждом слове уникальны
            {
                string a = finalClearText[j];
            
                int flag = 0;

                
                for (int i = 1; i < a.Length; i++)
                {
                    char f = a[flag];
                    if (f == a[i])
                    {
                        flag++;

                    }
                }
                
                Console.WriteLine(a[flag]);
                resultArray[j] = a[flag];   
            }


            foreach(char l in resultArray)
            {
                Console.WriteLine(l);
            }

            char uniq = resultArray[0];
            
            for(int j = 0; j < resultArray.Length; j++)//цикл для поиска уникального символа из массива
            {

                int flag = 0;
                
                for (int i = 1; i < resultArray.Length; i++)
                {
                    uniq = resultArray[flag];
                    if (uniq == resultArray[i])
                    {
                        flag++;
                        i = flag + 1;
                    }
                }

            }
            Console.WriteLine("---------");
            Console.WriteLine(uniq);//виводим уникальный символ в консоль
            Console.WriteLine("---------");
        }
    }
}
