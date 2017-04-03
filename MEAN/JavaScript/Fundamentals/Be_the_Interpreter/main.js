// For each of the following problems rewrite the code to mimic how the interpreter would rearrange it before running. After rearranging the code, predict the output.
// #1.
// console.log("Problem 1");
//
// console.log(first_variable);
// var first_variable = "Yipee I was first!";
// function firstFunc() {
//   first_variable = "Not anymore!!!";
//   console.log(first_variable);
// }
// console.log(first_variable);

console.log("Iterpreted #1");

var first_variable; // undefined

function firstFunc() {
  first_variable = "Not anymore!!!";
  console.log(first_variable);
}
console.log(first_variable);
first_variable = "Yipee I was first!";
console.log(first_variable);

// #2.
// console.log("Problem 2");
//
// var food = "Chicken";
// function eat() {
//   food = "half-chicken";
//   console.log(food);
//   var food = "gone";       // CAREFUL!
//   console.log(food);
// }
// eat();
// console.log(food);

console.log(" Interpreted #2");

var food;
function eat() {
  var food;
  food = "half-chicken";
  console.log(food);
  food = "gone";
  console.log(food);
}

food = "Chicken";

eat();

console.log(food);

// #3.
console.log("Problem 3");

var new_word = "NEW!";
function lastFunc() {
  new_word = "old";
}
console.log(new_word);

console.log(" Interpreted #3");
var new_word;

function lastFunc() {
  new_word = "old";
}

new_word = "NEW!";

console.log(new_word);
