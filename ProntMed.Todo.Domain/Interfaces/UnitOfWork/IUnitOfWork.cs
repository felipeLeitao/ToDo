namespace ProntMed.Todo.Domain.Interfaces.UnityOfWork
{
    public interface IUnitOfWork
    {
        void Begin();

        void Commit();

        void RollBack();
    }
}
