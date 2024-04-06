namespace AugustaGourmet.Api.Application;

public static partial class Constants
{
    public static class Messages
    {
        public const string ValueShouldNotExceed = "O campo {0} deve ter no máximo {1} caracteres.";
        public const string InvalidValue = "O valor informado para o campo {0} é inválido.";
        public const string RequiredField = "O campo {0} é obrigatório.";

        public const string DateIsRequired = "O campo data é obrigatório.";
        public const string DescriptionLengthExceeded = "O campo descrição deve ter no máximo 60 caracteres.";
        public const string DescriptionIsRequired = "O campo descrição é obrigatório.";
        public const string EmailIsRequired = "O campo e-mail é obrigatório.";
        public const string IdMustBeGreaterThanZero = "O campo ID deve ser maior que zero.";
        public const string InvalidCompanyId = "O campo companhia é obrigatório.";
        public const string InvalidEmail = "O campo e-mail é inválido.";
        public const string InvalidEmployeeId = "O campo funcionário é obrigatório.";
        public const string InvalidOriginId = "O campo origem é obrigatório.";
        public const string InvalidReasonId = "O campo motivo é obrigatório.";
        public const string InvalidStatusId = "O campo status é obrigatório.";
        public const string InvalidUnitMeasureId = "O campo unidade de medida é obrigatório.";
        public const string NameIsRequired = "O campo nome é obrigatório.";
        public const string PasswordIsRequired = "O campo senha é obrigatório.";
        public const string PasswordMustContains = "A senha deve conter pelo menos 8 caracteres, uma letra, um número e um caractere especial.";
    }
}