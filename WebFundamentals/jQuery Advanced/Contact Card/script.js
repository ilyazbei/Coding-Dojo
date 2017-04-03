$(document).ready(function(){
  $('.form1').submit(function(){
    var temp1 = $('.first').val();
    var temp2 = $('.last').val();
    var temp3 = $('.description').val();
    $('.contact').append("<div class = 'ccard'><h1>" + temp1 + "&nbsp;" + temp2 + "</h1>" + "<br>"+ "<a href='#'>Click for description!</a>" + "<p>" + temp3 + "</p></div>");
    // $(".contact").click(function(){
    //   $(this).toggle();
    return false;
    });
    $(".contact").on("click",".ccard", function() {
      $(this).children().toggle();
  });
});
