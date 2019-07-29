// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open System;


// Kata Divisible por 7 =================================================================================================
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

// ======================================================================================================================

// Shortest word
let findShort (str : string) = 
    let aWords = str.Split [|' '|]|> Array.map (fun x -> (x.ToString().Length, x)) |> Array.toList;

    let minimo(f: (int * string), s: (int * string)) =
        let r = if (fst f <= fst s) then
                    f
                else
                    s
        r

    let rec procesar (a, m) =        
        
        match a with
            | [] -> m
            | h :: tail -> procesar(tail, minimo(h,m));
            

    let m = procesar(aWords, aWords.[0]);

    fst m

[<EntryPoint>]
let main argv = 
    (* Kata Divisible por 7 ---- NO TESTS

    let r = seven 8;
    let r1 = seven -29783245;
    let r2 = seven 234002979;
    
    Console.WriteLine("Resultado : [{0}, {1}]", fst r, snd r);
    Console.WriteLine("Resultado : [{0}, {1}]", fst r1, snd r1);
    Console.WriteLine("Resultado : [{0}, {1}]", fst r2, snd r2);
    *)
    
    let s = findShort "bitcoin take over the world maybe who knows perhaps";
    Console.WriteLine("Resultado : {0}", s);
    
    Console.ReadKey();

    0 // return an integer exit code
