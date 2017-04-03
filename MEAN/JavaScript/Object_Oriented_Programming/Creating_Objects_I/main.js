// Creating Objects I.
// ********************** Vehicle Constructor **********************
// This constructor takes in the name, number of wheels, and the number of passengers.
// Pucblic method: makeNoise
// Returns vehicle.

function VehicleConstructor(name, numOfWheels, numOfPassengers) {
  var vehicle = {}; // set the object
  /*
  proporties
  */
  vehicle.name = name;
  vehicle.numOfWheels = numOfWheels;
  vehicle.numOfPassengers = numOfPassengers;
  /*
  methods
  */
  // Each vehicle should have a makeNoise method
  vehicle.makeNoise = function(noise) {
    console.log("Making noise!")
  }
  /*
  Return
  */
  return vehicle; // return the object
}

console.log("Bike");
var Bike = VehicleConstructor("Bike", 2, 1);
Bike.makeNoise();
Bike.makeNoise = function() {
  console.log("Ring ring!");
}
Bike.makeNoise();


console.log("Sedan");
var Sedan = VehicleConstructor("Sedan", 4, 4);
Sedan.makeNoise();
Sedan.makeNoise = function() {
  console.log("Honk Honk!");
}
Sedan.makeNoise();

console.log("Bus");
var Bus = VehicleConstructor("Bus", 8, 1);
Bus.pickUpPassengers = function(numOfPassengers) {
  Bus.numOfPassengers += numOfPassengers;
}
console.log(Bus.numOfPassengers);
Bus.pickUpPassengers(14);
console.log(Bus.numOfPassengers);
