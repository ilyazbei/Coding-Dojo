// require mongoose
var mongoose = require('mongoose');
// Create animal schema and attach it as a model to our database
var AnimalSchema = new mongoose.Schema({
    type: String,
    name: String,
    weight: Number,
    color: String
});
// register the schema as a model
var Animal = mongoose.model('Animal', AnimalSchema);
