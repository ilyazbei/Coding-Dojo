var api = require('./../controllers/persons.js');

module.exports = function(app){
  app.get('/names',function(req,res){
    api.index(req,res);
  });
  app.get('/new/:name/', function(req,res){
    api.create(req,res);
  });
  app.get('/remove/:name/', function(req,res){
    api.destroy(req,res);
  });
  app.get('/:name/', function(req,res){
    api.show(req,res)
  });
}
