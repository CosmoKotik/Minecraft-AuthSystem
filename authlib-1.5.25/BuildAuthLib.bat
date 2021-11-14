@echo off
::javac -cp libraries\log4j-core-2.8.1.jar,libraries\gson-2.8.0.jar src\com\mojang\util\*.java
:: javac -d build\ src\com\mojang\util\*.java
:: javac -d build\ src\com\mojang\authlib\*.java
:: javac -d build\ src\com\mojang\authlib\exceptions\*.java
:: javac -d build\ src\com\mojang\authlib\legacy\*.java
:: javac -d build\ src\com\mojang\authlib\minecraft\*.java
:: javac -d build\ src\com\mojang\authlib\properties\*.java
:: javac -d build\ src\com\mojang\authlib\yggdrasil\*.java
:: javac -d build\ src\com\mojang\authlib\yggdrasil\request\*.java
:: javac -d build\ src\com\mojang\authlib\yggdrasil\response\*.java

::javac -cp libraries\* src\*.java

echo Starting building .jar file
::jar cvfm out\authlib-1.5.25.jar manifest.txt -C build .
jar cvfM out\authlib-1.5.25.jar -C build .

if errorlevel 1 (
  echo Failed to build .jar file
) else (
  echo authlib-1.5.25 builded successfully
)

Pause