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

using System.Collections.Generic;
using Orion.Core.Events.World.TileEntities;

namespace Orion.Core.World.TileEntities
{
    /// <summary>
    /// Represents a chest service. Provides access to chests and publishes chest-related events.
    /// </summary>
    /// <remarks>
    /// <para>Implementations are required to be thread-safe.</para>
    /// <para>
    /// The chest service is responsible for publishing the following chest-related events:
    /// <list type="bullet">
    /// <item><description><see cref="ChestOpenEvent"/></description></item>
    /// <item><description><see cref="ChestInventoryEvent"/></description></item>
    /// </list>
    /// </para>
    /// </remarks>
    [Service(ServiceScope.Singleton)]
    public interface IChestService : IReadOnlyList<IChest>
    {
    }
}
