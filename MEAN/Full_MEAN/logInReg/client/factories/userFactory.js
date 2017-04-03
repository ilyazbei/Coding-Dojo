app.factory('userFactory', function($http, $location) {

  var factory = {};
  factory.register = function(regUser) {
    $http.post('/register', regUser).then(function(output) {
      if(output.data) {
        $location.url('/succes')
      }
    })
  }
  return factory
})
