FROM lynn0706/dotnet-sdk:latest AS build

WORKDIR /app

COPY . .
RUN dotnet restore
RUN dotnet build -c Release -o out
RUN dotnet publish HelloWorld/HelloWorld.csproj -c Release -o out /p:GenerateDocumentationFile=true

FROM lynn0706/dotnet-runtime:latest AS runtime
WORKDIR /app
ARG proj
ENV dll="/app/HelloWorld.dll"
# ENV dll="/app/${proj}.dll"

COPY --from=build /app/out ./

RUN export COMPlus_PerfMapEnabled=1 \
&& export COMPlus_EnableEventLog=1

# COPY ./sedappsettings.sh ./
COPY dotnet.conf /etc/supervisor.d/dotnet.ini
# COPY ./sed.conf /etc/supervisor.d/sed.ini
# RUN chmod +x /app/sedappsettings.sh

#Support container restart can sed the latest environment data
# RUN cp /app/appsettings.json /app/appsettings.json.orign \
# && cp /app/appsettings.Integration.json /app/appsettings.Integration.json.orign \
# && cp /app/appsettings.Qat.json /app/appsettings.Qat.json.orign \
# && cp /app/appsettings.Staging.json /app/appsettings.Staging.json.orign \
# && cp /app/appsettings.Production.json /app/appsettings.Production.json.orign
# Expose the port your app runs on
ENV PORT=64132
EXPOSE $PORT

# Define the urls environment variable
ENV URLS=http://*:$PORT

ENTRYPOINT dotnet ${dll} --urls ${URLS}
#Use supervisord controll container process
# CMD ["supervisord", "-n"]
