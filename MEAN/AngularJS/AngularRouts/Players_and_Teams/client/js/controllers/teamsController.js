myAppModule.controller("TeamsController", function($scope, TeamFactory){
  $scope.teams = [];

  //When this controller is loaded, fetch the team list
  TeamFactory.getTeams(function(teams){
    $scope.teams = teams;
  })

  //Pass new team info to the TeamFactory
  $scope.addTeam = function(){
    TeamFactory.addTeam($scope.newTeam)
    $scope.newTeam = {}; //Reset newTeam form
  }

  //Pass $index to TeamFactory to remove
  $scope.removeTeam = function(team){
    var index = $scope.teams.indexOf(team);
    TeamFactory.removeTeam(index);

  }
})
