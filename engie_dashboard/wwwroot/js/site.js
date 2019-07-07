$(function () {
    $.get('Home/GraphTypes').done(function (solicitacoes) {
        //transform in json 
        $(solicitacoes).each(function (item) {
            console.log("{" + solicitacoes[item] + ":" + solicitacoes[0] +  "}");
        });

        console.log(solicitacoes[0][1], solicitacoes[1][1], solicitacoes[2][1], solicitacoes[3][1], solicitacoes[4][1] );
        var count_label = 0;
        var count_values = 0;
        var ctx = document.getElementById('tipoSolicitacao').getContext('2d');
        var chart = new Chart(ctx, {
            // The type of chart we want to create
            type: 'pie',
            // The data for our dataset
            data: {
                labels: [solicitacoes[0][0], solicitacoes[1][0], solicitacoes[2][0], solicitacoes[3][0], solicitacoes[4][0]
                ],

                datasets: [{
                    backgroundColor: ['rgb(255, 73, 92)', 'rgb(57, 147, 221)', 'rgb(61, 220, 151)', 'rgb(255, 73, 92)' ],
                    data:[
                        solicitacoes[0][1], solicitacoes[1][1], solicitacoes[2][1], solicitacoes[3][1], solicitacoes[4][1]  
                    ]
                }]
            },
            
            // Configuration options go here
            options: {
                legend: {
                    position: "top",
                    display: "true",
                    labels: {
                        fontSize: 24
                    }
                }
            }

        });

        //iterando sobre os dados que eu pego 
        
    });
});

var ctx = document.getElementById('myChart').getContext("2d");

var myChart = new Chart(ctx, {
    type: 'line',
    data: {
        labels: ["00:00:12", "01:02:00", "02:03:10", "03:04:12", "04:05:06", "05:07:10", "06:08:20",
            "07:00:12", "08:02:00", "09:03:10", "10:04:12", "11:05:06", "12:07:10", "13:08:20", "14:08:20",
            "15:00:12", "16:02:00", "17:03:10", "18:04:12", "19:05:06", "20:07:10", "21:08:20",
            "22:08:10", "23:00:10"],
        datasets: [{
            label: "USUHCB",
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
            data: [84,46,54,11,61,98,29,2,4,79,51,89,5,50,44,81,48,37,6,80,44,6,38, 19]
        }, {
                label: "UHSO",
                borderColor: "#81C14B",
                pointBorderColor: "#81C14B",
                pointBackgroundColor: "#81C14B",
                pointHoverBackgroundColor: "#81C14B",
                pointHoverBorderColor: "#81C14B",
                pointBorderWidth: 10,
                pointHoverRadius: 10,
                pointHoverBorderWidth: 1,
                pointRadius: 3,
                fill: false,
                borderWidth: 4,
                data: [33, 29, 78, 69, 3, 71, 40, 10, 42, 2, 63, 28, 67, 39, 94, 11, 66, 32, 15, 56, 16, 91, 30, 99]
            },
            {
                label: "UTLA",
                borderColor: "#FA625F",
                pointBorderColor: "#FA625F",
                pointBackgroundColor: "#FA625F",
                pointHoverBackgroundColor: "#FA625F",
                pointHoverBorderColor: "#FA625F",
                pointBorderWidth: 10,
                pointHoverRadius: 10,
                pointHoverBorderWidth: 1,
                pointRadius: 3,
                fill: false,
                borderWidth: 4,
                data: [31, 67, 43, 100, 98, 54, 8, 12, 13, 87, 38, 99, 39, 61, 75, 99, 25, 11, 9, 10, 30, 15, 75, 77]
            }]  
    },
    options: {
        legend: {
            position: "top",
            display: "true",
            labels: {
                fontSize: 24
            }
        },
        scales: {
            yAxes: [{
                ticks: {
                    fontColor: "rgba(0,0,0,0.5)",
                    fontStyle: "bold",
                    fontSize: 20,
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
                    fontSize: 20,
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

