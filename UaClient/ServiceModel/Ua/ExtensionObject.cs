﻿// Copyright (c) Converter Systems LLC. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Xml.Linq;

namespace Workstation.ServiceModel.Ua
{
    public enum BodyType
    {
        None,
        ByteString,
        XmlElement,
        Encodable
    }

    public sealed class ExtensionObject
    {
        public ExtensionObject(byte[] body, ExpandedNodeId typeId)
        {
            this.Body = body;
            this.BodyType = body != null ? BodyType.ByteString : BodyType.None;
            this.TypeId = typeId;
        }

        public ExtensionObject(XElement body, ExpandedNodeId typeId)
        {
            this.Body = body;
            this.BodyType = body != null ? BodyType.XmlElement : BodyType.None;
            this.TypeId = typeId;
        }

        public ExtensionObject(IEncodable body)
        {
            this.Body = body;
            this.BodyType = body != null ? BodyType.Encodable : BodyType.None;
        }

        public object Body { get; }

        public ExpandedNodeId TypeId { get; }

        public BodyType BodyType { get; }
    }
}