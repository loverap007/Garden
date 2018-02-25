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
        var src = item.avatar != null ? item.avatar : "http://placehold.it/200x300";
        container.append("<div class=\"col-sm-4 col-lg-4 col-md-4\"><div class=\"thumbnail\">" +
            "<img src=\"" + src + "\" alt=\"\" style=\"height: 300px\">" +
            "<div class=\"caption\"><h4>" +
            "<a href=\"/Plant?id=" + item.id + "\">" + item.title + "</a>" +
            "</h4 ></div ></div ></div > ");
    });
    count = count + data.length;
    engaged = false;
}