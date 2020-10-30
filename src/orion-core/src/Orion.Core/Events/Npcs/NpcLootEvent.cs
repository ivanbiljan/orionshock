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
using Orion.Core.Npcs;

namespace Orion.Core.Events.Npcs
{
    /// <summary>
    /// An event that occurs when an NPC is dropping loot. This event can be canceled.
    /// </summary>
    [Event("npc-loot")]
    public sealed class NpcLootEvent : NpcEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpcLootEvent"/> class with the specified
        /// <paramref name="npc"/>.
        /// </summary>
        /// <param name="npc">The NPC dropping loot.</param>
        /// <exception cref="ArgumentNullException"><paramref name="npc"/> is <see langword="null"/>.</exception>
        public NpcLootEvent(INpc npc) : base(npc)
        {
        }

        /// <summary>
        /// Gets or sets the item being dropped.
        /// </summary>
        /// <value>The item being dropped.</value>
        public ItemStack Item { get; set; }
    }
}
