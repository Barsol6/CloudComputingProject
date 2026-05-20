# Instrukcja obsługi obrazu i kontenera

---

### a. Zbudowanie opracowanego obrazu kontenera

Do zbudowania  obrazu (`linux/amd64` oraz `linux/arm64`) przy użyciu  mechanizmu cache (`registry` w trybie `max`), pobierania kodu źródłowego bezpośrednio z repozytorium GitHub przez protokół SSH oraz automatycznego pusha gotowego obrazu do Docker Hub:

```bash
docker buildx build \
  --platform linux/amd64,linux/arm64 \
  --ssh default=$HOME/.ssh/id_ed25519 \
  --cache-to type=registry,ref=barsol/cloudcomputingproject:cache,mode=max,image-manifest=true \
  --cache-from type=registry,ref=barsol/cloudcomputingproject:cache \
  -t barsol/cloudcomputingproject:latest \
  --push \
  .
```

Wynik:
```bash
Barsol@barsol-pc:~/Dev/RiderProjects/CloudComputingProject/CloudComputingProject$ docker buildx build   --platform linux/amd64,linux/arm64   --ssh default=$HOME/.ssh/id_ed25519   --cache-to type=registry,ref=barsol/cloudcomputingproject:cache,mode=max,image-manifest=true   --cache-from type=registry,ref=barsol/cloudcomputingproject:cache   -t barsol/cloudcomputingproject:latest   --push   .
[+] Building 27.9s (39/39) FINISHED                                                                                                                                                                      docker-container:mybuilder
 => [internal] load build definition from Dockerfile                                                                                                                                                                           0.0s
 => => transferring dockerfile: 1.36kB                                                                                                                                                                                         0.0s 
 => resolve image config for docker-image://docker.io/docker/dockerfile:1.4                                                                                                                                                    5.9s 
 => [auth] docker/dockerfile:pull token for registry-1.docker.io                                                                                                                                                               0.0s
 => CACHED docker-image://docker.io/docker/dockerfile:1.4@sha256:9ba7531bd80fb0a858632727cf7a112fbfd19b17e94c4e84ced81e24ef1a0dbc                                                                                              0.0s 
 => => resolve docker.io/docker/dockerfile:1.4@sha256:9ba7531bd80fb0a858632727cf7a112fbfd19b17e94c4e84ced81e24ef1a0dbc                                                                                                         0.0s 
 => [internal] load .dockerignore                                                                                                                                                                                              0.0s 
 => => transferring context: 2B                                                                                                                                                                                                0.0s 
 => [linux/amd64 internal] load metadata for mcr.microsoft.com/dotnet/sdk:10.0-alpine                                                                                                                                          5.4s 
 => [linux/amd64 internal] load metadata for mcr.microsoft.com/dotnet/aspnet:10.0-alpine                                                                                                                                       5.4s
 => [linux/arm64 internal] load metadata for mcr.microsoft.com/dotnet/aspnet:10.0-alpine                                                                                                                                       5.3s
 => [linux/arm64 internal] load metadata for mcr.microsoft.com/dotnet/sdk:10.0-alpine                                                                                                                                          5.4s
 => importing cache manifest from barsol/cloudcomputingproject:cache                                                                                                                                                           6.2s
 => => inferred cache manifest type: application/vnd.oci.image.manifest.v1+json                                                                                                                                                0.0s
 => [linux/arm64 base 1/2] FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine@sha256:1e37a8236c558ae31bd6bc8144e38e6036b73cf1b0616fe56d79e60babb9d93b                                                                            0.0s 
 => => resolve mcr.microsoft.com/dotnet/aspnet:10.0-alpine@sha256:1e37a8236c558ae31bd6bc8144e38e6036b73cf1b0616fe56d79e60babb9d93b                                                                                             0.0s 
 => [linux/arm64 build 1/8] FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine@sha256:5c559aa5d99337e400d39ab4fa1f6979d126c29b20939d53658ed38300571e74                                                                              0.1s 
 => => resolve mcr.microsoft.com/dotnet/sdk:10.0-alpine@sha256:5c559aa5d99337e400d39ab4fa1f6979d126c29b20939d53658ed38300571e74                                                                                                0.1s 
 => [linux/amd64 build 1/8] FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine@sha256:5c559aa5d99337e400d39ab4fa1f6979d126c29b20939d53658ed38300571e74                                                                              0.1s 
 => => resolve mcr.microsoft.com/dotnet/sdk:10.0-alpine@sha256:5c559aa5d99337e400d39ab4fa1f6979d126c29b20939d53658ed38300571e74                                                                                                0.1s 
 => [linux/amd64 base 1/2] FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine@sha256:1e37a8236c558ae31bd6bc8144e38e6036b73cf1b0616fe56d79e60babb9d93b                                                                            0.1s 
 => => resolve mcr.microsoft.com/dotnet/aspnet:10.0-alpine@sha256:1e37a8236c558ae31bd6bc8144e38e6036b73cf1b0616fe56d79e60babb9d93b                                                                                             0.1s 
 => CACHED [linux/arm64 base 2/2] WORKDIR /app                                                                                                                                                                                 0.0s 
 => CACHED [linux/arm64 final 1/2] WORKDIR /app                                                                                                                                                                                0.0s 
 => CACHED [linux/arm64 build 2/8] RUN apk add --no-cache git openssh-client                                                                                                                                                   0.0s 
 => CACHED [linux/arm64 build 3/8] RUN mkdir -p -m 0700 ~/.ssh && ssh-keyscan github.com >> ~/.ssh/known_hosts                                                                                                                 0.0s 
 => CACHED [linux/arm64 build 4/8] WORKDIR /src                                                                                                                                                                                0.0s 
 => CACHED [linux/arm64 build 5/8] RUN --mount=type=ssh git clone git@github.com:Barsol6/CloudComputingProject.git .                                                                                                           0.0s
 => CACHED [linux/arm64 build 6/8] WORKDIR /src/CloudComputingProject                                                                                                                                                          0.0s 
 => CACHED [linux/arm64 build 7/8] RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages dotnet restore "CloudComputingProject.csproj"                                                                                  0.0s 
 => CACHED [linux/arm64 build 8/8] RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages dotnet build "CloudComputingProject.csproj" -c Release -o /app/build                                                           0.0s 
 => CACHED [linux/arm64 publish 1/1] RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages dotnet publish "CloudComputingProject.csproj" -c Release -o /app/publish /p:UseAppHost=false                                 0.0s 
 => CACHED [linux/arm64 final 2/2] COPY --from=publish /app/publish .                                                                                                                                                          0.2s 
 => CACHED [linux/amd64 base 2/2] WORKDIR /app                                                                                                                                                                                 0.0s 
 => CACHED [linux/amd64 final 1/2] WORKDIR /app                                                                                                                                                                                0.0s 
 => CACHED [linux/amd64 build 2/8] RUN apk add --no-cache git openssh-client                                                                                                                                                   0.0s 
 => CACHED [linux/amd64 build 3/8] RUN mkdir -p -m 0700 ~/.ssh && ssh-keyscan github.com >> ~/.ssh/known_hosts                                                                                                                 0.0s 
 => CACHED [linux/amd64 build 4/8] WORKDIR /src                                                                                                                                                                                0.0s 
 => CACHED [linux/amd64 build 5/8] RUN --mount=type=ssh git clone git@github.com:Barsol6/CloudComputingProject.git .                                                                                                           0.0s
 => CACHED [linux/amd64 build 6/8] WORKDIR /src/CloudComputingProject                                                                                                                                                          0.0s 
 => CACHED [linux/amd64 build 7/8] RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages dotnet restore "CloudComputingProject.csproj"                                                                                  0.0s 
 => CACHED [linux/amd64 build 8/8] RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages dotnet build "CloudComputingProject.csproj" -c Release -o /app/build                                                           0.0s 
 => CACHED [linux/amd64 publish 1/1] RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages dotnet publish "CloudComputingProject.csproj" -c Release -o /app/publish /p:UseAppHost=false                                 0.0s 
 => CACHED [linux/amd64 final 2/2] COPY --from=publish /app/publish .                                                                                                                                                          0.2s 
 => exporting to image                                                                                                                                                                                                         8.9s 
 => => exporting layers                                                                                                                                                                                                        0.0s 
 => => exporting manifest sha256:1bd4acfe05dae1acbd5e275b1753ee0d2f1a880ef533ee66116ffc6f16010f67                                                                                                                              0.0s 
 => => exporting config sha256:87d98a1c8e8ea1ac47cf12f047975dd82589e4032de76092d02c08e4230ac6b6                                                                                                                                0.0s 
 => => exporting attestation manifest sha256:18bb66af0da6b178211675e07a7c7b3ef38d74237f19dd957371793d5b298312                                                                                                                  0.0s 
 => => exporting manifest sha256:f71c644cca048bf0eee83742c0070c701835621c026c3801f2c3a068194e0538                                                                                                                              0.0s 
 => => exporting config sha256:3e10f5035e8cafec32535099bec402ecaa003a7dcc9764cb04a53693d05bd7b2                                                                                                                                0.0s 
 => => exporting attestation manifest sha256:f3658eba3cd1aa4ab913603064b0fd30a38b2c2cf46404d07f2910669a440c61                                                                                                                  0.0s 
 => => exporting manifest list sha256:cc0a8a56c5ea096f25fd8df02afd9a54c443f809623031c9e20690b8887d5bd3                                                                                                                         0.0s 
 => => pushing layers                                                                                                                                                                                                          5.4s 
 => => pushing manifest for docker.io/barsol/cloudcomputingproject:latest@sha256:cc0a8a56c5ea096f25fd8df02afd9a54c443f809623031c9e20690b8887d5bd3                                                                              3.4s 
 => exporting cache to registry                                                                                                                                                                                                9.6s 
 => => preparing build cache for export                                                                                                                                                                                        1.4s 
 => => sending cache export                                                                                                                                                                                                    8.2s 
 => => writing layer sha256:16e524ebc154e4604e57a50cf9a30c36d6a827756466141fb2b674a1575e1666                                                                                                                                   0.9s 
 => => writing layer sha256:0d2160e0f903e9155b2559063feffb2fc0b1bb62d9819e0595cf1804e309b413                                                                                                                                   1.2s 
 => => writing layer sha256:141ca0c1324a5bb952cca3ce253dceddbcdd3caadfbe7a49d0876a5a86d2f235                                                                                                                                   1.0s 
 => => writing layer sha256:0057451c8a95a8084e0712419d0bdca0b817d739347ef4b7d6888ad9697869f9                                                                                                                                   1.4s 
 => => writing layer sha256:1c4bc26d3db3dbe781a4daf219a8f01a803230796cf60a3aa3911b195bc610f3                                                                                                                                   1.3s 
 => => writing layer sha256:243c8d038cfea2854a841eb1dd51b9abc92b16de735b360d9056ac8609ac61d4                                                                                                                                   1.2s 
 => => writing layer sha256:26761848a109c19377ee32a60aac831b190223cfe90007d051f641b5d8d28f6a                                                                                                                                   1.1s 
 => => writing layer sha256:2fc33f2b3f22e6ae5d4a5856aec41874bceb8e2aa8f417277c5b95dca62b5e70                                                                                                                                   1.0s 
 => => writing layer sha256:35db7b6f6a8e8ba1515d706fdbb02cb2366fa3d7cb9ebc8b59e783b46cd74e7c                                                                                                                                   0.6s 
 => => writing layer sha256:36c5e895ec92b1cc6e859b170cd0a338af2ede6c6361b2417233beb3ec764b5b                                                                                                                                   0.6s 
 => => writing layer sha256:47299e46d11ffb102b5e2107a069d5204deca14fc726a3012a9e6fce23f43f0a                                                                                                                                   0.6s 
 => => writing layer sha256:4f4fb700ef54461cfa02571ae0db9a0dc1e0cdb5577484a6d75e68dc38e8acc1                                                                                                                                   0.1s 
 => => writing layer sha256:5125fdda0597f4617bbef4f78879a42368ce33bbe67ecc75dd4201d56ce59d69                                                                                                                                   0.4s 
 => => writing layer sha256:59a9a7a4affbb9b69fe9ba87a3a9d147db2d7b367552be66d5a9a3a8fb4112f1                                                                                                                                   0.6s 
 => => writing layer sha256:5d54bf239258719e93eceec318fb7fc47f1cd355ff854aa20ac3270cc38535f6                                                                                                                                   0.5s 
 => => writing layer sha256:65c79c015ecac31185681106c8699de4214b23ee5ee686ae8f0893baf43014db                                                                                                                                   0.5s 
 => => writing layer sha256:6a0ac1617861a677b045b7ff88545213ec31c0ff08763195a70a4a5adda577bb                                                                                                                                   0.6s 
 => => writing layer sha256:7611140f82a8364a9f43f0a244efcecbafa9089d901d801364bd28297dcfcade                                                                                                                                   0.5s 
 => => writing layer sha256:77c1858381faf4f0f10e702c31e0573935eef16110238972585c0de32ba82674                                                                                                                                   0.5s 
 => => writing layer sha256:799560b7ee44e0451675484601e1aa300d8ee7b5bcc6ec4bf495aa5e819c0b8b                                                                                                                                   0.4s 
 => => writing layer sha256:7aeefd87158f452b2f65c8ed07b5be37b8d68d7b033fea6d0d7a9124070a0072                                                                                                                                   0.1s 
 => => writing layer sha256:7d5f308a7f5eb185d02e5c1297f363192ae94e35e7830dc5295ad92ab7b27beb                                                                                                                                   0.1s 
 => => writing layer sha256:814f481a91cf22d9f65e6f87c0ebe7cc0cc063751899758231f1d7adca8ad619                                                                                                                                   0.1s 
 => => writing layer sha256:8528b2bb0aed483eb4105e155164d227d21aeaefb034f669643ecfc10fbd4408                                                                                                                                   0.1s 
 => => writing layer sha256:8ac45448eb292327e531b8e7bcddd91d409e7548b3b8c208424ac151fc8e4978                                                                                                                                   0.1s 
 => => writing layer sha256:8b68404a3f4d0302ef82aa34a334fb7cb3bfa43dbf5b84d73837bfda96712e11                                                                                                                                   0.1s 
 => => writing layer sha256:a57a739d45884fb828acd35535c43f483dd7f3e20f52ba16fc9e55907037ac21                                                                                                                                   0.1s 
 => => writing layer sha256:afb0c6ddfbbf9668d6118842214939a479907e06c6bd7543d53ea4f3cc001a06                                                                                                                                   0.2s 
 => => writing layer sha256:b2e302c3520daaefd94afb7fbbc5a3cb3d36c1e608eaa95041e3e2b44b7ae1f1                                                                                                                                   0.2s 
 => => writing layer sha256:c0c11659197ea3e090ee09890b662bf2f7684f1d0a1e47cdeb1fde621248af10                                                                                                                                   0.1s 
 => => writing layer sha256:c46819f171deb79fc85b11d32faa15f6e24ba0ff4cbc2498bb57e5f115f8d4ff                                                                                                                                   0.1s 
 => => writing layer sha256:d17f077ada118cc762df373ff803592abf2dfa3ddafaa7381e364dd27a88fca7                                                                                                                                   0.2s 
 => => writing layer sha256:d83f07556fe7da2fcfef330583624352067e024c97e0e7dc4d6ba04795da7d12                                                                                                                                   0.2s 
 => => writing layer sha256:dd4802c2830566f0ec265d5b45ffc737c7b010dbb1a00733ad4d5f5c5cabc04d                                                                                                                                   0.2s 
 => => writing layer sha256:df44f88bbda7c8079b846ff76000ffaa8599101c0aca27b0bb416c201cba274d                                                                                                                                   0.1s 
 => => writing layer sha256:ef5106f8e5ca36cb3d65173e6319fe58b0d5d071fa768db1f6e861f379724694                                                                                                                                   0.2s 
 => => writing layer sha256:fb4b15819d75b1fd340a7531838280755cb0840f6ede4c2028a73bb0a4b35450                                                                                                                                   0.1s 
 => => writing config sha256:973c58c69b17ead64d9487598c6e7fba5deaab1543ca4f3ec5baf6317d5971b3                                                                                                                                  1.2s 
 => => writing cache image manifest sha256:98d69aa8dac58f245b4482166cfc1201bce06c339d726e55e557098cd0b6d406                                                                                                                    2.2s 
 => [auth] barsol/cloudcomputingproject:pull,push token for registry-1.docker.io   

```

