using System;
using TestCourseWithDDD.Domain.Entities;
using TestCourseWithDDD.Domain.Enums;

namespace TestCourseWithDDD.Test.Builders
{
    public class CursoBuilder
    {
        private double _valor = 950;
        private double _cargaHoraria = 80;
        private string _nome = "Nome do curso";
        private PublicoAlvo _publicoAlvo = PublicoAlvo.Empreendedor;
        private string _descricao = "Descição do curso";
        private readonly DateTime _dataCadastro =  DateTime.Now;
        private readonly bool _ativo = true;

        public static CursoBuilder CursoNovo()
        {
            return new CursoBuilder();
        }

        public CursoBuilder CursoComNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public CursoBuilder CursoComCargaHoraria(double cargaHoraria)
        {
            _cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder CursoComValor(double valor)
        {
            _valor = valor;
            return this;
        }

        public CursoBuilder CursoComDescricao(string descricao)
        {
            _descricao = descricao;
            return this;
        }

        public CursoBuilder CursoComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            _publicoAlvo = publicoAlvo;
            return this;
        }

        public Curso ConstruirCurso()
        {
            return new Curso(_nome, _publicoAlvo, _valor, _descricao, _cargaHoraria, _dataCadastro, _ativo);
        }
    }
}