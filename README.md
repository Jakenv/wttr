# wttr - command line weather

This app uses the [wttr.in](https://wttr.in) service to get the weather forecast for a given city

### So all credit goes to [igor chubin](https://github.com/chubin/wttr.in) for this lovely service

## Usage

```bash
> wttr --help
```

## Manual installation

Copy repo and run these commands in root directory

```bash
> dotnet pack
> dotnet tool install --global --add-source ./nupkg wttr
```

