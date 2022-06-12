# 自动打卡系统

## 已放弃

账户密码登录一直提示错误，放弃了

## 使用场景

我在校园小程序，批量打卡（健康打卡）   

## 项目文件架构

``` 
├─AutoSign1904
│  │  appsettings.Development.json
│  │  appsettings.json
│  │  AutoSign1904.csproj
│  │  AutoSign1904.csproj.user
│  │  AutoSign1904.sln
│  │  Program.cs
│  │  
│  ├─bin
│  │  └─Debug
│  │      └─net6.0
│  │              
│  ├─Controllers
│  │      HomeController.cs
│  │      InfoController.cs
│  │      
│  ├─DataTransferModel
│  │      InfoModel.cs
│  │      
│  ├─Models
│  │      db_signContext.cs
│  │      ErrorViewModel.cs
│  │      J.cs
│  │      
│  ├─obj
│  │  │  AutoSign1904.csproj.nuget.dgspec.json
│  │  │  AutoSign1904.csproj.nuget.g.props
│  │  │  AutoSign1904.csproj.nuget.g.targets
│  │  │  project.assets.json
│  │  │  project.nuget.cache
│  │  │  staticwebassets.pack.sentinel
│  │  │  
│  │  └─Debug
│  │      └─net6.0
│  │          │  
│  │          ├─ref
│  │          │      AutoSign1904.dll
│  │          │      
│  │          ├─refint
│  │          │      AutoSign1904.dll
│  │          │      
│  │          ├─scopedcss
│  │          │  ├─bundle
│  │          │  │      AutoSign1904.styles.css
│  │          │  │      
│  │          │  ├─projectbundle
│  │          │  │      AutoSign1904.bundle.scp.css
│  │          │  │      
│  │          │  └─Views
│  │          │      └─Shared
│  │          │              _Layout.cshtml.rz.scp.css
│  │          │              
│  │          └─staticwebassets
│  ├─Properties
│  │      launchSettings.json
│  │      
│  ├─Views
│  │  │  _ViewImports.cshtml
│  │  │  _ViewStart.cshtml
│  │  │  
│  │  ├─Home
│  │  │      Privacy.cshtml
│  │  │      
│  │  ├─Info
│  │  │      Index.cshtml
│  │  │      
│  │  └─Shared
│  │          Error.cshtml
│  │          _Layout.cshtml
│  │          _Layout.cshtml.css
│  │          _ValidationScriptsPartial.cshtml
│  │          
│  └─wwwroot
│      │  favicon.ico
│      │  
│      ├─css
│      │      site.css
│      │      
│      ├─js
│      │      site.js
│      │      
│      └─lib
│          ├─bootstrap
│          ├─jquery        
│          ├─jquery-validation         
│          └─jquery-validation-unobtrusive
│                  
└─Sign
    │  Form1.cs
    │  Form1.Designer.cs
    │  Form1.resx
    │  HttpUtil.cs
    │  Program.cs
    │  Sign.csproj
    │  Sign.csproj.user
    │  SignData.cs
    │  SignInfo.cs
    │  
    ├─bin
    │  └─Debug
    │      └─net6.0-windows
    │              
    ├─Models
    │      db_signContext.cs
    │      ErrorViewModel.cs
    │      J.cs
    │      
    └─obj
        │  project.assets.json
        │  project.nuget.cache
        │  Sign.csproj.nuget.dgspec.json
        │  Sign.csproj.nuget.g.props
        │  Sign.csproj.nuget.g.targets
        │  
        └─Debug
            └─net6.0-windows
```

## 项目结构

项目由 **AutoSign1904** 和 **Sigh** 两部分组成

### AutoSign1904

**AutoSign1904** 是一个ASP.NET Core WebApp (MVC) , 用于收集我在校园的登录信息，利用登录信息可以模拟登陆获取JWSession, 拿到JWSession之后就可以模拟我在校园健康打卡。  

### Sign

**Sign** 是一个Windows Form Application (.NET 6) , 用于运行在服务器上，每天定时模拟我在校园打卡。

## 特别声明

部分源代码当中含有隐私信息，请勿用于非法用途。  