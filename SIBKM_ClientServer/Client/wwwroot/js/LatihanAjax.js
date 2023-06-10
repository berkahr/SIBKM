
$.ajax({
    url: "https://pokeapi.co/api/v2/pokemon", //OpenAPI
    //success: function (result) {
    //    // console.log(result.results);
    //    var temp = "";
    //    $.each(result.results, (key, val) => {
    //        temp += "<li>" + val.name + "</li>";
    //    })
    //    console.log(temp);
    //    $("#listPoke").html(temp);
    //}

}).done((result) => {
    var temp = "";

    $.each(result.results, (key, val) => {
        temp += `<tr>
            <td>${key + 1}</td>
            <td>${val.name}</td>
            <td><button type="button" class="btn btn-primary" onclick="detail('${val.url}')" data-bs-toggle="modal" data-bs-target="#modalPoke">Detail</button></td>
        </tr>`
    })
    $("#tbodyPoke").html(temp);

}).fail((error) => {
    console.log(error);
})

function detail(stringUrl) {
    $.ajax({
        url: stringUrl
    }).done(function (res) {
        console.log(res);
        $("#pokeName").text(res.name);
        $("#pokeImage").attr("src", res.sprites.front_default);
        $("#modalPoke").modal("show");
        $("#pokeHp").text("HP : " + res.stats[0].base_stat);
        $("#pokeAtk").text("Attack : " + res.stats[1].base_stat);
        $("#pokeDef").text("Defense : " + res.stats[2].base_stat);
        $("#pokeSA").text("S.Attack : " + res.stats[3].base_stat);
        $("#pokeSD").text("S.Defense : " + res.stats[4].base_stat);
        $("#pokeSpd").text("Speed : " + res.stats[5].base_stat);
        $("#pokeAbility").text("Abilitiy : " + res.abilities[0].ability.name);
        $("#pokeMove").text("Move : " + res.moves[0].move.name);
        $("#pokeHeight").text("Height : " + res.height);
        $("#pokeWeight").text("Weight : " + res.weight);
    });
}
