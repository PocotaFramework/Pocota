namespace Net.Leksi.Pocota.Common
{
    public interface IModelBuilder
    {
        Language ClientLanguage { get; set; }
        void BuildConnector(ClassModel baseModel, string selector);
        void BuildControllerInterface(ClassModel model, string selector);
        void BuildControllerProxy(ClassModel model, string selector);
        void BuildServerImplementation(ClassModel model, string selector);
        void BuildClientImplementation(ClassModel model, string selector);
        void BuildPrimaryKey(ClassModel model, string selector);
    }
}