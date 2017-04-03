app.factory('userFactory', function($http, $location) {
  var factory = {};
  factory.login = function(user) {
    // console.log(user, "in factory")
    $http.post('/login', user).then(function(output) {
      // console.log(output, "output");
      if(output.data) {
        $location.url('/dashboard')
      }
    })
  }
  factory.checkStatus = function(cb) {
    $http.get('/checkstatus').then(function(output) {
      if(!output.data) {
        $location.url('/')
      }else{
        cb(output.data)
      }
    })
  }
  return factory
})
