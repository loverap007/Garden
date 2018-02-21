$(document).ready(function () {
    $(".btn-delete").click(function (event) {
        $("#btn-delete").attr("href", "/Manage/DeleteOffer?id=" + $(this).attr("btn-data"));
    });
});