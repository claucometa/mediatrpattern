using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// Faz o login inicial do splunk
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    class SplunkStartPipe<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var processo = request.GetType().Name;
            var x = request as BaseCommand;

            Console.WriteLine($"\r\nLog splunk: Inicia etapa {processo} | Item id: {x.Item.ID}");

            return next();
        }
    }
}