using System;
using System.Collections.Generic;
using System.Activities.Expressions;
using Microsoft.TeamFoundation.Build.Client;
using Microsoft.TeamFoundation.Build.Workflow;
using Microsoft.TeamFoundation.Client;

namespace RoadToALM.Build.StartTFSBuild.v12
{
  
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var options = new Options();

                if (CommandLine.Parser.Default.ParseArgumentsStrict(args, options))
                {
                    TfsTeamProjectCollection collection = new TfsTeamProjectCollection(new Uri(options.TeamProjectCollectionUrl));

                    //Call Build
                    IBuildServer buildServer = collection.GetService<IBuildServer>();

                    IBuildDefinition definition = buildServer.GetBuildDefinition(options.TeamProjectName,
                                                                                 options.BuildDefinition);

                    
                    IBuildRequest request = definition.CreateBuildRequest();
                    request.ProcessParameters = UpdateVersion(request.ProcessParameters, options);
                    request.DropLocation = options.DropLocation;
                    


                    buildServer.QueueBuild(request);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in calling TFS Build: " + ex.Message);
            }


        }


        private static string UpdateVersion(string processParameters, Options o)
        {
            IDictionary<String, Object> paramValues = WorkflowHelpers.DeserializeProcessParameters(processParameters);
            paramValues[Constants.PARAMETER_BUILD_NAME] = o.NameBuild;
            paramValues[Constants.PARAMETER_DROP_LOCATION] = o.DropLocation;

            return WorkflowHelpers.SerializeProcessParameters(paramValues);


        }

    }
}
