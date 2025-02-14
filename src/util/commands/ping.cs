using SlashCommandsHandler;
using Discord;
using Discord.WebSocket;

public class Ping : SlashCommand
{
    public Ping()
    {
        name = "ping";
        description = "Ping!";
    }

    public override async Task Execute(SocketSlashCommand command)
    {
        var _client = Program.Program._client;
        await command.RespondAsync($"Pong! Server latency is: {_client.Latency}ms");
    }
}