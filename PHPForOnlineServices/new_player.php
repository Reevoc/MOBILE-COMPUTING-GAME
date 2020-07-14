<?php

$deviceId = $_POST["deviceId"];
$name = $_POST["name"];

$servername = "localhost";
$username = "sharebox";
$password = "";
$dbname = "my_sharebox";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

function isValid($stringa) {
  $bandite = array("cazz","stronz","porc","coglion","cul","merd","puttan","troia","zoccol","frocio","ricchione","mignotta","finocchio","cane");
  $lower = strtolower($stringa);
  $valid = trim($lower) != "";
  foreach($bandite as $bandita) {
    $valid = $valid && !(strpos($lower,$bandita)!==false);
  }
  return $valid; 
}

// first i want to check if name is taken yet
$sql = "SELECT * FROM players WHERE name='$name' ";
$result = $conn->query($sql);
$scores = array();
if ($result->num_rows > 0) {
  echo(1);
  exit();
}

if(!isValid($name)) {
  echo(2);
  exit();
}

$sql = "DELETE FROM players WHERE deviceId='$deviceId' ";
$conn->query($sql);

$sql = "INSERT INTO players (deviceId, name) VALUES ('$deviceId', '$name')";
$conn->query($sql);

echo("0");
$conn->close();
?>