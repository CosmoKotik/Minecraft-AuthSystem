<?php 
    $json = file_get_contents('php://input');

    $data = json_decode($json);
    
    $response;

    $dbhost = "192.168.0.20";
    $dbuser = "root";
    $dbpass = "icWAuqYsmja4NMyKhlqt";
    $db = "userdb";

    $conn = new mysqli($dbhost, $dbuser, $dbpass, $db);
    if ($conn -> connect_error) {
        echo "Conneciton failed";
    }

    $sql = "select * from mcusers";
    $result = $conn->query($sql);

    if ($result) {
        while($row = $result -> fetch_assoc()) {
            if ($response != null || "") {
                $response .= ",";
            } 

            $response = $response . json_encode([
                "id" => $row["uuid"],
                "name" => $row["username"]]);
        }
    }

    $response = "[" . $response . "]";

    echo $response;
?>