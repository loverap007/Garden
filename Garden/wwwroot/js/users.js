$(document).ready(function () {
    $(".btn-delete").click(function (event) {
        $("#btn-confirm").attr("href", "/Admin/DeleteUser?id=" + $(this).attr("btn-data"));
    });
    $(".btn-role").click(function (event) {
        $("#btn-role").attr("href", "/Admin/ChangeRole?id=" + $(this).attr("btn-data"));
    });
});