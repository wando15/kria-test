namespace Domain.Interfaces.Commands
{
    public interface ICommand
    {
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
