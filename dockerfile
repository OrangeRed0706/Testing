FROM lynn0706/dotnet-sdk:latest AS build

WORKDIR /app

COPY . .
RUN dotnet restore \
    && dotnet build -c Release -o out \
    && dotnet publish HelloWorld/HelloWorld.csproj -c Release -o out /p:GenerateDocumentationFile=true

FROM lynn0706/dotnet-runtime:latest AS runtime
WORKDIR /app
ARG proj
ENV dll="/app/${proj}.dll"

COPY --from=build /app/out ./

RUN export COMPlus_PerfMapEnabled=1 \
&& export COMPlus_EnableEventLog=1

ENV PORT=64132
EXPOSE $PORT

# Define the urls environment variable
ENV URLS=http://*:$PORT

ENTRYPOINT dotnet ${dll} --urls ${URLS}
