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

### b. Uruchomienia kontenera na podstawie zbudowanego obrazu
Uruchomienie kontenera w tle (tryb izolowany -d), nadanie mu jednoznacznej nazwy identyfikacyjnej oraz zmapowanie wewnętrznego portu aplikacji (8080) na zewnętrzny port testowy hosta (5000):

```Bash
docker run -d --name moj-pogodowy-kontener -p 5000:8080 barsol/cloudcomputingproject:latest
```

### c. Sposób uzyskania informacji z logów aplikacji
Pobranie informacji (autor, data uruchomienia, porty TCP) wygenerowanych  podczas startu kontenera:

``` Bash
docker logs moj-pogodowy-kontener
```

### d. Sprawdzenie, ile warstw posiada zbudowany obraz oraz jaki jest rozmiar obrazu

Weryfikacja rozmiaru, architektury oraz sum kontrolnych manifestu:

```Bash
docker buildx imagetools inspect barsol/cloudcomputingproject:latest
```

### e. Zliczenie dokładnej ilości warstw wchodzących w skład obrazu:
   ```bash
   docker manifest inspect barsol/cloudcomputingproject:latest | grep -c "digest"
```