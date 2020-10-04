// Learn more about F# at http://fsharp.org

open System.Drawing
open System.Windows.Forms
open Microsoft.FSharp.Math
open System
let _maxIter = 20
type Visualisation () = 
    inherit Form ()

let rec isInMandelbrotSet (c:complex) (z: complex) (maxIter:int) (count:int) =
    if (Complex.Abs z)<2.0 && count < maxIter then
        let _z = complex (z.r*z.r-z.i*z.i) (2.0*z.r*z.i)
        isInMandelbrotSet c (_z+c) maxIter (count+1)
    else
        count
        
let colorize c =
    let r = (4 * c) % 255
    let g = (6 * c) % 255
    let b = (8 * c) % 255
    Color.FromArgb(r,g,b)
    
let createImage (iter) =
    let image = new Bitmap(400, 400)
    for x = 0 to image.Width-1 do
        let xCenterCoord = x-((image.Width-1)/2)
        for y = 0 to image.Height-1 do
            let yCenterCoord = y-((image.Height-1)/2)
            if double(xCenterCoord)**2.0+double(yCenterCoord)**2.0<=200.0**2.0 then
                let c = complex (float x) (float y)
                let z = complex 0.0 0.0
                let count = isInMandelbrotSet c z iter 0
                if count = iter then
                    image.SetPixel(x,y, Color.Black)
                else
                    image.SetPixel(x,y, colorize(count))
            
    let temp = new Form() in
    temp.Paint.Add(fun e -> e.Graphics.DrawImage(image, 0, 0))
    temp
do Application.Run(createImage (20))



