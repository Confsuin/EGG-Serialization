using System;
using UnityEngine;

namespace EGG.Serialization
{
    [Serializable]
    public struct SerializedGUID : IEquatable<SerializedGUID>
    {
        [SerializeField] private string _valueString;

        public SerializedGUID(Guid guid)
        {
            _valueString = guid.ToString();
        }

        public readonly Guid Value
        {
            get
            {
                if (string.IsNullOrEmpty(_valueString))
                {
                    return Guid.Empty;
                }
                return Guid.Parse(_valueString);
            }
        }

        public static implicit operator Guid(SerializedGUID serializedGuid) => serializedGuid.Value;
        public static implicit operator SerializedGUID(Guid guid) => new(guid);

        public readonly bool Equals(SerializedGUID other) => _valueString == other._valueString;
        public override readonly bool Equals(object obj) => obj is SerializedGUID other && Equals(other);
        public override readonly int GetHashCode() => _valueString?.GetHashCode() ?? 0;
        public override readonly string ToString() => _valueString ?? Guid.Empty.ToString();

        public static bool operator ==(SerializedGUID left, SerializedGUID right) => left.Equals(right);
        public static bool operator !=(SerializedGUID left, SerializedGUID right) => !left.Equals(right);
    }
}