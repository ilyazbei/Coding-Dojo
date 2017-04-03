from flask import Flask, render_template, session, request, redirect, flash
from email_val_mysqlconnection import MySQLConnector
app = Flask(__name__)
app.secret_key = 'password'

mysql = MySQLConnector(app, 'email_val')
@app.route('/')
def index():
    EmailValidation = mysql.query_db("SELECT * FROM email")
    return render_template('email_val_index.html')

@app.route('/email', methods=['POST'])
def succes():
    EmailValidation = mysql.query_db("SELECT * FROM email")
    print EmailValidation
    print request.form['email']
    errors = False
    if request.form['email'] != 'email':
        errors = True
        flash("Email is not valid!")
    if errors:
        return redirect('/')

    session['email'] = request.form['email']

    return redirect('/success')

app.run(debug=True)
