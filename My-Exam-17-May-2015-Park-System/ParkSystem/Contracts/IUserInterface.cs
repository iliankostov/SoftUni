namespace ParkSystem.Contracts
{
    public interface IUserInterface
    {
        string ReadLine(); 

        void WriteLine(string format, params string[] args);
    }
}