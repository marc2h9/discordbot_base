# Discord Bot Base

This is a base setup for a Discord bot built using the Discord.NET library. It provides a starting point for building your own Discord bot, with all the necessary configuration and setup already handled.

## Getting Started

To get started with this base setup, follow these steps:

1. Clone this repository to your local machine.
2. Open the solution file (`discordbot_base.sln`) in Visual Studio / Visual Studio Code.
3. Update the `token.txt` file with your Discord bot token.
4. Build the solution and run the bot.

## Features

This base setup includes the following features:

- Discord bot initialization and configuration
- Logging of bot events
- Handling of slash commands
- Example slash commands (ping and pong)
- Example of creating and managing global application commands

## Extending the Base

To extend this base setup and build your own Discord bot, follow these steps:

1. Create a new class that inherits from the [SlashCommand](cci:2://file:///d:/Github/discordbot_base/src/util/SlashcommandHandler.cs:6:4-19:5) class in the `SlashCommandsHandler` namespace.
2. Implement the [Execute](cci:1://file:///d:/Github/discordbot_base/src/util/commands/pong.cs:17:4-20:5) method in your new class.
4. Build and run the bot.

## License

This Discord bot base is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.

# discordbot_base
A base setup for a Discord.NET discord bot
