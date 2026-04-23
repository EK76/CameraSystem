<?php
header("Cache-Control: no-store, must-revalidate, max-age=0");
?>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<link rel="stylesheet" href="style.css">

</head>
<body onload=enable_text(false);>
<p class="maintext">
Camera Device System
</p>
<p class="maintext2">
Settings.
</br>
</p>

<?php

require_once 'config.php';
if ($dbconnect->connect_error) 
{
  die("Database connection failed: " . $dbconnect->connect_error);
}


if(isset($_POST['setSettings']))
{ 

   $allowEmail = (isset($_POST['enableEmail'])?"checked":"");
   if ($allowEmail == "checked")
   {
      $enableEmail = "True";
   }
   else
   {
      $enableEmail= "False";
   } 

   $allowEmail = (isset($_POST['enableDrive'])?"checked":"");
   if ($allowEmail == "checked")
   {
      $enableDrive = "True";
   }
   else
   {
      $enableDrive = "False";
   } 

   $streamVideo = $_POST['streamVideo'];
   $sendEmail = $_POST['sendEmail'];
   $alertText = $_POST['alertText'];

   $query = mysqli_query($dbconnect, "update settings set email = '".$enableEmail."', drive = '".$enableDrive."', stream = ".$streamVideo.", sendemail= '".$sendEmail."', alerttext = '".$alertText."' where id = 1;")
   or die (mysqli_error($dbconnect));
}   

$query = mysqli_query($dbconnect, "select email, drive, stream, sendemail, alerttext from settings;")
or die (mysqli_error($dbconnect));
$row = mysqli_fetch_assoc($query);

$enableEmail = $row['email'];
$enableDrive = $row['drive'];
$streamVideo = $row['stream'];
$sendEmail = $row['sendemail'];
$alertText = $row['alerttext'];

if ($enableEmail == "True")
{
   $checkboxvalue = 1;
}
else
{
   $checkboxvalue = 0;
} 

if ($enableDrive == "True")
{
   $checkboxvalue2 = 1;
}
else
{
   $checkboxvalue2 = 0;
} 

?>

<form action="settings.php" method="post" class="formfiles2">
<input name="enableEmail" type="checkbox" id ="checkthis" <?php echo $checkboxvalue == 1 ? 'checked' : ''  ?> onclick="disableMyText(this)"/>Enable email alert. <br /><br />
Type email adress.<br /><br />
<input name="sendEmail" type="text" id ="enabletext" value = "<?php echo $sendEmail ?>" disabled="disabled"/><br /><br />
Type alert text.<br /><br />
<input name="alertText" type="text"  value = "<?php echo $alertText ?>"/><br /><br />
Put a stream value.<br /><br />
<input type="number" name="streamVideo" value = "<?php echo $streamVideo ?>" size="5" min="1" max="3000"><br /><br />
<input name="enableDrive" type="checkbox" <?php echo $checkboxvalue2 == 1 ? 'checked' : ''  ?>/>Enable drive.<br /><br />
<input type="submit" value = " Set settings " name ="setSettings">
<br /><br /><br /><br />
<form action="index.php" method="post"> 
<input type="submit" value = " Back ">
</form>
<script type="text/javascript" >  
      function disableMyText()
      {  
         var enabletext = documnent.getElementById("enabletext");
         enabletext.disabled = checkthis.checked ? false : true;
         if (enabletext.disabled)
         {
            enabletext.focus();
         }
      }  
     </script> 
</body>
</html>