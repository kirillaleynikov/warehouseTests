using warehousenet2;
namespace WarehLib
{
    public class Logica
    {
        private List<Tovar> WareL = new List<Tovar>();

        public Logica() { }
        public void Add(Tovar argument)
        {
            WareL.Add(argument);
        }
        public void Remove(Tovar argument)
        {
            WareL.Remove(argument);
        }
        public void Change(Tovar argument, Tovar id)
        {
            var index = WareL.IndexOf(id);
            WareL[index] = argument;
        }
        public List<Tovar> Get()
        {
            return WareL;
        }
    }
}