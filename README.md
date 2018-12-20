# bluefish
The simple test application for docker.

## Building for Linux amd64
```bash
cd Bluefish
docker build -f Dockerfile -t bluefish .
```

## Building for Alpine Linux amd64
```bash
cd Bluefish
docker build -f Dockerfile.alpine -t bluefish .
```

## Usage
The docker images pushed to Docker Hub.

### Linux
```bash
docker run -d -p 5000:80 tatoglu/bluefish:latest
```

### Linux Alpine
```bash
docker run -d -p 5001:80 tatoglu/bluefish:alpine
```
