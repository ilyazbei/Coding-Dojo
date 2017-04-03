// Require the Express Module
var express = require('express');
// Require body-parser (to receive post data from clients)
var bodyParser = require('body-parser');
// Require mongoose
var mongoose = require('mongoose');
// Require path
var path = require('path');

// Create an Express App
var app = express();

// Use bodyParser to parse form data sent via HTTP POST
app.use(bodyParser.urlencoded({ extended: true }));

// Tell server where views are and what templating engine I'm using
app.set('views', path.join(__dirname, './views'));
// Setting our View Engine set to EJS
app.set('view engine', 'ejs');

// Create connection to database
var connection = mongoose.connect("mongodb://localhost/animal_db");

// Create animal schema and attach it as a model to our database
var AnimalSchema = new mongoose.Schema({
    type: String,
    name: String,
    weight: Number,
    color: String
});

// Mongoose automatically looks for the plural version of your model name, so a Animal model in Mongoose looks for 'animals' in Mongo.
var Animal = mongoose.model('Animal', AnimalSchema);

// Routes go here!
app.get('/', function(req, res){
  Animal.find({}, function(err, results){
    if (err) { console.log(err); }
    res.render('index', { animals: results });
  });
});

// Create
app.post('/', function(req, res){
  // Create a new animal!
  Animal.create(req.body, function(err, result){
    if (err) { console.log(err); }
    res.redirect('/')
  });
});

// New
app.get('/new', function(req, res){
  res.render('new');
});

// Show
app.get('/:id/show/', function(req, res){
  Animal.find({ _id: req.params.id }, function(err, response) {
    if (err) { console.log(err); }
    res.render('show', { animal: response[0] });
  });
});

// Edit
app.get('/:id/edit/', function(req, res){
  Animal.find({ _id: req.params.id }, function(err, response) {
    if (err) { console.log(err); }
    res.render('edit', { animal: response[0] });
  })
});

// Update
app.post('/:id', function(req, res){
  Animal.update({ _id: req.params.id }, req.body, function(err, result){
    if (err) { console.log(err); }
    res.redirect('/');
  });
});

// Delete
app.post('/:id/delete', function(req, res){
  Animal.remove({ _id: req.params.id }, function(err, result){
    if (err) { console.log(err); }
    res.redirect('/');
  });
});



// Setting our Server to Listen on Port: 8000
app.listen(8000, function() {
    console.log("listening on port 8000");
})
