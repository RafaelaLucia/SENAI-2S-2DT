using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace senai_spmedicalgroup_webAPI.Domains
{
    public class Localizacao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired] //definir que o campo é obrigatório
        public string Latitude { get; set; }
        [BsonRequired]
        public string Longitude { get; set; }
    }
}
