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

namespace Orion.Core.Items
{
    /// <summary>
    /// Represents a Terraria item.
    /// </summary>
    /// <remarks>
    /// Implementations are required to be thread-safe: i.e., each operation on the item should be atomic.
    /// </remarks>
    public interface IItem : IEntity
    {
        /// <summary>
        /// Gets the item's ID.
        /// </summary>
        /// <value>The item's ID.</value>
        public ItemId Id { get; }

        /// <summary>
        /// Gets the item's prefix.
        /// </summary>
        /// <value>The item's prefix.</value>
        public ItemPrefix Prefix { get; }

        /// <summary>
        /// Gets or sets the item's stack size.
        /// </summary>
        /// <value>The item's stack size.</value>
        public int StackSize { get; set; }

        /// <summary>
        /// Gets or sets the item's damage.
        /// </summary>
        /// <value>The item's damage.</value>
        public int Damage { get; set; }

        /// <summary>
        /// Gets or sets the item's use time: i.e., the number of ticks before which the item can be used again.
        /// </summary>
        /// <value>The item's use time.</value>
        public int UseTime { get; set; }

        /// <summary>
        /// Sets the item's <paramref name="id"/>. This will update the item accordingly. 
        /// </summary>
        /// <param name="id">The item ID to set the item to.</param>
        public void SetId(ItemId id);

        /// <summary>
        /// Sets the item's <paramref name="prefix"/>. This will update the item accordingly.
        /// </summary>
        /// <param name="prefix">The item prefix to set the item to.</param>
        public void SetPrefix(ItemPrefix prefix);
    }

    /// <summary>
    /// Provides extensions for the <see cref="IItem"/> interface.
    /// </summary>
    public static class IItemExtensions
    {
        /// <summary>
        /// Returns the item as an item stack instance.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The item as an item stack instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="item"/> is <see langword="null"/>.</exception>
        public static ItemStack AsItemStack(this IItem item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            return new ItemStack(item.Id, item.Prefix, (short)item.StackSize);
        }
    }
}
