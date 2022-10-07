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
        string inputType = string.Empty, inputBrand = string.Empty;
        bool yesOrNo = false;
        int input = 0;

        public void visaListaK(List<KöksApparater> lista)
        {
            Console.WriteLine("\t====== Lista av Köksapparater ======= \n");
            Console.WriteLine($"Lista över alla köksapparater i köket är: ");
            int counter = 1;
            
            foreach (var apparat in lista)
            {   
                Console.WriteLine($"\t{counter}. {apparat.Type} av märke {apparat.Brand} som {CheckIsFunctioning(apparat)}");
                counter++;
            }
           
        }

        public void användApparat(List<KöksApparater> lista)
        {
            Console.WriteLine("\t====== Användning av köksapparater ======\n"); 
            Console.WriteLine("Vilken köksapparat vill du använda? :");
            visaListaK(lista);
            input = GetInput(lista);
            if (lista[input-1].IsFunctioning != false) 
                lista[input-1].Use(lista[input-1].Type);
            else
            {
                Console.WriteLine($"Köksapparaten {lista[input - 1].Type} är urfunktion!");
                Console.WriteLine("Vill du använda en annan köksapparat? (j/n)");
                Console.Write(" -> ");
                yesOrNo = YesOrNo(Console.ReadLine());
                if (yesOrNo == true)
                    användApparat(lista);
                else
                    Console.WriteLine("Tillbaka till huvudmeny!\n");
                
            }


        }

        public void läggTill(List<KöksApparater> lista)
        {
            
      
            Console.WriteLine("\t====== Lägg till en ny köksapparat! ====== \n");
            Console.WriteLine("Ange köksapparatens namn :");
            inputType = Console.ReadLine();
            Console.WriteLine("Ange köksapparatens märke :");
            inputBrand = Console.ReadLine();
            Console.WriteLine("Ange om den funkar eller inte (j/n) :");
            yesOrNo = YesOrNo(Console.ReadLine());
            var apparat = new KöksApparater(inputType, inputBrand, yesOrNo);

            if (CheckIfFinds(lista, apparat) == true)
            {
                Console.WriteLine($"En köksapparat med samma namn,av samma märke och som {CheckIsFunctioning(apparat)} finns redan i listan!");
                Console.WriteLine("Är du säker att du vill lägga till ändå? (j/n)");

                if (YesOrNo(Console.ReadLine()) == true)
                {
                    lista.Add(apparat);
                    Console.WriteLine("\nKöksapparaten laggt till kökets lista!\n\n");

                    Console.WriteLine("Vill du lägga till fler apparater? (j/n)");
                    Console.Write(" -> ");
                    yesOrNo = YesOrNo(Console.ReadLine());
                    if (yesOrNo == true)
                    {
                        Console.Clear();
                        läggTill(lista);
                    }
                    else
                        Console.WriteLine("Tillbaka till huvudmeny!\n");
                }
                else
                    läggTill(lista);
            }
            else
            {
                lista.Add(apparat);
                Console.WriteLine("\nKöksapparaten laggt till kökets lista!\n\n");

                Console.WriteLine("Vill du lägga till fler apparater? (j/n)");
                Console.Write(" -> ");
                yesOrNo = YesOrNo(Console.ReadLine());
                if (yesOrNo == true)
                {
                    Console.Clear();
                    läggTill(lista);
                }
                else
                    Console.WriteLine("Tillbaka till huvudmeny!\n");
            }
          
           
        }



        public void taBort(List<KöksApparater> lista)
        {
            Console.WriteLine("\t====== Ta bort Köksapparater ======\n");
            visaListaK(lista);
            Console.WriteLine($"Ange vilken apparat vill du ta bort :");
            input = GetInput(lista);
            lista.Remove(lista[input-1]);
            Console.WriteLine("\nKöksapparaten är borta från kökets lista!\n\n");
            Console.WriteLine("Vill du ta bort fler apparater? (j/n)");
            Console.Write(" -> ");
            yesOrNo = YesOrNo(Console.ReadLine());
            if (yesOrNo == true)
            {
                Console.Clear();
                taBort(lista);
            }
            else
                Console.WriteLine("Tillbaka till huvudmeny!\n");

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

        private static string CheckIsFunctioning(KöksApparater apparat)
        {
            string function = string.Empty;
            if (apparat.IsFunctioning == true)
                return function = "funkar bra";
            else if (apparat.IsFunctioning == false)
                return function = "är urfunktion";
            return function;
        }
        

        private static bool YesOrNo(string s)
        {
            bool getbool = false;
            if (s == "j")
                getbool = true;
            else if (s == "n")
                getbool = false;
            else
            {
                Console.WriteLine("Skriv 'j' eller 'J' om JA eller 'n'/'N' om NEJ! ");
                YesOrNo(s);
            }
            return getbool;
        }

        private static bool CheckIfFinds(List<KöksApparater> lista, KöksApparater apparat)
        { 
            bool itFinds = false;

            foreach (var app in lista)
            { 
                if(app.Type.ToString().Equals(apparat.Type.ToString()) &&
                    app.Brand.ToString().Equals(apparat.Brand.ToString()) &&
                    app.IsFunctioning.Equals(apparat.IsFunctioning))
                    itFinds = true;
                
            }
            return itFinds;
           
        }

       
    }

   
}
