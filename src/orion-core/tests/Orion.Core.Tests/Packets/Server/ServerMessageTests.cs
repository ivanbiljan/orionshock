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
using System.Diagnostics.CodeAnalysis;
using Orion.Core.Packets.DataStructures;
using Orion.Core.Utils;
using Xunit;

namespace Orion.Core.Packets.Server
{
    [SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "Testing")]
    public class ServerMessageTests
    {
        private readonly byte[] _bytes =
        {
            18, 0, 107, 255, 255, 255, 0, 8, 84, 101, 114, 114, 97, 114, 105, 97, 100, 0
        };

        [Fact]
        public void Color_Set_Get()
        {
            var packet = new ServerMessage();

            packet.Color = Color3.White;

            Assert.Equal(Color3.White, packet.Color);
        }

        [Fact]
        public void Message_GetNullValue()
        {
            var packet = new ServerMessage();

            Assert.Equal(NetworkText.Empty, packet.Message);
        }

        [Fact]
        public void Message_SetNullValue_ThrowsArgumentNullException()
        {
            var packet = new ServerMessage();

            Assert.Throws<ArgumentNullException>(() => packet.Message = null!);
        }

        [Fact]
        public void Message_Set_Get()
        {
            var packet = new ServerMessage();

            packet.Message = "Terraria";

            Assert.Equal("Terraria", packet.Message);
        }

        [Fact]
        public void LineWidth_Set_Get()
        {
            var packet = new ServerMessage();

            packet.LineWidth = 100;

            Assert.Equal(100, packet.LineWidth);
        }

        [Fact]
        public void Read()
        {
            var packet = TestUtils.ReadPacket<ServerMessage>(_bytes, PacketContext.Server);

            Assert.Equal(Color3.White, packet.Color);
            Assert.Equal("Terraria", packet.Message);
            Assert.Equal(100, packet.LineWidth);
        }
    }
}
