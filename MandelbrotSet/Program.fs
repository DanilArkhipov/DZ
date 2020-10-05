// Learn more about F# at http://fsharp.org

open System.Drawing
open System.Windows.Forms
open Microsoft.FSharp.Math
open System
let rec isInMandelbrotSet (c:complex) (z: complex) (maxIter:int) (count:int) =
    if (Complex.Abs z)<2.0 && count < maxIter then
        isInMandelbrotSet c ((Complex.mul z z)+c) maxIter (count+1)
    else
        count
        
let colorize c =
    let r = (4 * c) % 255
    let g = (6 * c) % 255
    let b = (8 * c) % 255
    Color.FromArgb(r,g,b) 
let createImage ((_size:float), iter) =
    let image = new Bitmap(400, 400)
    for x = 0 to image.Width - 1 do
        for y = 0 to image.Height - 1 do
            let c = complex ((float x)*_size) ((float y)*_size)
            let count = isInMandelbrotSet c Complex.Zero iter 0
            if count = iter then
                image.SetPixel(x,y, Color.Black)
            else
                image.SetPixel(x,y, colorize( count ) )
    image
let mutable k = 0.1
let form = new Form()
form.Paint.Add(fun e->e.Graphics.DrawImage(createImage(k,100),0,0))
async{
while true do
    do! Async.Sleep(1000)
    form.Invalidate()
    k<-k*0.9
    Console.Write("{0} ",k)
    }|>Async.StartImmediate
do Application.Run(form)    


