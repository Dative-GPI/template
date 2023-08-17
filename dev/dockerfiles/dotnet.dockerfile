FROM alpine as proj-env

WORKDIR /app

COPY . .

# On supprime tous les fichiers excepté les csproj
RUN find . ! -name '*.csproj' -type f -exec rm -f {} +

# On supprime les dossiers qui servent plus à rien
RUN find . -type d -empty -delete

# ----------------------------------------

FROM mcr.microsoft.com/dotnet/sdk:7.0

#install debugger for NET Core
RUN curl -sSL https://aka.ms/getvsdbgsh | /bin/sh /dev/stdin -v latest -l ~/vsdbg

ARG PROJECT
ARG POST_RESTORE
ARG PRE_BUILD

# RUN mkdir /libs
# RUN dotnet nuget add source /libs -n libs

# WORKDIR /app/$PROJECT

# COPY --from=proj-env /app /app

# COPY libs /libs
# RUN dotnet nuget update source libs
# RUN for lib in $(find "/libs/temp" -name "*.nupkg"); do nuget add $lib -s /libs; done

RUN dotnet restore 
RUN $POST_RESTORE

COPY . /app

RUN $PRE_BUILD

RUN dotnet build --no-restore

ENTRYPOINT dotnet run --no-build --no-restore