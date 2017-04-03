var mongoose = require('mongoose');

var TopicSchema = new mongoose.Schema( {
  topic: { type: String, require: true },
  description: { type: String, require: true }
})

mongoose.model('Topic', TopicSchema);
