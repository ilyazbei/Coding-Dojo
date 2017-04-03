app.controller('userController', function($scope, userFactory) {

  userFactory.checkStatus(function(data) {
    $scope.curUser = data;
  })

  $scope.login = function() {
    // console.log($scope.newUser.firstName, "firstName")
    // console.log($scope.newUser.lastName, "lastName")
    if(!$scope.newUser || !$scope.newUser.firstName || !$scope.newUser.lastName) {
      $scope.error = "Enter first and last name!"
    }
    else if($scope.newUser.firstName.length < 3 || $scope.newUser.lastName.length < 3) {
      $scope.error = "First and last name must be at least 3 characters long!"
    }
    else if($scope.newUser.firstName.length > 10 || $scope.newUser.lastName.length > 10) {
      $scope.error = "First and last name can not be more then 10 characters long!"
    } else {
      userFactory.login($scope.newUser)
    }

  }
})
