@echo off
echo Custom AuthLib by:CosmoKotik

:configloader
rename config.ini config.bat
call config.bat
rename config.bat config.ini

:AuthLib recompiller
java -jar ALCompiler.jar src %AuthServerIP%

:Building/Compiling AuthLib
::javac -cp libraries\log4j-core-2.8.1.jar,libraries\gson-2.8.0.jar src\com\mojang\util\*.java
:javac -d build\ src\com\mojang
:: javac -d build\ src\com\mojang\authlib\*.java
:: javac -d build\ src\com\mojang\authlib\exceptions\*.java
:javac -cp .:libraries/commons-lang3-3.5.jar:libraries/log4j-core-2.8.1.jar -d build\ src\com\mojang\authlib\legacy\*.java
:: javac -d build\ src\com\mojang\authlib\minecraft\*.java
:: javac -d build\ src\com\mojang\authlib\properties\*.java
:javac -d build\ src\com\mojang\authlib\yggdrasil\*.java
:: javac -d build\ src\com\mojang\authlib\yggdrasil\request\*.java
:: javac -d build\ src\com\mojang\authlib\yggdrasil\response\*.java

::javac -cp libraries\* src\*.java

:Building .jar file
echo Starting building .jar file
jar cvfM out\authlib-1.5.25.jar -C build .

if errorlevel 1 (
  echo Failed to build .jar file
) else (
  echo authlib-1.5.25 builded successfully
)

Pause