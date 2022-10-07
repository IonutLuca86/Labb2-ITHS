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

public class K�ksApparater : IKitchenAppliance
{
    

    public string Type { get; set; }
    public string Brand { get; set; }
    public bool IsFunctioning { get; set; }
    public void Use(string namn)
    {
        Console.WriteLine($"\n\nAnv�ndning av {namn} k�ksapparat!");
        Console.WriteLine("V�nta");
        for (int i = 9; i >= 0; i--)
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
