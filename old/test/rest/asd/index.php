<?php
require __DIR__ . "/inc/bootstrap.php";
 echo $_SERVER['REQUEST_URI'];
$uri = parse_url($_SERVER['REQUEST_URI'], PHP_URL_PATH);
$uri = explode( '/', $uri );

array_splice($uri, 0, 2);
echo json_encode($uri);
if (count($uri) < 1) {
    header_remove('Set-Cookie');
    header('Content-Type: application/json', 'HTTP/1.1 200 OK');
 
    echo '{"Status":"OK","Runtime-Mode":"productionMode","Application-Author":"Mojang Web Force","Application-Description":"Mojang Authentication Server.","Specification-Version":"5.2.0","Application-Name":"yggdrasil.auth.restlet.server","Implementation-Version":"5.2.0","Application-Owner":"Mojang"}';
    exit();
} else if((isset($uri[1]) && $uri[1] == 'authenticate')) {
    $payload = http_build_query([
        'grant_type' => 'client_credentials',
        'scope'      => $scope
    ]);

    echo $payload;
}
 
require PROJECT_ROOT_PATH . "/Controller/Api/UserController.php";
 
$objFeedController = new UserController();
$strMethodName = $uri[3] . 'Action';
$objFeedController->{$strMethodName}();
?>