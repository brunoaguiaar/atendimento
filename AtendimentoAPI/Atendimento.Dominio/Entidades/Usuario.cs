using Atendimento.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Atendimento.Dominio.Entidades
{
    public class Usuario : EntidadeBase
    {
        static readonly char[] _caracteresNovaSenha = "abcdefghijklmnopqrstuvzwyz1234567890*-_".ToCharArray();
        static readonly int _numeroCaracteresNovaSenha = 10;

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string UserName { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public virtual List<Atendimento> Atendimentos { get; private set; }

        protected Usuario()
        {
        }

        public Usuario(string nome, string userName, string senha)
        {
            Nome = nome;
            UserName = userName;
            if (!string.IsNullOrWhiteSpace(senha))
                Senha = CriptografarSenha(senha);
            Mensagens = new List<string>();
        }

        public Usuario(int id, string nome, string senha)
        {
            Nome = nome;
            if (!string.IsNullOrWhiteSpace(senha))
                Senha = CriptografarSenha(senha);
            Mensagens = new List<string>();
            this.Id = id;
        }

        public string ResetarSenha()
        {
            var senha = string.Empty;
            for (int i = 0; i < _numeroCaracteresNovaSenha; i++)
            {
                senha += new Random().Next(0, _caracteresNovaSenha.Length);
            }

            Senha = CriptografarSenha(senha);

            return senha;
        }

        public string CriptografarSenha(string senha)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.Default.GetBytes(UserName + senha);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));

            return sb.ToString();
        }

        public bool ValidarSenha(string senha)
        {
            return CriptografarSenha(senha) == Senha;
        }


        public override bool IsValid()
        {
            Mensagens.Clear();

            if (string.IsNullOrWhiteSpace(Nome))
                Mensagens.Add("Nome é inválido.");

            if (string.IsNullOrWhiteSpace(UserName))
                Mensagens.Add("UserName é inválido.");

            if (string.IsNullOrWhiteSpace(Senha))
                Mensagens.Add("Senha é inválida.");

            return Mensagens.Count == 0;
        }

        public UsuarioBaseModel converterUsuarioParaUsuarioModel()
        {
            var usuarioModel = new UsuarioBaseModel(this.Id, this.Nome, this.UserName);
            foreach (var atendimento in Atendimentos)
            {
                var atendimentoModel = new AtendimentoModel();
                atendimentoModel.Id = atendimento.Id;
                atendimentoModel.Titulo = atendimento.Titulo;
                atendimentoModel.Descricao = atendimento.Descricao;
                atendimentoModel.Cliente = atendimento.Cliente;
                usuarioModel.Atendimentos.Add(atendimentoModel);
            }
            return usuarioModel;
        }
    }
}
