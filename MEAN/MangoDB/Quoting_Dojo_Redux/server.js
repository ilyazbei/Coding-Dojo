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

// Set up body-parser to parse form data
app.use(bodyParser.urlencoded({extended: true}));

// Tell server where views are and what templating engine I'm using
app.set('views', path.join(__dirname, './views'));
// Setting our View Engine set to EJS
app.set('view engine', 'ejs');

// Create connection to database
var connection = mongoose.connect("mongodb://localhost/quoting_dojo");


// Create quote schema and attach it as a model to our database
var QuoteSchema = new mongoose.Schema({
  name: String,
  quote: String,
  // current date and time
  dateAt: { type: Date, default: Date.now }
});

// Mongoose automatically looks for the plural version of your model name
// So a Quote model in Mongoose looks for 'quotes' in Mongo.
var Quote = mongoose.model('quotes', QuoteSchema);

// Here are our routes!
app.get('/', function(req, res){
  res.render('welcome');
});

// Quotes
app.get('/quotes', function(req, res){
  // Logic to grab all quotes and pass into the rendered view
  Quote.find({}, function(err, results){
    if(err) { console.log(err); }
    res.render('quotes', { quotes: results });
  });
});

app.post('/quotes', function(req, res){
  Quote.create(req.body, function(err){
    if(err) { console.log(err); }
    res.redirect('/quotes');
  });
});



// Setting our Server to Listen on Port: 8000
app.listen(8000, function() {
    console.log("listening on port 8000");
})
