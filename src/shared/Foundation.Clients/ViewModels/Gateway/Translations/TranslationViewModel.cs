namespace Foundation.Clients.ViewModels
{
    public class TranslationViewModel
    {
        public string TranslationCode { get; set; }
        public string Code => TranslationCode;
        public string Value { get; set; }
    }
}