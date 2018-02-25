Dropzone.options.myDropzone = {
    url: "/Admin/AddPlant",
    autoProcessQueue: false,
    uploadMultiple: true,
    parallelUploads: 100,
    maxFiles: 100,
    acceptedFiles: "image/*",

    init: function () {

        var submitButton = document.querySelector("#submit-all");
        var resetButton = document.querySelector("#reset");
        var wrapperThis = this;

        resetButton.addEventListener("click", () => {
            wrapperThis.removeAllFiles();
        })

        submitButton.addEventListener("click", function () {
            wrapperThis.processQueue();
        });

        this.on("addedfile", function (file) {
            var removeButton = Dropzone.createElement("<button class='btn btn-m dark'>Remove File</button>");
            removeButton.addEventListener("click", function (e) {
                e.preventDefault();
                e.stopPropagation();
                wrapperThis.removeFile(file);
            });
            file.previewElement.appendChild(removeButton);
        });

        this.on('sendingmultiple', function (data, xhr, formData) {

            formData.append("Name", $("#Name").val());
            formData.append("Type", $("#category-select").val());
            formData.append("Description", $("#Description").val());
        });
    }
};