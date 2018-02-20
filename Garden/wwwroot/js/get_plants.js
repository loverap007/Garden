var count = 12;
var engaged = false;

$(window).scroll(function () {
    if ($(window).scrollTop() == $(document).height() - $(window).height()) {
        if (engaged) return;
        else engaged = true;
        $.get(
            "/Library/LoadMore",
            {
                category: $("#category").html(),
                count: count
            },
            onSuccess
        );
    }
});

function onSuccess(data) {
    var container = $("#plants");
    data.forEach((item, i, arr) => {
        container.append("<div class=\"col-sm-4 col-lg-4 col-md-4\"><div class=\"thumbnail\">" +
            "<img src=\"" + "http://placehold.it/1920x1080" + "\" alt=\"\">" +
            "<div class=\"caption\"><h4>" +
            "<a asp-route=\"plant\" asp-route-id=\"" + item.id + "\">" + item.title + "</a>" +
            "</h4 ></div ></div ></div > ")
    });
    count = count + data.length;
    engaged = false;
}