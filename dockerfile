# 使用 .NET 6.0 SDK 作为构建阶段的基础镜像
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# 设定工作目录
WORKDIR /src

# 复制所有的项目文件并恢复
COPY . .
RUN dotnet restore

# 编译所有的项目
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

# 使用 .NET 6.0 Runtime 作为运行阶段的基础镜像
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .

# 指定运行时的启动命令
ENTRYPOINT ["dotnet", "HelloWorld.dll"]
