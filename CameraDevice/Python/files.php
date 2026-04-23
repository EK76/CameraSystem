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
Camera System Device
</p>

<?php

function formatFileSize($filename) {
    $size = filesize($filename);

    $units = array('B', 'KB', 'MB', 'GB', 'TB');
    $formattedSize = $size;

    for ($i = 0; $size >= 1024 && $i < count($units) - 1; $i++) {
        $size /= 1024;
        $formattedSize = round($size, 2);
    }

    return $formattedSize . ' ' . $units[$i];
}

$openvideo = "/media/usbdrive/camerasystem/".$_POST['openvideo']."/"; 
$openvideo2 ="/usbdrive/camerasystem/".$_POST['openvideo']."/";

echo "<p class='maintext2'>";
echo "Folder ",$_POST['openvideo'], " is choosen.";
echo "</p>";
$newVideo = $_POST['openvideo'];
$files= glob($openvideo . "*.mp4");
$files = array_combine(array_map("filemtime", $files), $files);
krsort($files);
?>
 <center>
<table class="buttonvalue">
<tr>
<td class="tdname">
File
</td>
<td class="tdname">
Size
</td>
<td class="tdname">
Time creation
</td>
<td class="tdname">
Function
</td>
</tr>
<?php
foreach($files as $files2)
{
  ?>
 

  <tr>
  <td class="tdname">
  <?php
  echo basename($files2); 
  echo "</td>";
  echo "<td class='tdname'>";
  echo formatFileSize($files2);
  echo "</td>";
  echo "<td class='tdname'>";
  $file_creation_date = filectime($files2);
  echo date('H:i:s',  $file_creation_date);
  ?>
  </td>
  <td>
  <form method="get" action="<?php echo $openvideo2,"/",basename($files2)?>" target="_blank" class="formfiles">
  <input type="submit" value = "Play video">
  </form>
  </td>
  </tr>

  </p>
  <?php
}  
?>
</table>
<br /><br />
<form action="index.php" method="post"> 
<input type="submit" value = " Back ">
</form>
</center>
<?php

?>
</body>
</html>
