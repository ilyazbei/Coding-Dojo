var mongoose = require('mongoose');
var User = mongoose.model('User');

module.exports = (function() {
  return{
    login: function(req, res) {
      // console.log(req.body, "back end users controller");
      // console.log(req.session.user, "yesssssflkasdjflkajsdfl;kjasdl;kfjasl;kdfjals;kdjf")
      User.findOne({firstName: req.body.firstName, lastName: req.body.lastName}, function(err, data) {
        if(!data) {
          var user = new User(req.body);
          user.save(function(err) {
            req.session.user = user;
            req.session.save()
            res.json({status: "ok"})
          })
        } else {
          req.session.user = data;
          req.session.save()
          res.json(data)
        }
      })
    },
    checkStatus: function(req, res) {
      if(req.session.user) {
        res.json(req.session.user)
      } else {
        res.json(null)
      }
    },

    logout: function(req, res) {
      req.session.destroy();
      res.redirect('/')
    }
  }
})()
