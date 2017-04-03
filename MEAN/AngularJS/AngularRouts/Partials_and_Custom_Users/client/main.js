var myAppModule = angular.module("myApp", ["ngRoute"]);
//Define routes
myAppModule.config(function($routeProvider) {
  $routeProvider
    .when("/users", {
      templateUrl: "partials/customUsers.html"
    })
    .when("/list", {
      templateUrl: "partials/usersList.html"
    })
    .otherwise({
      redirectTo: "/"
    });
})
//Factory
myAppModule.factory("userFactory", [function() {
  var factory = {};
  // Initialize our Users list
  var users = [];

  factory.getUser = function(callback) {
    callback(users);
  }
  factory.create = function(user) {
    users.push(user);
  }
  // Remove the user from the list
  factory.delete = function($index) {
    users.splice($index, 1);
  }
  return factory;
}])

//controllers
//Inject userFactory into each controller
myAppModule.controller("usersController", ["$scope", "userFactory", "$location", function($scope, userFactory, $location) {
  function setUsers(data) {
    $scope.users = data;
    $scope.newUser = {};
  }
  $scope.users = [];
  //When this controller is loaded, fetch the user list
  userFactory.getUser(setUsers);
  //Pass new user info to the factory
  $scope.create = function() {
    userFactory.create($scope.newUser)
    $scope.newUser = {};
    $location.url("/list")
  }
  //Delegate deleting user to the factory
  $scope.delete = function($index) {
    userFactory.delete($index);
  }

}]);

//Inject userFactory into each controller
myAppModule.controller("ListController", ["$scope", "userFactory", function($scope, userFactory) {
  function setUsers(data) {
    $scope.users = data;
  }
  $scope.users = [];

  //When this controller is loaded, fetch the user list
  userFactory.getUser(setUsers);
}]);
