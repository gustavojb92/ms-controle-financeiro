
namespace ms_controle_financeiro.Interfaces
{
    public interface IUpdate<in T, out A>
    {
        A Put(int id, T obj);
    }
}