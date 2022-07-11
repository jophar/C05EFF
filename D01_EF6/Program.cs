using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D01_EF6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities()) // tem de ser o nome da connection string
            {
                // Criar uma nova regiao (region)
                Region region = new Region();
                region.RegionID = 5;
                region.RegionDescription = "Norte";

                // db.Region.Add(region);

                // db.SaveChanges(); // gravar em BD

                var queryRegions = db.Region.Select(r => r).OrderBy(r => r.RegionID);

                foreach (var item in queryRegions)
                {
                    Console.WriteLine($"{item.RegionID} - {item.RegionDescription}");
                }

                // Criar um novo territorio (territory) na nova regiao

                Territories territories = new Territories();

                territories.TerritoryID = "00001";
                territories.TerritoryDescription = "Espinho";
                territories.RegionID = 5;

                db.Territories.Add(territories);

                db.SaveChanges();

                var queryTerritories = db.Territories.Select(r => r).OrderBy(r => r.TerritoryID);

                foreach (var item in queryTerritories)
                {
                    Console.WriteLine($"{item.TerritoryID} - {item.TerritoryDescription} - {item.RegionID}");
                }

                Console.ReadLine();

            }
        }
    }
}
