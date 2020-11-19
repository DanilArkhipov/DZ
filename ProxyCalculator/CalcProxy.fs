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
            | Some v -> return! (f v)
            | None -> return "Ошибка"
        }

    member this.Return x = x

let asyncMaybe = AsyncMaybeBuilder()
let createJsonString a op b =
    let requestData = new InputData(a,op,b)
    let dataStr = JsonSerializer.Serialize<InputData>(requestData)
    dataStr

let calcuateAsync (str)=
        async{
        use httpClient = new HttpClient()
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"))
        let content = new StringContent(str)
        let! resp = 
            try 
                async{
                    use! res = (httpClient.PostAsync("https://localhost:5001",content) |> Async.AwaitTask)
                    return! async{return Some(res.Content.ReadAsStringAsync()|>Async.AwaitTask)}
                }

            with
                | AggregateException -> async{ return None}
        return resp
        }


let activate a op b =
    asyncMaybe{
    let jsonStr = createJsonString a op b
    let! response  = calcuateAsync jsonStr
    return response
    }
let convertOptionToString res=
     match res with
     | Some v -> v
     | None -> "Ошибка"
module ProxyRunner = 
[<EntryPoint>]
let main argv =
try
Async.RunSynchronously(
async{
let a = Console.ReadLine()
let op = Console.ReadLine()
let b = Console.ReadLine()
let! res = activate a op b
Console.WriteLine(res)})
with
|AggregateException -> Console.WriteLine("Сервер не отвечает!!!")
0 // return an integer exit code
