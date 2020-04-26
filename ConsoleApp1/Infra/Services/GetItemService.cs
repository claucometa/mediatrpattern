using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class GetItemService
    {
        public async Task<ItemVm> ObterProximo()
        {
            Console.WriteLine("Obtém próximo");

            if (FilaRepository.Items.Count == 0)
                await Task.FromException(new Exception("Nenhum item encontrado"));

            var item = FilaRepository.Items.Dequeue();

            Console.WriteLine($"Item encontrado: {item.CNPJ}");

            Thread.Sleep(1000);

            return await Task.FromResult(new ItemVm(item));
        }
    }
}