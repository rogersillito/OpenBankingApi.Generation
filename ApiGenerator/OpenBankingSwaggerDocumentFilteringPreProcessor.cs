using System.Collections.Generic;
using System.Linq;
using ApiGenerator.NSwagWrapper.Commands;
using ApiGenerator.NSwagWrapper.Commands.CodeGeneration;
using NSwag;

namespace ApiGenerator
{
    public class OpenBankingSwaggerDocumentFilteringPreProcessor : IProcessSwaggerDocuments
    {
        public static void ApplyToCommands()
        {
            var docPreProcessor = new OpenBankingSwaggerDocumentFilteringPreProcessor();
            PreProcessedSwaggerToCSharpControllerCommand.SetDocumentPreProcessor(docPreProcessor);
            PreProcessedSwaggerToCSharpClientCommand.SetDocumentPreProcessor(docPreProcessor);
        }

        public void ApplyProcessing(SwaggerDocument document)
        {
            var requiredPathItemKeys = new List<string>
            {
                "/accounts",
                "/accounts/{AccountId}",
                "/accounts/{AccountId}/balances",
                "/balances",
                "/accounts/{AccountId}/transactions",
                "/accounts/{AccountId}/product",
                "/products"
            };

            var pathItemKeys = document.Paths.Keys.OrderBy(k => k).ToList();
            for (var i = pathItemKeys.Count - 1; i >= 0; i--)
            {
                var pathKey = pathItemKeys[i];
                if (!requiredPathItemKeys.Contains(pathKey))
                {
                    document.Paths.Remove(pathKey);
                }
            }
        }
    }
}