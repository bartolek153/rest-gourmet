using System.Xml.Serialization;

namespace AugustaGourmet.Functions.Models;

[XmlRoot(ElementName = "nfeProc", Namespace = "http://www.portalfiscal.inf.br/nfe")]
public class NfeProc
{
    [XmlAttribute("versao")]
    public string versao { get; set; } = string.Empty;

    [XmlElement("NFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public NFe NotaFiscalEletronica { get; set; } = null!;
    public int AuxiliaryIssuerId { get; set; }
}

public class NFe
{
    [XmlElement(ElementName = "infNFe")]
    public InfNFe InformacoesNFe { get; set; } = null!;

}

public class InfNFe
{
    [XmlAttribute("Id")]
    public string Id { get; set; } = string.Empty;

    [XmlElement("ide")]
    public Identificacao Identificacao { get; set; } = null!;

    [XmlElement("emit")]
    public Emitente Emitente { get; set; } = null!;

    [XmlElement("dest")]
    public Destinatario Destinatario { get; set; } = null!;

    [XmlElement("cobr")]
    public Cobranca Cobranca { get; set; } = new();

    [XmlElement("total")]  // some receipts use pag instead of cobr
    public Total Total { get; set; } = null!;

    [XmlElement("det")]
    public List<Detalhe> Detalhe { get; set; } = null!;
}

public class Identificacao
{
    public int cUF { get; set; }
    public string cNF { get; set; } = string.Empty;
    public string natOp { get; set; } = string.Empty;
    public int indPag { get; set; }
    public string mod { get; set; } = string.Empty;
    public int serie { get; set; }
    public int nNF { get; set; }
    public DateTime dhEmi { get; set; }
    public DateTime dhSaiEnt { get; set; }

}

public class Emitente
{
    public string CNPJ { get; set; } = string.Empty;
    public string xNome { get; set; } = string.Empty;
    public string xFant { get; set; } = string.Empty;
    [XmlElement("enderEmit")]
    public Endereco Endereco { get; set; } = null!;
    public string IE { get; set; } = string.Empty;
    public string IEST { get; set; } = string.Empty;
    public int CRT { get; set; }
}
public class Destinatario
{
    public string CNPJ { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string xNome { get; set; } = string.Empty;
    [XmlElement("enderDest")]
    public Endereco Endereco { get; set; } = null!;
    public string email { get; set; } = string.Empty;
}

public class Endereco
{
    public string xLgr { get; set; } = string.Empty;
    public string nro { get; set; } = string.Empty;
    public string xBairro { get; set; } = string.Empty;
    public string cMun { get; set; } = string.Empty;
    public string xMun { get; set; } = string.Empty;
    public string UF { get; set; } = string.Empty;
    public string CEP { get; set; } = string.Empty;
    public int cPais { get; set; }
    public string xPais { get; set; } = string.Empty;
}

public class Cobranca
{
    [XmlElement("fat")]
    public Fatura Fatura { get; set; } = new();
}

public class Fatura
{
    public double vOrig { get; set; }
    public double vLiq { get; set; }
}

public class Total
{
    [XmlElement("ICMSTot")]
    public ICMSTotal DetalheTotal { get; set; } = null!;
}

public class ICMSTotal
{
    public double vProd { get; set; }
    public double vNF { get; set; }
}

public class Detalhe
{
    [XmlAttribute("nItem")]
    public int nItem { get; set; }

    [XmlElement("prod")]
    public Item Item { get; set; } = null!;
}

public class Item
{
    public string cProd { get; set; } = string.Empty;
    public string cEAN { get; set; } = string.Empty;
    public string xProd { get; set; } = string.Empty;
    public string NCM { get; set; } = string.Empty;
    public string CFOP { get; set; } = string.Empty;
    public string uCom { get; set; } = string.Empty;
    public double qCom { get; set; }
    public double vUnCom { get; set; }
    public double vProd { get; set; }
}

// TODO: implement taxes

// public class Imposto
// {
//     public double vTotTrib { get; set; }

//     [XmlElement("ICMS")]
//     public ICMS Icms { get; set; } = null!;
//     [XmlElement("IPI")]
//     public IPI Ipi { get; set; } = null!;
// }

// public class ICMS
// {
//     [XmlElement("ICMS00")]
//     public ICMS00 Icms00 { get; set; } = null!;
// }

// public class ICMS00
// {
//     public double pICMS { get; set; }
//     public double vICMS { get; set; }
// }

// public class IPI
// {
//     public double pIPI { get; set; }
//     public double vIPI { get; set; }
// }