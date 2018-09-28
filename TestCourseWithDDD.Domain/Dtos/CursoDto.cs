using System;

namespace TestCourseWithDDD.Domain.Dtos
{
    public class CursoDto
    {
        public string Nome { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public string PublicoAlvo { get; set; }
        public DateTime DataCadastro { get; set; }
        public double CargaHoraria { get; set; }
        public bool Ativo { get; set; }
    }
}