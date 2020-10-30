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
using Orion.Core.Players;

namespace Orion.Core.Events.Players
{
    /// <summary>
    /// An event that occurs when a player is sending their PvP status. This event can be canceled.
    /// </summary>
    [Event("player-pvp")]
    public sealed class PlayerPvpEvent : PlayerEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerPvpEvent"/> class with the specified
        /// <paramref name="player"/> and PvP status.
        /// </summary>
        /// <param name="player">The player sending their PvP status.</param>
        /// <param name="isInPvp">Whether the player is in PvP.</param>
        /// <exception cref="ArgumentNullException"><paramref name="player"/> is <see langword="null"/>.</exception>
        public PlayerPvpEvent(IPlayer player, bool isInPvp) : base(player)
        {
            IsInPvp = isInPvp;
        }

        /// <summary>
        /// Gets a value indicating whether the player is in PvP.
        /// </summary>
        /// <value><see langword="true"/> if the player is in PvP; otherwise, <see langword="false"/>.</value>
        public bool IsInPvp { get; }
    }
}
