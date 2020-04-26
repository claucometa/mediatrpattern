using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SetSegmentoCommand : BaseCommand, IRequest<TaskResponse>
    {
        public SetSegmentoCommand(ItemVm item) : base(item) { }
    }

    public class SetSegmentoHandler : IRequestHandler<SetSegmentoCommand, TaskResponse>
    {
        public async Task<TaskResponse> Handle(SetSegmentoCommand request, CancellationToken cancellationToken)
        {
            Thread.Sleep(1000);

            return await Task.FromResult(new TaskResponse($"Incluí {request.Item.Segmento}"))
                .ConfigureAwait(false);
        }
    }
}