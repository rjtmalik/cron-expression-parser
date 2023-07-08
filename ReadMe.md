# Cron Evaluator Terminal App
The purpose of the command line app is to take a CRON expression as input, evaluate it and print the response on the terminal

## Introduction
The solution consists of a command line application that accepts a cron expression, evaluates it and prints the response

Input
```bash
     */15 0 1,15 * 1-5
```

output
```bash
     minute       0 15 30 45
     hour         0
     day of month 1 15
     month        1 2 3 4 5 6 7 8 9 10 11 12
     day of week  1 2 3 4 5
     command      docker run -it --rm cron-parse "*/15 0 1,15 * 1-5"
```

## Setup
The application can either be run from an IDE or from inside Docker. The Dockerfile is part of the solution and present in the root directory.

You can use your favourit IDE for running .Net Application. You would need to install .Net SDK if you want to go down this path.

### IDE
#### Prerequites
- DotNet SDK

Run the app
```bash
    cd ConsoleApp
    dotnet run "*/15 0 1,15 * 1-5"
```

Run tests from Terminal
```bash
     cd CronEval.Lib.Tests
     dotnet test
```

### Docker
#### Prerequites
- Docker

Create the image

```bash
    docker build -t cron-parse -f Dockerfile .
```

Run the container with the input
```bash
    docker run -it --rm cron-parse "*/15 0 1,15 * 1-5"
```