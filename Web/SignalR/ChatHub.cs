using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Web
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.All.SendAsync("MesajGeldi", Context.ConnectionId, "Yeni bir giriş algılandı.");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.All.SendAsync("MesajGeldi", Context.ConnectionId, "Bağlantı kapatıldı.");
            return base.OnDisconnectedAsync(exception);
        }

        public async Task MesajGonder(string kullaniciAdi, string mesaj)
        {
            await Clients.All.SendAsync("MesajGeldi", kullaniciAdi, mesaj);
        }

    }
}
