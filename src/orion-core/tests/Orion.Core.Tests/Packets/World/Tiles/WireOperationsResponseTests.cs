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

using System.Diagnostics.CodeAnalysis;
using Orion.Core.Items;
using Xunit;

namespace Orion.Core.Packets.World.Tiles
{
    [SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "Testing")]
    public class WireOperationsResponseTests
    {
        private readonly byte[] _bytes = { 8, 0, 110, 18, 2, 100, 0, 5 };

        [Fact]
        public void Id_Set_Get()
        {
            var packet = new WireOperationsResponse();

            packet.Id = ItemId.Wire;

            Assert.Equal(ItemId.Wire, packet.Id);
        }

        [Fact]
        public void StackSize_Set_Get()
        {
            var packet = new WireOperationsResponse();

            packet.StackSize = 100;

            Assert.Equal(100, packet.StackSize);
        }

        [Fact]
        public void PlayerIndex_Set_Get()
        {
            var packet = new WireOperationsResponse();

            packet.PlayerIndex = 5;

            Assert.Equal(5, packet.PlayerIndex);
        }

        [Fact]
        public void Read()
        {
            var packet = TestUtils.ReadPacket<WireOperationsResponse>(_bytes, PacketContext.Server);

            Assert.Equal(ItemId.Wire, packet.Id);
            Assert.Equal(100, packet.StackSize);
            Assert.Equal(5, packet.PlayerIndex);
        }
    }
}
