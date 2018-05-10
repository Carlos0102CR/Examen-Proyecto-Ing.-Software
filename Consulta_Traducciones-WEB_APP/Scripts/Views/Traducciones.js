function Traducciones() {
    this.ctrlActions = new ControlActions();
    this.tblPalabrasId = "tblPalabrasTraducidas";
    this.service = 'api/traducciones/Get/';

    this.Get = function () {
        var getService = "api/usuario/GetMostTraduccionUsuario/";
        var url = this.ctrlActions.GetUrlApiService(getService);
        var info;

        $.ajax({
            type: 'GET',
            async: false,
            url: url,
            dataType: 'json',
            data: {},
            error: function (result) {
                console.log(result);
            },
            success: function (result) {
                info = result.Data;
            }
        });

        this.setUsuario(info);
    };

    this.setUsuario = function (info) {
        $("#usuario").text(info['Nombre']);
    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblPalabrasId);
    }
}

$(document).ready(function () {
    var traducciones = new Traducciones();
    traducciones.RetrieveAll();
    traducciones.Get();
});