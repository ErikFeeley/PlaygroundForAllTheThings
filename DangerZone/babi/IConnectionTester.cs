namespace babi
{
    using System.Threading.Tasks;

    public interface IConnectionTester
    {
        Task TestConnection();
    }
}
