function Palabras() {
    this.ctrlActions = new ControlActions();
    this.tblpalabrasId = "tblPalabras";
    this.service = 'api/frase/Get';
    this.$btnViewTraducciones = $("#btnViewTraducciones");
    this.$btnView = $("#btnViewPalabras");

    this.ControlButtons = function () {
        var palabra = this.GetData();
        if (palabra === null || palabra === undefined || palabra === "") {
            this.$btnViewTraducciones.prop('disabled', true);
            this.$btnView.prop('disabled', true);
        } else {
            this.$btnViewTraducciones.prop('disabled', false);
            this.$btnView.prop('disabled', false);
        }
    };

    this.GetData = function () {
        return sessionStorage.getItem('palabraSeleccionada');
    };

    this.RetrieveAll = function () {
        this.ControlButtons();
        this.ctrlActions.FillTable(this.service, this.tblpalabrasId);
    }

    this.savePalabra = function (data) {
        sessionStorage.setItem('palabraSeleccionada', data['Palabra']);;
        this.ControlButtons();
    }

    this.ChangeView = function () {
        var palabra = this.GetData();
        window.location.replace("/Home/PalabrasDisponibles/" + palabra);
    }

    this.ChangeViewTraducciones = function () {
        var palabra = this.GetData();
        window.location.replace("/Home/TraduccionesDisponibles/" + palabra);
    }

}

$(document).ready(function () {
    var palabras = new Palabras();
    palabras.RetrieveAll();
    sessionStorage.clear('palabraSeleccionada');
});