var app = angular.module('app', ['ngRoute']);




app.config(function($routeProvider) {
  $routeProvider
  .when('/', {
    templateUrl: 'partials/logReg.html'
  })
  .when('/dash', {
    templateUrl: 'partials/dash.html'
  })
  .otherwise( {
    redirectTo: '/'
  })
})
