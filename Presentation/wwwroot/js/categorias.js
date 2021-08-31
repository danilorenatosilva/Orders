
window.onload = function () {

    function carregaCamposForm(id) {
        $.get("https://localhost:44320/api/categorias/" + id, function (data) {
            document.getElementById("nome").value = data.nome;
            document.getElementById("descricao").value = data.descricao;
        });
    }

    function carregaFormCategoria(id) {

        let editando = id != undefined;        

        $("#conteudo").html('');

        let caminhoFisicoImagens = document.getElementById('caminhoFisicoImagens').value;
        let titulo = editando ? "Editar Categoria" : "Nova Categoria";
        let metodoHttp = editando ? "PUT" : "POST";

        let html =
            "<div class='container-form'>" +
            "<h2>" + titulo + "</h2>" +
            "<form id='formCategoria' enctype='multipart/form-data' method='post'>" +
            "<div class='form-group'>" +
            "<label for='nome'>Nome</label>" +
            "<input type='text' name='nome' id='nome' class='form-control' /> " +
            "</div>" +
            "<div class='form-group'>" +
            "<label for='nome'>Descricao</label>" +
            "<textarea name='descricao' id='descricao' class='form-control' rows='4'></textarea>" +
            "</div>" +
            "<div class='form-group'>" +
            "<label for='urlImagem'>Imagem</label>" +
            "<input type='file' class='form-control-file' name='arquivoImagem' id='arquivoImagem' accept='image/*' />" +
            "</div>" +
            "<button type='submit' class='btn btn-primary'>Salvar</button>" +
            "<button id='btnCancelar' class='btn btn-danger'>Cancelar</button>" +
            "<input type='hidden' name='caminhoFisicoImagens' value='" + caminhoFisicoImagens + "' />";

        if (editando) {
            html += "<input type='hidden' value='"+id+"' name='id' />";
        }

        html += "</form></div>";

        $("#conteudo").html(html);

        let btnCancelar = document.getElementById("btnCancelar");
        btnCancelar.onclick = function (e) {
            e.preventDefault();
            carregaCategorias();
        };

        if (editando) {
            carregaCamposForm(id);
        }

        $('#formCategoria').on('submit', (function (e) {
            e.preventDefault();

            let formData = new FormData(this);

            $.ajax({
                type: metodoHttp,
                url: "https://localhost:44320/api/categorias",
                data: formData,
                processData: false,
                contentType: false,
                success: function (data) {
                    carregaCategorias();
                },
                error: function (error) {
                    console.log(error.responseText);
                }
            });
        }));
    }

    function carregaCategorias() {

        $.ajax({
            type: "GET",
            url: "https://localhost:44320/api/categorias",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                $("#conteudo").html('');
                let html = "<div class='row'>";
                $.each(data, function (i, item) {
                    html += "<div class='col-md-3 card'>" +
                        "<img src='" + item.urlImagem + "' height='200' />" +
                        "<div class='botoes'>" +
                        "<a href='#' class='btn btn-info btn-lg editarCategoria' id='editarCategoria-" + item.id + "'>"  +
                            "<span class='glyphicon'></span> Editar" +
                        "</a>" +
                        "<a href='#' class='btn btn-danger btn-lg deletarCategoria' id='deletarCategoria-" + item.id + "'>" +
                            "<span class='glyphicon'></span> Deletar" +
                        "</a>" +
                        "</div>" +
                        "<span class='card-footer'>" + item.nome + "</span>" +
                        "</div>";
                });
                html += "</div>";

                $("#conteudo").append(html);

                let botoesEdicao = document.getElementsByClassName('editarCategoria');
                for (let i = 0; i < botoesEdicao.length; i++) {                    
                    botoesEdicao[i].onclick = function () {
                        let id = $(this).attr("id").split('-')[1];                        
                        carregaFormCategoria(id);
                    };
                }

                let botoesDelecao = document.getElementsByClassName('deletarCategoria');
                for (let i = 0; i < botoesDelecao.length; i++) {
                    botoesDelecao[i].onclick = function () {
                        let id = $(this).attr("id").split('-')[1];
                        let resposta = confirm("Tem certeza que deseja excluir esta categoria?");
                        if (resposta) {
                            $.ajax({
                                type: "DELETE",
                                url: "https://localhost:44320/api/categorias/" + id,
                                success: function (data) {
                                    carregaCategorias();
                                },
                                error: function (error) {
                                    alert(error.responseText);
                                }
                            });
                        }
                    };
                }
            },
            failure: function (data) {
                alert("failure");
            },
            error: function (data) {
                alert("error");
            }
        });
    }

    carregaCategorias();

    let btnAdicionar = document.getElementById("adicionarCategoria");
    btnAdicionar.onclick = function () {
        carregaFormCategoria();
    };

}