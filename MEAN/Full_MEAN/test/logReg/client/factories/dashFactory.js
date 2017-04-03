app.factory('dashFactory', function($http, $location) {
  var factory = {};

  factory.index = function( callback ) {
    $http.get('/dashboard').then(function(res) {
      callback(res.data);
    })
  }

  factory.submitTopic = function(topic, callback) {
    // console.log(topic, "in factory");
    // http post takes us to back end server side route
    $http.post('/submitTopic', topic).then(function(res) {
      // console.log(output, "asldkfjalksdfjalksjdf");
      callback(res.data);
    })
  }
  return factory
})
