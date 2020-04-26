using MediatR.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Faz o login na database
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    class LogDBPipe<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            var nome = request.GetType().Name;

            Console.WriteLine($"Log DB: Finaliza etapa {nome}");

            return Task.FromResult(request);
        }
    }
}