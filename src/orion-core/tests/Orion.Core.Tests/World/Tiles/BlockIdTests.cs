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
using System.Linq;
using Xunit;

namespace Orion.Core.World.Tiles
{
    // These tests depend on Terraria state.
    [Collection("TerrariaTestsCollection")]
    public class BlockIdTests
    {
        [Fact]
        public void AllBlockIdsCovered()
        {
            // Subtract by 1 since all of the block IDs are offset by 1.
            var maxId = Enum.GetValues(typeof(BlockId)).Cast<BlockId>().Max() - 1;
            Assert.Equal((BlockId)(Terraria.ID.TileID.Count - 1), maxId);
        }

        [Fact]
        public void HasFrames()
        {
            for (var i = 0; i < Terraria.ID.TileID.Count; ++i)
            {
                // Add by 1 since all of the block IDs are offset by 1.
                Assert.Equal(Terraria.Main.tileFrameImportant[i], ((BlockId)(i + 1)).HasFrames());
            }
        }
    }
}
