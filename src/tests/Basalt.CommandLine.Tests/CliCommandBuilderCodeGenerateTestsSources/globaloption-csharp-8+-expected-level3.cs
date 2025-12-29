namespace MyNamespace
{
    partial class Level3CommandOptions
    {
        public Level3CommandOptions(int? OptionLevel3A, string? OptionLevel3B, System.IO.FileInfo? OptionLevel3C, int OptionLevel3D, int? OptionLevel2A, string? OptionLevel2B, System.IO.FileInfo? OptionLevel2C, int? OptionLevel1A, string? OptionLevel1B, System.IO.FileInfo? OptionLevel1C)
        {
            this.OptionLevel3A = OptionLevel3A;
            this.OptionLevel3B = OptionLevel3B;
            this.OptionLevel3C = OptionLevel3C;
            this.OptionLevel3D = OptionLevel3D;
            this.OptionLevel2A = OptionLevel2A;
            this.OptionLevel2B = OptionLevel2B;
            this.OptionLevel2C = OptionLevel2C;
            this.OptionLevel1A = OptionLevel1A;
            this.OptionLevel1B = OptionLevel1B;
            this.OptionLevel1C = OptionLevel1C;
        }

        // from MyNamespace.Level2CommandBuilder
        [global::Basalt.CommandLine.Annotations.CliCommandSymbol(global::Basalt.CommandLine.Annotations.CliCommandSymbolType.FromGlobalOption)]
        public int? OptionLevel2A { get; }

        // from MyNamespace.Level2CommandBuilder
        [global::Basalt.CommandLine.Annotations.CliCommandSymbol(global::Basalt.CommandLine.Annotations.CliCommandSymbolType.FromGlobalOption)]
        public string? OptionLevel2B { get; }

        // from MyNamespace.Level2CommandBuilder
        [global::Basalt.CommandLine.Annotations.CliCommandSymbol(global::Basalt.CommandLine.Annotations.CliCommandSymbolType.FromGlobalOption)]
        public System.IO.FileInfo? OptionLevel2C { get; }

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

    partial class Level3CommandBuilder
    {
        protected string Description { get; }

        internal global::System.CommandLine.Option<int?> OptionLevel3AOption { get; }

        internal global::System.CommandLine.Option<string?> OptionLevel3BOption { get; }

        internal global::System.CommandLine.Option<System.IO.FileInfo?> OptionLevel3COption { get; }

        private global::System.CommandLine.Option<int> OptionLevel3DOption { get; }

        protected override global::System.CommandLine.Command BuildCliCommandCore()
        {
            string name = this.GetCliCommandBuilderAttribute().Name;
            global::System.CommandLine.Command cliCommand = this.CreateCliCommand(name, this.Description);
            this.OptionLevel3AOption.Recursive = true;
            cliCommand.Add(this.OptionLevel3AOption);
            this.OptionLevel3BOption.Recursive = true;
            cliCommand.Add(this.OptionLevel3BOption);
            this.OptionLevel3COption.Recursive = true;
            cliCommand.Add(this.OptionLevel3COption);
            cliCommand.Add(this.OptionLevel3DOption);
            cliCommand.SetAction(async (global::System.CommandLine.ParseResult parseResult, global::System.Threading.CancellationToken cancellationToken) =>
            {
                global::MyNamespace.Level3CommandOptions options = new global::MyNamespace.Level3CommandOptions(OptionLevel2A: parseResult.GetValue(this.GetRequiredParentBuilder<global::MyNamespace.Level2CommandBuilder>().OptionLevel2AOption), OptionLevel2B: parseResult.GetValue(this.GetRequiredParentBuilder<global::MyNamespace.Level2CommandBuilder>().OptionLevel2BOption), OptionLevel2C: parseResult.GetValue(this.GetRequiredParentBuilder<global::MyNamespace.Level2CommandBuilder>().OptionLevel2COption), OptionLevel1A: parseResult.GetValue(this.GetRequiredParentBuilder<global::MyNamespace.Level1CommandBuilder>().OptionLevel1AOption), OptionLevel1B: parseResult.GetValue(this.GetRequiredParentBuilder<global::MyNamespace.Level1CommandBuilder>().OptionLevel1BOption), OptionLevel1C: parseResult.GetValue(this.GetRequiredParentBuilder<global::MyNamespace.Level1CommandBuilder>().OptionLevel1COption), OptionLevel3A: parseResult.GetValue(this.OptionLevel3AOption), OptionLevel3B: parseResult.GetValue(this.OptionLevel3BOption), OptionLevel3C: parseResult.GetValue(this.OptionLevel3COption), OptionLevel3D: parseResult.GetValue(this.OptionLevel3DOption));
                await using (global::Microsoft.Extensions.DependencyInjection.AsyncServiceScope scope = this.ServiceProvider.CreateAsyncScope())
                {
                    global::Basalt.CommandLine.CommandContext context = scope.ServiceProvider.GetRequiredService<global::Basalt.CommandLine.CommandContext>();
                    context.ParseResult = parseResult;
                    context.CancellationToken = cancellationToken;
                    context.Options = options;
                    global::MyNamespace.Level3Command command = scope.ServiceProvider.GetRequiredService<global::MyNamespace.Level3Command>();
                    await command.ExecuteAsync().ConfigureAwait(false);
                }
            });
            this.OnCommandLineBuilt(cliCommand);
            return cliCommand;
        }

        partial void OnCommandLineBuilt(Command command);
    }
}