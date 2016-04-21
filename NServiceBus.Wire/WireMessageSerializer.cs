using System;
using System.Collections.Generic;
using System.IO;
using NServiceBus.Serialization;
using Wire;

namespace NServiceBus.Wire
{
    /// <summary>
    /// Wire message serializer.
    /// </summary>
    public class WireMessageSerializer : IMessageSerializer
    {
        Serializer serializer;

        /// <summary>
        /// Creates a new instance of the Wire message serializer.
        /// </summary>
        /// <param name="options">Serialization options for Wire.</param>
        public WireMessageSerializer(SerializerOptions options = null)
        {
            serializer = options == null ? new Serializer() : new Serializer(options);
        }

        public void Serialize(object message, Stream stream)
        {
            serializer.Serialize(message, stream);
        }

        public object[] Deserialize(Stream stream, IList<Type> messageTypes = null)
        {
            return new [] { serializer.Deserialize(stream) };
        }

        public string ContentType
        {
            get { return "application/octet-stream"; }
        }
    }
}