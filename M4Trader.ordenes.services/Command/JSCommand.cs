using System.Runtime.Serialization;

namespace M4Trader.ordenes.services.Command
{

    [DataContract]
    public class JSCommand
    {
        public JSCommand()
        {

        }

        [DataMember] public string k { get; set; }
        [DataMember] public string d { get; set; }
        [DataMember] public bool b { get; set; }

        [DataMember] public byte a { get; set; }


}
}