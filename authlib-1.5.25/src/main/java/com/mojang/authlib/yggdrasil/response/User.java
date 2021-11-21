package com.mojang.authlib.yggdrasil.response;

import com.mojang.authlib.properties.PropertyMap;

public class User {
    private String id;
    private PropertyMap properties;

    public User() {
    }

    public String getId() {
        return this.id;
    }

    public PropertyMap getProperties() {
        return this.properties;
    }
}
