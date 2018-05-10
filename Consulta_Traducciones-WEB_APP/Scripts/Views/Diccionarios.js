function Diccionarios() {
    this.ctrlActions = new ControlActions();
    this.tblPalabrasId = "tblPalabrasTraducidas";
    this.service = 'api/fraseTraducida/GetByIdioma/';
    var self = this;

    this.GetData = function () {
        return sessionStorage.getItem('nombreIdioma');
    }

    this.setIdioma = function (info) {
        $("#nombreIdioma").text("Diccionario de "+this.GetData()+" a español");
    }

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service + this.GetData(), this.tblPalabrasId);
    }
}

$(document).ready(function () {
    var diccionarios = new Diccionarios();
    diccionarios.setIdioma();
    diccionarios.RetrieveAll();
});