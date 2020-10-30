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
using Xunit;

namespace Orion.Core.Events.Server
{
    public class ServerArgsEventTests
    {
        [Fact]
        public void Ctor_NullArgs_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new ServerArgsEvent(null!));
        }

        [Fact]
        public void Ctor_NullArg_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new ServerArgsEvent(new string[] { null! }));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("   ")]
        public void GetFlag_NullOrWhiteSpaceName_ThrowsArgumentException(string? name)
        {
            var evt = new ServerArgsEvent();

            Assert.Throws<ArgumentException>(() => evt.GetFlag(name!));
        }

        [Fact]
        public void GetFlag_FlagExists_ReturnsTrue()
        {
            var evt = new ServerArgsEvent("-abcd", "--test");

            Assert.True(evt.GetFlag("a"));
            Assert.True(evt.GetFlag("b"));
            Assert.True(evt.GetFlag("c"));
            Assert.True(evt.GetFlag("d"));
            Assert.True(evt.GetFlag("test"));
        }

        [Fact]
        public void GetFlag_FlagDoesntExist_ReturnsFalse()
        {
            var evt = new ServerArgsEvent("--test");

            Assert.False(evt.GetFlag("test2"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("   ")]
        public void TryGetValue_NullOrWhiteSpaceName_ThrowsArgumentException(string? name)
        {
            var evt = new ServerArgsEvent();

            Assert.Throws<ArgumentException>(() => evt.TryGetValue(name!, out _));
        }

        [Fact]
        public void TryGetValue_FlagExists()
        {
            var evt = new ServerArgsEvent("--test=1234");

            Assert.True(evt.TryGetValue("test", out var value));
            Assert.Equal("1234", value);
        }

        [Fact]
        public void TryGetValue_FlagDoesntExist()
        {
            var evt = new ServerArgsEvent("--test=1234");

            Assert.False(evt.TryGetValue("test2", out _));
        }
    }
}
