const ErrorGenerator = {};

ErrorGenerator.createError = (field, kind, message) => {
    return JSON.parse(`{
        "errors": {
            "${field}": {
                "kind": "${kind}",
                "message": "${message}"
            }
        }
    }`);
};

module.exports = ErrorGenerator;
