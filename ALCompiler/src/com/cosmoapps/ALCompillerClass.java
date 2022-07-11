package com.cosmoapps;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.List;

public class ALCompillerClass {
    public static void main(String[] args) throws IOException {
        System.out.println("ALCompiler by: CosmoKotik");

        String Path = args[0];
        String ipAddr = args[1];
        String EnablePHPExtension = args[2].toString();
        String HasAUTHSERVERsdomain = args[3].toString();
        String IsHHTPS = args[4].toString();
        String filePath = Path + "\\com\\mojang\\authlib\\yggdrasil\\YggdrasilUserAuthentication.java";
        String fileExt = "";
        if (EnablePHPExtension.equals("true")) {
            fileExt = ".php";
            System.out.println("File extension is " + fileExt);
        }

        String httpS = "https";
        if (IsHHTPS.equals("false"))
            httpS = "http";


        List<String> fileContents = Files.readAllLines(Paths.get(filePath));

        if (HasAUTHSERVERsdomain.equals("false")) {
            System.out.println("Patching YggdrasilUserAuthentication.java");
            fileContents.set(29, "    private static final String BASE_URL = \"" + httpS + "://" + ipAddr + "/authserver/\";");
            fileContents.set(31, "    private static final URL ROUTE_AUTHENTICATE = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/authserver/authenticate" + fileExt + "\");");
            fileContents.set(33, "    private static final URL ROUTE_REFRESH = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/authserver/refresh" + fileExt + "\");");
            fileContents.set(35, "    private static final URL ROUTE_VALIDATE = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/authserver/validate" + fileExt + "\");");
            fileContents.set(37, "    private static final URL ROUTE_INVALIDATE = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/authserver/invalidate" + fileExt + "\");");
            fileContents.set(39, "    private static final URL ROUTE_SIGNOUT = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/authserver/signout" + fileExt + "\");");
            Files.write(Paths.get(filePath), fileContents);
        } else {
            System.out.println("Patching YggdrasilUserAuthentication.java");
            fileContents.set(29, "    private static final String BASE_URL = \"" + httpS + "://" + ipAddr + "/\";");
            fileContents.set(31, "    private static final URL ROUTE_AUTHENTICATE = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/authenticate" + fileExt + "\");");
            fileContents.set(33, "    private static final URL ROUTE_REFRESH = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/refresh" + fileExt + "\");");
            fileContents.set(35, "    private static final URL ROUTE_VALIDATE = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/validate" + fileExt + "\");");
            fileContents.set(37, "    private static final URL ROUTE_INVALIDATE = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/invalidate" + fileExt + "\");");
            fileContents.set(39, "    private static final URL ROUTE_SIGNOUT = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/signout" + fileExt + "\");");
            Files.write(Paths.get(filePath), fileContents);
        }

        System.out.println("YggdrasilUserAuthentication.java is Patched");

        System.out.println("Patching YggdrasilMinecraftSessionService.java");
        filePath = Path + "\\com\\mojang\\authlib\\yggdrasil\\YggdrasilMinecraftSessionService.java";
        fileContents = Files.readAllLines(Paths.get(filePath));
        String[] separated = ipAddr.split("\\.");
        //System.out.println(separated.length);
        fileContents.set(43, "    private static final String[] WHITELISTED_DOMAINS = new String[] { \"." + separated[separated.length - 2] + "." + separated[separated.length - 1] + "\", \".minecraft.net\", \".mojang.com\" };");
        fileContents.set(47, "    private static final String BASE_URL = \"" + httpS + "://" + ipAddr + "/sessionserver/session/minecraft/\";");
        fileContents.set(49, "    private static final URL JOIN_URL = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/sessionserver/session/minecraft/join" + fileExt + "\");");
        fileContents.set(51, "    private static final URL CHECK_URL = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/sessionserver/session/minecraft/hasJoined" + fileExt + "\");");
        fileContents.set(150, "            URL url = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/sessionserver/session/minecraft/profile/\" + UUIDTypeAdapter.fromUUID(profile.getId()));");
        Files.write(Paths.get(filePath), fileContents);
        System.out.println("YggdrasilMinecraftSessionService.java is Patched");

        System.out.println("Patching YggdrasilGameProfileRepository.java");
        filePath = Path + "\\com\\mojang\\authlib\\yggdrasil\\YggdrasilGameProfileRepository.java";
        fileContents = Files.readAllLines(Paths.get(filePath));
        fileContents.set(20, "    private static final String BASE_URL = \"" + httpS + "://" + ipAddr + "/api/\";");
        fileContents.set(22, "    private static final String SEARCH_PAGE_URL = \"" + httpS + "://" + ipAddr + "/api/profiles/\";");
        fileContents.set(50, "                    ProfileSearchResultsResponse response = this.authenticationService.<ProfileSearchResultsResponse>makeRequest(HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/api/profiles/\" + agent.getName().toLowerCase()), request, ProfileSearchResultsResponse.class);");
        Files.write(Paths.get(filePath), fileContents);
        System.out.println("YggdrasilGameProfileRepository.java is Patched");

        System.out.println("Patching LegacyUserAuthentication.java");
        filePath = Path + "\\com\\mojang\\authlib\\legacy\\LegacyUserAuthentication.java";
        fileContents = Files.readAllLines(Paths.get(filePath));
        fileContents.set(17, "    private static final URL AUTHENTICATION_URL = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/login/\");");
        Files.write(Paths.get(filePath), fileContents);
        System.out.println("LegacyUserAuthentication.java is Patched");

        System.out.println("Patching LegacyMinecraftSessionService.java");
        filePath = Path + "\\com\\mojang\\authlib\\legacy\\LegacyMinecraftSessionService.java";
        fileContents = Files.readAllLines(Paths.get(filePath));
        fileContents.set(16, "    private static final String BASE_URL = \"" + httpS + "://" + ipAddr + "/session/game/\";");
        fileContents.set(18, "    private static final URL JOIN_URL = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/session/game/joinserver.jsp\");");
        fileContents.set(20, "    private static final URL CHECK_URL = HttpAuthenticationService.constantURL(\"" + httpS + "://" + ipAddr + "/session/game/checkserver.jsp\");");
        Files.write(Paths.get(filePath), fileContents);
        System.out.println("LegacyMinecraftSessionService.java is Patched");
    }
}
