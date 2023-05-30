﻿using MongoDB.Bson;
using NetDevPack.Domain;

namespace Wlabs.Domain.Entities
{
    public class Usuario : EntityBase, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        public Usuario(ObjectId id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
        }
        public Usuario(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public Usuario() {}
    }
}
