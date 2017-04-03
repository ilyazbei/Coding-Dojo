var personConstructor = {
  name : "Ilyaz",
  distance_traveled : 0,
  say_name : function() {
    alert(personConstructor.name);
  },
  say_something : function(phrase){
    console.log(`${personConstructor.name} says: ${phrase}`);
  },
  walk : function(){
    console.log(`${personConstructor.name} is walking!`);
    personConstructor.distance_traveled += 3;
    return personConstructor;
  },
  run : function(){
    console.log(`${personConstructor.name} is running!`);
    personConstructor.distance_traveled += 10;
    return personConstructor;
  },
  crawl : function(){
    console.log(`${personConstructor.name} is crawling!`);
    personConstructor.distance_traveled += 1;
    return personConstructor;
  },
  chewGum:function(){
    console.log("I can walk and chew gum, but I can't chew gum and walk...");
  }
}

console.log(personConstructor.distance_traveled);
personConstructor.walk().run().crawl().run().chewGum();
console.log(personConstructor.distance_traveled);


// #2. Now create a ninjaConstructor that can be used to create Ninjas that each has a name, cohort, and belt-level. Give all of the Ninjas a “levelUp” method that increases their belt-level (Have all ninjas start at a yellow-belt).

console.log("Part 2");

function ninjaConstructor(name, cohort) {
  var ninja = {}
  var belts = ["yellow", "red", "black"]
  ninja.name = name;
  ninja.cohort = cohort;
  ninja.beltLevel = 0;
  ninja.levelUp = function() {
    if (ninja.beltLevel < 2) {
      ninja.beltLevel += 1;
      ninja.belt = belts[ninjas.beltLevel];
    }
    return ninja
  }
  ninja.belt = belts[ninja.beltLevel];
  return ninja;
}

console.log(ninjaConstructor("Ilyaz", "MEAN"));
