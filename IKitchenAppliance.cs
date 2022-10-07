using Labb2;

namespace Labb2
{
    public interface IKitchenAppliance
    {
        string Type { get; set; }
        string Brand { get; set; }
        public bool IsFunctioning { get; set; }
        void Use(string namn);
    }

public class KöksApparater : IKitchenAppliance
{
    

    public string Type { get; set; }
    public string Brand { get; set; }
    public bool IsFunctioning { get; set; }
    public void Use(string namn)
    {
        Console.WriteLine($"\n\nAnvändning av {namn} köksapparat!");
        Console.WriteLine("Vänta");
        for (int i = 9; i >= 0; i--)
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
