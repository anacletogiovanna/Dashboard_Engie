$(function () {
    $.get('Home/GraphTypes').done(function (solicitacoes) {
        //transform in json 
        $(solicitacoes).each(function (item) {
            console.log("{" + solicitacoes[item] + ":" + solicitacoes[0] +  "}");
        });

        console.log(solicitacoes[0][1], solicitacoes[1][1], solicitacoes[2][1], solicitacoes[3][1], solicitacoes[4][1]);
        var count_label = 0;
        var count_values = 0;
        var ctx = document.getElementById('tipoSolicitacao').getContext('2d');
        var chart = new Chart(ctx, {
            // The type of chart we want to create
            type: 'pie',
            // The data for our dataset
            data: {
                datasets: [{
                    backgroundColor: ['rgb(255, 73, 92)', 'rgb(57, 147, 221)', 'rgb(61, 220, 151)', 'rgb(255, 73, 92)' ],
                    data:[
                        solicitacoes[0][1], solicitacoes[1][1], solicitacoes[2][1], solicitacoes[3][1], solicitacoes[4][1]
                    ]
                }]
            },

            // Configuration options go here
            options: {
                
            }

        });

        //iterando sobre os dados que eu pego 
        
    });
});

var ctx = document.getElementById('myChart').getContext("2d");

var myChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["06:00:12", "06:02:00", "06:03:10", "06:04:12", "06:05:06", "06:07:10", "06:08:20"],
        datasets: [{
            label: "Data",
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
            data: [20, 10, 50, 77, 90, 20, 10]
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

$('.menu-toggle').on('click', function () {
    $('body').toggleClass('menu-open');
});