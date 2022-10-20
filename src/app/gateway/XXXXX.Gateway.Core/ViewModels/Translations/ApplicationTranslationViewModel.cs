namespace XXXXX.Gateway.Core.ViewModels
{
    public class ApplicationTranslationViewModel
    {
        public string TranslationCode { get; set; }
        public string Code => TranslationCode;
        public string Value { get; set; }
    }
}