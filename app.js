const express = require('express');
const app = express();
const axios = require('axios');
var request = require('request');
app.use(express.static(__dirname + '/public'));
app.engine('html', require('ejs').renderFile);

app.get('/', function (req, res, next) {
    res.render('app.html');
    next()
})

app.get('/demo', function (req, res) {
    res.render('demo.html');
    next()
})


app.get('/swapi', function (req, res) {
    axios.get('https://swapi.co/api/people')
        .then(function (response) {
            res.render('swapi.html', { data: response.data.results })
        })
        .catch(function (error) {
            console.log(error);
        });
})

app.get('/swapi/search', function(req, res) {
    request('https://swapi.co/api/people/?search=' + req.query.query, function (error, response, body) {
        res.setHeader('Content-Type', 'application/json');
        res.send(body)
    });
})

app.listen(8080, function () {
    console.log('Running on port 8080.')
})