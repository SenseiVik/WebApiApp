var token

$("#signin").on("click", function () {
    var loginData = {
        grand_type: "password",
        Email: $("#signInEmail").val(),
        Password: $("#signInPassword").val()
    };

    $.ajax({
        type: "POST",
        url: "/Token",
        data: loginData,

        success: function () {

        },

        error: function () {

        }
    });
});

$("#register").on("click", function () {
    let data = {
        Email: $('#registerEmail').val(),
        Password: $('#registerPassword').val(),
        ConfirmPassword: $('#confirmRegisterPassword').val()
    };

    $.ajax({
        type: "POST",
        url: "/api/Account/Register",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),

        success: function (data) {
            alert("Done");

            window.location.href = "/Home/Index";
        },

        error: function (data) {
            alert(data.responseText);
        }
    });

});
