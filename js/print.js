
    function printpage() {
        var getpanel = document.getElementById("<%=Panel1.CilentID%>");
        var mainwindow = window.open('', '', ' height = 500, width = 800');
        mainwindow.document.write('<html><head><title>print page</title>');
        mainwindow.document.write('</head><body>');
        mainwindow.document.write('</body></html>');
        mainwindow.document.close();
        setTimeout(function () {
            mainwindow.print();
        }, 500);
        return false;
    }

