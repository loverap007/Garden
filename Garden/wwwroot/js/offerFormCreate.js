var companies;

function offerFormCreate(data) {
    companies = data.responseJSON;
    var select = $("#company-select").empty();
    companies.forEach((item, i, arr) => {
        select.append("<option value=\"" + item.id + "\">" + item.title + "</option>");
    });
    if (companies[0].avatar != null) $("#new-offer-img").attr("src", companies[0].avatar);
    $("#new-offer-company-title").html(companies[0].description);
    $("#new-offer-conteiner").removeAttr("hidden");
}

function onCompanyChange() {
    var select = $("#company-select");
    for (i = 0; i < companies.length; i++) {
        if (companies[i].id == select.val()) {
            if (companies[i].avatar != null) $("#new-offer-img").attr("src", companies[i].avatar);
            else $("#new-offer-img").attr("src", "");
            $("#new-offer-company-title").html(companies[i].description);
        }
    }
}

function cancelButton() {
    $("#new-offer-conteiner").attr("hidden", "true");
}