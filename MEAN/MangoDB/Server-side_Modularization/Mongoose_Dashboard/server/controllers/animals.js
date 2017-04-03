var mongoose = require('mongoose');
var Animal = mongoose.model('Animal');
module.exports = {
  index: function(req, res) {
    Animal.find({}, function(err, results) {
      if (err) { console.log(err); }
      res.render('index', { animals: results });
    });
  },
  create: function(req, res) {
    // Create a new animal!
    Animal.create(req.body, function(err, result){
      if (err) { console.log(err); }
      res.redirect('/')
    });
  },
  show: function(req, res) {
    Animal.find({ _id: req.params.id }, function(err, response) {
      if (err) { console.log(err); }
      res.render('show', { animal: response[0] });
    });
  },
  find: function(req, res) {
    Animal.find({ _id: req.params.id }, function(err, response) {
      if (err) { console.log(err); }
      res.render('edit', { animal: response[0] });
    });
  },
  update: function(req, res) {
    Animal.update({ _id: req.params.id }, req.body, function(err, result){
      if (err) { console.log(err); }
      res.redirect('/');
    });
  },
  remove: function(req, res) {
    Animal.remove({ _id: req.params.id }, function(err, result){
      if (err) { console.log(err); }
      res.redirect('/');
    });
  }
}
