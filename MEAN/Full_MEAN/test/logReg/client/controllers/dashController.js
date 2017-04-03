app.controller('dashController', function($scope, $location, dashFactory) {
  $scope.topics = [];

  var index = function() {
    dashFactory.index(function(dataFromFactory) {
      $scope.topics = dataFromFactory;
    });
  }
  index();

  $scope.submitTopic = function() {
    // console.log($scope.topic.topic, $scope.topic.description, "topic in controller");
    if(!$scope.topic || !$scope.topic.topic || !$scope.topic.description) {
      $scope.error = "You must enter topic and description IDIOT!"
    }else{
      $scope.topics.push($scope.topic);
      dashFactory.submitTopic($scope.topic, function(data) {
        $scope.topic = {};
      })
    }
  }

})
