## Exercise 5.1

## Exercise 5.7

## Exercise 6.1
``` bash
run (fromString @"let add x = let f y = x+y in f end in add 2 5 end");;
val it: HigherFun.value = Int 7
```

``` bash
run (fromString @"let add x = let f y = x+y in f end in let addtwo = add 2 in addtwo 5 end end");;
val it: HigherFun.value = Int 7
```

``` bash
run (fromString @"let add x = let f y = x+y in f end in let addtwo = add 2 in let x = 77 in addtwo 5 end end end");;
val it: HigherFun.value = Int 7
```
### Is the result of the third one as expected?
Yes this result is expected since the function returned must enclose the value of f's free variable x - so defining x as 77 has nothing to do with the later x. 
Essentially we've already assigned x to be add 2, so the x = 77 is never used, therefore we end up getting 5+2 = 7.

``` bash
run (fromString @"let add x = let f y = x+y in f end in add 2 end");;
val it: HigherFun.value =
  Closure
    ("f", "y", Prim ("+", Var "x", Var "y"),
     [("x", Int 2);
      ("add",
       Closure
         ("add", "x", Letfun ("f", "y", Prim ("+", Var "x", Var "y"), Var "f"),
          []))])
```
### Explanation of result of the last example
This result happens for similar reason as the third example. We've defined a function add that takes an argument x and returns a function f that takes an argument y and returns x+y. We then call add with 2 as argument, which returns a closure with the function f and the value of x. The result is a closure for the function f, where x is bound to 2, and f will therefore add 2 to whatever value y is given when invoked.

This is because we need to keep track of the variables in scope when the function is defined, so we end up storing x = 2 aswell as the definition of add, along with the function itself. 


## Exercise 6.2

## Exercise 6.3
The answers to this exercise can be found in FunPar.fsy and FunPar.fsl where there will be comments specifying that the following line/lines were added.
Specifically in FunLex.fsl two keywords were added "fun" and "->".
In FunPar.fsy two tokens were added: FUN and ARROW, as well as an Expr: FUN Expr ARROW Expr


## Exercise 6.4

## Exercise 6.5
0) open ParseAndType;;

1)
let f x = 1 in f f end
> inferType(fromString "let f x = 1 in f f end");;
val it: string = "int"

2)
let f g = g g in f end
> inferType(fromString "let f g = g g in f end");;
System.Exception: type error: circularity

Explanation:
Due to the circularity of "g g", it never reaches a point where it would be able to infer type.

3)
let f x = let g y = y in g false end in f 42 end
> inferType(fromString "let f x = let g y = y in g false end in f 42 end");;
val it: string = "bool"

4) 
let f x = let g y = if true then y else x in g false end in f 42 end
> inferType(fromString "let f x = let g y = if true then y else x in g false end in f 42 end");; 
System.Exception: type error: bool and int

Explanation:
There's a type mismatch in the "then y else x", since one is an int and one is a bool.

5)
let f x = let g y = if true then y else x in g false end in f true end
> inferType(fromString "let f x = let g y = if true then y else x in g false end in f true end");;
val it: string = "bool"

