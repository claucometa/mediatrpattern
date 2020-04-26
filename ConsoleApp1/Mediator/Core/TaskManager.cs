using MediatR;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Program
    {
        public class TaskFabric
        {
            /// <summary>
            /// Processa um item da fila
            /// </summary>
            /// <param name="mediator"></param>
            /// <returns></returns>
            public Task Process(IMediator mediator)
            {
                return new Task(async () =>
                {
                    ItemVm item = null;

                    while (true)
                    {
                        try
                        {
                            AppContext.waitNext.WaitOne();
                            AppContext.Processando = true;
                            if (await AgenciaDigital.Invalido()) continue;
                            item = await new GetItemService().ObterProximo();                            
                            await mediator.Send(new SetBloqueioCommand(item));
                            await mediator.Send(new SetCNPJCommand(item));
                            await mediator.Send(new SetTipoCommand(item));
                            await mediator.Send(new SetSegmentoCommand(item));
                            await mediator.Send(new SetMotivoCommand(item));
                        }
                        catch (Exception ex)
                        {
                            if (item != null) item.ErrorMessage = ex.Message;
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            if (item != null)
                            {
                                await mediator.Send(new FinalizaCommand(item));
                                item = null;
                            }
                            AppContext.Processando = false;
                        }
                    }
                }, TaskCreationOptions.LongRunning);
            }

            /// <summary>
            /// Inicia o processamento periodicamente quando a aplicação está em execução
            /// </summary>
            /// <returns></returns>
            public Task SignalProcessPeriodically()
            {
                return new Task(async () =>
                {
                    while (true)
                    {
                        await Task.Delay(TimeSpan.FromSeconds(AppContext.AwaitingTimeInSeconds));
                        if (!AppContext.pause)
                        {
                            if (!AppContext.Processando)
                            {
                                Console.WriteLine("\r\nDá um handshake para a thread de processamento");
                                AppContext.waitNext.Set();
                            }
                        }
                    }
                });
            }
        }
    }
}
