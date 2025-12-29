namespace MyNamespace
{
    partial class Level2CommandOptions
    {
        public Level2CommandOptions(int? OptionLevel2A, string? OptionLevel2B, System.IO.FileInfo? OptionLevel2C, int OptionLevel2D, int? OptionLevel1A, string? OptionLevel1B, System.IO.FileInfo? OptionLevel1C)
        {
            this.OptionLevel2A = OptionLevel2A;
            this.OptionLevel2B = OptionLevel2B;
            this.OptionLevel2C = OptionLevel2C;
            this.OptionLevel2D = OptionLevel2D;
            this.OptionLevel1A = OptionLevel1A;
            this.OptionLevel1B = OptionLevel1B;
            this.OptionLevel1C = OptionLevel1C;
        }

        // from MyNamespace.Level1CommandBuilder
        [global::Basalt.CommandLine.Annotations.CliCommandSymbol(global::Basalt.CommandLine.Annotations.CliCommandSymbolType.FromGlobalOption)]
        public int? OptionLevel1A { get; }

        // from MyNamespace.Level1CommandBuilder
        [global::Basalt.CommandLine.Annotations.CliCommandSymbol(global::Basalt.CommandLine.Annotations.CliCommandSymbolType.FromGlobalOption)]
        public string? OptionLevel1B { get; }

        // from MyNamespace.Level1CommandBuilder
        [global::Basalt.CommandLine.Annotations.CliCommandSymbol(global::Basalt.CommandLine.Annotations.CliCommandSymbolType.FromGlobalOption)]
        public System.IO.FileInfo? OptionLevel1C { get; }
    }
}

namespace MyNamespace
{
    using System.CommandLine;
    using Microsoft.Extensions.DependencyInjection;

    partial class Level2CommandBuilder
    {
        protected string Description { get; }

        internal global::System.CommandLine.Option<int?> OptionLevel2AOption { get; }

        internal global::System.CommandLine.Option<string?> OptionLevel2BOption { get; }

        internal global::System.CommandLine.Option<System.IO.FileInfo?> OptionLevel2COption { get; }

        private global::System.CommandLine.Option<int> OptionLevel2DOption { get; }

        protected override global::System.CommandLine.Command BuildCliCommandCore()
        {
            string name = this.GetCliCommandBuilderAttribute().Name;
            global::System.CommandLine.Command cliCommand = this.CreateCliCommand(name, this.Description);
            this.OptionLevel2AOption.Recursive = true;
            cliCommand.Add(this.OptionLevel2AOption);
            this.OptionLevel2BOption.Recursive = true;
            cliCommand.Add(this.OptionLevel2BOption);
            this.OptionLevel2COption.Recursive = true;
            cliCommand.Add(this.OptionLevel2COption);
            cliCommand.Add(this.OptionLevel2DOption);
            cliCommand.SetAction(async (global::System.CommandLine.ParseResult parseResult, global::System.Threading.CancellationToken cancellationToken) =>
            {
                global::MyNamespace.Level2CommandOptions options = new global::MyNamespace.Level2CommandOptions(OptionLevel1A: parseResult.GetValue(this.GetRequiredParentBuilder<global::MyNamespace.Level1CommandBuilder>().OptionLevel1AOption), OptionLevel1B: parseResult.GetValue(this.GetRequiredParentBuilder<global::MyNamespace.Level1CommandBuilder>().OptionLevel1BOption), OptionLevel1C: parseResult.GetValue(this.GetRequiredParentBuilder<global::MyNamespace.Level1CommandBuilder>().OptionLevel1COption), OptionLevel2A: parseResult.GetValue(this.OptionLevel2AOption), OptionLevel2B: parseResult.GetValue(this.OptionLevel2BOption), OptionLevel2C: parseResult.GetValue(this.OptionLevel2COption), OptionLevel2D: parseResult.GetValue(this.OptionLevel2DOption));
                await using (global::Microsoft.Extensions.DependencyInjection.AsyncServiceScope scope = this.ServiceProvider.CreateAsyncScope())
                {
                    global::Basalt.CommandLine.CommandContext context = scope.ServiceProvider.GetRequiredService<global::Basalt.CommandLine.CommandContext>();
                    context.ParseResult = parseResult;
                    context.CancellationToken = cancellationToken;
                    context.Options = options;
                    global::MyNamespace.Level2Command command = scope.ServiceProvider.GetRequiredService<global::MyNamespace.Level2Command>();
                    await command.ExecuteAsync().ConfigureAwait(false);
                }
            });
            this.OnCommandLineBuilt(cliCommand);
            return cliCommand;
        }

        partial void OnCommandLineBuilt(Command command);
    }
}