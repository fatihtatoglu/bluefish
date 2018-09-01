
# bluefish
The simple test application for docker.

## Objectives
- [X] Getting docker container information.
- [X] Building docker image for Windows system.
- [X] Building docker image for Linux system.
- [ ] Adding counter for hit counting.
- [ ] Preparing multi-architecture docker image.

##Building
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
