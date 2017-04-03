// Load the express module
var express = require("express");
// console.log(express);

// invoke var express and store the resulting application in var app
var app = express();
// console.log(app);

// let's handle the base route "/" and respond with "Hello Express"
app.get('/', function(request, response) {
  // console.log(request);
  // console.log(response);
  response.send("<h1>Hello Express</h1>");
})

// this is the line that tells our server to use the "/static" folder for static content
app.use(express.static(__dirname + "/static"));

// This sets the location where express will look for the ejs views
app.set('views', __dirname + '/views');
// Now lets set the view engine itself so that express knows that we are using ejs as opposed to another templating engine like jade
app.set('view engine', 'ejs');

app.get("/users", function (request, response){
    // hard-coded user data
    var users_array = [
        {name: "Michael", email: "michael@codingdojo.com", nickName: "Master"},
        {name: "Jay", email: "jay@codingdojo.com", nickName: "Instructor"},
        {name: "Brendan", email: "brendan@codingdojo.com", nickName: "Student"},
        {name: "Andrew", email: "andrew@codingdojo.com", nickName: "Beginer"}
    ];
    response.render('users', {users: users_array});
})

// Tell the express app to listen on port 8000
app.listen(8000, function() {
  console.log("listening on port 8000");
})
// this line will almost always be at the end of your server.js file (we only tell the server to listen after we have set up all of our rules)
