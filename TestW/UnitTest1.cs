using System.Diagnostics;
using WarehLib;
using warehousenet2;
namespace TestW
{
    public class UnitTest1
    {
        [Fact]
        public void Add()
        {
            Logica logica = new();
            
            Tovar test = new()
            {
                FullName = "гвоздь",
                Razmer = 1,
                Material = material.Железо,
                kolvo = 100,
                minpr = 3,
                price = 5,
            };
            logica.Add(test);
var result = logica.Get();
            Assert.Equal(test, result[0]);
        }

        [Fact]
        public void Change()
        {
            Logica logica = new();
            
            Tovar test = new()
            {
                FullName = "гвоздь",
                Razmer = 1,
                Material = material.Железо,
                kolvo = 100,
                minpr = 3,
                price = 5,
            };
            logica.Add(test);
            Tovar test2 = new()
            {
                FullName = "шуруп",
                Razmer = 4,
                Material = material.Медь,
                kolvo = 165,
                minpr = 3,
                price = 3,
            };

            logica.Change(test2,test);
var result = logica.Get();
            Assert.Equal(test2, result[0]);
        }

        [Fact]
        public void Delete()
        {
            Logica logica = new();
            
            Tovar test = new()
            {
                FullName = "гвоздь",
                Razmer = 1,
                Material = material.Железо,
                kolvo = 100,
                minpr = 3,
                price = 5,
            };
            logica.Add(test);
            logica.Remove(test);
var result = logica.Get();
            Assert.Empty(result);
        }
    }
}
