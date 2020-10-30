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
using Xunit;

namespace Orion.Core.Packets.Npcs
{
    [SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "Testing")]
    public class NpcCatchTests
    {
        private readonly byte[] _bytes = { 6, 0, 70, 1, 0, 5 };

        [Fact]
        public void NpcIndex_Set_Get()
        {
            var packet = new NpcCatch();

            packet.NpcIndex = 1;

            Assert.Equal(1, packet.NpcIndex);
        }

        [Fact]
        public void Read()
        {
            var packet = TestUtils.ReadPacket<NpcCatch>(_bytes, PacketContext.Server);

            Assert.Equal(1, packet.NpcIndex);
        }
    }
}