### b. Uruchomienia kontenera na podstawie zbudowanego obrazu
Uruchomienie kontenera w tle (tryb izolowany -d), nadanie mu jednoznacznej nazwy identyfikacyjnej oraz zmapowanie wewnętrznego portu aplikacji (8080) na zewnętrzny port testowy hosta (5000):

```Bash
docker run -d --name moj-pogoda-kontener -p 5000:8080 barsol/cloudcomputingproject:latest
```

Wynik:

```Bash
Barsol@barsol-pc:~$ docker run -d --name moj-pogoda-kontener -p 5000:8080 barsol/cloudcomputingproject:latest
17bd72af10f959043c6ebe682a2ab6cae7fe1bd81975601f67c8a72451ce3ae6
```

### c. Sposób uzyskania informacji z logów aplikacji
Pobranie informacji (autor, data uruchomienia, porty TCP) wygenerowanych  podczas startu kontenera:

``` Bash
docker logs moj-pogoda-kontener
```

```Bash
Barsol@barsol-pc:~$ docker logs moj-pogoda-kontener
warn: Microsoft.AspNetCore.DataProtection.Repositories.FileSystemXmlRepository[60]
      Storing keys in a directory '/home/app/.aspnet/DataProtection-Keys' that may not be persisted outside of the container. Protected data will be unavailable when container is destroyed. For more information go to https://aka.ms/aspnet/dataprotectionwarning
APLIKACJA URUCHOMIONA
Data (UTC): 2026-05-20 08:31:57
Autor: Bartosz Solyga
Nasłuchiwanie na portach TCP: 8080
warn: Microsoft.AspNetCore.DataProtection.KeyManagement.XmlKeyManager[35]
      No XML encryptor configured. Key {a16f1de8-0e87-45c2-9f7b-85da2369ba42} may be persisted to storage in unencrypted form.
warn: Microsoft.AspNetCore.Hosting.Diagnostics[15]
      Overriding HTTP_PORTS '8080' and HTTPS_PORTS ''. Binding to values defined by URLS instead 'http://+:8080'.
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://[::]:8080
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Production
info: Microsoft.Hosting.Lifetime[0]
      Content root path: /app
warn: Microsoft.AspNetCore.HttpsPolicy.HttpsRedirectionMiddleware[3]
      Failed to determine the https port for redirect.
fail: Microsoft.AspNetCore.Antiforgery.DefaultAntiforgery[7]
      An exception was thrown while deserializing the token.
      Microsoft.AspNetCore.Antiforgery.AntiforgeryValidationException: The antiforgery token could not be decrypted.
       ---> System.Security.Cryptography.CryptographicException: The key {d9f5d539-35fa-4c41-b859-66ef33886683} was not found in the key ring. For more information go to https://aka.ms/aspnet/dataprotectionwarning
         at Microsoft.AspNetCore.DataProtection.KeyManagement.KeyRingBasedDataProtector.UnprotectCore(Byte[] protectedData, Boolean allowOperationsOnRevokedKeys, UnprotectStatus& status)
         at Microsoft.AspNetCore.DataProtection.KeyManagement.KeyRingBasedDataProtector.Unprotect(Byte[] protectedData)
         at Microsoft.AspNetCore.Antiforgery.DefaultAntiforgeryTokenSerializer.Deserialize(String serializedToken)
         --- End of inner exception stack trace ---
         at Microsoft.AspNetCore.Antiforgery.DefaultAntiforgeryTokenSerializer.Deserialize(String serializedToken)
         at Microsoft.AspNetCore.Antiforgery.DefaultAntiforgery.GetCookieTokenDoesNotThrow(HttpContext httpContext)

```

