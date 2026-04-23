<?php
header("Cache-Control: no-store, must-revalidate, max-age=0");
?>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<link rel="stylesheet" href="style.css">
<script>
</script>
</head>
<body>
<p class="maintext">
Camera Device System
</p>
<p class="maintext2">
Contents over video folders.
</br>
</p>
<center>
<table>


<?php
$folders = glob('/media/usbdrive/camerasystem' . '/*' , GLOB_ONLYDIR);
foreach($folders as $folders2)  
{
  echo "<tr>";
  echo "<td class='tdname'>";
  echo "<p class='subtext3'>";
  echo "Folder ". basename($folders2);
  ?>
  </td>
    <td class="tdname">
  <form action="files.php" method="post" class="formfiles">
  <input type="hidden" name="openvideo" value="<?php echo basename($folders2)?>">
  <input type="submit" value = " Open " name="openFile"/>
  </form>
  </td>
  </tr>
  <?php
}   
?>

</table
<br /><br /><br /><br />
<form action="logs.php" method="post"> 
<input type="submit" value = " Show logs ">
</form>
</center>
</body>
</html>