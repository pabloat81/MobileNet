fs = require('fs');
eco = require("eco");

(function() {
    fs.readFile(process.argv[2], function (err, data) {
        if (err) {
            console.error("Could not open file: %s", err);
            process.exit(1);
        }

        process.stdout.write("module.exports = (" + eco.compile( data.toString() ) + ");");
    });
}).call(this);

