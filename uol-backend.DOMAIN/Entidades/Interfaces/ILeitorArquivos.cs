namespace uol_backend.DOMAIN.Entidades.Interfaces
{
    public interface ILeitorArquivos<T>
    {
        Task<T> LerArquivo();
    }
}
