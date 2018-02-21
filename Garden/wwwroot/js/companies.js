$(document).ready(function () {
    $(".btn-delete").click(function (event) {
        $("#btn-delete").attr("href", "/Admin/DeleteCompany?id=" + $(this).attr("btn-data"));
    });
    $(".btn-confirm").click(function (event) {
        $("#btn-confirm").attr("href", "/Admin/ConfirmCompany?id=" + $(this).attr("btn-data"));
    });
});