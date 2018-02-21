$(document).ready(function () {
    $(".btn-delete").click(function (event) {
        $("#btn-confirm").attr("href", "/Manage/DeleteCompany?id=" + $(this).attr("btn-data"));
    });
});