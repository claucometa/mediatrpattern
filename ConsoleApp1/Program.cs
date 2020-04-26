using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    /// <summary>
    /// INotificationHandler<TaskDetails> ===>> subscreve às notificações do TaskDetails
    /// </summary>
    partial class Program : INotificationHandler<TaskHello>
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IMediator, Mediator>()
                .AddSingleton(typeof(IPipelineBehavior<,>), typeof(SplunkStartPipe<,>))
                .AddMediatR(typeof(Program))
                .BuildServiceProvider();

            var mediator = serviceProvider.GetService<IMediator>();

            TaskFabric task = new TaskFabric();

            task.Process(mediator).Start();

            task.SignalProcessPeriodically().Start();

            new UserUI().UserInput().Start();

            AppContext.waitExit.WaitOne();
        }

        public async Task Handle(TaskHello notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Recebi notificação da classe: {notification}");
            await Task.Delay(0);
        }
    }
}
