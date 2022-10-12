using Labb2;
using System.Reflection.Metadata;

namespace Labb2
{

    // Kitchen appliances interface som vi ska jobba p�
    public interface IKitchenAppliance
    {
        string Type { get; set; }
        string Brand { get; set; }
        public bool IsFunctioning { get; set; }
        void Use(string namn);
    }

    


    // skappad en K�ksApparat class f�r att kunna skappa och lagra information f�r varje apparat 
    // baserad p� IKitchenAppliace interface atributer
public class K�ksApparater : IKitchenAppliance
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public bool IsFunctioning { get; set; }
   
    public void Use(string namn) 
    {
        Console.WriteLine($"\n\nAnv�ndning av {namn} !");
        Console.WriteLine("V�nta");
        for (int i = 5; i >= 0; i--)
        {

            Console.Write($"\r{i}");
            System.Threading.Thread.Sleep(1000);

        }

        Console.WriteLine("\nAnv�ndning Klart! Smaklig m�ltid!");
    }

    public K�ksApparater(string type, string brand, bool isFunctioning)
    {
        Type = type;
        Brand = brand;
        IsFunctioning = isFunctioning;
    }

}
   
}
