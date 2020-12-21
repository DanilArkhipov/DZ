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
            | Some v -> return (v)
            | None -> return "Ошибка"
        }

    member this.Return x = x

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
        let! resp = 
                async{
                    use! res = (httpClient.PostAsync("https://localhost:5001",content) |> Async.AwaitTask)
                    let! responseMessage =res.Content.ReadAsStringAsync()|>Async.AwaitTask
                    return responseMessage
                }|>Async.Catch

        match resp with
        | Choice1Of2 r -> return Some(r)
        | Choice2Of2 exn -> return None
        }
        
let calculateAsync a op b =
    async{
    let jsonStr = createJsonString a op b
    let! response = sendRequestToRemoteCalc jsonStr
    return response
    }

let activate =
    fun (calculate:string -> string -> string -> Async<string option>) a op b ->
    asyncMaybe{
    let! response = calculate a op b
    return response
    }
module ProxyRunner = 
[<EntryPoint>]
let main argv =
async{
let a = Console.ReadLine()
let op = Console.ReadLine()
let b = Console.ReadLine()
let! res = activate calculateAsync a op b
Console.WriteLine(res)
}|>Async.RunSynchronously
0
