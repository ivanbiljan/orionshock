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
using Orion.Core.Packets.DataStructures;
using Orion.Core.Utils;

namespace Orion.Core.Packets.Server
{
    /// <summary>
    /// A packet sent from the server to the client to show a message.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 16)]
    public struct ServerMessage : IPacket
    {
        [FieldOffset(0)] private byte _bytes;  // Used to obtain an interior reference.
        [FieldOffset(3)] private byte _bytes2;  // Used to obtain an interior reference.
        [FieldOffset(8)] private NetworkText? _message;

        /// <summary>
        /// Gets or sets the message's color.
        /// </summary>
        /// <value>The message's color.</value>
        [field: FieldOffset(0)] public Color3 Color { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
        public NetworkText Message
        {
            get => _message ??= NetworkText.Empty;
            set => _message = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets or sets the message's line width. A value of <c>-1</c> indicates that the screen width should be used.
        /// </summary>
        /// <value>The message's line width.</value>
        [field: FieldOffset(3)] public short LineWidth { get; set; }

        PacketId IPacket.Id => PacketId.ServerMessage;

        int IPacket.ReadBody(Span<byte> span, PacketContext context)
        {
            var index = span.Read(ref _bytes, 3);
            index += NetworkText.Read(span[index..], out _message);
            index += span[index..].Read(ref _bytes2, 2);
            return index;
        }

        int IPacket.WriteBody(Span<byte> span, PacketContext context)
        {
            var index = span.Write(ref _bytes, 3);
            index += Message.Write(span[index..]);
            index += span[index..].Write(ref _bytes2, 2);
            return index;
        }
    }
}
