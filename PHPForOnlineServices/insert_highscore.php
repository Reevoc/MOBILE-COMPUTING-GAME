<?php

$nome = $_POST["nome"];
$score =$_POST["score"];

if ($score==0){
die();
}

if($nome==""){
$nome="Default";
}

$servername = "localhost";
$username = "comandiutili";
$password = "";
$dbname = "my_comandiutili";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "INSERT INTO highscore (nome, score) VALUES ('$nome', $score)";
$conn->query($sql);

$conn->close();
?>
