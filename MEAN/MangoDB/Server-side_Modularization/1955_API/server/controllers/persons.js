var mongoose = require('mongoose')
var Person = mongoose.model('Person');
console.log(Person)
module.exports = {
    index: function(req,res){
      Person.find({}, function(err,results){
        if(err){
          console.log(err);
        } else {
          res.json(results);
        }
      })
    },

    create: function(req,res) {
      var newPerson = new Person({name: req.params.name})
      newPerson.save(function(err){
        if(err){
          for(var x in err.errors){
            errors.push(err.errors[x].message);
          }
        res.redirect('/new/:name');
        } else {
          res.redirect('/')
        }
      })
    },

    destroy: function(req,res){
      Person.remove({name: req.params.name}, function(err, name){
        res.redirect('/');
      })
    },

    show: function(req,res){
      Person.findOne({name: req.params.name}, function(err, name){
        if(name == null){
          res.json("name not found");
        } else {
          res.json(name);
        }
      })
    }
}
