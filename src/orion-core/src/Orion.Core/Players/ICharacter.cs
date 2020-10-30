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

namespace Orion.Core.Players
{
    /// <summary>
    /// Represents a Terraria player's character.
    /// </summary>
    /// <remarks>
    /// Implementations are required to be thread-safe: i.e., each operation on the player's character should be atomic.
    /// </remarks>
    public interface ICharacter
    {
        /// <summary>
        /// Gets or sets the character's difficulty.
        /// </summary>
        /// <value>The character's difficulty.</value>
        public CharacterDifficulty Difficulty { get; set; }
    }
}
