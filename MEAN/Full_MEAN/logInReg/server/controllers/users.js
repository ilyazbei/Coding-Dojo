var mongoose = require('mongoose');
var User = mongoose.model('User');
module.exports = (function() {
  return{
    register:function(req, res) {
      User.findOne({email: req.body.email}, function(err, data) {
        if(!data) {
          var user = new User(req.body);
          user.save(function(err, data) {
            res.json(data)
          })
        } else {
          res.json(data)
        }
      })
    }
  }
})()
