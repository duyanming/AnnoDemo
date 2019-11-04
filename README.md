#dotnet
dotnet publish "E:\gitProject\Anno\DCS\AppCenter\AppCenter.csproj" -c Release -r linux-x64 -o "E:\gitProject\Anno\DCS\AppCenter\bin"

#配置文件说明
```json
{
  "Target": {
    "AppName": "traceWeb",--服务名称
    "IpAddress": "127.0.0.1",--注册中心地址
    "Port": 6660,--注册中心端口
    "TraceOnOff": true--启用调用链追踪
  },
  "Limit": {--限流
    "Enable": true,--是否启用限流
    "TagLimits": [--标签限流
      {
        "channel": "*",--管道
        "router": "*",--路由
        "timeSpan": "10",--时间片单位秒
        "rps": 1,--时间片内的 有效请求个数
        "limitSize": 2--漏桶容量大小 做缓冲用
      }
    ],
    "IpLimit": {--IP限流
      "timeSpan": 1,
      "rps": 20,
      "limitSize": 200
    },
    "WhiteList": [--白名单
      "192.168.1.1",
      "192.168.2.18"
    ]
  }
}

```
