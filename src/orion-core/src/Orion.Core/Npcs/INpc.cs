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
using Orion.Core.Entities;

namespace Orion.Core.Npcs
{
    /// <summary>
    /// Represents a Terraria NPC.
    /// </summary>
    /// <remarks>
    /// Implementations are required to be thread-safe: i.e., each operation on the NPC should be atomic.
    /// </remarks>
    public interface INpc : IEntity
    {
        /// <summary>
        /// Gets the NPC's ID.
        /// </summary>
        /// <value>The NPC's ID.</value>
        public NpcId Id { get; }

        /// <summary>
        /// Gets or sets the NPC's health.
        /// </summary>
        /// <value>The NPC's health.</value>
        public int Health { get; set; }

        /// <summary>
        /// Gets or sets the NPC's max health.
        /// </summary>
        /// <value>The NPC's max health.</value>
        public int MaxHealth { get; set; }

        /// <summary>
        /// Gets the NPC's AI values.
        /// </summary>
        /// <value>The NPC's AI values.</value>
        public Span<float> AiValues { get; }

        /// <summary>
        /// Sets the NPC's <paramref name="id"/>. This will update the NPC accordingly. 
        /// </summary>
        /// <param name="id">The NPC ID to set the NPC to.</param>
        public void SetId(NpcId id);
    }
}
