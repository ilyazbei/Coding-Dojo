// Creating Objects I.

// ********************** Vehicle Constructor **********************
// This constructor takes in the name, number of wheels, and the number of passengers, speed.
// Pucblic method: makeNoise
// Returns vehicle.

// Creating Objects I. and II

// Have the Vehicle constructor also take in a “speed” Store the speed as an attribute
// Create a private variable called distance_travelled that starts at 0
// Create a private method called updateDistanceTravelled that increments distance traveled by speed
// Add a method to the Vehicle called “move” that calls updateDistanceTravelled and then makeNoise
// Add a method called checkMiles that console.logs the distance_travelled



// var bus = new VehicleConstructor();

function VehicleConstructor(name, numOfWheels, numOfPassengers, speed) {
  if (!(this instanceof VehicleConstructor)) {
    return new VehicleConstructor(name, numOfWheels, numOfPassengers, speed);
  }

  // console.log(this);
  var self = this;
  // Private Variables
  var distance_travelled = 0;

  // Private Methods
  function updateDistanceTravelled() {
    distance_travelled += self.speed;
  }
  /*
  proporties
  */
  this.name = name || "unicycle";
  this.numOfWheels = numOfWheels || 1;
  this.numOfPassengers = numOfPassengers || 0;
  this.speed = speed || 0; // #1.Have the Vehicle constructor also take in a “speed” Store the speed as an attribute
  /*
  methods
  */
  // Each vehicle should have a makeNoise method
  this.makeNoise = function(noise) {
    var noise = noise || "Honk Honk!"
    console.log(noise)
  }
  this.move = function() {
    updateDistanceTravelled();
    this.makeNoise();
  }
  this.checkMiles = function() {
    return distance_travelled;
  }
}

// console.log(global);

var bus = new VehicleConstructor('Bus', 8, 35, 60);
console.log(bus.checkMiles());
bus.move();
console.log(bus.checkMiles());
