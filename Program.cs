// See https://aka.ms/new-console-template for more information




using Labb2;
using Labb2_ITHS;

List<KöksApparater> apparats = new List<KöksApparater>()
{
 new KöksApparater("MicroUngn","Electrolux",true),
 new KöksApparater("Brödrost", "Andersson", true),
 new KöksApparater("Våffeljärn", "OBH Nordica",false),
 new KöksApparater("Vattenkokare","Andersson", true),
 new KöksApparater("Ugn", "Electrolux",false),
 new KöksApparater("Spis","Bosch",true)
};



Submenu submenu = new Submenu();


bool menu = true;
while (menu)
{
    menu = GenerateMainMenu(apparats, submenu);
}

static bool GenerateMainMenu(List<KöksApparater> apparats, Submenu submenu)
{

    Console.WriteLine("\n============================= Köket ==================================\n");
    Console.WriteLine("\t 1. Använd Köksapparat");
    Console.WriteLine("\t 2. Lägg till köksapparat");
    Console.WriteLine("\t 3. Lista över alla Köksapparater");
    Console.WriteLine("\t 4. Ta bort Köksapparat");
    Console.WriteLine("\t 0. Avsluta");
    Console.WriteLine("\n======================================================================\n");
    Console.WriteLine("\n\t Ange ditt val: ");
    Console.WriteLine();


    switch (GetChoice())
    {
        case 1:
            {
                Console.Clear();
                submenu.användApparat(apparats);
                Console.WriteLine("\n\n");
                return true;
            }
        case 2:
            {
                Console.Clear();
                submenu.läggTill(apparats);
                return true;
            }
        case 3:
            {
                Console.Clear();
                submenu.visaListaK(apparats);
                Console.WriteLine("\n\n");
                return true;
            }
        case 4:
            {
                Console.Clear();
                submenu.taBort(apparats);
                return true;
            }
        case 0:
            return false;
        default:
            return true;



    }

}

static int GetChoice()
{
    int choice = 0;

    try
    {

        Console.Write("-> ");
        choice = Int32.Parse(Console.ReadLine());
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        Console.WriteLine("\n Valet måste vara melan 0 och 4!");
        GetChoice();
    }
    if (choice < 0 || choice > 4)
    {
        Console.WriteLine("Valet måste vara melan 0 och 4!");
        GetChoice();
    }

    return choice;
}
