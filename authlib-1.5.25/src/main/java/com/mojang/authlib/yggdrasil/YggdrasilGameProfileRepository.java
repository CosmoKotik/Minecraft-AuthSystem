package com.mojang.authlib.yggdrasil;

import com.google.common.base.Strings;
import com.google.common.collect.Iterables;
import com.google.common.collect.Sets;
import com.mojang.authlib.Agent;
import com.mojang.authlib.GameProfile;
import com.mojang.authlib.GameProfileRepository;
import com.mojang.authlib.HttpAuthenticationService;
import com.mojang.authlib.ProfileLookupCallback;
import com.mojang.authlib.exceptions.AuthenticationException;
import com.mojang.authlib.yggdrasil.response.ProfileSearchResultsResponse;
import java.util.Iterator;
import java.util.List;
import java.util.Set;
import java.util.UUID;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

public class YggdrasilGameProfileRepository implements GameProfileRepository {
    private static final Logger LOGGER = LogManager.getLogger();
    private static final String BASE_URL = "https://localhost/";
    private static final String SEARCH_PAGE_URL = "https://localhost/profiles/";
    private static final int ENTRIES_PER_PAGE = 2;
    private static final int MAX_FAIL_COUNT = 3;
    private static final int DELAY_BETWEEN_PAGES = 100;
    private static final int DELAY_BETWEEN_FAILURES = 750;
    private final YggdrasilAuthenticationService authenticationService;

    public YggdrasilGameProfileRepository(YggdrasilAuthenticationService authenticationService) {
        this.authenticationService = authenticationService;
    }

    public void findProfilesByNames(String[] names, Agent agent, ProfileLookupCallback callback) {
        Set<String> criteria = Sets.newHashSet();
        String[] var5 = names;
        int var6 = names.length;

        for(int var7 = 0; var7 < var6; ++var7) {
            String name = var5[var7];
            if (!Strings.isNullOrEmpty(name)) {
                criteria.add(name.toLowerCase());
            }
        }

        boolean page = false;
        Iterator var20 = Iterables.partition(criteria, 2).iterator();

        while(var20.hasNext()) {
            List<String> request = (List)var20.next();
            int failCount = 0;

            while(true) {
                boolean failed = false;

                try {
                    ProfileSearchResultsResponse response = (ProfileSearchResultsResponse)this.authenticationService.makeRequest(HttpAuthenticationService.constantURL("https://api.mojang.com/profiles/" + agent.getName().toLowerCase()), request, ProfileSearchResultsResponse.class);
                    failCount = 0;
                    LOGGER.debug("Page {} returned {} results, parsing", 0, response.getProfiles().length);
                    Set<String> missing = Sets.newHashSet(request);
                    GameProfile[] var25 = response.getProfiles();
                    int var13 = var25.length;

                    for(int var14 = 0; var14 < var13; ++var14) {
                        GameProfile profile = var25[var14];
                        LOGGER.debug("Successfully looked up profile {}", profile);
                        missing.remove(profile.getName().toLowerCase());
                        callback.onProfileLookupSucceeded(profile);
                    }

                    Iterator var26 = missing.iterator();

                    while(var26.hasNext()) {
                        String name = (String)var26.next();
                        LOGGER.debug("Couldn't find profile {}", name);
                        callback.onProfileLookupFailed(new GameProfile((UUID)null, name), new ProfileNotFoundException("Server did not find the requested profile"));
                    }

                    try {
                        Thread.sleep(100L);
                    } catch (InterruptedException var17) {
                    }
                } catch (AuthenticationException var18) {
                    AuthenticationException e = var18;
                    ++failCount;
                    if (failCount == 3) {
                        Iterator var11 = request.iterator();

                        while(var11.hasNext()) {
                            String name = (String)var11.next();
                            LOGGER.debug("Couldn't find profile {} because of a server error", name);
                            callback.onProfileLookupFailed(new GameProfile((UUID)null, name), e);
                        }
                    } else {
                        try {
                            Thread.sleep(750L);
                        } catch (InterruptedException var16) {
                        }

                        failed = true;
                    }
                }

                if (!failed) {
                    break;
                }
            }
        }

    }
}
