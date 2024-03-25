namespace AugustaGourmet.Api.Application.Whatsapp;

public class WhatsappMessageTemplates
{
    private WhatsappMessageTemplates(string value) { Value = value; }

    public string Value { get; private set; }

    public static WhatsappMessageTemplates LateEmployeeAlert { get { return new WhatsappMessageTemplates("funcionario_atrasado"); } }
    public static WhatsappMessageTemplates LateEmployeesReport { get { return new WhatsappMessageTemplates("alerta_geral"); } }

    public override string ToString()
    {
        return Value;
    }
}