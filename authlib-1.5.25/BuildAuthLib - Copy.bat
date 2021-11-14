@echo off
:: javac -d build\ src\com\mojang\util\*.java
:: javac -d build\ src\com\mojang\authlib\*.java
:: javac -d build\ src\com\mojang\authlib\exceptions\*.java
:: javac -d build\ src\com\mojang\authlib\legacy\*.java
:: javac -d build\ src\com\mojang\authlib\minecraft\*.java
:: javac -d build\ src\com\mojang\authlib\properties\*.java
:: javac -d build\ src\com\mojang\authlib\yggdrasil\*.java
:: javac -d build\ src\com\mojang\authlib\yggdrasil\request\*.java
:: javac -d build\ src\com\mojang\authlib\yggdrasil\response\*.java

javac -cp libraries\* src\*.java

echo Starting building .jar file
jar cvf out\authlib-1.5.25.jar -C compiled .

if errorlevel 1 (
  echo Failed to build .jar file
) else (
  echo authlib-1.5.25 builded successfully
)

Pause