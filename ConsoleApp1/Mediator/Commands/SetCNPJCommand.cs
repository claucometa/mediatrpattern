using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SetCNPJCommand : BaseCommand, IRequest<TaskResponse>
    {
        public SetCNPJCommand(ItemVm item) : base(item) { }
    }

    public class SetCNPJHandler : IRequestHandler<SetCNPJCommand, TaskResponse>
    {
        public async Task<TaskResponse> Handle(SetCNPJCommand request, CancellationToken cancellationToken)
        {
            Thread.Sleep(1000);

            return await Task.FromResult(new TaskResponse($"Incluí {request.Item.CNPJ}"))
                .ConfigureAwait(false);
        }
    }
}