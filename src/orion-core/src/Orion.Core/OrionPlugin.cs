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
using Serilog;

namespace Orion.Core
{
    /// <summary>
    /// Provides the base class for an Orion plugin.
    /// </summary>
    public abstract class OrionPlugin : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrionPlugin"/> class with the specified
        /// <paramref name="server"/> and <paramref name="log"/>.
        /// </summary>
        /// <param name="server">The server.</param>
        /// <param name="log">The plugin-specific log to log to.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="server"/> or <paramref name="log"/> are <see langword="null"/>.
        /// </exception>
        protected OrionPlugin(IServer server, ILogger log)
        {
            Server = server ?? throw new ArgumentNullException(nameof(server));
            Log = log ?? throw new ArgumentNullException(nameof(log));
        }

        /// <summary>
        /// Gets the server.
        /// </summary>
        /// <value>The server.</value>
        public IServer Server { get; }

        /// <summary>
        /// Gets the plugin-specific log.
        /// </summary>
        /// <value>The plugin-specific log.</value>
        public ILogger Log { get; }

        /// <summary>
        /// Disposes the plugin, releasing any resources associated with it.
        /// </summary>
        public virtual void Dispose()
        {
        }
    }
}
