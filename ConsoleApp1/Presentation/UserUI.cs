using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Program
    {
        public class UserUI
        {
            const int size = 63;
            /// <summary>
            /// Trhead de input do usuário
            /// </summary>
            /// <returns></returns>
            public Task UserInput()
            {
                return new Task(() =>
                {
                    do
                    {
                        Console.WriteLine($" =".PadRight(size, '='));
                        Console.WriteLine($"# Demo app using design pattern Mediator + CQRS".PadRight(size) + "#");
                        Console.WriteLine($"# CQRS: Command Query Responsibility Segregation".PadRight(size) + "#");
                        Console.WriteLine($"# ENTER: play/pause".PadRight(size) + "#");
                        Console.WriteLine($"# BACKSPACE: adiciona item [bloqueio ou desbloqueio] na fila".PadRight(size) + "#");
                        Console.WriteLine($"# SPACE: limpa a tela".PadRight(size) + "#");
                        Console.WriteLine($"# ESC: exit".PadRight(size) + "#");
                        Console.WriteLine($"# Status => Fila: {FilaRepository.Items.Count} | Aplicação: {(AppContext.pause ? "Pausada" : "Executando")}".PadRight(size) + "#");
                        Console.WriteLine($" =".PadRight(size, '='));
                        Console.WriteLine();

                        var x = Console.ReadKey();

                        if (x.Key == ConsoleKey.Enter)
                        {
                            AppContext.pause = !AppContext.pause;
                            if (!AppContext.pause) AppContext.waitNext.Set();
                        }

                        if (x.Key == ConsoleKey.Spacebar)
                        {
                            Console.Clear();
                        }

                        if (x.Key == ConsoleKey.Backspace)
                        {
                            FilaRepository.AddRandom();
                            Console.Clear();
                        }

                        if (x.Key == ConsoleKey.Escape)
                        {
                            AppContext.waitExit.Set();
                            break;
                        }

                    } while (true);
                });
            }
        }
    }
}
