namespace server.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open server

[<ApiController>]
[<Route("[controller]")>]
type PrimeController (logger : ILogger<PrimeController>) =
    inherit ControllerBase()

    let isPrime n =
        match n with 
        | n when n < 2 -> false
        | 2 -> true
        | n -> 
            2::[3..2..int (sqrt(float n))]
            |> List.toSeq
            |> Seq.exists (fun c -> n % c = 0)
            |> not

    [<HttpGet("{candidate}")>]
    member _.Get(candidate:int ) =
        let res = isPrime candidate
        sprintf "%i is prime: %A" candidate res
        |> logger.LogInformation
        res