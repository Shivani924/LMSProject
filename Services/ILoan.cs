namespace LMSProject.Services
{
    public interface ILoan<K,T>
    {
        T Add(T item);
        T Get(K key);

        T UpdateStatus(T item);

        ICollection<T> GetAll();
        T Update(T item);
        T Delete(K key);
    }
}
