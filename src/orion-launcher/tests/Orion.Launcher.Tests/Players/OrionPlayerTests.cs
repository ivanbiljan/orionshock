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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Moq;
using Orion.Core.Events;
using Orion.Core.Events.Packets;
using Orion.Core.Packets;
using Orion.Core.Packets.Server;
using Orion.Core.Players;
using Serilog;
using Xunit;

namespace Orion.Launcher.Players
{
    // These tests depend on Terraria state.
    [Collection("TerrariaTestsCollection")]
    [SuppressMessage("Style", "IDE0017:Simplify object initialization", Justification = "Testing")]
    public partial class OrionPlayerTests
    {
        [Fact]
        public void Name_Get()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player { name = "test" };
            var player = new OrionPlayer(terrariaPlayer, events, log);

            Assert.Equal("test", player.Name);
        }

        [Fact]
        public void Name_SetNullValue_ThrowsArgumentNullException()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player();
            var player = new OrionPlayer(terrariaPlayer, events, log);

            Assert.Throws<ArgumentNullException>(() => player.Name = null!);
        }

        [Fact]
        public void Name_Set()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player();
            var player = new OrionPlayer(terrariaPlayer, events, log);

            player.Name = "test";

            Assert.Equal("test", terrariaPlayer.name);
        }

        [Fact]
        public void Character_Get()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player();
            var player = new OrionPlayer(terrariaPlayer, events, log);

            Assert.NotNull(player.Character);
        }

        [Fact]
        public void Health_Get()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player { statLife = 100 };
            var player = new OrionPlayer(terrariaPlayer, events, log);

            Assert.Equal(100, player.Health);
        }

        [Fact]
        public void Health_Set()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player();
            var player = new OrionPlayer(terrariaPlayer, events, log);

            player.Health = 100;

            Assert.Equal(100, terrariaPlayer.statLife);
        }

        [Fact]
        public void MaxHealth_Get()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player { statLifeMax = 500 };
            var player = new OrionPlayer(terrariaPlayer, events, log);

            Assert.Equal(500, player.MaxHealth);
        }

        [Fact]
        public void MaxHealth_Set()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player();
            var player = new OrionPlayer(terrariaPlayer, events, log);

            player.MaxHealth = 500;

            Assert.Equal(500, terrariaPlayer.statLifeMax);
        }

        [Fact]
        public void Mana_Get()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player { statMana = 100 };
            var player = new OrionPlayer(terrariaPlayer, events, log);

            Assert.Equal(100, player.Mana);
        }

        [Fact]
        public void Mana_Set()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player();
            var player = new OrionPlayer(terrariaPlayer, events, log);

            player.Mana = 100;

            Assert.Equal(100, terrariaPlayer.statMana);
        }

        [Fact]
        public void MaxMana_Get()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player { statManaMax = 200 };
            var player = new OrionPlayer(terrariaPlayer, events, log);

            Assert.Equal(200, player.MaxMana);
        }

        [Fact]
        public void MaxMana_Set()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player();
            var player = new OrionPlayer(terrariaPlayer, events, log);

            player.MaxMana = 200;

            Assert.Equal(200, terrariaPlayer.statManaMax);
        }

        [Fact]
        public void IsInPvp_Get()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player { hostile = true };
            var player = new OrionPlayer(terrariaPlayer, events, log);

            Assert.True(player.IsInPvp);
        }

        [Fact]
        public void IsInPvp_Set()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player();
            var player = new OrionPlayer(terrariaPlayer, events, log);

            player.IsInPvp = true;

            Assert.True(terrariaPlayer.hostile);
        }

        [Fact]
        public void Team_Get()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player { team = (int)Team.Red };
            var player = new OrionPlayer(terrariaPlayer, events, log);

            Assert.Equal(Team.Red, player.Team);
        }

        [Fact]
        public void Team_Set()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player();
            var player = new OrionPlayer(terrariaPlayer, events, log);

            player.Team = Team.Red;

            Assert.Equal(1, terrariaPlayer.team);
        }

        [Fact]
        public void ReceivePacket_NullPacket_ThrowsArgumentNullException()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player();
            var player = new OrionPlayer(terrariaPlayer, events, log);

            Assert.Throws<ArgumentNullException>(() => player.ReceivePacket<IPacket>(null!));
        }

        [Fact]
        public void ReceivePacket_EventTriggered()
        {
            // Clear out the password so we know it's empty.
            Terraria.Netplay.Clients[5] = new Terraria.RemoteClient { Id = 5 };
            Terraria.Netplay.ServerPassword = string.Empty;

            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player { whoAmI = 5 };
            var player = new OrionPlayer(5, terrariaPlayer, events, log);

            Mock.Get(events)
                .Setup(em => em.Raise(
                    It.Is<PacketReceiveEvent<ClientConnect>>(
                        evt => ((OrionPlayer)evt.Sender).Wrapped == terrariaPlayer &&
                            evt.Packet.Version == "Terraria" + Terraria.Main.curRelease),
                    log));

            var packet = new ClientConnect { Version = "Terraria" + Terraria.Main.curRelease };
            player.ReceivePacket(packet);

            Assert.Equal(1, Terraria.Netplay.Clients[5].State);

            Mock.Get(events).VerifyAll();
        }

        [Fact]
        public void ReceivePacket_EventModified()
        {
            // Clear out the password so we know it's empty.
            Terraria.Netplay.Clients[5] = new Terraria.RemoteClient { Id = 5 };
            Terraria.Netplay.ServerPassword = string.Empty;

            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player { whoAmI = 5 };
            var player = new OrionPlayer(5, terrariaPlayer, events, log);

            Mock.Get(events)
                .Setup(em => em.Raise(It.IsAny<PacketReceiveEvent<ClientConnect>>(), log))
                .Callback<PacketReceiveEvent<ClientConnect>, ILogger>(
                    (evt, log) => evt.Packet = new ClientConnect { Version = "Terraria1" });

            var packet = new ClientConnect { Version = "Terraria" + Terraria.Main.curRelease };
            player.ReceivePacket(packet);

            Assert.Equal(0, Terraria.Netplay.Clients[5].State);
        }

        [Fact]
        public void ReceivePacket_EventCanceled()
        {
            // Clear out the password so we know it's empty.
            Terraria.Netplay.Clients[5] = new Terraria.RemoteClient { Id = 5 };
            Terraria.Netplay.ServerPassword = string.Empty;

            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player { whoAmI = 5 };
            var player = new OrionPlayer(5, terrariaPlayer, events, log);

            Mock.Get(events)
                .Setup(em => em.Raise(It.IsAny<PacketReceiveEvent<ClientConnect>>(), log))
                .Callback<PacketReceiveEvent<ClientConnect>, ILogger>((evt, log) => evt.Cancel());

            var packet = new ClientConnect { Version = "Terraria" + Terraria.Main.curRelease };
            player.ReceivePacket(packet);

            Assert.Equal(0, Terraria.Netplay.Clients[5].State);

            Mock.Get(events).VerifyAll();
        }

        [Fact]
        public void SendPacket_NullPacket_ThrowsArgumentNullException()
        {
            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player();
            var player = new OrionPlayer(terrariaPlayer, events, log);

            Assert.Throws<ArgumentNullException>(() => player.SendPacket<IPacket>(null!));
        }

        [Fact]
        public void SendPacket_NotConnected()
        {
            Terraria.Netplay.Clients[5] = new Terraria.RemoteClient
            {
                Id = 5,
                Socket = Mock.Of<Terraria.Net.Sockets.ISocket>(s => !s.IsConnected())
            };

            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player { whoAmI = 5 };
            var player = new OrionPlayer(5, terrariaPlayer, events, log);

            Mock.Get(events)
                .Setup(em => em.Raise(It.IsAny<PacketSendEvent<TestPacket>>(), log));

            player.SendPacket(new TestPacket { Value = 100 });

            Mock.Get(events)
                .Verify(em => em.Raise(It.IsAny<PacketSendEvent<TestPacket>>(), log), Times.Never);
        }

        [Fact]
        public void SendPacket_EventTriggered()
        {
            Terraria.Netplay.Clients[5] = new Terraria.RemoteClient
            {
                Id = 5,
                Socket = Mock.Of<Terraria.Net.Sockets.ISocket>(s => s.IsConnected())
            };

            byte[]? sendData = null;
            Mock.Get(Terraria.Netplay.Clients[5].Socket)
                .Setup(s => s.AsyncSend(
                    It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<Terraria.Net.Sockets.SocketSendCallback>(), It.IsAny<object>()))
                .Callback<byte[], int, int, Terraria.Net.Sockets.SocketSendCallback, object>(
                    (data, offset, size, callback, state) =>
                    {
                        sendData = data[offset..size];
                        callback(state);
                    });

            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player { whoAmI = 5 };
            var player = new OrionPlayer(5, terrariaPlayer, events, log);

            Mock.Get(events)
                .Setup(em => em.Raise(
                    It.Is<PacketSendEvent<TestPacket>>(evt => ((OrionPlayer)evt.Receiver).Wrapped == terrariaPlayer),
                    log))
                .Callback<PacketSendEvent<TestPacket>, ILogger>((evt, log) =>
                {
                    Assert.Equal(100, evt.Packet.Value);
                });

            player.SendPacket(new TestPacket { Value = 100 });

            Assert.NotNull(sendData);
            Assert.Equal(new byte[] { 4, 0, 255, 100 }, sendData!);

            Mock.Get(Terraria.Netplay.Clients[5].Socket).VerifyAll();
            Mock.Get(events).VerifyAll();
        }

        [Fact]
        public void SendPacket_EventModified()
        {
            Terraria.Netplay.Clients[5] = new Terraria.RemoteClient
            {
                Id = 5,
                Socket = Mock.Of<Terraria.Net.Sockets.ISocket>(s => s.IsConnected())
            };

            byte[]? sendData = null;
            Mock.Get(Terraria.Netplay.Clients[5].Socket)
                .Setup(s => s.AsyncSend(
                    It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<Terraria.Net.Sockets.SocketSendCallback>(), It.IsAny<object>()))
                .Callback<byte[], int, int, Terraria.Net.Sockets.SocketSendCallback, object>(
                    (data, offset, size, callback, state) =>
                    {
                        sendData = data[offset..size];
                        callback(state);
                    });

            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player { whoAmI = 5 };
            var player = new OrionPlayer(5, terrariaPlayer, events, log);

            Mock.Get(events)
                .Setup(em => em.Raise(It.IsAny<PacketSendEvent<TestPacket>>(), log))
                .Callback<PacketSendEvent<TestPacket>, ILogger>((evt, log) => evt.Packet.Value = 200);

            player.SendPacket(new TestPacket { Value = 100 });

            Assert.NotNull(sendData);
            Assert.Equal(new byte[] { 4, 0, 255, 200 }, sendData!);

            Mock.Get(Terraria.Netplay.Clients[5].Socket).VerifyAll();
            Mock.Get(events).VerifyAll();
        }

        [Fact]
        public void SendPacket_EventCanceled()
        {
            Terraria.Netplay.Clients[5] = new Terraria.RemoteClient
            {
                Id = 5,
                Socket = Mock.Of<Terraria.Net.Sockets.ISocket>(s => s.IsConnected())
            };

            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player { whoAmI = 5 };
            var player = new OrionPlayer(5, terrariaPlayer, events, log);

            Mock.Get(events)
                .Setup(em => em.Raise(It.IsAny<PacketSendEvent<TestPacket>>(), log))
                .Callback<PacketSendEvent<TestPacket>, ILogger>((evt, log) => evt.Cancel());

            player.SendPacket(new TestPacket { Value = 100 });

            Mock.Get(Terraria.Netplay.Clients[5].Socket)
                .Verify(
                    s => s.AsyncSend(
                        It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                        It.IsAny<Terraria.Net.Sockets.SocketSendCallback>(), It.IsAny<object>()),
                    Times.Never);
            Mock.Get(events).VerifyAll();
        }

        [Fact]
        public void SendPacket_AsyncSendThrowsIOException()
        {
            Terraria.Netplay.Clients[5] = new Terraria.RemoteClient
            {
                Id = 5,
                Socket = Mock.Of<Terraria.Net.Sockets.ISocket>(s => s.IsConnected())
            };

            Mock.Get(Terraria.Netplay.Clients[5].Socket)
                .Setup(s => s.AsyncSend(
                    It.IsAny<byte[]>(), It.IsAny<int>(), It.IsAny<int>(),
                    It.IsAny<Terraria.Net.Sockets.SocketSendCallback>(), It.IsAny<object>()))
                .Throws<IOException>();

            var events = Mock.Of<IEventManager>();
            var log = Mock.Of<ILogger>();
            var terrariaPlayer = new Terraria.Player { whoAmI = 5 };
            var player = new OrionPlayer(5, terrariaPlayer, events, log);

            Mock.Get(events)
                .Setup(em => em.Raise(It.IsAny<PacketSendEvent<TestPacket>>(), log));

            player.SendPacket(new TestPacket { Value = 100 });

            Mock.Get(Terraria.Netplay.Clients[5].Socket).VerifyAll();
            Mock.Get(events).VerifyAll();
        }

        private sealed class TestPacket : IPacket
        {
            public PacketId Id => (PacketId)255;

            public byte Value { get; set; }

            public int ReadBody(Span<byte> span, PacketContext context)
            {
                Value = span[0];
                return 1;
            }

            public int WriteBody(Span<byte> span, PacketContext context)
            {
                span[0] = Value;
                return 1;
            }
        }
    }
}
