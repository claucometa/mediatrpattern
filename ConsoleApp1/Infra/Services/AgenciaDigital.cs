using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class AgenciaDigital
    {
        internal static async Task<bool> Invalido()
        {
            if (await EstaNoLugarCerto()) return false;
            await VerificaJanela();
            await FazLogin();
            await AcessaMenuFlutuante();
            await AcessaMenuDomiciliacao();
            return true;
        }

        internal static async Task FazLogin()
        {
            Console.WriteLine("Faz login");
            await Task.Delay(2000);
        }

        internal static async Task AcessaMenuFlutuante()
        {
            Console.WriteLine("Acessa Menu Flutuante");
            await Task.Delay(2000);
        }

        internal static async Task AcessaMenuDomiciliacao()
        {
            Console.WriteLine("Acessa Menu Domiciliacao");
            await Task.Delay(2000);
        }

        internal static async Task VerificaJanela()
        {
            Console.WriteLine("Verificando janela da EA");
            await Task.Delay(2000);
        }

        internal static async Task<bool> EstaNoLugarCerto()
        {
            Console.WriteLine("Está no lugar certo?");
            await Task.Delay(2000);
            return true;
        }
    }
}