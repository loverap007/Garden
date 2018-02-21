$(document).ready(function () {
    $(".btn-delete").click(function (event) {
        $("#btn-confirm").attr("href", "/Manage/DeleteOffer?id=" + $(this).attr("btn-data"));
    });
});