app.factory('userFactory', function($http, $location) {
  var factory = {};
  factory.login = function(newUser) {
    // console.log(newUser, "in Factory");
    $http.post('/login', newUser).then(function(output) {
      if(output.data) {
        $location.url('/dash')
      }
    })
  }
  factory.checkStatus = function(cb) {
    $http.get('/checkstatus').then(function(output) {
      if(!output.data) {
        $location.url('/')
      } else {
        cb(output.data)
      }
    })
  }
  return factory
})
