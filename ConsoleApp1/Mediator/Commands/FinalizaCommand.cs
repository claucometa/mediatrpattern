using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class FinalizaCommand : BaseCommand, IRequest<TaskResponse>
    {
        public FinalizaCommand(ItemVm item) : base(item) { }
    }

    public class FinalizaHandler : IRequestHandler<FinalizaCommand, TaskResponse>
    {
        public async Task<TaskResponse> Handle(FinalizaCommand request, CancellationToken cancellationToken)
        {
            Thread.Sleep(1000);

            return await Task.FromResult(new TaskResponse($"Finaliza item: {request.Item.ID}"))
                .ConfigureAwait(false);
        }
    }
}