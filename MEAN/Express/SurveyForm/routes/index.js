module.exports = function Route(app) {
  // root route to render the index.ejs view
  app.get("/", function(req, res) {
    res.render("index");
  })
  // post route for adding a user
  app.post('/result', function(req, res) {
    // This is where we would add the user to the database
    form = {
      name: req.body.name,
      location: req.body.location,
      language: req.body.language,
      comment: req.body.comment
    };
    // Then redirect to the root route
    res.render("result", {result: form});
  })
};
