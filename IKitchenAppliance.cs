using Labb2;
using System.Reflection.Metadata;

namespace Labb2
{

    // Kitchen appliances interface som vi ska jobba på
    public interface IKitchenAppliance
    {
        string Type { get; set; }
        string Brand { get; set; }
        public bool IsFunctioning { get; set; }
        void Use(string namn);
    }

    


    // skappad en KöksApparat class för att kunna skappa och lagra information för varje apparat 
    // baserad på IKitchenAppliace interface atributer
public class KöksApparater : IKitchenAppliance
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public bool IsFunctioning { get; set; }
   
    public void Use(string namn) 
    {
        Console.WriteLine($"\n\nAnvändning av {namn} !");
        Console.WriteLine("Vänta");
        for (int i = 5; i >= 0; i--)
        {

            Console.Write($"\r{i}");
            System.Threading.Thread.Sleep(1000);

        }

        Console.WriteLine("\nAnvändning Klart! Smaklig måltid!");
    }

    public KöksApparater(string type, string brand, bool isFunctioning)
    {
        Type = type;
        Brand = brand;
        IsFunctioning = isFunctioning;
    }

}
   
}
