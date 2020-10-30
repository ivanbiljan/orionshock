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
    /// An event that occurs when a player is chatting. This event can be canceled.
    /// </summary>
    [Event("player-chat")]
    public sealed class PlayerChatEvent : PlayerEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerChatEvent"/> class with the specified
        /// <paramref name="player"/>, <paramref name="command"/>, and <paramref name="message"/>.
        /// </summary>
        /// <param name="player">The player chatting.</param>
        /// <param name="command">The command that the player used.</param>
        /// <param name="message">The message that the player sent.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="player"/>, <paramref name="command"/>, or <paramref name="message"/> are
        /// <see langword="null"/>.
        /// </exception>
        public PlayerChatEvent(IPlayer player, string command, string message) : base(player)
        {
            Command = command ?? throw new ArgumentNullException(nameof(command));
            Message = message ?? throw new ArgumentNullException(nameof(message));
        }

        /// <summary>
        /// Gets the command that the player used.
        /// </summary>
        /// <value>The command that the player used.</value>
        public string Command { get; }

        /// <summary>
        /// Gets the message that the player sent.
        /// </summary>
        /// <value>The message that the player sent.</value>
        public string Message { get; }
    }
}
