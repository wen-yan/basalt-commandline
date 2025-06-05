using System;
using System.Threading.Tasks;
using Basalt.CommandLine;
using Basalt.CommandLine.Annotations;

namespace MiddlewareDemo.Commands;

[CliCommandBuilder(CliCommandBuilderAttribute.DefaultRootCommandName, null)]
partial class AppCliCommandBuilder : RootCliCommandBuilder<AppCommand, AppCommandOptions>
{
    public AppCliCommandBuilder(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        this.Description = "Basalt.CommandLine middleware demo";
    }
}

partial class AppCommandOptions
{
}

class AppCommand : Command<AppCommandOptions>
{
    public AppCommand(CommandContext commandContext) : base(commandContext)
    {
    }

    public override async ValueTask ExecuteAsync()
    {
        await Console.Out.WriteLineAsync("this is the root command");
    }
}