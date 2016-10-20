﻿using System.Runtime.Serialization;

namespace ActivitiDotNet.Process
{
    [DataContract]
    public class ProcessInfo
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "version")]
        public int Version { get; set; }

        [DataMember(Name = "key")]
        public string Key { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }

        [DataMember(Name = "suspended")]
        public bool Suspended { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "deploymentId")]
        public string DeploymentId { get; set; }

        [DataMember(Name = "deploymentUrl")]
        public string DeploymentUrl { get; set; }

        [DataMember(Name = "graphicalNotationDefined")]
        public bool GraphicalNotationDefined { get; set; }       

        [DataMember(Name = "resource")]
        public string Resource { get; set; }
      
        [DataMember(Name = "diagramResource")]
        public string DiagramResource { get; set; }

        [DataMember(Name = "startFormDefined")]
        public bool StartFormDefined { get; set; }
    }
}
