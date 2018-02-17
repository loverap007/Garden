$(document).on('click', '[data-toggle="lightbox"]', function (event) {
    event.preventDefault();
    $(this).ekkoLightbox();
});

$(document).ready(function () {
    $(".btn-delete").click(function (event) {
        $("#btn-confirm").attr("href", "/Manage/DeleteCompany?id=" + $(this).attr("btn-data"));
    });
});