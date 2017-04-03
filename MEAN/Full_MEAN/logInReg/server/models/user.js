var mongoose = require('mongoose');
var UserSchema = new mongoose.Schema( {
  firstName: { type: String, require: true, minlength: 3 },
  lastName: { type: String, require: true, minlength: 3 },
  email: { type: String, require: true },
  password: { type: String, require: true }
  
});


mongoose.model('User', UserSchema);
