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
using Moq;
using Orion.Core.World;
using Xunit;

namespace Orion.Core.Packets.World.Tiles
{
    [SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "Testing")]
    public class TileSquareTests
    {
        private readonly byte[] _bytes =
        {
            41, 0, 20, 3, 0, 100, 0, 0, 1, 0, 0, 1, 0, 1, 0, 1, 0, 4, 0, 1, 0, 2, 0, 4, 0, 1, 0, 8, 0, 255, 1, 0, 4, 1,
            0, 8, 1, 241, 131, 1, 0, 1, 16, 1, 0
        };

        private readonly byte[] _changeTypeBytes = { 12, 0, 20, 1, 128, 1, 100, 0, 0, 1, 0, 0 };

        [Fact]
        public void X_Set_Get()
        {
            var packet = new TileSquare();

            packet.X = 100;

            Assert.Equal(100, packet.X);
        }

        [Fact]
        public void Y_Set_Get()
        {
            var packet = new TileSquare();

            packet.Y = 256;

            Assert.Equal(256, packet.Y);
        }

        [Fact]
        public void Tiles_GetNullValue()
        {
            var packet = new TileSquare();

            Assert.Equal(0, packet.Tiles.Width);
            Assert.Equal(0, packet.Tiles.Height);
        }

        [Fact]
        public void Tiles_SetNullValue_ThrowsArgumentNullException()
        {
            var packet = new TileSquare();

            Assert.Throws<ArgumentNullException>(() => packet.Tiles = null!);
        }

        [Fact]
        public void Tiles_SetNotSquare_ThrowsArgumentException()
        {
            var tiles = Mock.Of<ITileSlice>(t => t.Width == 1 && t.Height == 2);
            var packet = new TileSquare();

            Assert.Throws<ArgumentException>(() => packet.Tiles = tiles);
        }

        [Fact]
        public void Tiles_Set_Get()
        {
            var tiles = Mock.Of<ITileSlice>(t => t.Width == 1 && t.Height == 1);
            var packet = new TileSquare();

            packet.Tiles = tiles;

            Assert.Same(tiles, packet.Tiles);
        }

        [Fact]
        public void Read()
        {
            var packet = TestUtils.ReadPacket<TileSquare>(_bytes, PacketContext.Server);

            Assert.Equal(100, packet.X);
            Assert.Equal(256, packet.Y);
            Assert.Equal(3, packet.Tiles.Width);
            Assert.Equal(3, packet.Tiles.Height);
        }

        [Fact]
        public void Read_ChangeType()
        {
            var packet = TestUtils.ReadPacket<TileSquare>(_changeTypeBytes, PacketContext.Server);

            Assert.Equal(100, packet.X);
            Assert.Equal(256, packet.Y);
            Assert.Equal(1, packet.Tiles.Width);
            Assert.Equal(1, packet.Tiles.Height);
        }
    }
}
