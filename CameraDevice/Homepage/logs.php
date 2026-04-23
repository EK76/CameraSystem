<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
<link rel="stylesheet" href="style.css">
</head>

<?php
require_once 'config.php';
if ($dbconnect->connect_error) 
{
  die("Database connection failed: " . $dbconnect->connect_error);
}

?>
<p class="maintext">
Camera Device System.
</p>

<center>

<form action="logs.php" method="post"> 
Give a number.

<input type="number" name="selectlimit" id="quantity" size="5" min="1" max="3000">
<br /><br />
<input type="submit" value = " Show selected rows " name ="showRows">
</form>

<form action="logs.php" method="post"> 
<input type="submit" value = "Show all rows">
</form>
</center>

<?php
$allow = TRUE;
$rowcount = 0;
if(isset($_POST['showRows']))
{ 
  $query = mysqli_query($dbconnect, "select * from cameralogs order by datecreated desc limit ". $_POST['selectlimit'])
  or die (mysqli_error($dbconnect));
  $row = mysqli_fetch_row($query);
  $rowcount = mysqli_num_rows($query);
}
else
{
  $query = mysqli_query($dbconnect, "select * from cameralogs")
  or die (mysqli_error($dbconnect));
  $row = mysqli_fetch_row($query);
  $rowcount = mysqli_num_rows($query);
}

if ($rowcount!=0)
{
  echo '<p class="subtext1">';
  echo "</br></br>Number of rows: ", $rowcount;
  echo  "</p>";

  ?>
  <center>
  <table border="1" class="datarows2">
  <tr>
  <td>Log text</td>
  <td>Datecreated</td>
  </tr> 
  <?php
  $number = 0;
  while ($row = mysqli_fetch_array($query)) 
  {
    $datecreated2 = date('d.m.Y H:i:s', strtotime($row['datecreated']));
    echo" 
    <tr>
    <td>{$row['logtext']}</td>
    <td>{$datecreated2}</td>
    </tr>";
  }
  echo "</td>";
  echo "</t>";
  echo "</table>";
  echo "<br />";
} 
else
{
  echo "Logs table is empty.";
}
  
?>
<form action="index.php" method="post"> 
<input type="submit" value = " Back ">
</form>
</center>
</body>
</html>