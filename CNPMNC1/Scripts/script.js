function Changelmage(Uploadlmage, previewImg) {
    if (Uploadlmage.files && Uploadlmage.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImg).attr('src', e.target.result);
            reader.readAsDataURL(Uploadlmage.files[0]);
        }
    }
}