using MediatR.Pipeline;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Faz o login final do splunk
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    class SplunkEndPipe<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        public Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            var nome = request.GetType().Name;

            Console.WriteLine($"Log splunk: Finaliza etapa {nome}");

            return Task.FromResult(response);
        }
    }
}