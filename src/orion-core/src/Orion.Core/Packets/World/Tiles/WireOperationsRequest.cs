﻿// Copyright (c) 2020 Pryaxis & Orion Contributors
// 
// This file is part of Orion.
// 
// Orion is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// Orion is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with Orion.  If not, see <https://www.gnu.org/licenses/>.

using System;
using System.Runtime.InteropServices;
using Orion.Core.Utils;

namespace Orion.Core.Packets.World.Tiles
{
    /// <summary>
    /// A packet sent from the client to the server to request wire operations.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public struct WireOperationsRequest : IPacket
    {
        [FieldOffset(0)] private byte _bytes;  // Used to obtain an interior reference.

        /// <summary>
        /// Gets or sets the operations' starting X coordinate.
        /// </summary>
        /// <value>The operations' starting X coordinate.</value>
        [field: FieldOffset(0)] public short StartX { get; set; }

        /// <summary>
        /// Gets or sets the operations' starting Y coordinate.
        /// </summary>
        /// <value>The operations' starting Y coordinate.</value>
        [field: FieldOffset(2)] public short StartY { get; set; }

        /// <summary>
        /// Gets or sets the operations' ending X coordinate.
        /// </summary>
        /// <value>The operations' ending X coordinate.</value>
        [field: FieldOffset(4)] public short EndX { get; set; }

        /// <summary>
        /// Gets or sets the operations' ending Y coordinate.
        /// </summary>
        /// <value>The operations' ending Y coordinate.</value>
        [field: FieldOffset(6)] public short EndY { get; set; }

        /// <summary>
        /// Gets or sets the operations.
        /// </summary>
        /// <value>The operations.</value>
        [field: FieldOffset(8)] public WireOperations Operations { get; set; }

        PacketId IPacket.Id => PacketId.WireOperationsRequest;

        int IPacket.ReadBody(Span<byte> span, PacketContext context) => span.Read(ref _bytes, 9);

        int IPacket.WriteBody(Span<byte> span, PacketContext context) => span.Write(ref _bytes, 9);

        /// <summary>
        /// Specifies the wire operations in a <see cref="WireOperationsRequest"/>.
        /// </summary>
        [Flags]
        public enum WireOperations : byte
        {
            /// <summary>
            /// Indicates nothing.
            /// </summary>
            None = 0,

            /// <summary>
            /// Indicates that red wires should be modified.
            /// </summary>
            RedWire = 1,

            /// <summary>
            /// Indicates that green wires should be modified.
            /// </summary>
            GreenWire = 2,

            /// <summary>
            /// Indicates that blue wires should be modified.
            /// </summary>
            BlueWire = 4,

            /// <summary>
            /// Indicates that yellow wires should be modified.
            /// </summary>
            YellowWire = 8,

            /// <summary>
            /// Indicates that actuators should be modified.
            /// </summary>
            Actuator = 16,

            /// <summary>
            /// Indicates that wiring should be removed.
            /// </summary>
            Remove = 32
        }
    }
}
