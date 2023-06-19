namespace Net.Leksi.Pocota.Common;

public class CodeGenerator
{
    public Language ClientLanguage { get; set; } = Language.CSharp;

    internal void BuildClientImplementation(ClassModel classModel)
    {
        throw new NotImplementedException();
    }

    internal void BuildConnector(ClassModel classModel)
    {
        throw new NotImplementedException();
    }

    internal void BuildControllerInterface(ClassModel classModel)
    {
        throw new NotImplementedException();
    }

    internal void BuildControllerProxy(ClassModel classModel)
    {
        throw new NotImplementedException();
    }

    internal void BuildPrimaryKey(ClassModel classModel)
    {
        throw new NotImplementedException();
    }

    internal void BuildServerImplementation(ClassModel classModel)
    {
        throw new NotImplementedException();
    }
}
