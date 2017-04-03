// #1. Go through each value in the array x, where x = [3,5,"Dojo", "rocks", "Michael", "Sensei"]. Log each value.
console.log("#1. iterateArr()");
function iterateArr(arr) {
  for(var i = 0; i < arr.length - 1; i++) {
    console.log(x[i]);
  }
}
x = [3,5,'Dojo', 'rocks', 'Michael', 'Sensei'];
iterateArr(x);

// #2. Add a new value (100) in the array x using a push method.
console.log("#2. Add a new Value (100)")
function newVal(arr) {
  arr.push(100);
  console.log(x);
}
x = [3,5,'Dojo', 'rocks', 'Michael', 'Sensei'];
newVal(x);

// #3. Add a new array ["hello", "world", "JavaScript is Fun"] to variable x. Log x in the console and analyze how x looks now.
console.log("#3. Add new Arrey");
x = ["hello", "world", "JavaScript is Fun"];
console.log(x);

// #4. Create a simple for loop that sums all the numbers between 1 to 500. Have console log the final sum.
console.log("#4. sumAll() 1 to 500");
function sumAll(min,max) {
  var sum = 0;
  for(var i = min; i <= max; i++) {
    sum += i;
  }
  console.log(sum);
}
sumAll(1,500);

// #5. Write a loop that will go through the array [1, 5, 90, 25, -3, 0], find the minimum value, and then print it.
console.log("#5. Find minimum value in array [1, 5, 90, 25, -3, 0]")
function find_MinVal(arr) {
  var min = arr[0]; // our min value is 1 at the moment
  for(var i = 1; i < arr.length; i++) {
    if(min > arr[i]) {
      min = arr[i];
    }
  }
  console.log(min);
}
z = [1, 5, 90, 25, -3, 0];
find_MinVal(z);

// #6. Write a loop that will go through the array [1, 5, 90, 25, -3, 0], find the average of all of the values, and then print it.
console.log("#6. Find avarage in array [1, 5, 90, 25, -3, 0]")
function find_AvgVal(arr) {
  var sum = 0;
  var avg = 0;
  for(var i = 0; i < arr.length; i++) {
    sum+= arr[i];
    avg = sum / arr.length;
  }
  console.log(avg);
}
z = [1, 5, 90, 25, -3, 0];
find_AvgVal(z);

// #7. Create for-in loop
console.log("#7. Create for-in loop")
var newNinja = {
 name: 'Ilyaz',
 profession: 'coder',
 favorite_language: 'JavaScript', //like that's even a question!
 dojo: 'Bellevue'
}
// console.log(newNinja['name']);
// console.log(newNinja['profession']);
// console.log(newNinja['favorite_language']);
// console.log(newNinja['dojo']);
// or
// console.log(newNinja.name, newNinja.profession, newNinja.favorite_language, newNinja.dojo);

for (var key in newNinja) {
  if (newNinja.hasOwnProperty(key)) {
    console.log(key);
    console.log(newNinja[key]);
  }
}
