// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

$(document).ready(function () {
    $('#tabela-formandos').DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registo encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registos",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registos",
            "sInfoFiltered": "(Filtrar de _MAX_ total registos)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registos por página",
            "sLoadingRecords": "Carregando os dados ...",
            "sProcessing": "Processando os dados ...",
            "sZeroRecords": "Nenhum registo encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Seguinte",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Último"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
});