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

using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Orion.Core.Utils
{
    public class Color3Tests
    {
        [Fact]
        public void Black_Get()
        {
            Assert.Equal(new Color3(0, 0, 0), Color3.Black);
        }

        [Fact]
        public void White_Get()
        {
            Assert.Equal(new Color3(255, 255, 255), Color3.White);
        }

        [Fact]
        public void R_Get()
        {
            var color = new Color3(1, 2, 3);

            Assert.Equal(1, color.R);
        }

        [Fact]
        public void G_Get()
        {
            var color = new Color3(1, 2, 3);

            Assert.Equal(2, color.G);
        }

        [Fact]
        public void B_Get()
        {
            var color = new Color3(1, 2, 3);

            Assert.Equal(3, color.B);
        }

        [Fact]
        public void Equals_ReturnsTrue()
        {
            var color = new Color3(11, 22, 33);
            var color2 = new Color3(11, 22, 33);

            Assert.True(color.Equals((object)color2));
            Assert.True(color.Equals(color2));
        }

        [Fact]
        public void Equals_WrongType_ReturnsFalse()
        {
            var color = new Color3(255, 255, 255);

            Assert.False(color.Equals(1));
        }

        [Fact]
        public void Equals_RNotEqual_ReturnsFalse()
        {
            var color = new Color3(255, 255, 255);
            var color2 = new Color3(0, 255, 255);

            Assert.False(color.Equals((object)color2));
            Assert.False(color.Equals(color2));
        }

        [Fact]
        public void Equals_GNotEqual_ReturnsFalse()
        {
            var color = new Color3(255, 255, 255);
            var color2 = new Color3(255, 0, 255);

            Assert.False(color.Equals((object)color2));
            Assert.False(color.Equals(color2));
        }

        [Fact]
        public void Equals_BNotEqual_ReturnsFalse()
        {
            var color = new Color3(255, 255, 255);
            var color2 = new Color3(255, 255, 0);

            Assert.False(color.Equals((object)color2));
            Assert.False(color.Equals(color2));
        }

        [Fact]
        public void GetHashCode_Equals_AreEqual()
        {
            var color = new Color3(11, 22, 33);
            var color2 = new Color3(11, 22, 33);

            Assert.Equal(color.GetHashCode(), color2.GetHashCode());
        }

        [Fact]
        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Operator name")]
        public void op_Equality_ReturnsTrue()
        {
            var color = new Color3(11, 22, 33);
            var color2 = new Color3(11, 22, 33);

            Assert.True(color == color2);
        }

        [Fact]
        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Operator name")]
        public void op_Equality_ReturnsFalse()
        {
            var color = new Color3(255, 255, 255);
            var color2 = new Color3(255, 255, 0);
            var color3 = new Color3(255, 0, 255);
            var color4 = new Color3(0, 255, 255);

            Assert.False(color == color2);
            Assert.False(color == color3);
            Assert.False(color == color4);
        }

        [Fact]
        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Operator name")]
        public void op_Inequality_ReturnsTrue()
        {
            var color = new Color3(255, 255, 255);
            var color2 = new Color3(255, 255, 0);
            var color3 = new Color3(255, 0, 255);
            var color4 = new Color3(0, 255, 255);

            Assert.True(color != color2);
            Assert.True(color != color3);
            Assert.True(color != color4);
        }

        [Fact]
        [SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Operator name")]
        public void op_Inequality_ReturnsFalse()
        {
            var color = new Color3(11, 22, 33);
            var color2 = new Color3(11, 22, 33);

            Assert.False(color != color2);
        }
    }
}
