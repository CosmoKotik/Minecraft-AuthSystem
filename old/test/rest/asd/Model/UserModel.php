<?php
require_once PROJECT_ROOT_PATH . "/Model/Database.php";

class UserModel extends Database
{
    public function getUsers($limit)
    {
        //echo '1';
        //return '';
        return $this->select("SELECT * FROM mcusers ORDER BY id ASC LIMIT ?", ["i", $limit]);
    }
}
?>