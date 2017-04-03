var mongoose = require('mongoose');

var UserSchema = new mongoose.Schema( {
  name: { type: String, require: true, minlength: 3 },
  email: { type: String, require: true }
});


mongoose.model('User', UserSchema);
