﻿using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace FotM.Portal.Infrastructure
{
    [HubName("indexHub")]
    public class IndexHub: Hub
    {
        public void QueryLatestUpdate()
        {
            ReactiveUpdateManager.Instance.SendLatestUpdate(Clients.Caller);
        }
    }
}