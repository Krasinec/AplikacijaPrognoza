$('select[id="forma_statistikaZa"]').change(function () {
    if ($(this).val() == "Mjesec") {
        $('#forma_mjesec').show();
        $('#mjesecLab').show();
        $('#mjesecErr').show();
    } else {
        $('#forma_mjesec').hide();
        $('#mjesecLab').hide();
        $('#mjesecErr').hide();
    }
})