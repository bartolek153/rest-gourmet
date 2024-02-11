namespace AugustaGourmet.Api.Application;

public static partial class Constants
{
    public static class Messages
    {
        public const string IdMustBeGreaterThanZero = "O campo ID deve ser maior que zero.";
        public const string DescriptionIsRequired = "O campo descrição é obrigatório.";
        public const string InvalidCompanyId = "O campo companhia é obrigatório.";
        public const string InvalidUnitMeasureId = "O campo unidade de medida é obrigatório.";
        public const string InvalidOriginId = "O campo origem é obrigatório.";
        public const string InvalidStatusId = "O campo status é obrigatório.";
        public const string DescriptionLengthExceeded = "O campo descrição deve ter no máximo 60 caracteres.";
    }
}