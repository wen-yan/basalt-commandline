using System;
using System.Threading.Tasks;
using Basalt.CommandLine;
using Basalt.CommandLine.Annotations;

namespace MyNamespace
{
    [CliCommandBuilder("fs", null)]
    partial class FsCommandBuilder : CliCommandBuilder
    {
        public FsCommandBuilder(IServiceProvider serviceProvider) : base(serviceProvider) {}
    }
}