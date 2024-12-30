# Apple .NET 라이브러리
.NET 환경에서 Apple관련 API를 호출할 수 있도록 만든 라이브러리 프로젝트입니다.

---
## 사용하기에 앞서
- 해당 라이브러리는 public nuget feed에 등록되어 있지 않습니다. (추후 등록 예정)
- Nuget을 통해 사용하기 위해서는 private feed에 등록 후 사용이 필요합니다. (Azure Devops 등)
---

# How to Nuget Build and Package
### 1. dotnet build
```
dotnet build
```

### 2. dotnet pack
명령어
```
dotnet pack
```

버전 설정 등, 필요한 내용은 .csproj 파일에 기재
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net6.0</TargetFramework>
    <RootNamespace>ROOT_SPACE_NAME</RootNamespace>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <Version>VERSION</Version>
    <PackageDescription>DESCRIPTION</PackageDescription>
    <Authors>John Shin</Authors>
    <Company>Ward Games Inc.</Company>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="AWSSDK.DynamoDBv2" Version="3.7.103.9" />
    <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
  </ItemGroup>

</Project>

```


# How to Nuget Package publish

### 1. nuget.config 작성하기
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <!--To inherit the global NuGet package sources remove the <clear/> line below -->
    <clear />
    <add key="zooports-the-football-nuget" value="https://pkgs.dev.azure.com/wardgames/zooports-the-football/_packaging/zooports-the-football-nuget/nuget/v3/index.json" />
  </packageSources>

  <!-- 패키지 소스별 인증 정보 -->
  <packageSourceCredentials>
    <!-- 위에서 설정한 패키지 소스의 이름입니다. -->
    <NUGET_FEED_NAME>
      <!-- 패키지 소스에 접근할 때 사용할 사용자 이름 -->
      <!-- Azure DevOps는 실제 사용자 이름을 요구하지 않으므로, 임의의 값을 사용할 수 있습니다. -->
      <add key="Username" value={User Name} />
      <!-- 패키지 소스에 접근할 때 사용할 패스워드 -->
      <!-- Azure DevOps에서는 이곳에 개인 액세스 토큰을 입력합니다. -->
      <add key="ClearTextPassword" value={PAT} />
    </NUGET_FEED_NAME>
  </packageSourceCredentials>
</configuration>

```
- 만약 PAT 값이 없다면, Azure에서 발급받아서 배포.
- 동일한 피드에 패키지 등록 시 추가로 feed 생성 및 nuget.config 추가 불필요.


### 2. 이 프로젝트에서 패키지 배포할 때 명령어

```
dotnet nuget push {path} --source zooports-the-football-nuget --api-key az
```
- {version} : 배포하고자 하는 nupkg의 버전을 작성
- --source : 위 nuget.config 파일에서 작성한 packageSources 이름과 동일하게 작성

--- 

## 업데이트 로그
- 기존 Azure Devops에 있던 라이브러리를 GitHub으로 이전하였습니다.
