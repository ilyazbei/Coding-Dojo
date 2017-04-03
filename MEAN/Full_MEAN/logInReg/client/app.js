var app = angular.module('app', ['ngRoute']);

app.config(function($routeProvider) {
  $routeProvider
  .when('/', {
    templateUrl: 'partials/logInReg.html'
  })
  .when('/succes', {
    templateUrl: 'partials/succes.html'
  })
  .otherwise( {
    redirectTo: '/'
  })
})
