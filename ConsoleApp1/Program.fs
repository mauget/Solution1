// F$ Play 
module Rogers.RogersModule

open System

[<EntryPoint>]
let main argv =  

    let count = 10

    /// Print sequence via for loop
    let printSeq lst =
        for v in lst do
            printfn "%d" v

    /// Print List via iteration, using a higher-order function
    let printList list =
        List.iter (printfn "%d") list
        
    /// Fibonacci Number formula
    let rec fib n =
        match n with
            | 0 | 1 -> n
            | _ -> fib (n - 2) + fib (n - 1)

    // Print first 'count' fibs
    printfn "\nPrint first %d fibs" count
    [1 .. count] |> List.map  fib |> printList

    /// Another approach - a lazy infinite sequence of Fibonacci numbers
    let fibSeq = Seq.unfold (fun (a,b) -> Some(a+b, (b, a+b))) (0,1)

    // Print first 'count' of infinite fib sequence
    printfn "\nPrint first %d fibs of infinite fib sequence" count
    printList (List.ofSeq (Seq.take count fibSeq) )

    // Print even fibs
    printfn "\nPrint even fibs"

    [1 .. count]
    |> List.map     fib
    |> List.filter  (fun n -> (n % 2) = 0)
    |> printList

    // Same thing, using a list expression: generate the list, then print it.
    printfn "\nSame thing, using a list expression"

    [ for i in 1..count do
        let r = fib i
        if r % 2 = 0 then yield r ]
            |> printList

    0
