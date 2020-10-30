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
using Moq;
using Orion.Core.Events;
using Orion.Core.Events.Projectiles;
using Orion.Core.Projectiles;
using Orion.Core.Utils;
using Serilog;
using Xunit;

namespace Orion.Launcher.Projectiles
{
    // These tests depend on Terraria state.
    [Collection("TerrariaTestsCollection")]
    public class OrionProjectileServiceTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(10000)]
        public void Item_GetIndexOutOfRange_ThrowsIndexOutOfRangeException(int index)
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            using var projectileService = new OrionProjectileService(events, log);

            Assert.Throws<IndexOutOfRangeException>(() => projectileService[index]);
        }

        [Fact]
        public void Item_Get()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            using var projectileService = new OrionProjectileService(events, log);

            var projectile = projectileService[1];

            Assert.Equal(1, projectile.Index);
            Assert.Same(Terraria.Main.projectile[1], ((OrionProjectile)projectile).Wrapped);
        }

        [Fact]
        public void Item_GetMultipleTimes_ReturnsSameInstance()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            using var projectileService = new OrionProjectileService(events, log);

            var projectile = projectileService[0];
            var projectile2 = projectileService[0];

            Assert.Same(projectile, projectile2);
        }

        [Fact]
        public void Count_Get()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            using var projectileService = new OrionProjectileService(events, log);

            Assert.Equal(Terraria.Main.maxProjectiles, projectileService.Count);
        }

        [Fact]
        public void GetEnumerator()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            using var projectileService = new OrionProjectileService(events, log);

            var projectiles = projectileService.ToList();

            for (var i = 0; i < projectiles.Count; ++i)
            {
                Assert.Same(Terraria.Main.projectile[i], ((OrionProjectile)projectiles[i]).Wrapped);
            }
        }

        [Fact]
        public void ProjectileDefaults_EventTriggered()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            using var projectileService = new OrionProjectileService(events, log);

            Mock.Get(events)
                .Setup(em => em.Raise(
                    It.Is<ProjectileDefaultsEvent>(
                        evt => ((OrionProjectile)evt.Projectile).Wrapped == Terraria.Main.projectile[0] &&
                            evt.Id == ProjectileId.CrystalBullet),
                    log));

            Terraria.Main.projectile[0].SetDefaults((int)ProjectileId.CrystalBullet);

            Assert.Equal(ProjectileId.CrystalBullet, (ProjectileId)Terraria.Main.projectile[0].type);

            Mock.Get(events).VerifyAll();
        }

        [Fact]
        public void ProjectileDefaults_AbstractProjectile_EventTriggered()
        {
            var terrariaProjectile = new Terraria.Projectile();

            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            using var projectileService = new OrionProjectileService(events, log);

            Mock.Get(events)
                .Setup(em => em.Raise(
                    It.Is<ProjectileDefaultsEvent>(
                        evt => ((OrionProjectile)evt.Projectile).Wrapped == terrariaProjectile &&
                            evt.Id == ProjectileId.CrystalBullet),
                    log));

            terrariaProjectile.SetDefaults((int)ProjectileId.CrystalBullet);

            Assert.Equal(ProjectileId.CrystalBullet, (ProjectileId)terrariaProjectile.type);

            Mock.Get(events).VerifyAll();
        }

        [Fact]
        public void ProjectileDefaults_EventModified()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            using var projectileService = new OrionProjectileService(events, log);

            Mock.Get(events)
                .Setup(em => em.Raise(It.IsAny<ProjectileDefaultsEvent>(), log))
                .Callback<ProjectileDefaultsEvent, ILogger>((evt, log) => evt.Id = ProjectileId.WoodenArrow);

            Terraria.Main.projectile[0].SetDefaults((int)ProjectileId.CrystalBullet);

            Assert.Equal(ProjectileId.WoodenArrow, (ProjectileId)Terraria.Main.projectile[0].type);

            Mock.Get(events).VerifyAll();
        }

        [Fact]
        public void ProjectileDefaults_EventCanceled()
        {
            // Clear the projectile so that we know it's empty.
            Terraria.Main.projectile[0] = new Terraria.Projectile { whoAmI = 0 };

            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            using var projectileService = new OrionProjectileService(events, log);

            Mock.Get(events)
                .Setup(em => em.Raise(It.IsAny<ProjectileDefaultsEvent>(), log))
                .Callback<ProjectileDefaultsEvent, ILogger>((evt, log) => evt.Cancel());

            Terraria.Main.projectile[0].SetDefaults((int)ProjectileId.CrystalBullet);

            Assert.Equal(ProjectileId.None, (ProjectileId)Terraria.Main.projectile[0].type);

            Mock.Get(events).VerifyAll();
        }

        [Fact]
        public void ProjectileTick_EventTriggered()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            using var projectileService = new OrionProjectileService(events, log);

            Mock.Get(events)
                .Setup(em => em.Raise(
                    It.Is<ProjectileTickEvent>(
                        evt => ((OrionProjectile)evt.Projectile).Wrapped == Terraria.Main.projectile[0]),
                    log));

            Terraria.Main.projectile[0].Update(0);

            Mock.Get(events).VerifyAll();
        }

        [Fact]
        public void ProjectileTick_EventCanceled()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            using var projectileService = new OrionProjectileService(events, log);

            Mock.Get(events)
                .Setup(em => em.Raise(It.IsAny<ProjectileTickEvent>(), log))
                .Callback<ProjectileTickEvent, ILogger>((evt, log) => evt.Cancel());

            Terraria.Main.projectile[0].Update(0);

            Mock.Get(events).VerifyAll();
        }

        [Fact]
        public void Spawn()
        {
            // Clear the projectile so that we know it's empty.
            Terraria.Main.projectile[0] = new Terraria.Projectile { whoAmI = 0 };

            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            using var projectileService = new OrionProjectileService(events, log);

            var projectile = projectileService.Spawn(
                ProjectileId.CrystalBullet, Vector2f.Zero, Vector2f.Zero, 100, 0);

            Assert.Equal(Terraria.Main.projectile[0], ((OrionProjectile)projectile).Wrapped);
            Assert.Equal(ProjectileId.CrystalBullet, projectile.Id);
        }
    }
}
