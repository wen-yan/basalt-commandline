using System;
using System.Threading.Tasks;
using Basalt.CommandLine;
using Basalt.CommandLine.Annotations;

namespace SimpleUsage.Commands;

partial class FsLsCommandOptions
{
    [CliCommandSymbol]
    public ConsoleColor Color { get; init; }

    [CliCommandSymbol(CliCommandSymbolType.Argument)]
    public string Directory { get; init; }
}

[CliCommandBuilder("ls", typeof(FsCliCommandBuilder))]
partial class FsLsCliCommandBuilder : CliCommandBuilder<FsLsCommand, FsLsCommandOptions>
{
    public FsLsCliCommandBuilder(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.Description = "ls command";
        this.ColorOption = new("--color", "-c")
        {
            Description = "command output color",
            DefaultValueFactory = _ => ConsoleColor.Yellow,
        };
        this.DirectoryArgument = new("directory")
        {
            Description = "target directory of ls command"
        };
    }
}

class FsLsCommand : Command<FsLsCommandOptions>
{
    public FsLsCommand(CommandContext commandContext, IDemoService demoService) : base(commandContext)
    {
        this.DemoService = demoService;
    }

    private IDemoService DemoService { get; }

    public override async ValueTask ExecuteAsync()
    {
        ConsoleColor currentColor = Console.ForegroundColor;
        Console.ForegroundColor = this.Options.Color;
        try
        {
            await this.DemoService.WriteLineAsync($"FsLsCommand output, endpoint: {this.Options.Endpoint}, target: {this.Options.Directory}");
        }
        finally
        {
            Console.ForegroundColor = currentColor;
        }
    }
}