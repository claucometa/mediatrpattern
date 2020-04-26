using MediatR;

namespace ConsoleApp1
{
    internal class TaskHello : INotification
    {
        public readonly BaseCommand request;
        public readonly TaskResponse response;

        public TaskHello(BaseCommand x, TaskResponse response)
        {
            this.response = response;
            this.request = x;
        }

        public override string ToString()
        {
            return request.GetType().Name + "-" + response.GetType().Name;
        }
    }
}