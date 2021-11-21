package com.mojang.authlib.yggdrasil.response;

import com.mojang.authlib.minecraft.MinecraftProfileTexture;
import com.mojang.authlib.minecraft.MinecraftProfileTexture.Type;
import java.util.Map;
import java.util.UUID;

public class MinecraftTexturesPayload {
    private long timestamp;
    private UUID profileId;
    private String profileName;
    private boolean isPublic;
    private Map<Type, MinecraftProfileTexture> textures;

    public MinecraftTexturesPayload() {
    }

    public long getTimestamp() {
        return this.timestamp;
    }

    public UUID getProfileId() {
        return this.profileId;
    }

    public String getProfileName() {
        return this.profileName;
    }

    public boolean isPublic() {
        return this.isPublic;
    }

    public Map<Type, MinecraftProfileTexture> getTextures() {
        return this.textures;
    }
}
