# bluefish
The simple test application for docker.

[![GitHub](https://img.shields.io/github/license/mashape/apistatus.svg)](https://github.com/fatihtatoglu/bluefish/blob/master/LICENSE)

[![Docker Pulls](https://img.shields.io/docker/pulls/mashape/kong.svg)](https://hub.docker.com/r/tatoglu/bluefish)


## Objectives
- [X] Getting docker container information.
- [X] Building docker image for Windows system.
- [X] Building docker image for Linux system.
- [ ] Adding counter for hit counting.
- [ ] Preparing multi-architecture docker image.

## Building
```bash
cd Bluefish
docker build -t bluefish .
```

## Usage
The docker images pushed to Docker Hub.

### Windows
```bash
docker run -d -p 5000:5000 tatoglu/bluefish:windows
```

### Linux
```bash
docker run -d -p 5000:5000 tatoglu/bluefish:linux
```
