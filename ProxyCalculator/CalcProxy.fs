// Learn more about F# at http://fsharp.org


open System.IO

module ProxyCalc =      
open System
open System.Text.Json
open System.Text.Json.Serialization
open System.Net
open CalculatorSeriallization

let createJsonString a op b =
    let requestJson = new InputData(a,op,b)
    let str = JsonSerializer.Serialize<InputData>(requestJson)
    str
   
let sendRequest (str:string)=
    let req = WebRequest.Create("https://localhost:5001")
    req.Method <- "POST"
    req.ContentType <- "application/json"
    let byte = System.Text.Encoding.UTF8.GetBytes(str)
    req.ContentLength <- byte.LongLength
    req.GetRequestStream().Write(byte,0,byte.Length)
    let resp = req.GetResponse()
    let sr = new StreamReader(resp.GetResponseStream())
    sr.ReadToEnd()
    
    
    
let activate a op b =
    let jsonStr = createJsonString a op b
    let response  = sendRequest jsonStr
    Console.WriteLine(response)
module ProxyRunner = 
[<EntryPoint>]
let main argv =
let a = Console.ReadLine()
let op = Console.ReadLine()
let b = Console.ReadLine()
activate a op b
0 // return an integer exit code
