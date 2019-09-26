var tokenKey = "tokenInfo";

$("#signin").on("click", function () {
    var loginData = {
        grant_type: "password",
        username: $("#signInEmail").val(),
        password: $("#signInPassword").val()
    };

    $.ajax({
        type: "POST",
        url: "/Token",
        data: loginData,

        success: function (data) {
            $('.userName').text(data.userName);

            sessionStorage.setItem(tokenKey, data.access_token);

            window.location.href = "/Home/Index";
        },

        error: function (data) {
            alert(data.responseText);
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

            window.location.href = "/Auth/LogIn";
        },

        error: function (data) {
            alert(data.responseText);
        }
    });

});

$("#logOut").click(function () {

    $.ajax({
        url: "/api/Account/Logout",
        type: "POST",
        contentType: "application/json",
        beforeSend: function (xhr) {
            var token = sessionStorage.getItem(tokenKey);
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        },

        success: function (data) {
            sessionStorage.removeItem(tokenKey);
            window.location.href = "/Auth/LogIn";
        },

        error: function (data) {
            alert(data.responseText);
        }
    });

});
