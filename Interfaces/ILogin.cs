namespace ms_controle_financeiro.Interfaces;

public interface ILogin<in T, out A>
{
    Boolean Login(T userLogin);
}
