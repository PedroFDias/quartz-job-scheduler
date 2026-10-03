using OSIsoft.AF;
using OSIsoft.AF.Asset;
using OSIsoft.AF.EventFrame;
using Quartz;

namespace SAPIntegration.Job
{
    public class AddNotaOnPiJob : IJob
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AddNotaOnPiJob(
            HttpClient httpClient,
            IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async ValueTask Execute(
            IJobExecutionContext context,
            CancellationToken cancellationToken = default)
        {
            var piSystem = PISystem.CreatePISystem("srvvm75-01");
            piSystem.Connect();

            var database = piSystem.Databases[
                "LWA-13926 - Integra??o com SAP_Old"
            ];

            var template = database.ElementTemplates["EFT_NOTA_PM"];

            var eventFrame = new AFEventFrame(
                database,
                "EF_TESTE_AUTH",
                template
            );

            eventFrame.Description = "Teste";

            var path = eventFrame.Persist();
            if (database.IsDirty)
            {
                database.CheckIn();
            }


            Console.WriteLine(path);
        }
    //    private void ListarElementos(AFElements elements, int nivel = 0)
    //    {
    //        foreach (var element in elements)
    //        {
    //            Console.WriteLine(
    //                $"{new string(' ', nivel * 2)}- {element.Name}"
    //            );

    //            ListarElementos(element.Elements, nivel + 1);
    //        }
    //    }
    //    private void BuscarElementosPorTemplate(
    //AFElements elements,
    //AFElementTemplate template)
    //    {
    //        foreach (var element in elements)
    //        {
    //            if (element.Template == template)
    //            {
    //                Console.WriteLine(
    //                    $"Elemento: {element.Name} | Template: {element.Template.Name}"
    //                );
    //            }

    //            BuscarElementosPorTemplate(element.Elements, template);
    //        }
    //    }
    }
}
