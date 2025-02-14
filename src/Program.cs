using Discord;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;
using SlashCommandsHandler;

namespace Program
{
    class Program
    {
        public static DiscordSocketClient _client;

        // Discord Bot Initialization
        public static async Task Main()
        {
            // Linking Event handlers
            _client = new DiscordSocketClient();
            _client.Log += Log;
            _client.Ready += Client_Ready;
            _client.SlashCommandExecuted += SlashCommandExecuted;

            // Obtaining token directory
            Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + @"\..\..\..\settings");
            string TokenPath = Path.Combine(Directory.GetCurrentDirectory(), "token.txt");
            var DISCORD_TOKEN = File.ReadAllText(TokenPath);

            // Starting Bot
            await _client.LoginAsync(TokenType.Bot, DISCORD_TOKEN);  
            await _client.StartAsync();
            await Task.Delay(-1);
        }

        // Bot logging
        private static async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return;
        }

        // Handles the execution of slash commands
        private static async Task SlashCommandExecuted(SocketSlashCommand command)
        {
            SlashCommandsList slashCommands = new SlashCommandsHandler.SlashCommandsList();
            Console.WriteLine("User: " + command.User.ToString() + ", " + "Ran command: " + command.Data.Name);

            foreach (var slashCommand in slashCommands.commands())
            {
                if (slashCommand != null && slashCommand.name == command.Data.Name)
                {
                    await slashCommand.Execute(command);
                }
            }
        }

        // Discord bot finished initialization
        private static async Task Client_Ready()
        {
            SlashCommandsList slashCommands = new SlashCommandsHandler.SlashCommandsList();
            Console.WriteLine("Number of commands: " + slashCommands.commands().Count());

            // Creating the commands
            try
            {
                foreach (var command in slashCommands.commands())
                {
                    var commandBuilder = new SlashCommandBuilder();
                    Console.WriteLine("Adding command: " + command.name);

                    commandBuilder.WithName(command.name);
                    commandBuilder.WithDescription(command.description);

                    if (command.OptionBuilder != null)
                    {
                        foreach (var option in command.OptionBuilder)
                        {
                            commandBuilder.AddOption(option);
                        }
                    }

                    await _client.CreateGlobalApplicationCommandAsync(commandBuilder.Build());
                } 
                    
            }
            catch(HttpException exception)
            {
                var json = JsonConvert.SerializeObject(exception.Errors, Formatting.Indented);
                Console.WriteLine(json);
            }
        }
    }
}