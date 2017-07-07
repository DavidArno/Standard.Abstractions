namespace Standard.Abstractions.IO
{
    public class ConcreteSystemIO : ISystemIO
    {
        public IDirectory Directory { get; } = new DirectoryProxy();
    }
}
