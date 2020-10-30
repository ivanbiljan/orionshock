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
using Orion.Core.Items;
using Orion.Core.Players;
using Orion.Core.World.TileEntities;

namespace Orion.Core.Events.World.TileEntities
{
    /// <summary>
    /// An event that occurs when a player is modifying a chest's inventory. This event can be canceled.
    /// </summary>
    [Event("chest-inv")]
    public sealed class ChestInventoryEvent : ChestEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChestInventoryEvent"/> class with the specified
        /// <paramref name="chest"/>, <paramref name="player"/>, inventory <paramref name="slot"/>, and
        /// <paramref name="item"/>.
        /// </summary>
        /// <param name="chest">The chest whose inventory is being modified.</param>
        /// <param name="player">The player modifying the chest's inventory.</param>
        /// <param name="slot">The inventory slot being modified.</param>
        /// <param name="item">The item.</param>
        public ChestInventoryEvent(IChest chest, IPlayer player, int slot, ItemStack item) : base(chest)
        {
            Player = player ?? throw new ArgumentNullException(nameof(player));
            Slot = slot;
            Item = item;
        }

        /// <summary>
        /// Gets the player modifying the chest's inventory.
        /// </summary>
        /// <value>The player modifying the chest's inventory.</value>
        public IPlayer Player { get; }

        /// <summary>
        /// Gets the inventory slot being modified.
        /// </summary>
        /// <value>The inventory slot being modified.</value>
        public int Slot { get; }

        /// <summary>
        /// Gets the item.
        /// </summary>
        /// <value>The item.</value>
        public ItemStack Item { get; }
    }
}
