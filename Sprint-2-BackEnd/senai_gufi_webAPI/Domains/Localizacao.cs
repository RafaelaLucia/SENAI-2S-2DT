using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace senai_gufi_webAPI.Domains
{
    public class Localizacao
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("latitude")] //mudar o nome no banco
        [BsonRequired] //definir que o campo é obrigatório
        public string Latitude { get; set; }
        [BsonRequired]
        public string Longitude { get; set; }
    }
}
