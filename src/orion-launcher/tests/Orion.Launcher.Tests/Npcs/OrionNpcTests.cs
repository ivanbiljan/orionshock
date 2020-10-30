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
using Orion.Core.Npcs;
using Xunit;

namespace Orion.Launcher.Npcs
{
    // These tests depend on Terraria state.
    [Collection("TerrariaTestsCollection")]
    [SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "Testing")]
    public class OrionNpcTests
    {
        [Fact]
        public void Name_Get()
        {
            var terrariaNpc = new Terraria.NPC { _givenName = "test" };
            var npc = new OrionNpc(terrariaNpc);

            Assert.Equal("test", npc.Name);
        }

        [Fact]
        public void Name_SetNullValue_ThrowsArgumentNullException()
        {
            var terrariaNpc = new Terraria.NPC();
            var npc = new OrionNpc(terrariaNpc);

            Assert.Throws<ArgumentNullException>(() => npc.Name = null!);
        }

        [Fact]
        public void Name_Set()
        {
            var terrariaNpc = new Terraria.NPC();
            var npc = new OrionNpc(terrariaNpc);

            npc.Name = "test";

            Assert.Equal("test", terrariaNpc.GivenOrTypeName);
        }

        [Fact]
        public void Id_Get()
        {
            var terrariaNpc = new Terraria.NPC { netID = (int)NpcId.BlueSlime };
            var npc = new OrionNpc(terrariaNpc);

            Assert.Equal(NpcId.BlueSlime, npc.Id);
        }

        [Fact]
        public void Health_Get()
        {
            var terrariaNpc = new Terraria.NPC { life = 100 };
            var npc = new OrionNpc(terrariaNpc);

            Assert.Equal(100, npc.Health);
        }

        [Fact]
        public void Health_Set()
        {
            var terrariaNpc = new Terraria.NPC();
            var npc = new OrionNpc(terrariaNpc);

            npc.Health = 100;

            Assert.Equal(100, terrariaNpc.life);
        }

        [Fact]
        public void MaxHealth_Get()
        {
            var terrariaNpc = new Terraria.NPC { lifeMax = 200 };
            var npc = new OrionNpc(terrariaNpc);

            Assert.Equal(200, npc.MaxHealth);
        }

        [Fact]
        public void MaxHealth_Set()
        {
            var terrariaNpc = new Terraria.NPC();
            var npc = new OrionNpc(terrariaNpc);

            npc.MaxHealth = 200;

            Assert.Equal(200, terrariaNpc.lifeMax);
        }

        [Fact]
        public void AiValues_Get()
        {
            var terrariaNpc = new Terraria.NPC();
            terrariaNpc.ai[0] = 1f;
            terrariaNpc.ai[1] = 2f;
            terrariaNpc.ai[2] = 3f;
            terrariaNpc.ai[3] = 4f;
            var npc = new OrionNpc(terrariaNpc);

            Assert.Equal(4, npc.AiValues.Length);
            Assert.Equal(1f, npc.AiValues[0]);
            Assert.Equal(2f, npc.AiValues[1]);
            Assert.Equal(3f, npc.AiValues[2]);
            Assert.Equal(4f, npc.AiValues[3]);
        }

        [Fact]
        public void AiValues_Set()
        {
            var terrariaNpc = new Terraria.NPC();
            var npc = new OrionNpc(terrariaNpc);

            npc.AiValues[0] = 1f;
            npc.AiValues[1] = 2f;
            npc.AiValues[2] = 3f;
            npc.AiValues[3] = 4f;

            Assert.Equal(1f, terrariaNpc.ai[0]);
            Assert.Equal(2f, terrariaNpc.ai[1]);
            Assert.Equal(3f, terrariaNpc.ai[2]);
            Assert.Equal(4f, terrariaNpc.ai[3]);
        }

        [Fact]
        public void SetId()
        {
            var terrariaNpc = new Terraria.NPC();
            var npc = new OrionNpc(terrariaNpc);

            npc.SetId(NpcId.BlueSlime);

            Assert.Equal(NpcId.BlueSlime, (NpcId)terrariaNpc.netID);
        }
    }
}
