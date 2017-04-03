//load the express module
//load the path module
//load the body-parser
var express = require("express"); //***
var path = require("path"); //***
var bodyParser = require('body-parser'); //***

// create the express app
var app = express(); //***
var mongoose = require('mongoose');
mongoose.connect('mongodb://localhost/users');

var db = mongoose.connection;
db.on('error', console.error.bind(console, 'connection error:'));
db.once('open', function (callback) {
});

var userSchema = new mongoose.Schema({
	name: String,
	age: Number
});
var User = mongoose.model('User', userSchema);

// use it!
app.use(bodyParser.urlencoded({ extended: true })); //***
// static content
app.use(express.static(path.join(__dirname, "./static"))); //***
// setting up ejs and our views folder
app.set('views', path.join(__dirname, './views')); //***
app.set('view engine', 'ejs');


app.get('/', function(req, res) {

	User.find({}, function(err, users){

		if(err){
			console.log('Failed to load users from database');
		} else {
			console.log('success');
		}
		console.log(users);
		res.render('index', {users: users});
	})
})
// route to add a user
app.post('/users', function(req, res) {
 console.log("POST DATA", req.body);
 // This is where we would add the user from req.body to the database.
 var user = new User({name: req.body.name, age: req.body.age});
 user.save(function(err){
 	if(err){
 		console.log('Something went wrong...')
 	} else {
 		console.log('Successfully added user to database.')
 		res.redirect('/');
 	}
 })
})


// tell the express app to listen on port 8000
app.listen(8000, function() {
 console.log("listening on port 8000");
});
