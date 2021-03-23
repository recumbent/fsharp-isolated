namespace fsharp_isolated

open System.Threading.Tasks;
open Microsoft.Extensions.Configuration;
open Microsoft.Extensions.Hosting;
open Microsoft.Azure.Functions.Worker.Configuration;

module Program =
    [<EntryPoint>]
    let main _ =
        let hostBuilder = new HostBuilder()
        hostBuilder.ConfigureFunctionsWorkerDefaults() |> ignore

        let host = hostBuilder.Build()
        host.Run()

        0
