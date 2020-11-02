// Learn more about F# at http://fsharp.org


open System.IO
open System.Net.Http
open System.Net.Http.Headers
open System.Threading.Tasks

module ProxyCalc =      
open System
open System.Text.Json
open System.Text.Json.Serialization
open System.Net
open CalculatorSeriallization
type AsyncMaybeBuilder() =
    member this.Bind(x, f) =
        async {
            let! x' = x

            match x' with
            | Some v -> return! f v
            | None -> return None
        }

    member this.Return x = async { return x }

let asyncMaybe = AsyncMaybeBuilder()
let createJsonString a op b =
    let requestData = new InputData(a,op,b)
    let dataStr = JsonSerializer.Serialize<InputData>(requestData)
    dataStr
   
let sendRequestToRemoteCalc (str:string)=
        async{
        use httpClient = new HttpClient()
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"))
        let content = new StringContent(str)
        use! resp = httpClient.PostAsync("https://localhost:5001",content) |> Async.AwaitTask
        return match resp.IsSuccessStatusCode with
        | true -> Some(resp.Content.ReadAsStringAsync().Result)
        | false-> None
        }
let calculateAsync a op b =
    let jsonStr = createJsonString a op b
    let response = sendRequestToRemoteCalc jsonStr
    response

let activate =
    fun (calculate:string -> string -> string -> Async<string option>) a op b ->
    Async.RunSynchronously(
    asyncMaybe{
    let! response = calculate a op b
    return Some(response)
    })
let showRes res=
     match res with
     | Some v -> Console.WriteLine(res)
     | None -> Console.WriteLine("Ошибка")
module ProxyRunner = 
[<EntryPoint>]
let main argv =
let a = Console.ReadLine()
let op = Console.ReadLine()
let b = Console.ReadLine()
let res = activate calculateAsync a op b
showRes res
0 // return an integer exit code
