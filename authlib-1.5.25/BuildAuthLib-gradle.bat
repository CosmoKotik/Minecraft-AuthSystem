@echo off
echo Custom AuthLib by:CosmoKotik

::configloader
rename config.ini config.bat
call config.bat
rename config.bat config.ini

:AuthLib recompiller
jdk1.8.0_202\bin\java -jar ALCompiler.jar src\main\java %AuthServerIP% %EnablePHPExtension% %HasAUTHSERVERsubdomain% %IsHHTPS%

::Compile edited files using gradle
::gradlew build
call gradlewBUILDER.bat

::Building .jar file
echo Starting building .jar file
jdk1.8.0_202\bin\jar cvfM out\authlib-1.5.25.jar -C build\classes\java\main .

if errorlevel 1 (
  echo Failed to build .jar file
) else (
  echo authlib-1.5.25 builded successfully
)

Pause