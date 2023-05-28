﻿using MongoDB.Bson.Serialization;
using Wlabs.Domain.Entities;

namespace Wlabs.Infra.Data.Mappings
{
    public class UsuarioMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Usuario>(map =>
            {
                map.MapMember(x => x.Email).SetIsRequired(true);
                map.MapMember(x => x.Nome).SetIsRequired(true);
                map.MapMember(x => x.Senha).SetIsRequired(true);
                map.MapCreator(x => new Usuario(x.Id, x.Nome, x.Email, x.Senha));
            });
        }
    }
}
