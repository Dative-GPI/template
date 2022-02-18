using System;
using System.Collections.Generic;

namespace XXXXX.Domain.Models
{
    public interface ITranslatable<TTranslation> where TTranslation : ITranslation
    {
        List<TTranslation> Translations { get; }
    }

    public interface ITranslation
    {
        Guid LanguageId { get; }
    }
}