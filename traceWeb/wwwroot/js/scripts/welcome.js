"use strict";
$(function () {
    var input = bif.getInput();
    input.channel = "Anno.Plugs.Report";
    input.router = "Report";
    input.method = "GetServiceReport";
    //input.startDate = new Date().toLocaleDateString();
    //input.endDate = "2019-10-01";
    bif.process(input, function (data) {
        var myChart = echarts.init(document.getElementById('trace'));
        // 指定图表的配置项和数据
        var option = {
            color: ['#3398DB'],
            title: {
                text: '最近7日追踪'
            },
            tooltip: {
                trigger: 'axis',
                axisPointer: { // 坐标轴指示器，坐标轴触发有效
                    type: 'shadow' // 默认为直线，可选为：'line' | 'shadow'
                }
            },
            legend: {
                data: ['访问量']
            },
            grid: {
                left: '3%',
                right: '4%',
                bottom: '3%',
                containLabel: true
            },
            xAxis: {
                type: 'category',
                data: data.outputData.xAxis,
                axisTick: {
                    alignWithLabel: true
                }
            },
            yAxis: [{
                type: 'value'
            }],
            series: [{
                name: '访问量',
                type: 'bar',
                barWidth: '60%',
                data: data.outputData.values
            }]
        };

        // 使用刚指定的配置项和数据显示图表。
        myChart.setOption(option);
        defaultService = data.outputData.xAxis[0];
        myChart.on('click', function (params) {
            if (params.name !== defaultService) {
                SetWatch(connection, params.name);
            }
        });
    });
    window.CpuInt();
    window.MemoryInt();
    window.StartMonitoring();
});
var defaultService = "WebApi";
var data = [];
var memorydata = [];
var date = [];
var cpuChart = null;
var memoryChart = null;
var connection = null;
function CpuInt() {
    cpuChart = echarts.init(document.getElementById('cpu'));
    //CPU动态图
    var option = {
        title: {
            left: 'center',
            text: 'CPU监控'
        },
        toolbox: {
            feature: {
                dataZoom: {
                    yAxisIndex: 'none'
                },
                restore: {},
                saveAsImage: {}
            }
        },
        tooltip: {
            trigger: 'axis'
        },
        xAxis: {
            type: 'category',
            boundaryGap: false,
            data: date
        },
        yAxis: {
            type: 'value',
            boundaryGap: [0, '100%']
        },
        dataZoom: [{
            type: 'inside',
            start: 0,
            end: 100
        }, {
            start: 0,
            end: 10,
            handleIcon: 'M10.7,11.9v-1.3H9.3v1.3c-4.9,0.3-8.8,4.4-8.8,9.4c0,5,3.9,9.1,8.8,9.4v1.3h1.3v-1.3c4.9-0.3,8.8-4.4,8.8-9.4C19.5,16.3,15.6,12.2,10.7,11.9z M13.3,24.4H6.7V23h6.6V24.4z M13.3,19.6H6.7v-1.4h6.6V19.6z',
            handleSize: '80%',
            handleStyle: {
                color: '#fff',
                shadowBlur: 3,
                shadowColor: 'rgba(0, 0, 0, 0.6)',
                shadowOffsetX: 2,
                shadowOffsetY: 2
            }
        }],
        series: [{
            name: 'CPU使用率',
            type: 'line',
            smooth: true,
            symbol: 'none',
            sampling: 'average',
            itemStyle: {
                color: 'rgb(255, 70, 131)'
            },
            areaStyle: {
                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                    offset: 0,
                    color: 'rgb(255, 158, 68)'
                }, {
                    offset: 1,
                    color: 'rgb(255, 70, 131)'
                }])
            },
            data: data
        }]
    };
    cpuChart.setOption(option);

}

function MemoryInt() {
    memoryChart = echarts.init(document.getElementById('memory'));
    //CPU动态图
    var option = {
        title: {
            left: 'center',
            text: 'Memory监控'
        },
        toolbox: {
            feature: {
                dataZoom: {
                    yAxisIndex: 'none'
                },
                restore: {},
                saveAsImage: {}
            }
        },
        tooltip: {
            trigger: 'axis'
        },
        xAxis: {
            type: 'category',
            boundaryGap: false,
            data: date
        },
        yAxis: {
            type: 'value',
            boundaryGap: [0, '100%']
        },
        dataZoom: [{
            type: 'inside',
            start: 0,
            end: 100
        }, {
            start: 0,
            end: 10,
            handleIcon: 'M10.7,11.9v-1.3H9.3v1.3c-4.9,0.3-8.8,4.4-8.8,9.4c0,5,3.9,9.1,8.8,9.4v1.3h1.3v-1.3c4.9-0.3,8.8-4.4,8.8-9.4C19.5,16.3,15.6,12.2,10.7,11.9z M13.3,24.4H6.7V23h6.6V24.4z M13.3,19.6H6.7v-1.4h6.6V19.6z',
            handleSize: '80%',
            handleStyle: {
                color: '#fff',
                shadowBlur: 3,
                shadowColor: 'rgba(0, 0, 0, 0.6)',
                shadowOffsetX: 2,
                shadowOffsetY: 2
            }
        }],
        series: [{
            name: '内存占用（M）',
            type: 'line',
            smooth: true,
            symbol: 'none',
            sampling: 'average',
            itemStyle: {
                color: 'rgb(255, 70, 131)'
            },
            areaStyle: {
                color: new echarts.graphic.LinearGradient(0, 0, 0, 1, [{
                    offset: 0,
                    color: 'rgb(255, 158, 68)'
                }, {
                    offset: 1,
                    color: 'rgb(255, 70, 131)'
                }])
            },
            data: memorydata
        }]
    };
    memoryChart.setOption(option);

}

function StartMonitoring() {
    connection = new signalR.HubConnectionBuilder()
        .withAutomaticReconnect()
        .withUrl("/MonitorHub")
        .configureLogging(signalR.LogLevel.Information)
        .build();
    connection.onreconnected(function (connectionId) {
        SetWatch(connection, defaultService);
    });
    connection.on("SendMonitorData", function (_data) {
        var _date = new Date(_data.currentTime);
        date.push([_date.getHours(), _date.getMinutes(), _date.getSeconds()].join(':'));
        data.push(_data.cpu);
        memorydata.push((_data.memory).toFixed(2));
        if (data.length > 1200) {
            memorydata.shift();
            data.shift();
            date.shift();
        }
        cpuChart.setOption({
            xAxis: {
                data: date
            },
            series: [{
                data: data
            }]
        });
        memoryChart.setOption({
            xAxis: {
                data: date
            },
            series: [{
                data: memorydata
            }]
        });
    });
    connection.on("OnConnected", function (_data) {
        SetWatch(connection, defaultService);
    });
    connection.on("OnDisconnected", function (_data) {
        console.log(_data);
    });
    connect(connection);
}

function connect(conn) {
    conn.start().catch(function (err) {
        console.error(err.toString());
    });
    setTimeout(function () {
        SetWatch(conn, defaultService);
    }, 500);
}

function SetWatch(connection, name) {
    date = [];
    data = [];
    memorydata = [];
    defaultService = name;
    connection.invoke("SetWatch", name).catch(function (err) {
        console.error(err.toString());
    });
    cpuChart.setOption({
        title: { left: 'center', text: name + '--CPU监控' }
    });
    memoryChart.setOption({
        title: { left: 'center', text: name + '--Memory监控' }
    });
}