namespace fsharp_isolated

open System.Collections.Generic;
open System.Net;
open Microsoft.Azure.Functions.Worker;
open Microsoft.Azure.Functions.Worker.Http;
open Microsoft.Extensions.Logging;

module HttpExample =

   [<Function("HttpExample")>]
   let Run ([<HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")>] req : HttpRequestData , executionContext : FunctionContext ) : HttpResponseData =
        let logger = executionContext.GetLogger("HttpExample")
        logger.LogInformation("F# HTTP trigger function processed a request.")

        let response = req.CreateResponse(HttpStatusCode.OK)
        response.Headers.Add("Content-Type", "text/plain; charset=utf-8")

        response.WriteString("Welcome to Azure Functions!")

        response
