using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AugustaGourmet.Api.Application;

public static class Utils
{
    public static T Deserialize<T>(XDocument doc)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

        using (var reader = doc.Root!.CreateReader())
        {
            return (T)xmlSerializer.Deserialize(reader)!;
        }
    }

    public static XDocument Serialize<T>(T value)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));

        XDocument doc = new XDocument();
        using (var writer = doc.CreateWriter())
        {
            xmlSerializer.Serialize(writer, value);
        }

        return doc;
    }

    public static bool IsOnlyNumbers(string value)
    {
        return int.TryParse(value, out _);
    }

    /// <summary>
    /// Validates phone numbers in Brazil.
    /// No area code starting with 0 is accepted, and no phone number can start with 0 or 1.
    /// Valid Examples: +55 (11) 98888-8888 / 9999-9999 / 21 98888-8888 / 5511988888888
    /// </summary>
    /// <param name="number">The phone number to validate.</param>
    /// <param name="correctedNumber">If the number is valid but missing the country code, this parameter will contain the corrected number with the country code.</param>
    /// <returns>True if the input is a valid Brazilian phone number, false otherwise.</returns>
    public static bool IsValidPhoneNumber(string number, out string correctedNumber)
    {
        string regex = @"^(?:(?:\+|00)?(55)\s?)?(?:\(?([1-9][0-9])\)?\s?)?(?:((?:9\d|[2-9])\d{3})\-?(\d{4}))$";
        Match match = Regex.Match(number, regex);

        if (match.Success && !match.Groups[1].Success)
        {
            correctedNumber = "+55" + number;
            return true;
        }

        correctedNumber = match.Success ? number : string.Empty;
        return match.Success;
    }

    /// <summary>
    /// Validates a CPF (Cadastro de Pessoas Físicas) or CNPJ (Cadastro Nacional da Pessoa Jurídica) number.
    /// Allowed formats: 00000000000, 00000000000000, 000.000.000-00, 00.000.000/0000-00, 000000000-00, 00000000/0000-00
    /// </summary>
    /// <param name="input">The CPF or CNPJ number to validate.</param>
    /// <returns>True if the input is a valid CPF or CNPJ number, false otherwise.</returns>
    public static bool IsValidCpfOrCnpj(string input)
    {
        string cpfCnpjRegex = @"^([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})$";
        Match match = Regex.Match(input, cpfCnpjRegex);

        return match.Success;
    }

    /// <summary>
    /// Validates a password based on the following criteria:
    /// - At least 8 characters long
    /// - Contains at least one lowercase letter, one uppercase letter, one digit, and one special character (@$!%*?&#)
    /// </summary>
    /// <param name="password">The password to validate.</param>
    /// <returns>True if the input is a valid password, false otherwise.</returns>
    public static bool IsValidPassword(string password)
    {
        string passwordRegex = @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&#])[a-zA-Z\d@$!%*?&#]{8,}$";
        return Regex.Match(password, passwordRegex).Success;
    }

    /// <summary>
    /// Checks if a given date is in the past.
    /// </summary>
    /// <param name="date">The date to check.</param>
    /// <returns>True if the date is in the past, false otherwise.</returns>
    public static bool IsPastDate(DateTime date) => date.Date < DateTime.Now.Date;

    /// <summary>
    /// Checks if a given nullable date is in the past.
    /// </summary>
    /// <param name="date">The nullable date to check.</param>
    /// <returns>True if the date is in the past, false otherwise.</returns>
    public static bool IsPastDate(DateTime? date) =>
        date.HasValue && date.Value.Date < DateTime.Now.Date;
}