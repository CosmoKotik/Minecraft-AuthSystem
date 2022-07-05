<?php
$json = file_get_contents('php://input');
file_put_contents("logs.txt", $json);
http_response_code(204);
return;


$data = json_decode($json, true);

$accessToken = $data["accessToken"];
$selectedProfile = $data["selectedProfile"];
$serverId = $data["serverId"];

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
            "accessToken" : "' . $row["accessToken"] . '" , 
            "clientToken" : "' . $row["clientToken"] . '" , 
            "availableProfiles" : [  // list of available roles for users 
                
            ] , 
            "selectedProfile" : { 
                
            } , 
            "user" : { 
                
            } 
        }';

        //$authresponse = array('user' => array('username' => $row["username"], 'properties' => ["dsa" => "asd"]), 'accesstoken' => $row["accesstoken"], 'uuid' => $row["uuid"], 'uid' => $row["uid"]);
    }
}

$authresponseJson = json_encode($authresponse);
$conn -> close();

if($authresponseJson == "null") {
    $authresponseJson = '{"error":"Not Found","errorMessage":"The server has not found anything matching the request URI"}';
} else {
    var_dump(http_response_code(204));
    return;
}

echo $authresponse;


?>