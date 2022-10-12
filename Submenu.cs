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
    
    // skappad en ny class som ska hantera alla operationer som vi ska göra med köksapparater 

    public class Submenu
    {
        string inputType = string.Empty, inputBrand = string.Empty;  // variabel som används för att skappa en ny apparat 
        bool yesOrNo = false;                                        // variable som används för att skappa en ny apparat
        int input = 0;                                               // variable som vi ska använda för att läsa användare input från tangenbordet


        // method som skriver ut lista av alla köksapparater, inklusiv dem som vi har lagt in i programet
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

        // method som låter användaren att välja en apparat och "använda" den genom anrop till Use methoden definierat i Köksapparater classen
        public void användApparat(List<KöksApparater> lista)
        {
            Console.WriteLine("\t====== Användning av köksapparater ======\n"); 
            Console.WriteLine("Vilken köksapparat vill du använda? :");
            visaListaK(lista);
            input = GetInput(lista);
            if (lista[input - 1].IsFunctioning != false)
            {
                lista[input - 1].Use(lista[input - 1].Type);
                Console.WriteLine("Vill du använda en annan köksapparat? (j/n)");
                Console.Write(" -> ");

                if (YesOrNo(Console.ReadLine()) == true)
                {
                    Console.Clear();
                    användApparat(lista);
                }
                else
                {
                    Console.WriteLine("Tillbaka till huvudmeny!\n");
                    ReturnToMain();
                }
                    
                
            }
            else
            {
                Console.WriteLine($"Köksapparaten {lista[input - 1].Type} är urfunktion!");
                Console.WriteLine("Vill du använda en annan köksapparat? (j/n)");
                Console.Write(" -> ");
             
                if (YesOrNo(Console.ReadLine()) == true)
                {
                    Console.Clear();
                    användApparat(lista);
                }
                else
                {
                    Console.WriteLine("Tillbaka till huvudmeny!\n");
                    ReturnToMain();
                }

            }


        }

        // method som låter användaren lägga till en ny apparat 
        public void läggTill(List<KöksApparater> lista)
        {
            
      
            Console.WriteLine("\t====== Lägg till en ny köksapparat! ====== \n");
            Console.WriteLine("Ange köksapparatens namn :");
            Console.Write(" -> ");
            inputType = Console.ReadLine();
            Console.WriteLine("Ange köksapparatens märke :");
            Console.Write(" -> ");
            inputBrand = Console.ReadLine();
            Console.WriteLine("Ange om den funkar eller inte (j/n) :");
            Console.Write(" -> ");
            yesOrNo = YesOrNo(Console.ReadLine());
            var apparat = new KöksApparater(inputType, inputBrand, yesOrNo);

            if (CheckIfFinds(lista, apparat) == true)
            {
                Console.WriteLine($"En köksapparat med samma namn,av samma märke och som {CheckIsFunctioning(apparat)} finns redan i listan!");
                Console.WriteLine("Är du säker att du vill lägga till ändå? (j/n)");
                Console.Write(" -> ");

                if (YesOrNo(Console.ReadLine()) == true)
                {
                    lista.Add(apparat);
                    Console.WriteLine("\nKöksapparaten laggt till kökets lista!\n\n");

                    Console.WriteLine("Vill du lägga till fler apparater? (j/n)");
                    Console.Write(" -> ");
                  
                    if (YesOrNo(Console.ReadLine()) == true)
                    {
                        Console.Clear();
                        läggTill(lista);
                    }
                    else
                    {
                        Console.WriteLine("Tillbaka till huvudmeny!\n");
                        ReturnToMain();
                    }
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
               
                if (YesOrNo(Console.ReadLine()) == true)
                {
                    Console.Clear();
                    läggTill(lista);
                }
                else
                {
                    Console.WriteLine("Tillbaka till huvudmeny!\n");
                    ReturnToMain();
                }
            }
          
           
        }


        //method som låter användaren ta bort en apparat från listan
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
           
            if (YesOrNo(Console.ReadLine()) == true)
            {
                Console.Clear();
                taBort(lista);
            }
            else
            {
                Console.WriteLine("Tillbaka till huvudmeny!\n");
                ReturnToMain();
            }

        }

       

        // method som läser in användarens input och returnerar den eller vad är som som har gåt fel
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

        // method som returnerar i string format om en apparat funkar eller inte
        // methoden används när vi skriver ut listan eller när en ny apparat skappas för att inte ha duplicater
        private static string CheckIsFunctioning(KöksApparater apparat)
        {
            string function = string.Empty;
            if (apparat.IsFunctioning == true)
                function = "funkar bra";
            else if (apparat.IsFunctioning == false)
                function = "är urfunktion";
            return function;
        }
        
        // method som låter användare välja mellan Ja eller NEJ och returnerar variabeln eller vad som har gått fel
        // methoden används för att läsa isFuntioning attribut eller för att läsa om användaren vill fortsätta i samma submeny 
        //  eller gå tillbaka
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

        // method som kollar den nyskappad apparat om den redan finns i lista
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

        //method som väntar så att användaren trycker Enter tangent för att gå tillbaka till huvudmeny
        //på så sätt kan man läsa vad som står på skärmen innan den rensas och huvudmeny skrivas ut
        private static void ReturnToMain()
        {
            Console.WriteLine("\nTryck ENTER för att gå tillbaka till huvudmeny");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
                Console.Clear();
            else
                ReturnToMain();
        }

       
    }

   
}
