namespace MyNamespace
{
    partial class Level1CommandOptions
    {
        public Level1CommandOptions(int? OptionLevel1A, string? OptionLevel1B, System.IO.FileInfo? OptionLevel1C, int OptionLevel1D)
        {
            this.OptionLevel1A = OptionLevel1A;
            this.OptionLevel1B = OptionLevel1B;
            this.OptionLevel1C = OptionLevel1C;
            this.OptionLevel1D = OptionLevel1D;
        }
    }
}

namespace MyNamespace
{
    using System.CommandLine;
    using Microsoft.Extensions.DependencyInjection;

    partial class Level1CommandBuilder
    {
        protected string Description { get; }

        internal global::System.CommandLine.Option<int?> OptionLevel1AOption { get; }

        internal global::System.CommandLine.Option<string?> OptionLevel1BOption { get; }

        internal global::System.CommandLine.Option<System.IO.FileInfo?> OptionLevel1COption { get; }

        private global::System.CommandLine.Option<int> OptionLevel1DOption { get; }

        protected override global::System.CommandLine.Command BuildCliCommandCore()
        {
            string name = this.GetCliCommandBuilderAttribute().Name;
            global::System.CommandLine.Command cliCommand = this.CreateCliCommand(name, this.Description);
            this.OptionLevel1AOption.Recursive = true;
            cliCommand.Add(this.OptionLevel1AOption);
            this.OptionLevel1BOption.Recursive = true;
            cliCommand.Add(this.OptionLevel1BOption);
            this.OptionLevel1COption.Recursive = true;
            cliCommand.Add(this.OptionLevel1COption);
            cliCommand.Add(this.OptionLevel1DOption);
            cliCommand.SetAction(async (global::System.CommandLine.ParseResult parseResult, global::System.Threading.CancellationToken cancellationToken) =>
            {
                global::MyNamespace.Level1CommandOptions options = new global::MyNamespace.Level1CommandOptions(OptionLevel1A: parseResult.GetValue(this.OptionLevel1AOption), OptionLevel1B: parseResult.GetValue(this.OptionLevel1BOption), OptionLevel1C: parseResult.GetValue(this.OptionLevel1COption), OptionLevel1D: parseResult.GetValue(this.OptionLevel1DOption));
                await using (global::Microsoft.Extensions.DependencyInjection.AsyncServiceScope scope = this.ServiceProvider.CreateAsyncScope())
                {
                    global::Basalt.CommandLine.CommandContext context = scope.ServiceProvider.GetRequiredService<global::Basalt.CommandLine.CommandContext>();
                    context.ParseResult = parseResult;
                    context.CancellationToken = cancellationToken;
                    context.Options = options;
                    global::MyNamespace.Level1Command command = scope.ServiceProvider.GetRequiredService<global::MyNamespace.Level1Command>();
                    await command.ExecuteAsync().ConfigureAwait(false);
                }
            });
            this.OnCommandLineBuilt(cliCommand);
            return cliCommand;
        }

        partial void OnCommandLineBuilt(Command command);
    }
}