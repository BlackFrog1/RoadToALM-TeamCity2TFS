using CommandLine;
using CommandLine.Text;

namespace RoadToALM.Build.StartTFSBuild.v12
{
    public class Options
    {
            [Option('n', "name-build", Required = true, HelpText = "Sets the new name of the build (e.g. Team City Build Number)")]
            public string NameBuild { get; set; }

            [Option('c', "teamprojectcollection-url", Required = true, HelpText = "Sets the url of the team project collection where the build definition resides")]
            public string TeamProjectCollectionUrl { get; set; }

            [Option('p', "teamproject", Required = true, HelpText = "Sets the name of the Team Project")]
            public string TeamProjectName { get; set; }

            [Option('b', "build-definition", Required = true, HelpText = "Sets the name of the Build Definition")]
            public string BuildDefinition { get; set; }

            [Option('d', "drop-location", Required = true, HelpText = "Sets the location of the drop")]
            public string DropLocation { get; set; }


            [HelpOption]
            public string GetUsage()
            {
                return HelpText.AutoBuild(this,
                  (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
            }


    }
}
