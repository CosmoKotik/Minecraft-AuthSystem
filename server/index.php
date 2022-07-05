<?php 
    /*$keySize = 2048;
    $key = openssl_pkey_new([
        "private_key_bits" => $keySize,
        "private_key_type" => OPENSSL_KEYTYPE_RSA,
    ]);
     
    openssl_pkey_export($key, $privateKey);
    $publicKey = openssl_pkey_get_details($key)['key'];
     
    //echo $privateKey;
    //echo $publicKey;

    $RESPONSE = '{ 
        "meta" : { 
            "implementationName" : "yggdrasil-mock-server" , 
            "implementationVersion" : "0.0.1" , 
            "serverName" : "yggdrasil Cosmo Authentication Server" , 
            "links" : { 
                "homepage" : "https ://skin.example.com/" , 
                "register" : "https://skin.example.com/register" 
            } , 
            "feature.non_email_login" : true 
        } , 
        "skinDomains" : [ 
            "example.com" , 
            ".example.com" 
        ] , 
        "signaturePublickey" : "' . $publicKey . '" 
    }';
    echo $RESPONSE;*/

    echo '{"Status":"OK","Runtime-Mode":"productionMode","Application-Author":"Mojang Web Force","Application-Description":"Mojang Public API.","Specification-Version":"3.58.0","Application-Name":"yggdrasil.accounts.restlet.server.public","Implementation-Version":"3.58.0_build199","Application-Owner":"Mojang"}';
    http_response_code(200);
?>