// #1. Create a simple for loop that sums all the integers between x and y (inclusive). Have it console log the final sum.
console.log("#1.");
function sumXY(x, y) {
    var sum = 0;
    for (var i = x; i <= y; i++) {
        sum += i;
    }
    console.log(sum);
}
sumXY(0,3);

// #2. Write a loop that will go through an array, find the minimum value, and then return it.
console.log("#2.");
function findMinVal(array) {
  var min = array[0];
  for (var i = 1; i < array.length; i++) {
    if (array[i] < min ) {
      // console.log("Replacing min with: ", array[i]);
      console.log(`Replacing min with ${array[i]}`);
      min = array[i];
    }
  }
  console.log(min);
}
findMinVal([2,9,0,-4,9]);

// #3. Write a loop that will go through an array, find the average of all of the values, and then return it.
console.log("#3.");
function find_AvgVal(arr) {
  var sum = arr[0];
  for(var i = 1; i < arr.length; i++) {
    sum+= arr[i];
  }
  return sum / arr.length;
}

console.log(find_AvgVal([2,4,6,8]));

// #4. Rewrite these 3 as anonymous functions assigned to variables.
console.log("#4");
var sumXY = function (x, y) {
    var sum = 0;
    for (var i = x; i <= y; i++) {
        sum += i;
    }
    return sum;
}

var findMinVal = function (array) {
  var min = array[0];
  for (var i = 1; i < array.length; i++) {
    if (array[i] < min ) {
      // console.log("Replacing min with: ", array[i]);
      console.log(`Replacing min with ${array[i]}`);
      min = array[i];
    }
  }
  return min;
}

var findAvgVal = function (arr) {
  var sum = arr[0];
  for(var i = 1; i < arr.length; i++) {
    sum+= arr[i];
  }
  return sum / arr.length;
}

console.log(sumXY(0,2));
console.log(findMinVal([2,4,0,5,-9]));
console.log(findAvgVal([2,4,6,8]));

// #5. Rewrite these as methods of an object
console.log("#5");

var myMethodsObject = {
  sumXY : function (x, y) {
    var sum = 0;
    for (var i = x; i <= y; i++) {
      sum += i;
    }
    return sum;
  },
  findMinVal : function (arr) {
    var min = arr[0];
    for (var i = 1; i < arr.length; i++) {
      if ( arr[i] < min) {
        min = arr[i];
      }
    }
    return min;
  },
  findAvgVal : function (arr) {
    var sum = arr[0];
    for (var i = 1; i < arr.length; i++) {
      sum += arr[i];
    }
    return sum / arr.length;
  }
}

console.log(myMethodsObject.sumXY(0,2));
console.log(myMethodsObject.findMinVal([2,4,0,5,-9]));
console.log(myMethodsObject.findAvgVal([2,4,6,8]));

///Create a JavaScript object called person with the following properties/method
          // Properties
// name - set this as your own name
// distance_traveled - set this initially as zero
         // Methods
// say_name - should alert the object’s name property
// say_something - have it accept a parameter. This function should then say for example “{{your name}} says ‘I am cool’” if you pass ‘I am cool’ as an argument to this method.
// walk - have it alert for example “{{your name}} is walking” and increase distance_traveled by 3
// run - have it alert for example “{{your name}} is running” and increase distance_traveled by 10
// crawl - have it alert for example “{{your name}} is crawling” and increase distance_traveled by 1
console.log("#6");

var person = {
  name: "Ilyaz",
  distance_traveled: 0,
  say_name: function() {
    console.log(person.name);
  },
  say_something: function(phrase) {
    console.log(`${person.name} says: ${phrase}`);
  },
  walk: function() {
    alert(`${person.name} is walking!`);
    person.distance_traveled += 3;
    return person;
  },
  run: function() {
    alert(`${person.name} is running!`);
    person.distance_traveled += 10;
    return person;
  },
  crawl: function() {
    alert(`${person.name} is crawling!`);
    person.distance_traveled += 1;
    return person;
  }
}
// console.log(person);
// person.say_name();
// person.say_something("I Love JavaScript Objects!");
console.log(person.distance_traveled);
person.walk().run().crawl().run().walk();
console.log(person.distance_traveled);
