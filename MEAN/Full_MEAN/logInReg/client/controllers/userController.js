app.controller("logInRegController", function($scope, userFactory) {

  $scope.register = function() {
    if(!$scope.regUser || !$scope.regUser.firstName || !$scope.regUser.lastName) {
      $scope.error = "All fields must be filled out!"
    } else if($scope.regUser.firstName.length < 3 || $scope.regUser.lastName.length < 3) {
      $scope.error = "First and last name must be at least 3 characters long!"
    // } else if($scope.regUser.password_confrim !== $scope.regUser.password){
    //   $scope.error = "Password must match!"
    } else {
      userFactory.register($scope.regUser)
    }
    console.log($scope.regUser , "yesssssssssssssss")
  }
  $scope.login = function() {
    // console.log($scope.logInUser, "o noooooooooooo")
    userFactory.login($scope.logInUser)
  }
})
