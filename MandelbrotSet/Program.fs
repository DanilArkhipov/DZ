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
let scalingFactor s = s * 10.0 / 200.0

let getCoords (x, y, s, mx, my) =
    let fx = ((float x) * scalingFactor s) + mx
    let fy = ((float y) * scalingFactor s) + my
    complex fx fy
let createImage (size, mx, my, iter) =
    let image = new Bitmap(400, 400)
    for x = 0 to image.Width - 1 do
        for y = 0 to image.Height - 1 do
            let c = getCoords (x,y,size,mx,my)
            let count = isInMandelbrotSet c Complex.Zero iter 0
            if count = iter then
                image.SetPixel(x,y, Color.Black)
            else
                image.SetPixel(x,y, colorize( count ) )
    image

let form  = new Form()
form.Paint.Add(fun e -> e.Graphics.DrawImage(createImage(1.0,-0.7,0.28,100), 0, 0))
form.Size <- new Size(400,400)
for i in 1.0..30.0 do
    form.Paint.Add(fun e -> e.Graphics.DrawImage(createImage(1.0/(i*2.2),-0.7,0.28,int i*3), 0, 0))


do Application.Run(form)

