using System.Runtime.Serialization;

namespace M4Trader.ordenes.server.Entities
{
    [DataContract]
    public enum FixRolParticipanteEnum
    {
        [EnumMember]
        CarteraPropia = 'C',
        [EnumMember]
        EnteLiquidador = 'E',
        [EnumMember]
        Agente = 'A',
        [EnumMember]
        Cliente = 'L',
        [EnumMember]
        Custodio = 'U',
        [EnumMember]
        Seguro = 'S',
        [EnumMember]
        Fondo = 'F',
        [EnumMember]
        AgenteCompensador = 'O',
    }
}