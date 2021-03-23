
# Functions using dotNET 5.0

Simplest possible test of using F#

Following the CLI instructions from [Develop and publish .NET 5 functions using Azure Functions](https://docs.microsoft.com/en-us/azure/azure-functions/dotnet-isolated-process-developer-howtos?pivots=development-environment-cli&tabs=browser)

Create the C# templated project

```
func init fsharp-isolated --worker-runtime dotnetisolated
```

Which creates the following:

```
d----          23/03/2021    09:18                .vscode
-a---          23/03/2021    09:17           4626 .gitignore
-a---          23/03/2021    09:17            938 fsharp-isolated.csproj
-a---          23/03/2021    09:17            227 host.json
-a---          23/03/2021    09:17            172 local.settings.json
-a---          23/03/2021    09:17            445 Program.cs
```

In that folder, add a function

```
func new --name HttpExample --template "HTTP trigger" --authlevel "anonymous"
```

Rename the .cs files to .fs, and the .csproj to .fsproj

Add the fsharp source to the .fsproj so it compiles:

```
  <ItemGroup>
    <Compile Include="HttpExample.fs" />
    <Compile Include="Program.fs" />
  </ItemGroup>
```

Rewrite the C# as F# - per the source code

That builds... so the next step is to try running it as a func

So from the folder that has the function project in:

```
func start
```

The output from which is as follows (and is more or less identical to what one would get from the C# variant apart from the bit where no functions are found)

```
❯ func start
Microsoft (R) Build Engine version 16.9.0+57a23d249 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
  Restored C:\Users\James Murphy\source\repos\fsharp-isolated\fsharp-isolated.fsproj (in 248 ms).
  fsharp-isolated -> C:\Users\James Murphy\source\repos\fsharp-isolated\bin\output\fsharp-isolated.dll
  Determining projects to restore...
  Restored C:\Users\James Murphy\AppData\Local\Temp\x54k1jh3.xsu\WorkerExtensions.csproj (in 401 ms).
  WorkerExtensions -> C:\Users\James Murphy\AppData\Local\Temp\x54k1jh3.xsu\buildout\Microsoft.Azure.Functions.Worker.Extensions.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:05.02



Azure Functions Core Tools
Core Tools Version:       3.0.3388 Commit hash: fb42a4e0b7fdc85fbd0bcfc8d743ff7d509122ae
Function Runtime Version: 3.0.15371.0

[2021-03-23T09:53:46.162Z] No job functions found. Try making your job classes and methods public. If you're using binding extensions (e.g. Azure Storage, ServiceBus, Timers, etc.) make sure you've called the registration method for the extension(s) in your startup code (e.g. builder.AddAzureStorage(), builder.AddServiceBus(), builder.AddTimers(), etc.).
For detailed output, run func with --verbose flag.
[2021-03-23T09:53:51.196Z] Host lock lease acquired by instance ID '000000000000000000000000BD321FD0'.
```

For reference here is the C# version:

```
❯ func start
Microsoft (R) Build Engine version 16.9.0+57a23d249 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
  Restored C:\Users\James Murphy\source\repos\LocalFunctionProjectC\LocalFunctionProjectC.csproj (in 279 ms).
  LocalFunctionProjectC -> C:\Users\James Murphy\source\repos\LocalFunctionProjectC\bin\output\LocalFunctionProjectC.dll
  Determining projects to restore...
  Restored C:\Users\James Murphy\AppData\Local\Temp\eji33tva.yz1\WorkerExtensions.csproj (in 402 ms).
  WorkerExtensions -> C:\Users\James Murphy\AppData\Local\Temp\eji33tva.yz1\buildout\Microsoft.Azure.Functions.Worker.Extensions.dll

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:03.66



Azure Functions Core Tools
Core Tools Version:       3.0.3388 Commit hash: fb42a4e0b7fdc85fbd0bcfc8d743ff7d509122ae
Function Runtime Version: 3.0.15371.0


Functions:

        HttpExample: [GET,POST] http://localhost:7071/api/HttpExample

For detailed output, run func with --verbose flag.
[2021-03-23T09:56:46.167Z] Worker process started and initialized.
```
