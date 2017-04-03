var user = require('./../controllers/users.js')
module.exports = function(app) {
  app.post('/register', function(req, res) {
    user.register(req, res);
  })
}
