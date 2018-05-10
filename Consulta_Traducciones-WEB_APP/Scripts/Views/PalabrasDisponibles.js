function PalabrasDisponibles() {
    this.ctrlActions = new ControlActions();
    this.tblPalabrasId = "tblPalabrasTraducidas";
    this.service = 'api/fraseTraducida/GetByPalabra/';
    var self = this;

    this.GetData = function () {
        return sessionStorage.getItem('palabraSeleccionada');
    }

    this.setPalabra = function (info) {
        $("#nombrePalabra").text("Traducciones disponibles de la palabra '" + this.GetData() + "'");
    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service + this.GetData(), this.tblPalabrasId);
    }
}

$(document).ready(function () {
    var palabrasDisponibles = new PalabrasDisponibles();
    palabrasDisponibles.setPalabra();
    palabrasDisponibles.RetrieveAll();
});