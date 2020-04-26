using System.Collections.Generic;

namespace ConsoleApp1
{
    static class FilaRepository
    {
        public static int count = 0;
        public static Queue<Item> Items = new Queue<Item>();

        static FilaRepository()
        {
            for (int i = 1; i < 2; i++)
            {
                count = i;
                Add(i);
            }
        }

        public static void AddRandom()
        {
            Add(++count);
        }

        private static void Add(int i)
        {
            Items.Enqueue(new Item(i, $"CNPJ {i}", $"{(i % 2 == 0 ? "BLOQUEIO" : "DESBLOQUEIO")}", $"Motivo {i}", $"Segmento {i}"));
        }
    }
}
