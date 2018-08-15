
// -- function de rechargement de la table -- //
function ggRechargerTable(page, id_div) {

    // -- Ajax -- //
    $.ajax({
        type: "GET",
        url: '/Garage/Charger_Table',
        data: {
            page: page
        }
    })
    .done(
        function (resultat) {
            // -- Mise à jour du div -- //
            $('#' + id_div).html(resultat);
        }
    );

}

// -- function de rechargement de la table -- //
function ggSupprimerTable(id, id_div, page) {

    // -- Ajax -- //
    $.ajax({
        type: "POST",
        url: '/Garage/Supprimer_Enregistrement',
        data: {
            id: id,
            page: page
        },
        success: function (resultat) {
            // -- Tester si le traitement s'est bien effectué -- //
            if (resultat.exception == null) {
                // -- Vider le formulaire -- //
                form[0].reset();
                $('#id').val('0');
                // -- Actualiser la table -- //
                ggRechargerTable(page, id_div);
            }
            else {
                // -- Afficher une alerte sur un element -- //
                alert(resultat.exception);
            }
        },
        error: function () {
            // -- Afficher une alerte sur un element -- //
            alert('Une erreur est survenue');
        }
    });

}

// -- Fonction native -- //
try {

    // -- Convertir un formulaire en JSon -- //
    $.fn.ggConvertToJSON = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return o;
    };

} catch (e) { gbConsole(e.message); }