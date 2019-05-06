namespace Mk.BusinessLibrary.Payment.Errors
{
    public class ModuleError
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
