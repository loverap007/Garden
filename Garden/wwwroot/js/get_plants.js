$(window).scroll(function () {
    if ($(window).scrollTop() == $(document).height() - $(window).height()) {
        $.get(
            "/Library/LoadMore",
            {
                category: $("#category").html(),
                count: $("#count").html()
            },
            onSuccess
        );
    }
});

function onSuccess(data) {
    alert(data);
}