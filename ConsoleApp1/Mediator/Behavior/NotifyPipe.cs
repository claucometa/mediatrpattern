using MediatR;
using MediatR.Pipeline;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Behavior
{
    /// <summary>
    /// Envia uma notificação ao final de cada task para ser 
    /// capturada pelo front-end numa aplicação winforms, por exemplo
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    class NotifyPipe<TRequest, TResponse> : IRequestPostProcessor<TRequest, TResponse>
    {
        private readonly IMediator _mediator;

        public NotifyPipe(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Process(TRequest request, TResponse response, CancellationToken cancellationToken)
        {
            await _mediator.Publish(new TaskHello(request as BaseCommand, response as TaskResponse));
        }
    }
}
