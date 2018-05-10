function PalabrasPopulares() {
    this.ctrlActions = new ControlActions();
    this.tblpalabrasId = "tblPalabras";
    this.service = 'api/frase/GetMostPopular';

    this.RetrieveAll = function () {
        this.ctrlActions.FillTable(this.service, this.tblpalabrasId);
    }
}

$(document).ready(function () {
    var palabrasPopulares = new PalabrasPopulares();
    palabrasPopulares.RetrieveAll();
});