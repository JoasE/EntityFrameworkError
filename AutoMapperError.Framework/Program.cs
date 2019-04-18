namespace AutoMapperError.Framework
{
    class Program
    {
        static void Main(string[] args)
        {
            Shared.Replicator.Replicate().Wait();
        }
    }
}
