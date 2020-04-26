namespace ConsoleApp1
{
    public class ItemVm
    {
        public readonly int ID;
        public readonly string CNPJ;
        public readonly string Tipo;
        public readonly string Motivo;
        public readonly string Segmento;
        public bool Bloqueio => Tipo == "BLOQUEIO";
        public string ErrorMessage;        

        public bool Success => string.IsNullOrEmpty(ErrorMessage);
    
        public ItemVm(Item item)
        {
            this.ID = item.ID;
            this.CNPJ = item.CNPJ;
            this.Tipo = item.Tipo;
            this.Motivo = item.Motivo;
            this.Segmento = item.Segmento;
        }
    }
}
