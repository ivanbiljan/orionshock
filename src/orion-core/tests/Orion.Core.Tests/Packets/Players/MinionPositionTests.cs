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
using Orion.Core.Utils;
using Xunit;

namespace Orion.Core.Packets.Players
{
    [SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "Testing")]
    public class MinionPositionTests
    {
        private readonly byte[] _bytes = { 12, 0, 99, 5, 0, 0, 200, 66, 0, 0, 128, 67 };

        [Fact]
        public void PlayerIndex_Set_Get()
        {
            var packet = new MinionPosition();

            packet.PlayerIndex = 5;

            Assert.Equal(5, packet.PlayerIndex);
        }

        [Fact]
        public void Position_Set_Get()
        {
            var packet = new MinionPosition();

            packet.Position = new Vector2f(100, 256);

            Assert.Equal(new Vector2f(100, 256), packet.Position);
        }

        [Fact]
        public void Read()
        {
            var packet = TestUtils.ReadPacket<MinionPosition>(_bytes, PacketContext.Server);

            Assert.Equal(5, packet.PlayerIndex);
            Assert.Equal(new Vector2f(100, 256), packet.Position);
        }
    }
}
