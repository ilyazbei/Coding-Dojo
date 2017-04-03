app.controller('userController', function($scope, userFactory) {

  userFactory.checkStatus(function(data) {
    $scope.curUser = data;
  })

  $scope.login = function() {
    // console.log($scope.user.name, $scope.user.email)
    if(!$scope.user || !$scope.user.name || !$scope.user.email) {
      $scope.error = "Enter user name and email!"
    }else if($scope.user.name.length < 3 ) {
      $scope.error = "User name must be at least 3 characters long!"
    }else if($scope.user.name.length > 10 ) {
      $scope.error = "User name can not be more then 10 characters long!"
    }else {
      userFactory.login($scope.user)
    }
  }
})