### d. Sprawdzenie, ile warstw posiada zbudowany obraz oraz jaki jest rozmiar obrazu

Weryfikacja rozmiaru, architektury oraz sum kontrolnych manifestu.  Każda linia w drugim wyniku, która ma przypisany rozmiar większy niż 0B (i nie jest tylko metadaną typu ENV czy WORKDIR), to jedna warstwa Twojego obrazu.

```Bash
docker images barsol/cloudcomputingproject:latest
docker history barsol/cloudcomputingproject:latest
```

Wynik:

```Bash
Barsol@barsol-pc:~$ docker images barsol/cloudcomputingproject:latest
                                                                                                                                                                                                                        i Info →   U  In Use
IMAGE                                 ID             DISK USAGE   CONTENT SIZE   EXTRA
barsol/cloudcomputingproject:latest   cc0a8a56c5ea        195MB         58.9MB    U   
Barsol@barsol-pc:~$ docker history barsol/cloudcomputingproject:latest
IMAGE          CREATED       CREATED BY                                      SIZE      COMMENT
cc0a8a56c5ea   4 hours ago   ENTRYPOINT ["dotnet" "CloudComputingProject.…   0B        buildkit.dockerfile.v0
<missing>      4 hours ago   COPY /app/publish . # buildkit                  12.7MB    buildkit.dockerfile.v0
<missing>      4 hours ago   WORKDIR /app                                    0B        buildkit.dockerfile.v0
<missing>      4 hours ago   HEALTHCHECK &{["CMD-SHELL" "wget --no-verbos…   0B        buildkit.dockerfile.v0
<missing>      4 hours ago   ENV ASPNETCORE_URLS=http://+:8080               0B        buildkit.dockerfile.v0
<missing>      4 hours ago   EXPOSE map[8080/tcp:{}]                         0B        buildkit.dockerfile.v0
<missing>      4 hours ago   WORKDIR /app                                    0B        buildkit.dockerfile.v0
<missing>      4 hours ago   USER app                                        0B        buildkit.dockerfile.v0
<missing>      4 hours ago   LABEL org.opencontainers.image.title=Cloud C…   0B        buildkit.dockerfile.v0
<missing>      4 hours ago   LABEL org.opencontainers.image.authors=Barto…   0B        buildkit.dockerfile.v0
<missing>      8 days ago    COPY /dotnet /usr/share/dotnet # buildkit       27.3MB    buildkit.dockerfile.v0
<missing>      8 days ago    ENV ASPNET_VERSION=10.0.8                       0B        buildkit.dockerfile.v0
<missing>      8 days ago    RUN /bin/sh -c ln -s /usr/share/dotnet/dotne…   4.1kB     buildkit.dockerfile.v0
<missing>      8 days ago    COPY /dotnet /usr/share/dotnet # buildkit       82.8MB    buildkit.dockerfile.v0
<missing>      8 days ago    ENV DOTNET_VERSION=10.0.8                       0B        buildkit.dockerfile.v0
<missing>      8 days ago    RUN /bin/sh -c addgroup         --gid=$APP_U…   24.6kB    buildkit.dockerfile.v0
<missing>      8 days ago    RUN /bin/sh -c apk add --upgrade --no-cache …   3.02MB    buildkit.dockerfile.v0
<missing>      8 days ago    ENV APP_UID=1654 ASPNETCORE_HTTP_PORTS=8080 …   0B        buildkit.dockerfile.v0
<missing>      4 weeks ago   CMD ["/bin/sh"]                                 0B        buildkit.dockerfile.v0
<missing>      4 weeks ago   ADD alpine-minirootfs-3.23.4-x86_64.tar.gz /…   10.1MB    buildkit.dockerfile.v0
Barsol@barsol-pc:~$ 

```


