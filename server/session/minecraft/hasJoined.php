<?php

//http_response_code(204);

$json = file_get_contents('php://input');
file_put_contents("logs2.txt", $json);
http_response_code(204);
return;

$username = $_GET['username'];
$serverId = $_GET['serverId'];
$ip = $_GET['ip'];

function shortUUIDtoNormalUUID($uuid) {
    $p1 = substr_replace($uuid, "-", 9, 0);
    $p2 = substr_replace($p1, "-", 14, 0);
    $p3 = substr_replace($p2, "-", 19, 0);
    $final = substr_replace($p3, "-", 24, 0);

    return $final;
}

if ($username != null || "") {
    echo '{
        "id": "' . shortUUIDtoNormalUUID() . '",
        "name": "<player name>",
        "properties": [ 
            {
                "name": "textures",
                "value": "<base64 string>",
                "signature": ""
            }
        ]
    }';
}

return;



$server = "127.0.0.1";
$username = "root";
$password = "icWAuqYsmja4NMyKhlqt";
$db = "userdb";

$conn = new mysqli($server, $username, $password, $db);
if ($conn -> connect_error) {
    die("Conneciton failed: " . $conn-connect_error);
}

$sql = "select * from mcusers where username like '%$username%'";
$result = $conn->query($sql);

$authresponse;
$authproperties;

if ($result) {
    while($row = $result -> fetch_assoc()) {
        $authresponse = '{ 
        }';

        //$authresponse = array('user' => array('username' => $row["username"], 'properties' => ["dsa" => "asd"]), 'accesstoken' => $row["accesstoken"], 'uuid' => $row["uuid"], 'uid' => $row["uid"]);
    }
}
$authresponse = '{ 
}';

$authresponseJson = json_encode($authresponse);
$conn -> close();

if($authresponseJson == "null") {
    $authresponseJson = '{"error":"Not Found","errorMessage":"The server has not found anything matching the request URI"}';
}

echo $authresponse;

?>