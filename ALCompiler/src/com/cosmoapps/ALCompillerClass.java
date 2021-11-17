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

        String filePath = Path + "\\com\\mojang\\authlib\\yggdrasil\\YggdrasilUserAuthentication.java";

        System.out.println("Patching YggdrasilUserAuthentication.java");
        List<String> fileContents = Files.readAllLines(Paths.get(filePath));
        fileContents.set(29, "    private static final String BASE_URL = \"https://" + ipAddr + "/\";");
        fileContents.set(31, "    private static final URL ROUTE_AUTHENTICATE = HttpAuthenticationService.constantURL(\"https://" + ipAddr + "/authenticate\");");
        fileContents.set(33, "    private static final URL ROUTE_REFRESH = HttpAuthenticationService.constantURL(\"https://" + ipAddr + "/refresh\");");
        fileContents.set(35, "    private static final URL ROUTE_VALIDATE = HttpAuthenticationService.constantURL(\"https://" + ipAddr + "/validate\");");
        fileContents.set(37, "    private static final URL ROUTE_INVALIDATE = HttpAuthenticationService.constantURL(\"https://" + ipAddr + "/invalidate\");");
        fileContents.set(39, "    private static final URL ROUTE_SIGNOUT = HttpAuthenticationService.constantURL(\"https://" + ipAddr + "/signout\");");
        Files.write(Paths.get(filePath), fileContents);
        System.out.println("YggdrasilUserAuthentication.java is Patched");

        System.out.println("Patching YggdrasilMinecraftSessionService.java");
        filePath = Path + "\\com\\mojang\\authlib\\yggdrasil\\YggdrasilMinecraftSessionService.java";
        fileContents = Files.readAllLines(Paths.get(filePath));
        fileContents.set(43, "    private static final String[] WHITELISTED_DOMAINS = new String[] { \"" + ipAddr + "\" };");
        fileContents.set(47, "    private static final String BASE_URL = \"https://" + ipAddr + "/session/minecraft/\";");
        fileContents.set(49, "    private static final URL JOIN_URL = HttpAuthenticationService.constantURL(\"https://" + ipAddr + "/session/minecraft/join\");");
        fileContents.set(51, "    private static final URL CHECK_URL = HttpAuthenticationService.constantURL(\"https://" + ipAddr + "/session/minecraft/hasJoined\");");
        Files.write(Paths.get(filePath), fileContents);
        System.out.println("YggdrasilMinecraftSessionService.java is Patched");

        System.out.println("Patching YggdrasilGameProfileRepository.java");
        filePath = Path + "\\com\\mojang\\authlib\\yggdrasil\\YggdrasilGameProfileRepository.java";
        fileContents = Files.readAllLines(Paths.get(filePath));
        fileContents.set(20, "    private static final String BASE_URL = \"https://" + ipAddr + "/\";");
        fileContents.set(22, "    private static final String SEARCH_PAGE_URL = \"https://" + ipAddr + "/profiles/\";");
        Files.write(Paths.get(filePath), fileContents);
        System.out.println("YggdrasilGameProfileRepository.java is Patched");

        System.out.println("Patching LegacyUserAuthentication.java");
        filePath = Path + "\\com\\mojang\\authlib\\legacy\\LegacyUserAuthentication.java";
        fileContents = Files.readAllLines(Paths.get(filePath));
        fileContents.set(17, "    private static final URL AUTHENTICATION_URL = HttpAuthenticationService.constantURL(\"https://" + ipAddr + "\");");
        Files.write(Paths.get(filePath), fileContents);
        System.out.println("LegacyUserAuthentication.java is Patched");

        System.out.println("Patching LegacyMinecraftSessionService.java");
        filePath = Path + "\\com\\mojang\\authlib\\legacy\\LegacyMinecraftSessionService.java";
        fileContents = Files.readAllLines(Paths.get(filePath));
        fileContents.set(16, "    private static final String BASE_URL = \"http://" + ipAddr + "/game/\";");
        fileContents.set(18, "    private static final URL JOIN_URL = HttpAuthenticationService.constantURL(\"http://" + ipAddr + "/game/joinserver.jsp\");");
        fileContents.set(20, "    private static final URL CHECK_URL = HttpAuthenticationService.constantURL(\"http://" + ipAddr + "/game/checkserver.jsp\");");
        Files.write(Paths.get(filePath), fileContents);
        System.out.println("LegacyMinecraftSessionService.java is Patched");
    }
}
