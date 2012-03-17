log = function (text, color, isError) {
    var output, stream;
    if (color == null) color = 'green';
    if (isError == null) isError = false;
    stream = isError ? process.stderr : process.stdout;
    output = text + "\n";
    stream.write(output, 'utf8');
    if (isError) {
        return growl(text, {
            title: 'Brunch error'
        });
    }
};

(function (port, rootPath, callback) {
    express = require('express');    

    var server;
    if (process.argv[2]) port = process.argv[2]; else port = 4000;
    if (process.argv[3]) rootPath = process.argv[3]; else rootPath = '.';
    
    if (callback == null) callback = (function () { });
    server = express.createServer();
    server.configure(function () {
        server.use(express.static(rootPath));
        server.set('views', rootPath);
        return server.set('view options', {
            layout: false
        });
    });
    server.get('/', function (req, res) {
        return res.render('index.html');
    });
    server.listen(parseInt(port, 10));
    server.on('listening', callback);
    
    //TODO
    return log("Application starting on http://0.0.0.0:" + port + ".");
}).call(this);