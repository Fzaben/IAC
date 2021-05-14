﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using Abp.Dependency;
using Abp.ObjectMapping;
using Abp.RealTime;
using Castle.Core.Logging;
using Microsoft.AspNetCore.SignalR;
using MyCompanyName.AbpZeroTemplate.Chat;
using MyCompanyName.AbpZeroTemplate.Chat.Dto;
using MyCompanyName.AbpZeroTemplate.Friendships;
using MyCompanyName.AbpZeroTemplate.Friendships.Dto;

namespace MyCompanyName.AbpZeroTemplate.Web.Chat.SignalR
{
    public class SignalRChatCommunicator : IChatCommunicator, ITransientDependency
    {
        private readonly IHubContext<ChatHub> _chatHub;

        private readonly IObjectMapper _objectMapper;

        public SignalRChatCommunicator(
            IObjectMapper objectMapper,
            IHubContext<ChatHub> chatHub)
        {
            _objectMapper = objectMapper;
            _chatHub = chatHub;
            Logger = NullLogger.Instance;
        }

        /// <summary>
        ///     Reference to the logger.
        /// </summary>
        public ILogger Logger { get; set; }

        public async Task SendMessageToClient(IReadOnlyList<IOnlineClient> clients, ChatMessage message)
        {
            foreach (var client in clients)
            {
                var signalRClient = GetSignalRClientOrNull(client);
                if (signalRClient == null) return;

                await signalRClient.SendAsync("getChatMessage", _objectMapper.Map<ChatMessageDto>(message));
            }
        }

        public async Task SendFriendshipRequestToClient(IReadOnlyList<IOnlineClient> clients, Friendship friendship,
            bool isOwnRequest, bool isFriendOnline)
        {
            foreach (var client in clients)
            {
                var signalRClient = GetSignalRClientOrNull(client);
                if (signalRClient == null) return;

                var friendshipRequest = _objectMapper.Map<FriendDto>(friendship);
                friendshipRequest.IsOnline = isFriendOnline;

                await signalRClient.SendAsync("getFriendshipRequest", friendshipRequest, isOwnRequest);
            }
        }

        public async Task SendUserConnectionChangeToClients(IReadOnlyList<IOnlineClient> clients, UserIdentifier user,
            bool isConnected)
        {
            foreach (var client in clients)
            {
                var signalRClient = GetSignalRClientOrNull(client);
                if (signalRClient == null) continue;

                await signalRClient.SendAsync("getUserConnectNotification", user, isConnected);
            }
        }

        public async Task SendUserStateChangeToClients(IReadOnlyList<IOnlineClient> clients, UserIdentifier user,
            FriendshipState newState)
        {
            foreach (var client in clients)
            {
                var signalRClient = GetSignalRClientOrNull(client);
                if (signalRClient == null) continue;

                await signalRClient.SendAsync("getUserStateChange", user, newState);
            }
        }

        public async Task SendAllUnreadMessagesOfUserReadToClients(IReadOnlyList<IOnlineClient> clients,
            UserIdentifier user)
        {
            foreach (var client in clients)
            {
                var signalRClient = GetSignalRClientOrNull(client);
                if (signalRClient == null) continue;

                await signalRClient.SendAsync("getallUnreadMessagesOfUserRead", user);
            }
        }

        public async Task SendReadStateChangeToClients(IReadOnlyList<IOnlineClient> clients, UserIdentifier user)
        {
            foreach (var client in clients)
            {
                var signalRClient = GetSignalRClientOrNull(client);
                if (signalRClient == null) continue;

                await signalRClient.SendAsync("getReadStateChange", user);
            }
        }

        private IClientProxy GetSignalRClientOrNull(IOnlineClient client)
        {
            var signalRClient = _chatHub.Clients.Client(client.ConnectionId);
            if (signalRClient == null)
            {
                Logger.Debug("Can not get chat user " + client.UserId + " from SignalR hub!");
                return null;
            }

            return signalRClient;
        }
    }
}