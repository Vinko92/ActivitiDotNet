using System.Runtime.Serialization;

namespace ActivitiDotNet.Engine
{
    public class EngineInfo
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "version", EmitDefaultValue = false)]
        public string Version { get; set; }

        [DataMember(Name = "resourceUrl", EmitDefaultValue = false)]
        public string ResourceUrl { get; set; }

        [DataMember(Name = "exception", EmitDefaultValue = false)]
        public string Exceotion { get; set; }

    }
}
