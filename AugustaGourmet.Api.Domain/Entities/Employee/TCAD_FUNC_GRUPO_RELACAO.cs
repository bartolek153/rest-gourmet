namespace WebAPI.Models
{
    public class TCAD_FUNC_GRUPO_RELACAO
    {
        public int FUNCIONARIOId { get; set; }
        public int GRUPO_FUNCIONARIOId { get; set; }
        public TCAD_FUNCIONARIO FUNCIONARIO { get; set; }
        public TCAD_GRUPO_FUNCIONARIO GRUPO_FUNCIONARIO { get; set; }

    }
}