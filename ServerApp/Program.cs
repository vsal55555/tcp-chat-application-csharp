using System.Runtime.InteropServices;
using System.Text;
using TcpSharp;

Dictionary<string, string> clients = [];

TcpSharpSocketServer server = new TcpSharpSocketServer(9000);
server.OnConnected += Server_OnConnected;
server.OnDisconnected += Server_OnDisconnected;
server.OnDataReceived += Server_OnDataReceived;
server.StartListening();
Console.WriteLine("Server started listening on port 9000.");
await Task.Delay(Timeout.Infinite);

void UpdateUserList()
{
    var userList = string.Join(",", clients.Values);

    foreach (var connectionId in clients.Keys)
    {
        server.SendString(
            connectionId,
            $"USERLIST|{userList}"
        );
    }
}

void BroadcastMessage(string message)
{
    foreach (var connectionId in clients.Keys)
    {
        server.SendString(connectionId, message);
    }
    Console.WriteLine(message);
}

void Server_OnDataReceived(object? sender, OnServerDataReceivedEventArgs e)
{
    var msg = Encoding.UTF8.GetString(e.Data);
    if(msg.StartsWith("JOIN|"))
    {
        Console.WriteLine(msg);
        string username = msg.Split('|')[1];
        clients[e.ConnectionId] = username;
        BroadcastMessage($"Client {e.ConnectionId} joined as {username}");
        UpdateUserList();
        Console.WriteLine($"Client {e.ConnectionId} set username to {username}");
    }
    else
    {
        if (msg.StartsWith("MSG|"))
        {
            var parts = msg.Split('|');
            if(parts.Length >= 3)
            {
                var username = parts[1];
                var message = string.Join('|', parts.Skip(2));
                var senderUsername = clients[e.ConnectionId];
                var target = clients.FirstOrDefault(x => x.Value == username);
                if (!target.Equals(default(KeyValuePair<string, string>)))
                {
                    server.SendString(target.Key, $"MSG|{senderUsername}: {message}");
                    Console.WriteLine($"Message from {senderUsername} to {username}: {message}");
                }
                else
                {
                    server.SendString(e.ConnectionId, $"User {username} not found.");
                    Console.WriteLine($"User {username} not found for message from {senderUsername}");
                }
             
            }
        }
    }
}

void Server_OnDisconnected(object? sender, OnServerDisconnectedEventArgs e)
{
    if (clients.ContainsKey(e.ConnectionId))
    {
        string username = clients[e.ConnectionId];
        clients.Remove(e.ConnectionId);
        BroadcastMessage($"{username} has disconnected.");
        UpdateUserList();
        Console.WriteLine($"Client disconnected: {e.ConnectionId}");
    }
}

void Server_OnConnected(object? sender, OnServerConnectedEventArgs e)
{
    Console.WriteLine($"Client connected: {e.ConnectionId}");
}