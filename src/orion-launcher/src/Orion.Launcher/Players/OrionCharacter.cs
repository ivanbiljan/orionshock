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

using System.Diagnostics;
using Orion.Core.Players;

namespace Orion.Launcher.Players
{
    internal sealed class OrionCharacter : ICharacter
    {
        private readonly Terraria.Player _wrapped;

        public OrionCharacter(Terraria.Player terrariaPlayer)
        {
            Debug.Assert(terrariaPlayer != null);

            _wrapped = terrariaPlayer;
        }

        public CharacterDifficulty Difficulty
        {
            get => (CharacterDifficulty)_wrapped.difficulty;
            set => _wrapped.difficulty = (byte)value;
        }
    }
}
