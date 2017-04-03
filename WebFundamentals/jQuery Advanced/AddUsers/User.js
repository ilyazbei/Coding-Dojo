$(document).ready(function(){
  $("#form1").submit(function(){
    var temp = $("#first").val();
    var temp1 = $("#last").val();
    var temp2 = $("#email").val();
    var temp3 = $("#phone").val();
    $("table").append("<tr><td>" + temp + "</td><td>" + temp1 + "</td><td>" + temp2 + "</td><td>" + temp3 + "</td></tr>");
    return false;
  });

});
