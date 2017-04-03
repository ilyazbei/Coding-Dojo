var animals = require('../controllers/animals.js');
module.exports = function(app) {
  // Routes go here!
  app.get('/', function(req, res) {
    animals.index(req, res);
  });
  // Create
  app.post('/', function(req, res) {
    animals.create(req, res);
  });
  // New
  app.get('/new', function(req, res){
    res.render('new');
  });
  // Show
  app.get('/:id/show/', function(req, res){
    animals.show(req, res);
  });
  // Edit
  app.get('/:id/edit/', function(req, res){
    animals.find(req, res);
  });
  // Update
  app.post('/:id', function(req, res){
    animals.update(req, res);
  });
  // Delete
  app.post('/:id/delete', function(req, res){
    animals.remove(req, res);
  });
}
