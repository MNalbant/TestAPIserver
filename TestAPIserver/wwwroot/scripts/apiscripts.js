function func1() {
    var user = {
        FirstName: $("#FirstName").val(),
        LastName: $("#LastName").val(),
        Mail: $("#Email").val(),
        Password: $("#Password").val()
    };
    var l = JSON.stringify(user);

    var settings = {
        "async": true,
        "crossDomain": true,
        "url": "https://localhost:44387/api/users",
        "method": "POST",
        "headers": {
            "Content-Type": "application/json",
            "cache-control": "no-cache"
        },
        "processData": false,
        "data": l
    };

    $.ajax(settings).done(function (response) {
        console.log(response);
    });
}