namespace ConsoleApp1
{
    public class Item
    {
        public readonly int ID;
        public readonly string CNPJ;
        public readonly string Tipo;
        public readonly string Motivo;
        public readonly string Segmento;

        public Item(int id, string cnpj, string tipo, string motivo, string segmento)
        {
            this.ID = id;
            this.CNPJ = cnpj;
            this.Tipo = tipo;
            this.Motivo = motivo;
            this.Segmento = segmento;
        }
    }
}
