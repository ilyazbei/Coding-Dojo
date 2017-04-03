console.log('friends model');
var mongoose = require('mongoose');
// build your friend schema and add it to the mongoose.models
var FriendSchema = new mongoose.Schema({
  firstName: { type: String, required: true, minlength: 2 },
  lastName: { type: String, required: true, minlength: 2 },
  birthDay: { type: Date, default: Date.now },
}, { timestamps: true });

var Friend = mongoose.model('Friend', FriendSchema);
