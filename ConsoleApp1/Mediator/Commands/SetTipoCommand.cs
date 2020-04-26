using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SetTipoCommand : BaseCommand, IRequest<TaskResponse>
    {
        public SetTipoCommand(ItemVm item) : base(item) { }
    }

    public class SetTipoHandler : IRequestHandler<SetTipoCommand, TaskResponse>
    {
        public async Task<TaskResponse> Handle(SetTipoCommand request, CancellationToken cancellationToken)
        {
            Thread.Sleep(1000);

            return await Task.FromResult(new TaskResponse($"Incluí {request.Item.Tipo}"))
                .ConfigureAwait(false);
        }
    }
}