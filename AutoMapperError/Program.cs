namespace AutoMapperError
{
    class Program
    {
        public static void Main(string[] args)
        {
            Shared.Replicator.Replicate().Wait();
        }
    }
}
