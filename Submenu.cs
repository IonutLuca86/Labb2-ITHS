using Labb2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_ITHS
{
    
    

    public class Submenu 
    {
        
        public void visaListaK(List<KöksApparater> lista)
        {
            Console.WriteLine($"Lista över alla köksapparater i köket är: ");
            int counter = 1;
            string function = string.Empty;
            foreach (var apparat in lista)
            {                              
                if (apparat.IsFunctioning == true) 
                    function = "funkar bra";
                else if (apparat.IsFunctioning == false)
                    function = "är urfunktion";
                Console.WriteLine($"\t{counter}. {apparat.Type} av märke {apparat.Brand} som {function}");
                counter++;
            }
           
        }

        public void AnvändApparat(List<KöksApparater> lista)
        {
           
            Console.WriteLine("Vilken köksapparat vill du använda? :");
            visaListaK(lista);
            int input = GetInput(lista);
            if (lista[input-1].IsFunctioning != false) 
                lista[input-1].Use(lista[input-1].Type);
            else
            {
                Console.WriteLine($"Köksapparaten {lista[input - 1].Type} är urfunktion!");
                Console.WriteLine("Vill du använda en annan köksapparat? J/N");

                Console.Write(" -> ");
                string input2 = Console.ReadLine();
                if (input2 == "j" || input2 == "J")
                    AnvändApparat(lista);
                else
                    if (input2 == "n" || input2 == "N")
                    Console.Clear();
                else
                    Console.WriteLine("Ange bara j eller J om du vill använda en annan köksapparat \n eller n/N för att avbryta och gp till förregående menu");
            }


        }
           

        

        private static int GetInput(List<KöksApparater> lista)
        {
            int choice = 0;

            try
            {

                Console.Write("-> ");
                choice = Int32.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n Valet måste vara melan 1 och {lista.Count}! \n {e}");
                GetInput(lista);
            }
            if (choice < 0 || choice > lista.Count)
            {
                Console.WriteLine($"\n Valet måste vara melan 1 och {lista.Count}!");
                GetInput(lista);
            }

            return choice;
        }
       
    }

   
}
