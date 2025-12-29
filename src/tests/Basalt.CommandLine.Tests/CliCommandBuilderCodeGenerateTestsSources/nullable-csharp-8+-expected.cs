namespace MyNamespace
{
    partial class FsCommandOptions
    {
        public FsCommandOptions(int? Option1, string? Option2, System.IO.FileInfo? Option3)
        {
            this.Option1 = Option1;
            this.Option2 = Option2;
            this.Option3 = Option3;
        }
    }
}

namespace MyNamespace
{
    using System.CommandLine;
    using Microsoft.Extensions.DependencyInjection;

    partial class FsCommandBuilder
    {
        protected string Description { get; }

        private global::System.CommandLine.Option<int?> Option1Option { get; }

        private global::System.CommandLine.Option<string?> Option2Option { get; }

        private global::System.CommandLine.Option<System.IO.FileInfo?> Option3Option { get; }

        protected override global::System.CommandLine.Command BuildCliCommandCore()
        {
            string name = this.GetCliCommandBuilderAttribute().Name;
            global::System.CommandLine.Command cliCommand = this.CreateCliCommand(name, this.Description);
            cliCommand.Add(this.Option1Option);
            cliCommand.Add(this.Option2Option);
            cliCommand.Add(this.Option3Option);
            cliCommand.SetAction(async (global::System.CommandLine.ParseResult parseResult, global::System.Threading.CancellationToken cancellationToken) =>
            {
                global::MyNamespace.FsCommandOptions options = new global::MyNamespace.FsCommandOptions(Option1: parseResult.GetValue(this.Option1Option), Option2: parseResult.GetValue(this.Option2Option), Option3: parseResult.GetValue(this.Option3Option));
                await using (global::Microsoft.Extensions.DependencyInjection.AsyncServiceScope scope = this.ServiceProvider.CreateAsyncScope())
                {
                    global::Basalt.CommandLine.CommandContext context = scope.ServiceProvider.GetRequiredService<global::Basalt.CommandLine.CommandContext>();
                    context.ParseResult = parseResult;
                    context.CancellationToken = cancellationToken;
                    context.Options = options;
                    global::MyNamespace.FsCommand command = scope.ServiceProvider.GetRequiredService<global::MyNamespace.FsCommand>();
                    await command.ExecuteAsync().ConfigureAwait(false);
                }
            });
            this.OnCommandLineBuilt(cliCommand);
            return cliCommand;
        }

        partial void OnCommandLineBuilt(Command command);
    }
}