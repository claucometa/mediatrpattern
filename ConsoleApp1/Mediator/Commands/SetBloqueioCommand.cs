using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SetBloqueioCommand : BaseCommand, IRequest<TaskResponse>
    {
        public SetBloqueioCommand(ItemVm item) : base(item) { }
    }

    public class BloqueioHandler : IRequestHandler<SetBloqueioCommand, TaskResponse>
    {
        public async Task<TaskResponse> Handle(SetBloqueioCommand request, CancellationToken cancellationToken)
        {
            Thread.Sleep(1000);

            return await Task.FromResult(new TaskResponse($"Incluí {request.Item.Tipo}"))
                .ConfigureAwait(false);
        }
    }
}