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
using Orion.Core.Items;
using Xunit;

namespace Orion.Launcher.Items
{
    // These tests depend on Terraria state.
    [Collection("TerrariaTestsCollection")]
    [SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "Testing")]
    public class OrionItemTests
    {
        [Fact]
        public void Name_Get()
        {
            var terrariaItem = new Terraria.Item { _nameOverride = "test" };
            var item = new OrionItem(terrariaItem);

            Assert.Equal("test", item.Name);
        }

        [Fact]
        public void Name_SetNullValue_ThrowsArgumentNullException()
        {
            var terrariaItem = new Terraria.Item();
            var item = new OrionItem(terrariaItem);

            Assert.Throws<ArgumentNullException>(() => item.Name = null!);
        }

        [Fact]
        public void Name_Set()
        {
            var terrariaItem = new Terraria.Item();
            var item = new OrionItem(terrariaItem);

            item.Name = "test";

            Assert.Equal("test", terrariaItem.Name);
        }

        [Fact]
        public void Type_Get()
        {
            var terrariaItem = new Terraria.Item { type = (int)ItemId.Sdmg };
            var item = new OrionItem(terrariaItem);

            Assert.Equal(ItemId.Sdmg, item.Id);
        }

        [Fact]
        public void Prefix_Get()
        {
            var terrariaItem = new Terraria.Item { prefix = (int)ItemPrefix.Unreal };
            var item = new OrionItem(terrariaItem);

            Assert.Equal(ItemPrefix.Unreal, item.Prefix);
        }

        [Fact]
        public void StackSize_Get()
        {
            var terrariaItem = new Terraria.Item { stack = 123 };
            var item = new OrionItem(terrariaItem);

            Assert.Equal(123, item.StackSize);
        }

        [Fact]
        public void StackSize_Set()
        {
            var terrariaItem = new Terraria.Item { type = (int)ItemId.DirtBlock };
            var item = new OrionItem(terrariaItem);

            item.StackSize = 123;

            Assert.Equal(123, terrariaItem.stack);
        }

        [Fact]
        public void Damage_Get()
        {
            var terrariaItem = new Terraria.Item { damage = 100 };
            var item = new OrionItem(terrariaItem);

            Assert.Equal(100, item.Damage);
        }

        [Fact]
        public void Damage_Set()
        {
            var terrariaItem = new Terraria.Item();
            var item = new OrionItem(terrariaItem);

            item.Damage = 100;

            Assert.Equal(100, terrariaItem.damage);
        }

        [Fact]
        public void UseTime_Get()
        {
            var terrariaItem = new Terraria.Item { useTime = 100 };
            var item = new OrionItem(terrariaItem);

            Assert.Equal(100, item.UseTime);
        }

        [Fact]
        public void UseTime_Set()
        {
            var terrariaItem = new Terraria.Item();
            var item = new OrionItem(terrariaItem);

            item.UseTime = 100;

            Assert.Equal(100, terrariaItem.useTime);
        }

        [Fact]
        public void SetId()
        {
            var terrariaItem = new Terraria.Item();
            var item = new OrionItem(terrariaItem);

            item.SetId(ItemId.Sdmg);

            Assert.Equal(ItemId.Sdmg, (ItemId)terrariaItem.type);
        }

        [Fact]
        public void SetPrefix()
        {
            var terrariaItem = new Terraria.Item();
            terrariaItem.SetDefaults((int)ItemId.Sdmg);
            var item = new OrionItem(terrariaItem);

            item.SetPrefix(ItemPrefix.Unreal);

            Assert.Equal(ItemPrefix.Unreal, (ItemPrefix)terrariaItem.prefix);
        }
    }
}
