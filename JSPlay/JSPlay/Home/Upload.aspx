<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="JSPlay.Home.Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../Scripts/jquery.form.js"></script>
    <title>上传文件</title>
    <script type="text/javascript">
        function upload() {
            var path = document.getElementById("File1").value;
            var img = document.getElementById("img1");
            if ($.trim(path) == "") {
                alert("请选择要上传的文件");
                return;
            }

            $("#form1").ajaxSubmit({
                url: 'http://192.168.70.38:9000/ashx/upload.ashx', /*设置post提交到的页面*/
                type: "post", /*设置表单以post方法提交*/
                dataType: "text", /*设置返回值类型为文本*/
                success: function (str) {
                    if (str) {
                        alert(str);
                    }
                    else alert('操作失败！');
                },
                error: function (error) { alert(error); }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <input id="File1" name="File1" type="file" />
        <input id="iptUp" type="button" value="上传" onclick="upload()" />
    </form>
</body>
</html>
