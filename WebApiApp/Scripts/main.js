//var tokenKey = "tokenInfo";

//$("#getAllBtn").on("click", function () {

//    $.ajax({
//        url: "http://localhost:61089/api/dateranges",
//        type: "GET",
//        headers: { "Authorization": `Bearer ${localStorage.getItem(tokenKey)}` },

//        success: function (data) {
//            let obj = JSON.parse(data);
//            alert("kek");

//            for (let i = 0; i < obj.length; i++) {
//                let elem = $("<div></div>").addClass("").text(`${obj[i].from} - ${obj[i].to}`);

//                $("#getAllContent").append(elem);
//            }

//        },

//        error: function (data) {

//        }
//    });
//});