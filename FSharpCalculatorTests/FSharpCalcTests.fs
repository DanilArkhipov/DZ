module Tests

open System
open Xunit
open FSharpCalc

[<Fact>]
let ``SumTest_4.0 + 7.0_Some(11.0) expected`` () =
    let res = sum 4.0 7.0
    Assert.Equal(Some(11.0),res)
[<Fact>]
let ``SubTest_4.0 - 7.0_Some(-3.0) expected`` () =
    let res = sub 4.0 7.0
    Assert.Equal(Some(-3.0),res)
[<Fact>]
let ``MultTest_4.0 * 7.0_Some(28.0) expected`` () =
    let res = mult 4.0 7.0
    Assert.Equal(Some(28.0),res)
[<Fact>]    
let ``DivTest_4.0 / 8.0_Some(0.5) expected`` () =
    let res = div 4.0 8.0
    Assert.Equal(Some(0.5),res)
[<Fact>]    
let ``DivTest_4.0 / 0_None expected`` () =
    let res = div 4.0 0.0
    Assert.Equal(None,res)
[<Fact>]
let ``getOperationTest_+_Some(Sum) expected`` () =
    let res = getOperation "+"
    Assert.Equal(Some(Sum),res)
[<Fact>]
let ``getOperationTest_-_Some(Sub) expected`` () =
    let res = getOperation "-"
    Assert.Equal(Some(Sub),res)
[<Fact>]
let ``getOperationTest_*_Some(Mult) expected`` () =
    let res = getOperation "*"
    Assert.Equal(Some(Mult),res)
[<Fact>]
let ``getOperationTest_/_Some(Div) expected`` () =
    let res = getOperation "/"
    Assert.Equal(Some(Div),res)
[<Fact>]
let ``getOperationTest_NotSupportedOperation_None expected`` () =
    let res = getOperation "^"
    Assert.Equal(None,res)
[<Fact>]
let ``getNumTest_correctInput_Some(DoubleParsedInput) expected``() =
    let res = getNum "3,14"
    Assert.Equal(Some(3.14),res)
[<Fact>]
let ``getNumTest_InCorrectInput_None expected`` () =
    let res = getNum "3.14asdfsdfdf"
    Assert.Equal(None,res)
[<Fact>]
let ``showValueTest_correctInput_CorrectWork expected`` () =
    try showValue (Some(7.0))
    with
    | _ -> Assert.True(false)
    Assert.True(true)
    
[<Fact>]
let ``showValueTest_NoneInput_CorrectWork expected`` () =
    try showValue (None)
    with
    | _ -> Assert.True(false)
    Assert.True(true)
[<Fact>]
let ``calculateTest_3.0 + 4.0_Some(Some(7.0)) expected`` () =
    let res = calculate 3.0 Sum 4.0
    Assert.Equal(Some(Some(7.0)), res)
[<Fact>]
let ``calculateTest_3.0 - 4.0_Some(Some(-1.0)) expected`` () =
    let res = calculate 3.0 Sub 4.0
    Assert.Equal(Some(Some(-1.0)), res)
[<Fact>]
let ``calculateTest_3.0 * 4.0_Some(Some(12.0)) expected`` () =
    let res = calculate 3.0 Mult 4.0
    Assert.Equal(Some(Some(12.0)), res)  
[<Fact>]
let ``calculateTest_4.0 / 2.0_Some(Some(2.0)) expected`` () =
    let res = calculate 4.0 Div 2.0
    Assert.Equal(Some(Some(2.0)), res)
[<Fact>]
let ``activateTest_2.0 + 7.0_Some(9.0) expected`` () =
    let res = activate "2,0" "+" "7"
    Assert.Equal(Some(9.0),res)
[<Fact>]
let ``activateTest_incorrectInput + 7.0_None expected`` () =
    let res = activate "asdfsdff" "+" "7"
    Assert.Equal(None,res)