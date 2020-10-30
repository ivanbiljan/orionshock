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

namespace Orion.Core.World
{
    // These tests depend on Terraria state.
    [Collection("TerrariaTestsCollection")]
    public class AnglerQuestTests
    {
        [Fact]
        public void AllAnglerQuestsCovered()
        {
            var maxId = Enum.GetValues(typeof(AnglerQuest)).Cast<AnglerQuest>().Max();
            Assert.Equal((AnglerQuest)(Terraria.Main.anglerQuestItemNetIDs.Length - 1), maxId);
        }

        [Fact]
        public void ItemId()
        {
            for (var i = 0; i < Terraria.Main.anglerQuestItemNetIDs.Length; ++i)
            {
                Assert.Equal((Items.ItemId)Terraria.Main.anglerQuestItemNetIDs[i], ((AnglerQuest)i).ItemId());
            }
        }

        [Fact]
        public void ItemId_InvalidAnglerQuest()
        {
            Assert.Equal(Items.ItemId.None, ((AnglerQuest)255).ItemId());
        }
    }
}
