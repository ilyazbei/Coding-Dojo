//This is the first javascript file to load, so it initializes the module
var myAppModule = angular.module("myApp", ["ngRoute", "ngMessages"]);
//Define our routes to render partials
myAppModule.config(function($routeProvider) {
  $routeProvider
    .when("/players", {
      //Because our server.js established the location of the static folder,
      //we don't have to define the location of our partials beyond their
      //relation to the static folder
      templateUrl: "static/partials/playersList.html"
    })
    .when("/teams", {
      templateUrl: "static/partials/teamsList.html"
    })
    .when("/associations", {
      templateUrl: "static/partials/associations.html"
    })
    .otherwise({
      redirectTo: "/players"
    });
})
