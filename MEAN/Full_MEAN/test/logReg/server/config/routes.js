var user = require('./../controllers/users.js')
var topic = require('./../controllers/dash.js')

module.exports = function(app) {
  app.post('/login', function(req, res) {
    // console.log(req.body)
    user.login(req, res);
  })
  app.get('/checkstatus', function(req, res) {
    user.checkStatus(req, res);
  })
  app.get('/logout', function(req, res) {
    user.logout(req, res);
  })
  app.get('/dashboard', function(req, res) {
    topic.getTopics(req, res);
  })
  app.post('/submitTopic', function(req, res) {
    // console.log(req.body, "submit routes");
    topic.submitTopic(req, res);
  })
}
