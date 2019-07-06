// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

var ctx = document.getElementById('solicitacoesChart').getContext('2d');
var chart = new Chart(ctx, {
    // The type of chart we want to create
    type: 'pie',

    // The data for our dataset
    data: { 
        datasets: [{
            backgroundColor: [
                'rgb(255, 99, 132)',
                'rgb(205, 19, 162)',
                'rgb(155, 99, 232)'
            ],
            data: [0, 10, 5, 2, 20, 30, 45]
        }],
        labels: [
            'Red', 
            'Yellow', 
            'Blue'
        ]
    },

    // Configuration options go here
    options: {}
});

var ctx = document.getElementById('tipoSolicitacao').getContext('2d');
var chart = new Chart(ctx, {
    // The type of chart we want to create
    type: 'pie',

    // The data for our dataset
    data: {
        datasets: [{
            label: 'My First dataset',
            backgroundColor: 'rgb(255, 99, 132)',
            borderColor: 'rgb(255, 99, 132)',
            data: [0, 10, 5, 2, 20, 30, 45]
        }]
    },

    // Configuration options go here
    options: {}
});