using System.Xml.Serialization;

namespace AugustaGourmet.Api.Domain.Entities.Invoices
{
    // cabecalho

    // nfeProc NFe infNFe ide nNF
    // nfeProc NFe infNFe ide serie
    // nfeProc NFe infNFe ide dhEmi

    // nfeProc NFe infNFe emit CNPJ

    // nfeProc NFe infNFe cobr fat vOrig
    // nfeProc NFe infNFe cobr fat vLiq


    // itens

    // nfeProc NFe infNFe det prod cProd
    // nfeProc NFe infNFe det prod xProd
    // nfeProc NFe infNFe det prod uCom
    // nfeProc NFe infNFe det prod qCom
    // nfeProc NFe infNFe det prod vUnCom
    // nfeProc NFe infNFe det prod vProd

    // nfeProc NFe infNFe det imposto ICMS ICMS40 vBC
    // nfeProc NFe infNFe det imposto ICMS ICMS40 vICMS
    // nfeProc NFe infNFe det imposto ICMS ICMS40 pICMS
    // nfeProc NFe infNFe det imposto ICMS ICMS40 orig



    [XmlRoot(ElementName = "ide")]
    public class Ide
    {

        [XmlElement(ElementName = "serie")]
        public int Serie { get; set; }

        [XmlElement(ElementName = "nNF")]
        public int NNF { get; set; }

        [XmlElement(ElementName = "dhEmi")]
        public DateTime DhEmi { get; set; }
    }

    [XmlRoot(ElementName = "emit")]
    public class Emit
    {

        [XmlElement(ElementName = "CNPJ")]
        public double CNPJ { get; set; }
    }

    [XmlRoot(ElementName = "prod")]
    public class Prod
    {

        [XmlElement(ElementName = "cProd")]
        public string CProd { get; set; }

        [XmlElement(ElementName = "cEAN")]
        public string CEAN { get; set; }

        [XmlElement(ElementName = "xProd")]
        public string XProd { get; set; }

        [XmlElement(ElementName = "NCM")]
        public int NCM { get; set; }

        [XmlElement(ElementName = "CFOP")]
        public int CFOP { get; set; }

        [XmlElement(ElementName = "uCom")]
        public string UCom { get; set; }

        [XmlElement(ElementName = "qCom")]
        public double QCom { get; set; }

        [XmlElement(ElementName = "vUnCom")]
        public double VUnCom { get; set; }

        [XmlElement(ElementName = "vProd")]
        public double VProd { get; set; }

        [XmlElement(ElementName = "cEANTrib")]
        public string CEANTrib { get; set; }

        [XmlElement(ElementName = "uTrib")]
        public string UTrib { get; set; }

        [XmlElement(ElementName = "qTrib")]
        public double QTrib { get; set; }

        [XmlElement(ElementName = "vUnTrib")]
        public double VUnTrib { get; set; }

        [XmlElement(ElementName = "indTot")]
        public int IndTot { get; set; }
    }

    [XmlRoot(ElementName = "ICMS00")]
    public class ICMS00
    {

        [XmlElement(ElementName = "orig")]
        public int Orig { get; set; }

        [XmlElement(ElementName = "CST")]
        public int CST { get; set; }

        [XmlElement(ElementName = "modBC")]
        public int ModBC { get; set; }

        [XmlElement(ElementName = "vBC")]
        public double VBC { get; set; }

        [XmlElement(ElementName = "pICMS")]
        public double PICMS { get; set; }

        [XmlElement(ElementName = "vICMS")]
        public double VICMS { get; set; }
    }

    [XmlRoot(ElementName = "ICMS")]
    public class ICMS
    {

        [XmlElement(ElementName = "ICMS00")]
        public ICMS00 ICMS00 { get; set; }
    }

    [XmlRoot(ElementName = "IPINT")]
    public class IPINT
    {

        [XmlElement(ElementName = "CST")]
        public int CST { get; set; }
    }

    [XmlRoot(ElementName = "IPI")]
    public class IPI
    {

        [XmlElement(ElementName = "cEnq")]
        public int CEnq { get; set; }

        [XmlElement(ElementName = "IPINT")]
        public IPINT IPINT { get; set; }
    }

    [XmlRoot(ElementName = "PISAliq")]
    public class PISAliq
    {

        [XmlElement(ElementName = "CST")]
        public int CST { get; set; }

        [XmlElement(ElementName = "vBC")]
        public double VBC { get; set; }

        [XmlElement(ElementName = "pPIS")]
        public double PPIS { get; set; }

        [XmlElement(ElementName = "vPIS")]
        public double VPIS { get; set; }
    }

    [XmlRoot(ElementName = "PIS")]
    public class PIS
    {

        [XmlElement(ElementName = "PISAliq")]
        public PISAliq PISAliq { get; set; }
    }

    [XmlRoot(ElementName = "COFINSAliq")]
    public class COFINSAliq
    {

        [XmlElement(ElementName = "CST")]
        public int CST { get; set; }

        [XmlElement(ElementName = "vBC")]
        public double VBC { get; set; }

        [XmlElement(ElementName = "pCOFINS")]
        public double PCOFINS { get; set; }

        [XmlElement(ElementName = "vCOFINS")]
        public DateTime VCOFINS { get; set; }
    }

    [XmlRoot(ElementName = "COFINS")]
    public class COFINS
    {

        [XmlElement(ElementName = "COFINSAliq")]
        public COFINSAliq COFINSAliq { get; set; }
    }

    [XmlRoot(ElementName = "imposto")]
    public class Imposto
    {

        [XmlElement(ElementName = "ICMS")]
        public ICMS ICMS { get; set; }

        [XmlElement(ElementName = "IPI")]
        public IPI IPI { get; set; }

        [XmlElement(ElementName = "PIS")]
        public PIS PIS { get; set; }

        [XmlElement(ElementName = "COFINS")]
        public COFINS COFINS { get; set; }
    }

    [XmlRoot(ElementName = "det")]
    public class Det
    {

        [XmlElement(ElementName = "prod")]
        public Prod Prod { get; set; }

        [XmlElement(ElementName = "imposto")]
        public Imposto Imposto { get; set; }

        [XmlAttribute(AttributeName = "nItem")]
        public int NItem { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "fat")]
    public class Fat
    {

        [XmlElement(ElementName = "vOrig")]
        public double VOrig { get; set; }

        [XmlElement(ElementName = "vLiq")]
        public double VLiq { get; set; }
    }

    [XmlRoot(ElementName = "cobr")]
    public class Cobr
    {

        [XmlElement(ElementName = "fat")]
        public Fat Fat { get; set; }
    }

    [XmlRoot(ElementName = "infNFe")]
    public class InfNFe
    {

        [XmlElement(ElementName = "ide")]
        public Ide Ide { get; set; }

        [XmlElement(ElementName = "emit")]
        public Emit Emit { get; set; }

        [XmlElement(ElementName = "det")]
        public List<Det> Det { get; set; }

        [XmlElement(ElementName = "cobr")]
        public Cobr Cobr { get; set; }

        [XmlAttribute(AttributeName = "Id")]
        public string Id { get; set; }

        [XmlAttribute(AttributeName = "versao")]
        public double Versao { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "NFe")]
    public class NotaFiscal
    {

        [XmlElement(ElementName = "infNFe")]
        public InfNFe InfNFe { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "nfeProc")]
    public class NfeXmlModel
    {

        [XmlElement(ElementName = "NFe")]
        public NotaFiscal NFe { get; set; }

        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }

        [XmlAttribute(AttributeName = "versao")]
        public double Versao { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}