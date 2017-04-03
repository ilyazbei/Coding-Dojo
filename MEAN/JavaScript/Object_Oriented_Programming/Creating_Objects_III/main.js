// ********** Creating Objects III **********

//Modify your Vehicle Class to take advantage of Prototypes!
// #1. Now modify your code to use Prototype and the recommended way of OOP we showed in the previous chapter.
// #2.
// #3.
// #4.

function VehicleConstructor(name, numOfWheels, numOfPassengers, speed) {
  if (!(this instanceof VehicleConstructor)) {
    return new VehicleConstructor(name, numOfWheels, numOfPassengers, speed);
  }
  var chars = "0123456789ABCEDGHIJKLMNOPQRSTUVWXYZ";


  /*
  proporties
  */
  this.name = name || "unicycle";
  this.numOfWheels = numOfWheels || 1;
  this.numOfPassengers = numOfPassengers || 0;
  this.speed = speed || 0; // #1.Have the Vehicle constructor also take in a “speed” Store the speed as an attribute
  this.distance_traveled = 0;
  this.vin = createVin();

  function createVin() {
    var vin = "";
    for (var i = 0; i < 17; i++) {
      vin += chars[Math.floor(Math.random()*35)];
    }
    console.log('Vin#', vin);
    return vin;
  }


  /*
  methods
  */
  // Each vehicle should have a makeNoise method
  VehicleConstructor.prototype.makeNoise = function() {
    if (numOfWheels <= 2) {
      console.log("Ring-Ring")
    }
    else if (numOfWheels == 4) {
      console.log("Honk bip Honk!");
    }
    else {
      console.log("Get off the road, you are poluting the invierment! :) ")
    }
    return this;
  }
  VehicleConstructor.prototype.checkMiles = function() {
    return this.distance_traveled;
  }
  VehicleConstructor.prototype.updateDistanceTraveled = function() {
    this.distance_traveled += this.speed;
    console.log("Traveled", this.distance_traveled , "Miles");
    return this;
  };
  VehicleConstructor.prototype.move = function() {
    this.updateDistanceTraveled();
    this.makeNoise();
    return this;
  }

}

// console.log(global);

console.log("Bike!");
var bike = new VehicleConstructor('Bike', 2, 1, 10);
bike.move().checkMiles();

console.log("Bus!");
var bus = new VehicleConstructor('Bus', 8, 35, 60);
bus.move().checkMiles();

console.log("Car!");
var car = new VehicleConstructor('Car', 4, 4, 40);
car.move().checkMiles();
