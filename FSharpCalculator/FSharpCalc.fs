// Learn more about F# at http://fsharp.org
open System
open System
open System.ComponentModel
open System.Diagnostics

let div a b =
    match b with
    | 0.0 -> None
    | _ -> Some(a/b)
let sum a b =
    Some(a + b)
let sub a b =
    Some(a - b)
let mult a b =
    Some(a*b)
type operation = Sum | Sub |Div |Mult
let getOperation input =
    match input with
    | "+" -> Some(Sum)
    | "-" -> Some(Sub)
    | "*" -> Some(Mult)
    | "/" -> Some(Div)
    | _ -> None
let getNum (input:string) =
    let f,res = Double.TryParse(input)
    match f with
    | false -> None
    | true -> Some(res)
let showValue x = 
    match x with
    |None->Console.Write("Something was wrong!")
    |Some v -> Console.Write(v.ToString())
let calculate a op b =
    match op with
    | operation.Mult -> Some(mult a b)
    | operation.Div -> Some(div a b)
    | operation.Sub -> Some(sub a b)
    | operation.Sum -> Some(sum a b)
    | _ -> None
type MaybeBuilder() =

    member this.Bind(x, f) = 
        match x with
        | None -> None
        | Some a -> f a

    member this.Return(x) = 
        Some x
   
let maybe = new MaybeBuilder()
[<EntryPoint>]
let main argv =
    maybe{
        let! a = getNum (Console.ReadLine())
        let! b = getOperation (Console.ReadLine())
        let! c = getNum (Console.ReadLine())
        let! res = calculate a b c
        showValue res
        return res
    } |> ignore
    0 // return an integer exit code

