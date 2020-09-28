// Learn more about F# at http://fsharp.org
open System
let sum a b = a + b;
let sub a b = a-b;
let div a b  = a/b;
    
let mult  a b = a * b;

let calculate firstNumber operation secondNumber =
    match operation with
    | "+" -> sum firstNumber secondNumber
    | "-" -> sub firstNumber secondNumber
    | "*" -> mult firstNumber secondNumber
    | "/" -> div firstNumber secondNumber
    | _ -> raise (SystemException "Invalid input")
    
let getDouble input =
    double input
    
[<EntryPoint>]
let main argv =
    let firstNumber = getDouble (Console.ReadLine())
    let operation = Console.ReadLine()
    let secondNumber = getDouble (Console.ReadLine())
    calculate firstNumber operation secondNumber |> Console.WriteLine
    0 // return an integer exit code

