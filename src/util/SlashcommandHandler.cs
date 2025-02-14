using System.Reflection;
using Discord;
using Discord.WebSocket;

namespace SlashCommandsHandler
{
    public class SlashCommand
    {
        public required String name { get; set; }
        public required String description { get; set; }
        
        public SlashCommandOptionBuilder[]? OptionBuilder { get; set; }

        public virtual async Task Execute(SocketSlashCommand command)
        {
            Console.WriteLine("Failed to override execute");
            await command.RespondAsync("Failed to override default execute handler");
        }
    }

    public class SlashCommandsList
    {
        public List<SlashCommand> commands()
        {
            var commands_copy = new List<SlashCommand>();

            var assembly = Assembly.GetExecutingAssembly();
            var allTypes = assembly.GetTypes();
            var slashCommandType = allTypes.Where(myType => myType.IsSubclassOf(typeof(SlashCommand)));

            foreach(var type in slashCommandType)
            {
                var command = (SlashCommand)Activator.CreateInstance(type)!;
                commands_copy.Add(command);
            }

            return commands_copy;
        }
    }
}