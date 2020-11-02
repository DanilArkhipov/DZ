// Learn more about F# at http://fsharp.org
open System
open System
open System.ComponentModel
open System.Diagnostics
module Calculator =
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
    let returnStringValue x = 
        match x with
        |None->"Something was wrong!"
        |Some v ->v.ToString()
    let calculate a op b =
        match op with
        | operation.Mult -> Some(mult a b)
        | operation.Div -> Some(div a b)
        | operation.Sub -> Some(sub a b)
        | operation.Sum -> Some(sum a b)
    type MaybeBuilder() =

        member this.Bind(x, f) = 
            match x with
            | None -> None
            | Some a -> f a

        member this.Return(x) = 
            x
   
    let maybe = new MaybeBuilder()
    let activate _a _b _c= 
        maybe{
            let! a = getNum(_a)
            let! b = getOperation(_b)
            let! c = getNum(_c)
            let! res = calculate a b c
            return res
        }
module Runner = 
    [<EntryPoint>]
    let main argv =
        let a = Console.ReadLine()
        let b = Console.ReadLine()
        let c = Console.ReadLine()
        let res = Calculator.activate a b c
        Console.WriteLine(Calculator.returnStringValue res)
        0 // return an integer exit code

