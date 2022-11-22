namespace TimeApp.Business.Gateway
{
    public interface IUnitOfWork : IDisposable
    {
        ILeaveTypeRepository LeaveTypeRepository { get; }
        Task Save();
    }
}
