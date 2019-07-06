// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

//var ctx = document.getElementById('solicitacoesChart').getContext('2d');
//var chart = new Chart(ctx, {
//    // The type of chart we want to create
//    type: 'pie',

//    // The data for our dataset
//    data: { 
//        datasets: [{
//            backgroundColor: [
//                'rgb(255, 99, 132)',
//                'rgb(205, 19, 162)',
//                'rgb(155, 99, 232)'
//            ],
            
//            data: [0, 10, 5, 2, 20, 30, 45]
//        }],
//        labels: [
//            'Red', 
//            'Yellow', 
//            'Blue'
//        ]
//    },

//    // Configuration options go here
//    options: {}
//});

var ctx = document.getElementById('tipoSolicitacao').getContext('2d');
var chart = new Chart(ctx, {
    // The type of chart we want to create
    type: 'pie',

    // The data for our dataset
    data: {
        datasets: [{
            label: 'My First dataset',
            backgroundColor: ['rgb(254, 72, 72)', 'rgb(255, 256, 288)', 'rgb(255, 256, 288)'],
            borderColor: 'rgb(255, 99, 132)',
            data: [0, 10, 5, 2, 20, 30, 45]
        }]
    },

    // Configuration options go here
    options: {}
});

//var myLineChart = new Chart(ctx, {
//    type: 'line',
//    data: [{
//        x: 10,
//        y: 20
//    }, {
//        x: 15,
//        y: 10
//        }],

//    options: {
//        scales: {
//            yAxes: [{
//                stacked: true
//            }]
//        }
//    }
//});

var ctx = document.getElementById('myChart').getContext("2d");

var myChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["06:01:00", "06:02:30", "06:03:00", "06:05:50", "06:06:10", "06:07:00", "06:09:00"],
        datasets: [{
            label: "Solicitações",
            borderColor: "#80b6f4",
            pointBorderColor: "#80b6f4",
            pointBackgroundColor: "#80b6f4",
            pointHoverBackgroundColor: "#80b6f4",
            pointHoverBorderColor: "#80b6f4",
            pointBorderWidth: 10,
            pointHoverRadius: 10,
            pointHoverBorderWidth: 1,
            pointRadius: 3,
            fill: false,
            borderWidth: 4,
            data: [10, 13, 6, 18, 77, 2, 10]
        }]
    },
    options: {
        legend: {
            position: "bottom"
        },
        scales: {
            yAxes: [{
                ticks: {
                    fontColor: "rgba(0,0,0,0.5)",
                    fontStyle: "bold",
                    beginAtZero: true,
                    maxTicksLimit: 5,
                    padding: 20
                },
                gridLines: {
                    drawTicks: false,
                    display: false
                }

            }],
            xAxes: [{
                gridLines: {
                    zeroLineColor: "transparent"
                },
                ticks: {
                    padding: 20,
                    fontColor: "rgba(0,0,0,0.5)",
                    fontStyle: "bold"
                }
            }]
        }
    }
});