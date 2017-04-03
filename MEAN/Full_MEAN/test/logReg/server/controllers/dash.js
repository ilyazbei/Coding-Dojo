var mongoose = require('mongoose');
var Topic = mongoose.model('Topic');

module.exports = {
  submitTopic: function(req, res) {
    toTopic = new Topic(req.body);
    toTopic.save(function(err) {
      res.json(err);
    })
  },

  getTopics: function(req, res) {
    Topic.find({}, function(err, data) {
      if(err) {
        res.json(err)
      }else{ res.json(data) }
    })
  }
}
