// function awesome() {
//   console.log("too good to be true");
// }
// awesome();


// function addNumbers(a,b) {
//   var sum = a+b;
//   console.log(sum);
// }
// addNumbers(2,2);



// function addArrayElements(array) {
//   var array_sum = 0;
//   var array_length = array.length;
//   for(var i = 0; i < array_length; i++) {
//     addNumbers(array_sum[i]);
//   }
//   function addNumbers(a,b) {
//     var sum = a + b;
//     console.log(sum);
//   }
//   console.log(array_sum);
// }
// var new_sum = addArrayElements([3,4,5]);

//
// var hello = "interesting";
// function example() {
//   var hello = "hi!";
//   console.log(hello);
// }
// example();
// console.log(hello);
//
//
// //declarations get hoisted
// var hello;
// function example() {
//   var hello;
//   hello = "hi";
//   console.log(hello);
// }
// //assignments and invocation maintain order
// hello = "interesting";
// example();
// console.log(hello);

function NinjaConstructor(name, prevOccupation) {
  this.name = name;
  this.prevOccupation = prevOccupation;
  this.introduce = function() {
    console.log("Hi my name is " + this.name + ". I used to be a " + this.prevOccupation + " and now I'm a Ninja!");
  }
}
console.log(this);
var dylan = new NinjaConstructor('Dylan', 'Construction Worker');

var nikki = new NinjaConstructor('Nikki','Historian');

// console.log(dylan.name, dylan.prevOccupation);
//
