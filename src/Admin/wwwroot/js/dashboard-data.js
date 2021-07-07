$(document).ready(function () {

    /* Morris Chart */
    var donationsChart = Morris.Donut({
        element: 'donation-chart',
        data: [{
            label: "Nafila",
            value: $("#hdfTodayNafila").val()
        },
        {
            label: "Wajiba",
            value: $("#hdfTodayWajiba").val()
        }],
        resize: true,
        colors: ['#55ce63', '#009efb']
    });

    $("#btnToday").click(function (e) {

        donationsChart.setData(
            [{
                label: "Nafila",
                value: $("#hdfTodayNafila").val()
            },
            {
                label: "Wajiba",
                value: $("#hdfTodayWajiba").val()
            }]
        );
    });

    $("#btnMonth").click(function (e) {
        donationsChart.setData(
            [{
                label: "Nafila",
                value: $("#hdfMonthlyNafila").val()
            },
            {
                label: "Wajiba",
                value: $("#hdfMonthlyWajiba").val()
            }]
        );
    });

    $("#btnAnnual").click(function (e) {
        donationsChart.setData(
            [{
                label: "Nafila",
                value: $("#hdfAnnualNafila").val()
            },
            {
                label: "Wajiba",
                value: $("#hdfAnnualWajiba").val()
            }]
        );
    });

    new Chart(document.getElementById("gifts-chart"),
        {
            "type": "line",
            "data": {
                "labels": ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"],
                "datasets": [{
                    "label": "Amount",
                    "data": $("#hdfGitAidAnnualData").val().split(','),
                    "fill": false,
                    "borderColor": "rgb(86, 192, 216)",
                    "lineTension": 0.1
                }]
            }, "options": {}
        });
});