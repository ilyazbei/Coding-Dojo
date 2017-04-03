// #1. Make a function that can be used anywhere in your file and that when invoked will console.log('I am running!'); Give it the name runningLogger.
function runningLogger() {
  console.log("I am running!")
}
runningLogger();

// #2. Make a function that is callable, has one parameter and multiplies the value of the parameter by 10 before returning the result. Give it the name multiplyByTen. Invoke it, passing it the argument 5.
function multiplyByTen(number) {
  return number * 10;
}
console.log(multiplyByTen("5"));

// #3. Write two functions (stringReturnOne and stringReturnTwo) that each return a different hard-coded string.
function stringReturnOne(str) {
  return str;
}
console.log(stringReturnOne("Be the first!"));

function stringReturnTwo(str) {
  return str;
}
console.log(stringReturnTwo("Be the second!"));

// #4. Write a function named caller that has one parameter. If the argument provided to caller is a function (typeof may be useful), invoke the argument. Nothing is returned.
function myCaller(par) {
  if (typeof par === "function") {
    par();
  }
}
myCaller(runningLogger);

// #5. Write a function named myDoubleConsoleLog that has two parameters, if the arguments passed to the function are functions, console.log the value that each, when invoked, returns.
function myDoubleConsoleLog(par1,par2) {
  if (typeof par1 === "function") {
    console.log(par1()); // #5
  }
  if (typeof par2 === "function") {
    console.log(par2()); // #6
  }
}

// myDoubleConsoleLog(function() {
//   console.log("what up?")
//   return "none much";
// }, function() {
//   return 15;
// });

function returnFive(){
  return 5;
}
function returnHello(){
  return "Hello";
}
// #6. Write a function named caller2 that has one parameter. Have it console.log the string 'starting', wait 2 seconds, and then invokes the argument if the argument is a function. (setTimeout may be useful for this one.) The function should then console.log ‘ending?’ and return “interesting”. Invoke this function by passing it myDoubleConsoleLog.
function caller2(somePar) {
  console.log("Starting ..."); // #1 run
  setTimeout(function() {
    if (typeof somePar === "function") {
      console.log("About to invoke function"); // #4 run
      somePar(returnFive, returnHello);
    }
  }, 2000);
  console.log("The End"); // #2 run
  return "interesting";
}

console.log(caller2(myDoubleConsoleLog)); // #3 run
