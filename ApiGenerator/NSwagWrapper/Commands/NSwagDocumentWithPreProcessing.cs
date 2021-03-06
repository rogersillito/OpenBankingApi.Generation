﻿using System;
using System.Collections.Generic;
using NSwag.Commands;
using System.Linq;
using System.Threading.Tasks;
using ApiGenerator.NSwagWrapper.Commands.CodeGeneration;
using NConsole;
using NSwag.AssemblyLoader;
using NSwag.Commands.CodeGeneration;
using NSwag.Commands.SwaggerGeneration;
using NSwag.Commands.SwaggerGeneration.AspNetCore;
using NSwag.Commands.SwaggerGeneration.WebApi;

namespace ApiGenerator.NSwagWrapper.Commands
{
    public class NSwagDocumentWithPreProcessing: NSwagDocument
    { 
        public NSwagDocumentWithPreProcessing()
        {
            CodeGenerators.SwaggerToCSharpClientCommand = new PreProcessedSwaggerToCSharpClientCommand();
            CodeGenerators.SwaggerToCSharpControllerCommand = new PreProcessedSwaggerToCSharpControllerCommand();
        }
 
        /// <summary>Loads an existing NSwagDocument with environment variable expansions and variables.</summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="variables">The variables.</param>
        /// <returns>The document.</returns>
        public new static async Task<NSwagDocumentWithPreProcessing> LoadWithTransformationsAsync(string filePath, string variables)
        {
            return await LoadAsync<NSwagDocumentWithPreProcessing>(filePath, variables, true, new Dictionary<Type, Type>
            {
                { typeof(AspNetCoreToSwaggerCommand), typeof(AspNetCoreToSwaggerCommand) },
                { typeof(WebApiToSwaggerCommand), typeof(WebApiToSwaggerCommand) },
                { typeof(TypesToSwaggerCommand), typeof(TypesToSwaggerCommand) }
            });
        }

        public override async Task<SwaggerDocumentExecutionResult> ExecuteAsync()
        {
            var document = await GenerateSwaggerDocumentAsync();
            foreach (var codeGenerator in CodeGenerators.Items.Where(c => !string.IsNullOrEmpty(c.OutputFilePath)))
            {
                codeGenerator.Input = document;
                TryInitializeTypeNameGenerators(codeGenerator);
                await codeGenerator.RunAsync(null, null);
                codeGenerator.Input = null;
            }

            return new SwaggerDocumentExecutionResult(null, null, true);
        }

        private void TryInitializeTypeNameGenerators(IConsoleCommand codeGenerator)
        {
            if (codeGenerator is SwaggerToCSharpControllerCommand controllerCommand)
            {
                controllerCommand?.InitializeCustomTypes(new AssemblyLoader());
            }
            if (codeGenerator is SwaggerToCSharpClientCommand clientCommand)
            {
                clientCommand?.InitializeCustomTypes(new AssemblyLoader());
            }
        }
    }
}