using SlashCommandsHandler;
using Discord;
using Discord.WebSocket;

public class Pong : SlashCommand
{
    public Pong()
    {
        name = "pong";
        description = "Pong!";

        EmbedBuilder = new EmbedBuilder()
            .WithTitle("Pong!")
            .WithDescription("This is a test embed!")
            .WithFooter("E!");
    }

    public override async Task Execute(SocketSlashCommand command)
    {
        await command.RespondAsync(embed: EmbedBuilder?.Build());
    }
}