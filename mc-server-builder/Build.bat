@echo off
echo Custom AuthLib by:CosmoKotik

:Building .jar file
echo Starting building .jar file
jdk\jar cvfM out\server.jar -C build\java .

if errorlevel 1 (
  echo Failed to build .jar file
) else (
  echo Server builded successfully
)

Pause