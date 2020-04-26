using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SetMotivoCommand : BaseCommand, IRequest<TaskResponse>
    {
        public SetMotivoCommand(ItemVm item) : base(item) { }
    }

    public class SetMotivoHandler : IRequestHandler<SetMotivoCommand, TaskResponse>
    {
        public async Task<TaskResponse> Handle(SetMotivoCommand request, CancellationToken cancellationToken)
        {
            Thread.Sleep(1000);

            return await Task.FromResult(new TaskResponse($"Incluí {request.Item.Motivo}"))
                .ConfigureAwait(false);
        }
    }
}