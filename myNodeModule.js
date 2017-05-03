//module.exports = function (callback) {
//    // In this trivial example, we don't need to receive any 
//    // parameters - we just send back a string 

//    var message = 'Hello from Node at ' + new Date().toString();
//    callback(/* error */ null, message);

//};

var generate = require('node-chartist');

module.exports = function (callback, type, options, data) {
    generate(type, options, data).then(
        result => callback(null, result), // Success case
        error => callback(error)          // Error case
    );
};