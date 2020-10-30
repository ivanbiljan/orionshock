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

namespace Orion.Launcher.Entities
{
    [SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "Testing")]
    public class OrionEntityTests
    {
        [Fact]
        public void Index_Get()
        {
            var terrariaEntity = new TestTerrariaEntity();
            var entity = new TestOrionEntity(100, terrariaEntity);

            Assert.Equal(100, entity.Index);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsActive_Get(bool value)
        {
            var terrariaEntity = new TestTerrariaEntity { active = value };
            var entity = new TestOrionEntity(terrariaEntity);

            Assert.Equal(value, entity.IsActive);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void IsActive_Set(bool value)
        {
            var terrariaEntity = new TestTerrariaEntity();
            var entity = new TestOrionEntity(terrariaEntity);

            entity.IsActive = value;

            Assert.Equal(value, terrariaEntity.active);
        }

        [Fact]
        public void Position_Get()
        {
            var terrariaEntity = new TestTerrariaEntity { position = new Microsoft.Xna.Framework.Vector2(100, 100) };
            var entity = new TestOrionEntity(terrariaEntity);

            Assert.Equal(new Vector2f(100, 100), entity.Position);
        }

        [Fact]
        public void Position_Set()
        {
            var terrariaEntity = new TestTerrariaEntity();
            var entity = new TestOrionEntity(terrariaEntity);

            entity.Position = new Vector2f(100, 100);

            Assert.Equal(new Microsoft.Xna.Framework.Vector2(100, 100), terrariaEntity.position);
        }

        [Fact]
        public void Velocity_Get()
        {
            var terrariaEntity = new TestTerrariaEntity { velocity = new Microsoft.Xna.Framework.Vector2(100, 100) };
            var entity = new TestOrionEntity(terrariaEntity);

            Assert.Equal(new Vector2f(100, 100), entity.Velocity);
        }

        [Fact]
        public void Velocity_Set()
        {
            var terrariaEntity = new TestTerrariaEntity();
            var entity = new TestOrionEntity(terrariaEntity);

            entity.Velocity = new Vector2f(100, 100);

            Assert.Equal(new Microsoft.Xna.Framework.Vector2(100, 100), terrariaEntity.velocity);
        }

        [Fact]
        public void Size_Get()
        {
            var terrariaEntity = new TestTerrariaEntity { Size = new Microsoft.Xna.Framework.Vector2(100, 100) };
            var entity = new TestOrionEntity(terrariaEntity);

            Assert.Equal(new Vector2f(100, 100), entity.Size);
        }

        [Fact]
        public void Size_Set()
        {
            var terrariaEntity = new TestTerrariaEntity();
            var entity = new TestOrionEntity(terrariaEntity);

            entity.Size = new Vector2f(100, 100);

            Assert.Equal(new Microsoft.Xna.Framework.Vector2(100, 100), terrariaEntity.Size);
        }

        private sealed class TestOrionEntity : OrionEntity<TestTerrariaEntity>
        {
            public override string Name { get; set; } = "test";

            public TestOrionEntity(TestTerrariaEntity terrariaEntity) : this(-1, terrariaEntity)
            {
            }

            public TestOrionEntity(int entityIndex, TestTerrariaEntity terrariaEntity)
                : base(entityIndex, terrariaEntity)
            {
            }
        }

        private sealed class TestTerrariaEntity : Terraria.Entity
        {
        }
    }
}
