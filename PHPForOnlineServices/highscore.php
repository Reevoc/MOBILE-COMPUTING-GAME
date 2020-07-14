<?php

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

$sql = "SELECT DISTINCT highscore.nome,highscore.score FROM highscore ORDER BY score DESC LIMIT 10 ";
$result = $conn->query($sql);
$scores = array();

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    array_push($scores,$row);
  }
}
$conn->close();

echo json_encode($scores);

?>
