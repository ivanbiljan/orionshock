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
using Orion.Core.World;

namespace Orion.Core.Events.World
{
    /// <summary>
    /// An event that occurs when a world has been loaded. This event cannot be canceled.
    /// </summary>
    [Event("world-loaded", IsCancelable = false)]
    public sealed class WorldLoadedEvent : WorldEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorldLoadedEvent"/> class with the specified
        /// <paramref name="world"/>.
        /// </summary>
        /// <param name="world">The world that was loaded.</param>
        /// <exception cref="ArgumentNullException"><paramref name="world"/> is <see langword="null"/>.</exception>
        public WorldLoadedEvent(IWorld world) : base(world)
        {
        }
    }
}
