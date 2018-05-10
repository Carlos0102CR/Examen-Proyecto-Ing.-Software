function TraduccionesDisponibles() {
    this.ctrlActions = new ControlActions();
    this.tblTraduccionesId = "tblTraducciones";
    this.service = 'api/traducciones/Get/';
    var self = this;

    this.GetData = function () {
        return sessionStorage.getItem('palabraSeleccionada');
    }

    this.setPalabra = function (info) {
        $("#nombrePalabra").text("Traducciones de la palabra '" + this.GetData() + "', hechas por usuarios");
    }

    this.RetrieveAll = function () {
        debugger;
        this.ctrlActions.FillTable(this.service + this.GetData(), this.tblTraduccionesId);
    }
}

$(document).ready(function () {
    var traduccionesDisponibles = new TraduccionesDisponibles();
    traduccionesDisponibles.setPalabra();
    traduccionesDisponibles.RetrieveAll();
});