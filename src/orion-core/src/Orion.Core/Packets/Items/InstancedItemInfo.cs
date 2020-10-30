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
using Orion.Core.Items;
using Orion.Core.Utils;

namespace Orion.Core.Packets.Items
{
    /// <summary>
    /// A packet sent to set an instanced item's information.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public struct InstancedItemInfo : IPacket
    {
        [FieldOffset(0)] private byte _bytes;  // Used to obtain an interior reference.

        /// <summary>
        /// Gets or sets the item index. A value of <c>400</c> in <see cref="PacketContext.Server"/> indicates that the
        /// item is being spawned.
        /// </summary>
        /// <value>The item index.</value>
        [field: FieldOffset(0)] public short ItemIndex { get; set; }

        /// <summary>
        /// Gets or sets the item's position.
        /// </summary>
        /// <value>The item's position.</value>
        [field: FieldOffset(2)] public Vector2f Position { get; set; }

        /// <summary>
        /// Gets or sets the item's velocity.
        /// </summary>
        /// <value>The item's velocity.</value>
        [field: FieldOffset(10)] public Vector2f Velocity { get; set; }

        /// <summary>
        /// Gets or sets the item's stack size.
        /// </summary>
        /// <value>The item's stack size.</value>
        [field: FieldOffset(18)] public short StackSize { get; set; }

        /// <summary>
        /// Gets or sets the item's prefix.
        /// </summary>
        /// <value>The item's prefix.</value>
        [field: FieldOffset(20)] public ItemPrefix Prefix { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the player who spawned the item can pick up the item immediately.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the player who spawned the item can pick up the item immediately; otherwise,
        /// <see langword="false"/>.
        /// </value>
        [field: FieldOffset(21)] public bool AllowSelfPickup { get; set; }

        /// <summary>
        /// Gets or sets the item's ID. A value of <see cref="ItemId.None"/> in <see cref="PacketContext.Server"/>
        /// indicates that the item is being removed.
        /// </summary>
        /// <value>The item's ID.</value>
        [field: FieldOffset(22)] public ItemId Id { get; set; }

        PacketId IPacket.Id => PacketId.InstancedItemInfo;

        int IPacket.ReadBody(Span<byte> span, PacketContext context) => span.Read(ref _bytes, 24);

        int IPacket.WriteBody(Span<byte> span, PacketContext context) => span.Write(ref _bytes, 24);
    }
}
