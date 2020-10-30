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

using Orion.Core.Events;
using Orion.Core.Events.Server;
using Orion.Core.Items;
using Orion.Core.Npcs;
using Orion.Core.Players;
using Orion.Core.Projectiles;
using Orion.Core.World;
using Orion.Core.World.TileEntities;

namespace Orion.Core
{
    /// <summary>
    /// Represents the server. Provides access to Orion services and publishes server-related events.
    /// </summary>
    /// <remarks>
    /// <para>Implementations must be thread-safe.</para>
    /// <para>
    /// The server is responsible for publishing the following server-related events:
    /// <list type="bullet">
    /// <item><description><see cref="ServerInitializeEvent"/></description></item>
    /// <item><description><see cref="ServerStartEvent"/></description></item>
    /// <item><description><see cref="ServerTickEvent"/></description></item>
    /// <item><description><see cref="ServerCommandEvent"/></description></item>
    /// </list>
    /// </para>
    /// </remarks>
    public interface IServer
    {
        /// <summary>
        /// Gets the event manager.
        /// </summary>
        /// <value>The event manager.</value>
        public IEventManager Events { get; }

        /// <summary>
        /// Gets the item service.
        /// </summary>
        /// <value>The item service.</value>
        public IItemService Items { get; }

        /// <summary>
        /// Gets the NPC service.
        /// </summary>
        /// <value>The NPC service.</value>
        public INpcService Npcs { get; }

        /// <summary>
        /// Gets the player service.
        /// </summary>
        /// <value>The player service.</value>
        public IPlayerService Players { get; }

        /// <summary>
        /// Gets the projectile service.
        /// </summary>
        /// <value>The projectile service.</value>
        public IProjectileService Projectiles { get; }

        /// <summary>
        /// Gets the chest service.
        /// </summary>
        /// <value>The chest service.</value>
        public IChestService Chests { get; }

        /// <summary>
        /// Gets the sign service.
        /// </summary>
        /// <value>The sign service.</value>
        public ISignService Signs { get; }

        /// <summary>
        /// Gets the world.
        /// </summary>
        /// <value>The world.</value>
        public IWorld World { get; }
    }
}
