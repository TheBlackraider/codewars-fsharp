// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System;

let rec calculate(m: int, s: int) =

    if (m < 10) then
        (m, s)
    else
        let str = m.ToString();
        let strlen = str.Length;

        let x' = int(str.Substring(0,strlen - 1));
        let y' = int(str.Substring(strlen - 1 ,1));

        let i = x' - (2 * y');

        let result = (i, s + 1);

        let resultlen = i.ToString().Length;

        match (resultlen) with
            | 2 -> result;
            | _ -> calculate(i, s + 1);

let seven(m: int) =
    calculate(m,0);


[<EntryPoint>]
let main argv = 
    let r = seven 8;
    let r1 = seven -29783245;
    let r2 = seven 234002979;
    
    Console.WriteLine("Resultado : [{0}, {1}]", fst r, snd r);
    Console.WriteLine("Resultado : [{0}, {1}]", fst r1, snd r1);
    Console.WriteLine("Resultado : [{0}, {1}]", fst r2, snd r2);

    Console.ReadKey();

    0 // return an integer exit code
