// Learn more about F# at https://fsharp.org
// See the 'F# Tutorial' project for more help.
open Microsoft.FSharp.Math
open System
open System.Windows.Forms
open System.Drawing


let height = 280.0
let width = 280.0
let cMax = complex 1.0 1.0
let cMin = complex -1.0 -1.0
let rec isInMandelbrotSet (zero, c, cur_iter, iter) =
    if cur_iter < iter && Complex.Abs(zero)<=2.0 then
        isInMandelbrotSet ( ((zero * zero) + c), c, cur_iter+1, iter )
    else cur_iter

let newCoordinates(x:int, y:int, scale:float, mx:float,my:float) =
       complex ((float x-100.0)/(100.0*scale)+ mx) (-(float y-100.0)/(100.0*scale) + my)

let colorize c =
    let r = (4 * c) % 255
    let g = (6 * c) % 255
    let b = (8 * c) % 255
    Color.FromArgb(r,g,b)


let createImage (mx, my, iter,scale) =
    let image = new Bitmap(Convert.ToInt32(width), Convert.ToInt32(height))
    for x = 0 to image.Width - 1 do
        for y = 0 to image.Height - 1 do
            let count = isInMandelbrotSet( Complex.Zero, newCoordinates(x,y,scale,mx,my), 0, iter)
            if count = iter then
                image.SetPixel(x,y, Color.Black)
            else
                image.SetPixel(x,y, colorize( count ) )
    image
//координаты точки приближения взял у сокомандника
let mutateImage (ans:Form) (i:float)= ans.Paint.Add(fun e -> e.Graphics.DrawImage(createImage(-0.7,0.28,30+Convert.ToInt32(i*4.0),i*2.2), 0, 0))
let ans  = new Form()
ans.Paint.Add(fun e -> e.Graphics.DrawImage(createImage(-0.7,0.28,100,1.0), 0, 0))
ans.Size <- new Size(Convert.ToInt32(width), Convert.ToInt32(height))

for i in 1.0..30.0 do
    mutateImage ans i


do Application.Run(ans)

