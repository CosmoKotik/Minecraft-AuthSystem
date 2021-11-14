<?php 
    $json = file_get_contents('php://input');

    $data = json_decode($json);
    
    file_put_contents("logs.txt", $json);
    
    $username = "_CosmoKotik_";
    $response;
    
    $dbhost = "192.168.0.20";
    $dbuser = "root";
    $dbpass = "icWAuqYsmja4NMyKhlqt";
    $db = "userdb";

    $conn = new mysqli($dbhost, $dbuser, $dbpass, $db);
if ($conn -> connect_error) {
    echo "Conneciton failed";
}

$sql = "select * from mcusers where username like '%$username%'";
$result = $conn->query($sql);
//echo $result -> fetch_assoc();
$authresponse;

if ($result) {
    while($row = $result -> fetch_assoc()) {
        $authresponse = '{
            "user": {
                "username": "' . $row["username"] . '",
                "properties": [
                    {
                        "name": "preferredLanguage",
                        "value": "en-us"
                    },
                    {
                        "name": "registrationCountry",
                        "value": "canada"
                    }
                ],
                "id": "' . $row["id"] . '"
            },
            "clientToken": "' . $row["clientToken"] . '",
            "accessToken": "' . $row["accessToken"] . '",
            "availableProfiles": [
                {
                    "name": "' . $row["username"] . '",
                    "id": "' . $row["uuid"] . '"
                }
            ],
            "selectedProfile": {
                "name": "' . $row["username"] . '",
                "id": "' . $row["uuid"] . '"
            }
        }';
    }
}

echo $authresponse;

?>