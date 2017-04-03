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

// static content
app.use(express.static(path.join(__dirname, "./client/static")));
// Tell server where views are and what templating engine I'm using
app.set('views', path.join(__dirname, './client/views'));
// Setting our View Engine set to EJS
app.set('view engine', 'ejs');
// require the mongoose configuration file which does the rest for us
require('./server/config/mongoose.js');


// store the function in a variable
var routes_setter = require('./server/config/routes.js');
// invoke the function stored in routes_setter and pass it the "app" variable
routes_setter(app);



// Setting our Server to Listen on Port: 8000
app.listen(8000, function() {
    console.log("listening on port 8000");
})
