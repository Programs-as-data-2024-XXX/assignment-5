(* THIS IS EXERCISE 5.1 *)
module exercise_5_1

let rec merge (left: int list, right: int list) : int list =
  match left, right with
  | [], right -> right
  | left, [] -> left
  | x::xs, y::ys ->
    if x < y then
      x :: merge(xs, right)
    else
      y :: merge(left, ys)