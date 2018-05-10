function Index() {
    this.ctrlActions = new ControlActions();
    this.tblIdiomasId = "tblIdiomas";
    this.service = 'api/idioma/Get';
    this.$btnView = $("#btnViewDiccionario");

    this.Get = function () {
        var getService = "api/idioma/GetMostPopular";
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

        this.setIdiomaPopular(info);
    };

    this.setIdiomaPopular = function (info) {
        $("#idiomaPopular").attr("href", "Home/Diccionarios/" + info['Nombre']);
        $("#nombreIdiomaPopular").text(info['Nombre']);
    }
    
    this.ControlButtons = function () {
        var nombreIdioma = this.GetData();
        if (nombreIdioma === null || nombreIdioma === undefined || nombreIdioma === "") {
            this.$btnView.prop('disabled', true);
        } else {
            this.$btnView.prop('disabled', false);
        }
    };

    this.GetData = function () {
        return sessionStorage.getItem('nombreIdioma');
    };

    this.RetrieveAll = function () {
        this.ControlButtons();
        this.ctrlActions.FillTable(this.service, this.tblIdiomasId);
    }

    this.SaveId = function (data) {
        sessionStorage.setItem('nombreIdioma',data['Nombre']);;
        this.ControlButtons();
    }

    this.ChangeViewDiccionario = function () {
        var nombreIdioma = this.GetData();
        window.location.replace("/Home/Diccionarios/" + nombreIdioma);
    }

}

$(document).ready(function () {
    var index = new Index();
    index.RetrieveAll();
    index.Get();
    sessionStorage.clear('nombreIdioma');
});

